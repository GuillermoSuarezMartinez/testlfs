//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.IO;
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OColumnas
    {
        bool permitirOrdenar;
        AutoAjustarEstilo estilo;
        bool mostrarFiltro;

        #region Eventos
        public event EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OCeldas.
        /// </summary>
        public OColumnas()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina si se permite ordenación por columna.")]
        public bool PermitirOrdenar
        {
            get { return this.permitirOrdenar; }
            set
            {
                if (this.permitirOrdenar != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("PermitirOrdenar"));
                    }
                    this.permitirOrdenar = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("PermitirOrdenar"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Especifica el estilo de columnas.")]
        public AutoAjustarEstilo Estilo
        {
            get { return this.estilo; }
            set
            {
                if (this.estilo != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("Estilo"));
                    }
                    this.estilo = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("Estilo"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Mostrar fila de filtros.")]
        public bool MostrarFiltro
        {
            get { return this.mostrarFiltro; }
            set
            {
                if (this.mostrarFiltro != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("MostrarFiltro"));
                    }
                    this.mostrarFiltro = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("MostrarFiltro"));
                    }
                }
            }
        }
        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetPermitirOrdenar()
        {
            this.PermitirOrdenar = Configuracion.DefectoPermitirOrdenar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstilo()
        {
            this.Estilo = Configuracion.DefectoAutoAjustarEstilo;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarFiltro()
        {
            this.MostrarFiltro = Configuracion.DefectoMostrarFiltro;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializePermitirOrdenar()
        {
            return (this.PermitirOrdenar != Configuracion.DefectoPermitirOrdenar);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != Configuracion.DefectoAutoAjustarEstilo);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarFiltro()
        {
            return (this.MostrarFiltro != Configuracion.DefectoMostrarFiltro);
        }
        /// <summary>
        /// Determina el número de propiedades modificadas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return null;
        }
    }
}
