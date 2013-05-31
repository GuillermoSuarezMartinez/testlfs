//***********************************************************************
// Assembly         : Orbita.VAGeneradorEscenarios
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Adaptado forma de iniciar la aplicación
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.VA.MaquinasEstados;
using Orbita.Trazabilidad;

namespace Orbita.VA.GeneradorEscenarios
{
    /// <summary>
    /// Programa generador de código automático
    /// </summary>
    class Program
    {
        #region Campos
        /// <summary>
        /// Indica si se han de generar las variables
        /// </summary>
        public static bool HabilitadoVariables;

        /// <summary>
        /// Indica si se han de generar el hardware
        /// </summary>
        public static bool HabilitadoHardware;

        /// <summary>
        /// Indica si se han de generar las funciones de visión
        /// </summary>
        public static bool HabilitadoVision;
        #endregion

        #region Punto de entrada
        /// <summary>
        /// Punto de entrada de la aplicación
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args.Length >= 5)
            {
                // Inicializar acceso a la base de datos
                OSistemaManager.Constructor(new OSistemaGeneradorEscenarios(args[1]), false, false);
                OSistemaManager.IniciarAplicacion(ModoInicio.Normal, args);

                // Generación de la unidad
                OGeneradorAccesoRapido generador = new OGeneradorAccesoRapido();
                List<string> listaUsing = new List<string>() { typeof(System.Int32).Namespace, typeof(Orbita.VA.Comun.OVariable).Namespace };

                HabilitadoVariables = string.Equals(args[3], "Vars", StringComparison.InvariantCultureIgnoreCase);
                if (HabilitadoVariables)
                {
                    listaUsing.Add(typeof(Orbita.VA.MaquinasEstados.OMaquinaEstadosBase).Namespace);
                }

                HabilitadoHardware = string.Equals(args[4], "Hard", StringComparison.InvariantCultureIgnoreCase);
                if (HabilitadoHardware)
                {
                    listaUsing.Add(typeof(Orbita.VA.Hardware.OCamaraBase).Namespace);
                }

                HabilitadoVision = string.Equals(args[5], "Vision", StringComparison.InvariantCultureIgnoreCase);
                if (HabilitadoVision)
                {
                    listaUsing.Add(typeof(Orbita.VA.Funciones.OFuncionVisionBase).Namespace);
                }

                generador.GenerarUnit(args[0], listaUsing.ToArray());

                // Lectura de la base de datos
                DataTable dtME = Orbita.VA.MaquinasEstados.AppBD.GetMaquinasEstados();

                // Para cada escenario se crea su clase
                foreach (DataRow drME in dtME.Rows)
                {
                    string codME = drME["CodMaquinaEstados"].ToString();
                    string descME = drME["DescMaquinaEstados"].ToString();
                    string claseImplementadora = drME["ClaseImplementadora"].ToString();
                    string codEscenario = drME["CodEscenario"].ToString();
                    bool OK;

                    //------------ MÁQUINA DE ESTADOS ---------------//
                    CodeTypeDeclaration claseMaquinaEstados;
                    OK = GenerarMaquinaEstados(generador, claseImplementadora, descME, out claseMaquinaEstados);
                    if (!OK)
                    {
                        continue;
                    }

                    //------------ ESCENARIO ---------------//
                    string claseImplementadoraEscenario = "Escenario_" + claseImplementadora;
                    CodeTypeDeclaration claseEscenario;
                    OK = GenerarEscenario(generador, claseImplementadoraEscenario, "Escenario de " + descME, out claseEscenario);
                    if (!OK)
                    {
                        continue;
                    }

                    //------------ VARIABLES ---------------//
                    if (HabilitadoVariables)
                    {
                        GenerarVariables(generador, codEscenario, claseEscenario);
                    }

                    //------------ HARDWARE ---------------//
                    if (HabilitadoHardware)
                    {
                        GenerarHardware(generador, codEscenario, claseEscenario);
                    }

                    //------------ FUNCIONES VISION ---------------//
                    if (HabilitadoVision)
                    {
                        GenerarFuncionesVision(generador, codEscenario, claseEscenario);
                    }

                    //------------ ESTADOS ---------------//
                    GenerarEstados(generador, codME, claseImplementadoraEscenario);

                    //------------ TRANSICIONES ---------------//
                    CodeTypeDeclaration ultimaTransicion;
                    GenerarTransiciones(generador, codME, claseImplementadoraEscenario, out ultimaTransicion);

                    //------------ REGIÓN ---------------//
                    if (ultimaTransicion != null)
                    {
                        generador.RegionStart(descME, claseMaquinaEstados);
                        generador.RegionEnd(ultimaTransicion);
                    }
                }

                if (HabilitadoVariables)
                {
                    CodeTypeDeclaration claseImplementacionVariables;
                    GenerarImplementadorVariables(generador, "OListaVariables", "Mapeado de las variables", out claseImplementacionVariables);
                }

                if (HabilitadoHardware)
                {
                    CodeTypeDeclaration claseImplementacionHardware;
                    GenerarImplementadorHardware(generador, "OListaHardware", "Mapeado del hardware", out claseImplementacionHardware);
                }

                if (HabilitadoVision)
                {
                    CodeTypeDeclaration claseImplementacionVision;
                    GenerarImplementadorVision(generador, "OListaVision", "Mapeado de las funciones de visión", out claseImplementacionVision);
                }

                // Guardar el fichero
                generador.GuardarCodigo(args[2]);
            }
        }
        #endregion

        #region Métodos estáticos
        /// <summary>
        /// Generación de la clase parcial de la máquina de estados
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="descripcionMaquinaEstados"></param>
        /// <param name="claseImplementadora"></param>
        /// <param name="claseMaquinaEstados"></param>
        /// <returns></returns>
        private static bool GenerarMaquinaEstados(OGeneradorAccesoRapido generador, string claseImplementadora, string descripcionMaquinaEstados, out CodeTypeDeclaration claseMaquinaEstados)
        {
            // Generación de la clase parcial de la máquina de estados
            string clasePadre = typeof(OMaquinaEstadosBase).Name; //"OMaquinaEstadosBase"
            claseMaquinaEstados = generador.GenerarClase(claseImplementadora, clasePadre, descripcionMaquinaEstados, MemberAttributes.Public, true);
            if (claseMaquinaEstados == null)
            {
                return false;
            }

            // Generadora de constructor con la instrucción new variable
            generador.GenerarConstructor(claseMaquinaEstados, "Constructor de la clase", MemberAttributes.Public,
                new CodeParameterDeclarationExpression[] { new CodeParameterDeclarationExpression(typeof(string), "codigo") },
                new CodeExpression[] { new CodeVariableReferenceExpression("codigo") },
                new CodeStatement[] { });

            // Generadora del método de creación del escenario
            CodeStatement creacionObjetoEscenario = generador.New("_Escenario", "Escenario_" + claseImplementadora, "CodEscenario");
            generador.GenerarMetodo("CrearEscenario", claseMaquinaEstados, "Constructor de la clase", MemberAttributes.Public | MemberAttributes.Override,
                new CodeParameterDeclarationExpression[] { },
                new CodeStatement[] { creacionObjetoEscenario });

            // Se genera la propiedad Escenarios
            generador.GenerarPropiedadReadOnly(ref claseMaquinaEstados, "Escenario", "Escenario_" + claseImplementadora, "Escenario de la máquina de estados", MemberAttributes.Public, "Escenario_" + claseImplementadora, false);

            generador.Region(descripcionMaquinaEstados, claseMaquinaEstados);

            return true;
        }

        /// <summary>
        /// Generación de la clase parcial del escenario
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="descripcionMaquinaEstados"></param>
        /// <param name="claseImplementadora"></param>
        /// <param name="claseEscenario"></param>
        /// <returns></returns>
        private static bool GenerarEscenario(OGeneradorAccesoRapido generador, string claseImplementadora, string descripcionEscenario, out CodeTypeDeclaration claseEscenario)
        {
            // Generación de la clase escenario asociada a la máquina de estados
            string clasePadre = typeof(OEscenario).Name; //"OEscenario"
            claseEscenario = generador.GenerarClase(claseImplementadora, clasePadre, descripcionEscenario, MemberAttributes.Public, true);
            if (claseEscenario == null)
            {
                return false;
            }

            // Generadora de constructor con la instrucción new variable y hardware
            List<CodeStatement> listaInstrucciones = new List<CodeStatement>();
            
            CodeStatement asignacionCodigoEscenario = generador.Asignacion("Codigo", "codigo");
            listaInstrucciones.Add(asignacionCodigoEscenario);

            if (HabilitadoVariables)
            {
                CodeStatement creacionObjetoVariables = generador.New("_Variables", "CVariables", "Codigo");
                listaInstrucciones.Add(creacionObjetoVariables);
            }
            if (HabilitadoHardware)
            {
                CodeStatement creacionObjetoHardware = generador.New("_Hardware", "CHardware", "Codigo");
                listaInstrucciones.Add(creacionObjetoHardware);
            }
            if (HabilitadoVision)
            {
                CodeStatement creacionObjetoFuncionVision = generador.New("_FuncionesVision", "CFuncionVision", "Codigo");
                listaInstrucciones.Add(creacionObjetoFuncionVision);
            }
            generador.GenerarConstructor(claseEscenario, "Constructor de la clase", MemberAttributes.Public,
                new CodeParameterDeclarationExpression[] { new CodeParameterDeclarationExpression(typeof(string), "codigo") },
                new CodeExpression[] { new CodeVariableReferenceExpression("codigo") },
                listaInstrucciones.ToArray());

            // Región
            generador.Region(descripcionEscenario, claseEscenario);

            return true;
        }

        /// <summary>
        /// Generación de la clase interior al escenario que implementa las variables
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codEscenario"></param>
        /// <param name="claseEscenario"></param>
        private static void GenerarVariables(OGeneradorAccesoRapido generador, string codEscenario, CodeTypeDeclaration claseEscenario)
        {
            // Se genera la propiedad Variables
            generador.GenerarPropiedadReadOnly(ref claseEscenario, "Variables", string.Empty, "Variables del escenario", MemberAttributes.Public, "CVariables", true);

            // Generador de la clase interna de escenarios de variables
            CodeTypeDeclaration claseVariables = generador.GenerarClase("CVariables", string.Empty, claseEscenario, "Variables del escenario", MemberAttributes.Public);
            generador.GenerarPropiedadReadOnly(ref claseVariables, "Codigo", string.Empty, "Código del escenario", MemberAttributes.Public, typeof(string).ToString(), true);

            // Constructor de la clase Variables con la asignación del código
            CodeStatement asignacionCodigoVariables = generador.Asignacion("_Codigo", "codigo");
            generador.GenerarConstructor(claseVariables, "Constructor de la clase", MemberAttributes.Public,
                new CodeParameterDeclarationExpression[] { new CodeParameterDeclarationExpression(typeof(string), "codigo") },
                new CodeExpression[] { },
                new CodeStatement[] { asignacionCodigoVariables });

            // Lectura de los alias de la base de datos
            DataTable dtAliasVariables = Orbita.VA.Comun.AppBD.GetAliasEscenarioVariables(codEscenario);
            foreach (DataRow drAlias in dtAliasVariables.Rows)
            {
                // Creamos una propiedad con cada uno de los alias
                string codAlias = drAlias["CodAlias"].ToString();
                string descVariable = drAlias["DescVariable"].ToString();
                generador.GenerarPropiedadReadOnlyRuntime(ref claseVariables, codAlias, string.Empty, descVariable, MemberAttributes.Public, "OVariable", "OVariablesManager", "GetVariable", new CodeExpression[] { new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Codigo"), new CodePrimitiveExpression(codAlias) });
            }

            generador.Region("Variables del escenario", claseVariables);
        }

        /// <summary>
        /// Generación de la clase interior al escenario que implementa las variables
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codEscenario"></param>
        /// <param name="claseEscenario"></param>
        private static void GenerarHardware(OGeneradorAccesoRapido generador, string codEscenario, CodeTypeDeclaration claseEscenario)
        {
            // Se genera la propiedad Hardware
            generador.GenerarPropiedadReadOnly(ref claseEscenario, "Hardware", string.Empty, "Hardware del escenario", MemberAttributes.Public, "CHardware", true);

            // Generador de la clase interna de escenarios de Hardware
            CodeTypeDeclaration claseHardware = generador.GenerarClase("CHardware", string.Empty, claseEscenario, "Hardware del escenario", MemberAttributes.Public);
            generador.GenerarPropiedadReadOnly(ref claseHardware, "Codigo", string.Empty, "Código del escenario", MemberAttributes.Public, typeof(string).ToString(), true);

            // Constructor de la clase Hardware con la asignación del código
            CodeStatement asignacionCodigoHardware = generador.Asignacion("_Codigo", "codigo");
            generador.GenerarConstructor(claseHardware, "Constructor de la clase", MemberAttributes.Public,
                new CodeParameterDeclarationExpression[] { new CodeParameterDeclarationExpression(typeof(string), "codigo") },
                new CodeExpression[] { },
                new CodeStatement[] { asignacionCodigoHardware });

            // Lectura de los alias de la base de datos
            DataTable dtAliasHardware = Orbita.VA.Hardware.AppBD.GetAliasEscenarioHardware(codEscenario);
            foreach (DataRow drAlias in dtAliasHardware.Rows)
            {
                // Creamos una propiedad con cada uno de los alias
                string codAlias = drAlias["CodAlias"].ToString();
                string descHardware = drAlias["DescHardware"].ToString();
                string claseImplementadoraHardware = drAlias["ClaseImplementadoraCast"].ToString();
                generador.GenerarPropiedadReadOnlyRuntime(ref claseHardware, codAlias, claseImplementadoraHardware, descHardware, MemberAttributes.Public, claseImplementadoraHardware, "OHardwareManager", "GetHardware", new CodeExpression[] { new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Codigo"), new CodePrimitiveExpression(codAlias) });
            }

            generador.Region("Hardware del escenario", claseHardware);
        }

        /// <summary>
        /// Generación de la clase interior al escenario que implementa las variables
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codEscenario"></param>
        /// <param name="claseEscenario"></param>
        private static void GenerarFuncionesVision(OGeneradorAccesoRapido generador, string codEscenario, CodeTypeDeclaration claseEscenario)
        {
            // Se genera la propiedad de las funciones de visión
            generador.GenerarPropiedadReadOnly(ref claseEscenario, "FuncionesVision", string.Empty, "Funciones de visión", MemberAttributes.Public, "CFuncionVision", true);

            // Generador de la clase interna de escenarios de las funciones de visión
            CodeTypeDeclaration claseFuncionesVision = generador.GenerarClase("CFuncionVision", string.Empty, claseEscenario, "Funciones de visión del escenario", MemberAttributes.Public);
            generador.GenerarPropiedadReadOnly(ref claseFuncionesVision, "Codigo", string.Empty, "Código del escenario", MemberAttributes.Public, typeof(string).ToString(), true);

            // Constructor de la clase FuncionesVision con la asignación del código
            CodeStatement asignacionCodigoFuncionesVision = generador.Asignacion("_Codigo", "codigo");
            generador.GenerarConstructor(claseFuncionesVision, "Constructor de la clase", MemberAttributes.Public,
                new CodeParameterDeclarationExpression[] { new CodeParameterDeclarationExpression(typeof(string), "codigo") },
                new CodeExpression[] { },
                new CodeStatement[] { asignacionCodigoFuncionesVision });

            // Lectura de los alias de la base de datos
            DataTable dtAliasFuncionesVision = Orbita.VA.Funciones.AppBD.GetAliasEscenarioFuncionesVision(codEscenario);
            foreach (DataRow drAlias in dtAliasFuncionesVision.Rows)
            {
                // Creamos una propiedad con cada uno de los alias
                string codAlias = drAlias["CodAlias"].ToString();
                string descFuncionVision = drAlias["DescFuncionVision"].ToString();
                string claseImplementadoraFuncionVision = drAlias["ClaseImplementadora"].ToString();
                generador.GenerarPropiedadReadOnlyRuntime(ref claseFuncionesVision, codAlias, claseImplementadoraFuncionVision, descFuncionVision, MemberAttributes.Public, claseImplementadoraFuncionVision, "OFuncionesVisionManager", "GetFuncionVision", new CodeExpression[] { new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Codigo"), new CodePrimitiveExpression(codAlias) });
            }

            generador.Region("Funciones de visión del escenario", claseFuncionesVision);
        }

        /// <summary>
        /// Generador de estados de una determinada máquina de estados
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codMaquinaEstados"></param>
        private static bool GenerarEstados(OGeneradorAccesoRapido generador, string codMaquinaEstados, string claseImplementadoraEscenarioAsociado)
        {
            // Lectura de la base de datos
            DataTable dtEstados = Orbita.VA.MaquinasEstados.AppBD.GetEstados(codMaquinaEstados);

            // Para cada estado se crea su clase
            foreach (DataRow drEstado in dtEstados.Rows)
            {
                string codEstado = drEstado["CodEstado"].ToString();
                string descEstado = "Estado: " + drEstado["DescEstado"].ToString();
                string claseImplementadora = drEstado["ClaseImplementadora"].ToString();
                TipoEstado tipoEstado = OEnumerado<TipoEstado>.Validar(drEstado["Tipo"].ToString(), TipoEstado.EstadoSimple);
                //OTipoEstado tipoEstado = (OTipoEstado)App.EnumParse(typeof(OTipoEstado), drEstado["Tipo"].ToString(), OTipoEstado.EstadoSimple);

                // Generación de la clase parcial del estado
                string claseEstadoPadre;
                switch (tipoEstado)
                {
                    case TipoEstado.EstadoSimple:
                    default:
                        claseEstadoPadre = typeof (OEstadoBase).Name; //"OEstadoBase";
                        break;
                    case TipoEstado.EstadoAsincrono:
                        claseEstadoPadre = typeof (OEstadoAsincrono).Name; //"OEstadoAsincrono";
                        break;
                }
                CodeTypeDeclaration claseEstado = generador.GenerarClase(claseImplementadora, claseEstadoPadre, descEstado, MemberAttributes.Public, true);
                if (claseEstado == null)
                {
                    return false;
                }

                // Generadora de constructor con la instrucción new variable
                generador.GenerarConstructor(claseEstado, "Constructor de la clase", MemberAttributes.Public,
                    new CodeParameterDeclarationExpression[] 
                        { new CodeParameterDeclarationExpression(typeof(string), "codigoMaquinaEstados"),
                          new CodeParameterDeclarationExpression(typeof(string), "codigo"),
                          new CodeParameterDeclarationExpression(typeof(OEscenario), "escenario")
                        },
                    new CodeExpression[] 
                        { new CodeVariableReferenceExpression("codigoMaquinaEstados"),
                          new CodeVariableReferenceExpression("codigo"),
                          new CodeVariableReferenceExpression("escenario")
                        },
                    new CodeStatement[] { });

                // Se genera la propiedad Escenarios
                generador.GenerarPropiedadRuntime(ref claseEstado, "Escenario", claseImplementadoraEscenarioAsociado, "Escenario del estado", MemberAttributes.Public | MemberAttributes.New, claseImplementadoraEscenarioAsociado, "_Escenario");

                generador.Region(descEstado, claseEstado);
            }

            return true;
        }

        /// <summary>
        /// Generador de transiciones de una determinada máquina de estados
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codMaquinaEstados"></param>
        private static bool GenerarTransiciones(OGeneradorAccesoRapido generador, string codMaquinaEstados, string claseImplementadoraEscenarioAsociado, out CodeTypeDeclaration ultimaTransicion)
        {
            ultimaTransicion = null;

            // Lectura de la base de datos
            DataTable dtTransiciones = Orbita.VA.MaquinasEstados.AppBD.GetTransiciones(codMaquinaEstados);

            // Para cada transición se crea su clase
            foreach (DataRow drTransicion in dtTransiciones.Rows)
            {
                string codTransicion = drTransicion["CodTransicion"].ToString();
                string descTransicion = "Transición: " + drTransicion["ExplicacionCondicionEsperada"].ToString();
                string claseImplementadora = drTransicion["ClaseImplementadora"].ToString();
                TipoTransicion tipoTransicion = OEnumerado<TipoTransicion>.Validar(drTransicion["Tipo"].ToString(), TipoTransicion.TransicionSimple);
                //OTipoTransicion tipoTransicion = (TipoTransicion)App.EnumParse(typeof(TipoTransicion), drTransicion["Tipo"].ToString(), TipoTransicion.TransicionSimple);

                // Generación de la clase parcial del transicion
                string claseTransicionPadre;
                switch (tipoTransicion)
                {
                    case TipoTransicion.TransicionSimple:
                    default:
                        claseTransicionPadre = typeof (OTransicionBase).Name; //"OTransicionBase";
                        break;
                    case TipoTransicion.TransicionUniversal:
                        claseTransicionPadre = typeof (OTransicionUniversal).Name; //"OTransicionUniversal";
                        break;
                }
                CodeTypeDeclaration claseTransicion = generador.GenerarClase(claseImplementadora, claseTransicionPadre, descTransicion, MemberAttributes.Public, true);
                if (claseTransicion == null)
                {
                    return false;
                }

                ultimaTransicion = claseTransicion;

                // Generadora de constructor con la instrucción new variable
                generador.GenerarConstructor(claseTransicion, "Constructor de la clase", MemberAttributes.Public,
                    new CodeParameterDeclarationExpression[] 
                        { new CodeParameterDeclarationExpression(typeof(string), "codigoMaquinaEstados"),
                          new CodeParameterDeclarationExpression(typeof(string), "codigo"),
                          new CodeParameterDeclarationExpression(typeof(OEscenario), "escenario")
                        },
                    new CodeExpression[] 
                        { new CodeVariableReferenceExpression("codigoMaquinaEstados"),
                          new CodeVariableReferenceExpression("codigo"),
                          new CodeVariableReferenceExpression("escenario")
                        },
                    new CodeStatement[] { });

                // Se genera la propiedad Escenarios
                generador.GenerarPropiedadRuntime(ref claseTransicion, "Escenario", claseImplementadoraEscenarioAsociado, "Escenario de la transición", MemberAttributes.Public | MemberAttributes.New, claseImplementadoraEscenarioAsociado, "_Escenario");

                DataTable dtTransicion = Orbita.VA.MaquinasEstados.AppBD.GetInstanciaTransicion(codMaquinaEstados, codTransicion);
                if (dtTransicion.Rows.Count == 1)
                {
                    string codEstadoOrigen = dtTransicion.Rows[0]["CodigoEstadoOrigen"].ToString();
                    string codEstadoDestino = dtTransicion.Rows[0]["CodigoEstadoDestino"].ToString();

                    DataTable dtEstadoOrigen = Orbita.VA.MaquinasEstados.AppBD.GetInstanciaEstado(codMaquinaEstados, codEstadoOrigen);
                    if (dtEstadoOrigen.Rows.Count == 1)
                    {
                        // Se genera la propiedad Estado Origen
                        string claseImplementadoraEstado = dtEstadoOrigen.Rows[0]["ClaseImplementadora"].ToString();
                        generador.GenerarPropiedadRuntime(ref claseTransicion, "EstadoOrigen", claseImplementadoraEstado, "Estado origen", MemberAttributes.Public | MemberAttributes.New, claseImplementadoraEstado, "_EstadoOrigen");
                    }                                                                                                                                                                                                   

                    DataTable dtEstadoDestino = Orbita.VA.MaquinasEstados.AppBD.GetInstanciaEstado(codMaquinaEstados, codEstadoDestino);
                    if (dtEstadoDestino.Rows.Count == 1)
                    {
                        // Se genera la propiedad Estado Origen
                        string claseImplementadoraEstado = dtEstadoDestino.Rows[0]["ClaseImplementadora"].ToString();
                        generador.GenerarPropiedadRuntime(ref claseTransicion, "EstadoDestino", claseImplementadoraEstado, "Destino", MemberAttributes.Public | MemberAttributes.New, claseImplementadoraEstado, "_EstadoDestino");
                    }
                }

                generador.Region(descTransicion, claseTransicion);
            }

            return true;
        }

        /// <summary>
        /// Generador de la clase estática de implementación de variables
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codMaquinaEstados"></param>
        private static bool GenerarImplementadorVariables(OGeneradorAccesoRapido generador, string claseImplementadora, string descripcion, out CodeTypeDeclaration clase)
        {
            // Generación de la clase parcial de la máquina de estados
            string clasePadre = typeof(Object).Name;
            clase = generador.GenerarClase(claseImplementadora, string.Empty, descripcion, MemberAttributes.Public | MemberAttributes.Static, false);
            if (clase == null)
            {
                return false;
            }
            generador.Region(descripcion, clase);

            // Lectura de los alias de la base de datos
            DataTable dtVariables = Orbita.VA.Comun.AppBD.GetVariables();
            foreach (DataRow drVar in dtVariables.Rows)
            {
                // Creamos una propiedad con cada uno de los alias
                string codVariable = drVar["CodVariable"].ToString();
                generador.GenerarPropiedadReadOnlyRuntime(ref clase, codVariable, string.Empty, codVariable, MemberAttributes.Public | MemberAttributes.Static, "OVariable", "OVariablesManager", "GetVariable", new CodeExpression[] { new CodePrimitiveExpression(codVariable) });
            }

            return true;
        }

        /// <summary>
        /// Generador de la clase estática de implementación del hardware
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codMaquinaEstados"></param>
        private static bool GenerarImplementadorHardware(OGeneradorAccesoRapido generador, string claseImplementadora, string descripcion, out CodeTypeDeclaration clase)
        {
            // Generación de la clase parcial de la máquina de estados
            string clasePadre = typeof(Object).Name;
            clase = generador.GenerarClase(claseImplementadora, string.Empty, descripcion, MemberAttributes.Public | MemberAttributes.Static, false);
            if (clase == null)
            {
                return false;
            }
            generador.Region(descripcion, clase);

            // Lectura de los alias de la base de datos
            DataTable dtHardware = Orbita.VA.Hardware.AppBD.GetHardware();
            foreach (DataRow drHw in dtHardware.Rows)
            {
                // Creamos una propiedad con cada uno de los alias
                string codHardware = drHw["CodHardware"].ToString();
                string descHardware = drHw["DescHardware"].ToString();
                string claseImplementadoraHw = drHw["ClaseImplementadoraCast"].ToString();
                generador.GenerarPropiedadReadOnlyRuntime(ref clase, codHardware, claseImplementadoraHw, descHardware, MemberAttributes.Public | MemberAttributes.Static, claseImplementadoraHw, "OHardwareManager", "GetHardware", new CodeExpression[] { new CodePrimitiveExpression(codHardware) });
            }

            return true;
        }

        /// <summary>
        /// Generador de la clase estática de implementación del hardware
        /// </summary>
        /// <param name="generador"></param>
        /// <param name="codMaquinaEstados"></param>
        private static bool GenerarImplementadorVision(OGeneradorAccesoRapido generador, string claseImplementadora, string descripcion, out CodeTypeDeclaration clase)
        {
            // Generación de la clase parcial de la máquina de estados
            string clasePadre = typeof(Object).Name;
            clase = generador.GenerarClase(claseImplementadora, string.Empty, descripcion, MemberAttributes.Public | MemberAttributes.Static, false);
            if (clase == null)
            {
                return false;
            }
            generador.Region(descripcion, clase);

            // Lectura de los alias de la base de datos
            DataTable dtVision = Orbita.VA.Funciones.AppBD.GetFuncionesVision();
            foreach (DataRow drHw in dtVision.Rows)
            {
                // Creamos una propiedad con cada uno de los alias
                string codVision = drHw["CodFuncionVision"].ToString();
                string descVision = drHw["DescFuncionVision"].ToString();
                string claseImplementadoraVis = drHw["ClaseImplementadora"].ToString();
                generador.GenerarPropiedadReadOnlyRuntime(ref clase, codVision, claseImplementadoraVis, descVision, MemberAttributes.Public | MemberAttributes.Static, claseImplementadoraVis, "OFuncionesVisionManager", "GetFuncionVision", new CodeExpression[] { new CodePrimitiveExpression(codVision) });
            }

            return true;
        }
        #endregion
    }
}
