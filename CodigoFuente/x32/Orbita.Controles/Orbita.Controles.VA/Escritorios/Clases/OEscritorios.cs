﻿//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Movido al proyecto Orbita.Controles.VA
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDock;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.Xml;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Clase para el manejo inteligente de la posición de los formularios en el MDI
    /// </summary>
    public static class OEscritoriosManager
    {
        #region Atributo(s)
        /// <summary>
        /// Habilita o deshabilita la opción de anclar formularios
        /// </summary>
        public static bool PermiteAnclajes;

        /// <summary>
        /// Informa si el manejo de la posición de los formularios se realiza de forma inteligente
        /// </summary>
        public static bool ManejoAvanzadoEscritorio;

        /// <summary>
        /// Nombre del escritorio que se está ejecutando actualmente
        /// </summary>
        public static string NombreEscritorioActual;

        /// <summary>
        /// El primer formulario aparece maximizado
        /// </summary>
        public static bool PreferenciaMaximizado;

        /// <summary>
        /// Al cargar el escritorio se abren los todos los formularios y se situan en su posicion guardada.
        /// En caso contrario únicamente se resituan los formularios ya abiertos
        /// </summary>
        public static bool AutoAbrirFoms;

        /// <summary>
        /// Lista de todos los escritorios existentes
        /// </summary>
        public static List<OEscritorio> ListaEscritorios;

        /// <summary>
        /// Configuración de los escritorios cargada del xml
        /// </summary>
        internal static OpcionesEscritorios OpcionesEscritorios;
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Constructor de los campos de la clase
        /// </summary>
        public static void Constructor()
        {
            if (ODebug.IsWinForms())
            {
                // Consulta de la configuración
                OpcionesEscritorios = null;
                try
                {
                    OpcionesEscritorios = (OpcionesEscritorios)(new OpcionesEscritorios(OpcionesEscritorios.ConfFile).CargarDatos());
                }
                catch (FileNotFoundException exception)
                {
                    OLogsControlesVA.Escritorios.Error(exception, "Constructor");

                    OpcionesEscritorios = new OpcionesEscritorios();
                    OpcionesEscritorios.Guardar();
                }

                PermiteAnclajes = OpcionesEscritorios.PermiteAnclajes;
                ManejoAvanzadoEscritorio = OpcionesEscritorios.ManejoAvanzadoEscritorio;
                NombreEscritorioActual = OpcionesEscritorios.NombreEscritorioActual;
                PreferenciaMaximizado = OpcionesEscritorios.PreferenciaMaximizado;
                AutoAbrirFoms = OpcionesEscritorios.AutoAbrirFoms;

                ListaEscritorios = new List<OEscritorio>();
                foreach (OpcionesEscritorio escritorio in OpcionesEscritorios.ListaOpcionesEscritorio)
                {
                    ListaEscritorios.Add(new OEscritorio(escritorio.Nombre, escritorio.ListaInfoPosForms));
                }
            }
        }

        /// <summary>
        /// Inicializa los campos
        /// </summary>
        public static void Inicializar()
        {
            if (ODebug.IsWinForms() && ManejoAvanzadoEscritorio)
            {
                Situar();
            }
        }

        /// <summary>
        /// Finaliza el control
        /// </summary>
        public static void Finalizar()
        {
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            ListaEscritorios = null;
        }

        /// <summary>
        /// Guarda la posición de los formularios abiertos en disco
        /// </summary>
        /// <param name="nombre">Nombre del escritorio</param>
        public static void Guardar(string codigo)
        {
            if (ODebug.IsWinForms())
            {
                OEscritorio infoEscritorio = null;

                // Busco si el escritorio ya existe!
                bool yaExiste = false;
                foreach (OEscritorio escritorio in ListaEscritorios)
                {
                    if (escritorio.Nombre == codigo)
                    {
                        yaExiste = true;
                        infoEscritorio = escritorio;
                        break;
                    }
                }

                // Obtengo la información de las posiciones de las forms
                if (!yaExiste)
                {
                    // Si el escritorio no existe lo creo y lo añado a la lista
                    infoEscritorio = new OEscritorio(codigo);
                    ListaEscritorios.Add(infoEscritorio);
                }

                // Guardo la información de la posición actual
                infoEscritorio.ObtenerEscritorioAplicacion();
            }
        }

        /// <summary>
        /// Elimina un determinado escritorio de disco
        /// </summary>
        /// <param name="nombre">Nombre del escritorio</param>
        public static void Eliminar(string codigo)
        {
            if (ODebug.IsWinForms())
            {
                // Busco si el escritorio ya existe!
                foreach (OEscritorio escritorio in ListaEscritorios)
                {
                    if (escritorio.Nombre == codigo)
                    {
                        // Si el escritorio no existe lo creo y lo añado a la lista
                        ListaEscritorios.Remove(escritorio);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Carga la posición de los formularios abiertos según la información de disco
        /// </summary>
        /// <param name="nombre">Nombre del escritorio a cargar</param>
        public static void Situar(string codigo)
        {
            if (ODebug.IsWinForms())
            {
                foreach (OEscritorio escritorio in ListaEscritorios)
                {
                    if (escritorio.Nombre == codigo)
                    {
                        escritorio.Situar();

                        if (PreferenciaMaximizado)
                        {
                            escritorio.Maximizar();
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Carga la posición de los formularios
        /// </summary>
        public static void Situar()
        {
            Situar(NombreEscritorioActual);
        }

        /// <summary>
        /// Carga la posición de un determinado formularios
        /// </summary>
        public static void SituarFormulario(ref IOrbitaForm frmBase)
        {
            if (ODebug.IsWinForms())
            {
                foreach (OEscritorio escritorio in ListaEscritorios)
                {
                    if ((OEscritoriosManager.ManejoAvanzadoEscritorio) && (escritorio.Nombre == NombreEscritorioActual))
                    {
                        escritorio.SituarFormulario(ref frmBase);
                        break;
                    }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene la información necesaria para restaurar las posiciones del escritorio (llamamos escritorio a la posición de los formularios)
    /// </summary>
    public class OEscritorio
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de las posiciones de los formularios
        /// </summary>
        internal List<PosicionFormulario> ListaInfoPosForms = new List<PosicionFormulario>();

        /// <summary>
        /// Nombre asignado al escritorio
        /// </summary>
        public string Nombre;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OEscritorio(string nombre)
        {
            this.Nombre = nombre;
            this.ListaInfoPosForms = new List<PosicionFormulario>();
        }
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        internal OEscritorio(string nombre, List<PosicionFormulario> listaInfoPosForms)
        {
            this.Nombre = nombre;
            this.ListaInfoPosForms = listaInfoPosForms;
        }
        #endregion Constructor

        #region Método(s) público(s)
        /// <summary>
        /// Obtiene la información de posición de todos los formularios abiertos
        /// </summary>
        public void ObtenerEscritorioAplicacion()
        {
            this.ListaInfoPosForms = new List<PosicionFormulario>();

            foreach (Form form in OTrabajoControles.FormularioPrincipalMDI.MdiChildren) // Para todos los formularios abiertos
            {
                if (form is IOrbitaForm)
                {
                    IOrbitaForm frmBase = (IOrbitaForm)form;
                    if (frmBase.RecordarPosicion) // Si el formulario permite recordar su posición
                    {
                        PosicionFormulario infoPosForm = new PosicionFormulario(); // Creación de la clase que guarda al información de posición del formulario
                        infoPosForm.ObtenerPosicion((IOrbitaForm)form); // Obtención de la información de un determinado formulario
                        this.ListaInfoPosForms.Add(infoPosForm); // Añadimos la información de posición del formlario a la lista
                    }
                }
            }
        }

        /// <summary>
        /// Resitua la posición de los formularios abiertos según la configuración del escritorio
        /// </summary>
        public void EstablecerEscritorioAplicacion()
        {
            //OTrabajoControles.DockManager.DockAreas.Clear();

            // Para todos los elementos del escritorio
            foreach (PosicionFormulario posicionFormulario in this.ListaInfoPosForms)
            {
                bool existeForm = false;
                IOrbitaForm frmBase = null;

                // Busqueda del formulario
                foreach (Form form in OTrabajoControles.FormularioPrincipalMDI.MdiChildren) // Para todos los formularios abiertos
                {
                    if (form.Name == posicionFormulario.Nombre)
                    {
                        if (form is IOrbitaForm)
                        {
                            frmBase = (IOrbitaForm)form;

                            // Posicionamiento del formulario
                            this.SituarFormulario(ref frmBase);

                            existeForm = true;
                            break;
                        }
                    }
                }

                // Creación del formulario por reflexión
                if (!existeForm && OEscritoriosManager.AutoAbrirFoms)
                {
                    try
                    {
                        Assembly a = Assembly.Load(posicionFormulario.Ensamblado);
                        frmBase = (IOrbitaForm)Activator.CreateInstance(a.GetType(posicionFormulario.Clase), null);
                        frmBase.Show();
                    }
                    catch (Exception exception)
                    {
                        OLogsControlesVA.Escritorios.Error(exception, "Carga del formulario por reflexión", String.Format("Ensamblado: {0}, Clase: {1}", posicionFormulario.Ensamblado, posicionFormulario.Clase));
                    }
                }
            }
        }

        /// <summary>
        /// Carga la posición de los formularios abiertos según la información de disco
        /// </summary>
        /// <param name="nombre">Nombre del escritorio a cargar</param>        
        public void Situar()
        {
            // Establece el escritorio de la aplicación
            this.EstablecerEscritorioAplicacion();
        }

        /// <summary>
        /// Resitua la posición de los formularios
        /// </summary>
        /// <param name="frmBase"></param>
        public void SituarFormulario(ref IOrbitaForm frmBase)
        {
            foreach (PosicionFormulario posForm in this.ListaInfoPosForms)
            {
                if (posForm.Nombre == frmBase.Name)
                {
                    posForm.EstablecerPosicion(ref frmBase);
                    break;
                }
            }
        }

        /// <summary>
        /// Se máximizan todos los formularios abiertos
        /// </summary>
        public void Maximizar()
        {
            // Se maximizan todos los formularios
            foreach (Form form in OTrabajoControles.FormularioPrincipalMDI.MdiChildren) // Para todos los formularios abiertos
            {
                if (form is IOrbitaForm)
                {
                    IOrbitaForm orbitaForm = (IOrbitaForm)form;
                    orbitaForm.Maximized = true;
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Opciones de configuración del gestor de escritorios
    /// </summary>
    [Serializable]
    public class OpcionesEscritorios : OAlmacenXML
    {
        #region Atributo(s) estáticos
        /// <summary>
        /// Ruta por defecto del fichero xml de configuración
        /// </summary>
        public static string ConfFile = Path.Combine(ORutaParametrizable.AppFolder, "Configuracion_Escritorios.xml");
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Habilita o deshabilita la opción de anclar formularios
        /// </summary>
        public bool PermiteAnclajes;

        /// <summary>
        /// Informa si el manejo de la posición de los formularios se realiza de forma inteligente
        /// </summary>
        public bool ManejoAvanzadoEscritorio;

        /// <summary>
        /// Nombre del escritorio que se está ejecutando actualmente
        /// </summary>
        public string NombreEscritorioActual;

        /// <summary>
        /// El primer formulario aparece maximizado
        /// </summary>
        public bool PreferenciaMaximizado;

        /// <summary>
        /// Al cargar el escritorio se abren los todos los formularios y se situan en su posicion guardada.
        /// En caso contrario únicamente se resituan los formularios ya abiertos
        /// </summary>
        public bool AutoAbrirFoms;

        /// <summary>
        /// Lista de todos los escritorios existentes
        /// </summary>
        public List<OpcionesEscritorio> ListaOpcionesEscritorio;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OpcionesEscritorios()
            : base(ConfFile)
        {
            this.ListaOpcionesEscritorio = new List<OpcionesEscritorio>();
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OpcionesEscritorios(string rutaFichero)
            : base(rutaFichero)
        {
        }
        #endregion
    }

    /// <summary>
    /// Clase que guarda la información de un escritorio
    /// </summary>
    [Serializable]
    public class OpcionesEscritorio
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre del escritorio
        /// </summary>
        public string Nombre;

        /// <summary>
        /// Lista de las posiciones de los formularios
        /// </summary>
        public List<PosicionFormulario> ListaInfoPosForms = new List<PosicionFormulario>();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OpcionesEscritorio()
        {
            this.ListaInfoPosForms = new List<PosicionFormulario>();
        }
        #endregion

        #region Método(s) herdados
        /// <summary>
        /// Returns a System.String that represents the current System.Object.
        /// </summary>
        /// <returns>Returns a System.String that represents the current System.Object.</returns>
        public override string ToString()
        {
            return this.Nombre;
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene la información de la posición de un formulario
    /// </summary>
    [Serializable]
    public class PosicionFormulario
    {
        #region Atributo(s)
        /// <summary>
        /// Clase del formulario
        /// </summary>
        public string Clase = string.Empty;
        /// <summary>
        /// Ensamblado del formulario
        /// </summary>
        public string Ensamblado = string.Empty;
        /// <summary>
        /// Nombre del formulario
        /// </summary>
        public string Nombre = string.Empty;
        /// <summary>
        /// Posicion X del formulario
        /// </summary>
        public int X = 0;
        /// <summary>
        /// Posicion Y del formulario
        /// </summary>
        public int Y = 0;
        /// <summary>
        /// Anchura del formulario
        /// </summary>
        public int Width = 200;
        /// <summary>
        /// Altura del formulario
        /// </summary>
        public int Height = 200;
        /// <summary>
        /// Indica que el formulario está maximizado
        /// </summary>
        public bool Maximizado;
        /// <summary>
        /// Informa si se trata de un formulario MDI con posibilidad de anclaje
        /// </summary>
        public bool EsFormularioMDIAnclado = false;
        /// <summary>
        /// Informa si el formulario anclado está siempre visible o se oculta automáticamente
        /// </summary>
        public bool Pinned = false;
        /// <summary>
        /// Anchura del panel anclado
        /// </summary>
        public int DockWidth = 100;
        /// <summary>
        /// Altura del panel anclado
        /// </summary>
        public int DockHeight = 400;
        /// <summary>
        /// Localización del anclaje
        /// </summary>
        public DockedLocation LocalizacionAnclaje = DockedLocation.DockedRight;
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Obtiene la información de posición de un formulario
        /// </summary>
        public void ObtenerPosicion(IOrbitaForm form)
        {
            this.Nombre = form.Name;
            this.Clase = form.GetType().ToString();
            this.Ensamblado = form.GetType().Assembly.FullName;
            this.Maximizado = form.Maximized;

            bool anclado = form.Anclado;
            if (!anclado)
            {
                this.X = form.Location.X;
                this.Y = form.Location.Y;
                this.Width = form.Size.Width;
                this.Height = form.Size.Height;
            }
            else
            {
                this.EsFormularioMDIAnclado = form.IsDockedMDIChild;
                if (this.EsFormularioMDIAnclado)
                {
                    Rectangle rectangle = form.DockedMDIRectangle;
                    this.X = rectangle.X;
                    this.Y = rectangle.Y;
                    this.Width = rectangle.Width;
                    this.Height = rectangle.Height;
                }
                else
                {
                    Size size = form.DockedPaneSize;
                    this.DockWidth = size.Width;
                    this.DockHeight = size.Height;
                    this.Pinned = form.DockedPined;
                    this.LocalizacionAnclaje = form.DockedLocation;
                }
            }
        }

        /// <summary>
        /// Establece la posición de un formulario
        /// </summary>
        public void EstablecerPosicion(ref IOrbitaForm form)
        {
            if (form.RecordarPosicion)
            {
                if (!form.Anclado)
                {
                    form.Location = new Point(this.X, this.Y);
                    form.Size = new Size(this.Width, this.Height);
                }
                else
                {
                    form.IsDockedMDIChild = this.EsFormularioMDIAnclado;
                    if (this.EsFormularioMDIAnclado)
                    {
                        form.DockedMDIRectangle = new Rectangle(this.X, this.Y, this.Width, this.Height);
                    }
                    else
                    {
                        form.DockedLocation = this.LocalizacionAnclaje;
                        form.DockedPaneSize = new Size(this.DockWidth, this.DockHeight);
                        form.DockedPined = this.Pinned;
                    }
                }
                form.Maximized = this.Maximizado;
            }
        }
        #endregion
    }
}