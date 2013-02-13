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
using System.Drawing.Design;
using System;
using System.ComponentModel;
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(OAparienciaConverter))]
    public class OApariencia : OAparienciaBase
    {
        #region Atributos
        /// <summary>
        /// Apariencia.
        /// </summary>
        OAparienciaDatos apariencia;
        #endregion

        #region Eventos
        /// <summary>
        /// Cambiando la propiedad.
        /// </summary>
        public event EventHandler<OPropiedadEventArgs> PropertyChanging;
        /// <summary>
        /// Cambio la propiedad.
        /// </summary>
        public event EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OApariencia.
        /// </summary>
        public OApariencia() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia del color de borde.")]
        public override System.Drawing.Color ColorBorde
        {
            get { return this.apariencia.ColorBorde; }
            set
            {
                if (this.apariencia.ColorBorde != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("ColorBorde"));
                    }
                    this.apariencia.ColorBorde = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("ColorBorde"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Determina la apariencia del color de fondo.")]
        public override System.Drawing.Color ColorFondo
        {
            get { return this.apariencia.ColorFondo; }
            set
            {
                if (this.apariencia.ColorFondo != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("ColorFondo"));
                    }
                    this.apariencia.ColorFondo = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("ColorFondo"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Determina la apariencia del color de texto.")]
        public override System.Drawing.Color ColorTexto
        {
            get { return this.apariencia.ColorTexto; }
            set
            {
                if (this.apariencia.ColorTexto != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("ColorTexto"));
                    }
                    this.apariencia.ColorTexto = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("ColorTexto"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Determina la apariencia del estilo de borde.")]
        public override EstiloBorde EstiloBorde
        {
            get { return this.apariencia.EstiloBorde; }
            set
            {
                if (this.apariencia.EstiloBorde != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("EstiloBorde"));
                    }
                    this.apariencia.EstiloBorde = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("EstiloBorde"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Determina la apariencia de alineación de texto horizontal.")]
        public override AlineacionHorizontal AlineacionTextoHorizontal
        {
            get { return this.apariencia.AlineacionTextoHorizontal; }
            set
            {
                if (this.apariencia.AlineacionTextoHorizontal != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("AlineacionTextoHorizontal"));
                    }
                    this.apariencia.AlineacionTextoHorizontal = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("AlineacionTextoHorizontal"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Determina la apariencia de alineación de texto vertical.")]
        public override AlineacionVertical AlineacionTextoVertical
        {
            get { return this.apariencia.AlineacionTextoVertical; }
            set
            {
                if (this.apariencia.AlineacionTextoVertical != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("AlineacionTextoVertical"));
                    }
                    this.apariencia.AlineacionTextoVertical = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("AlineacionTextoVertical"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Especifica como se reprensentará el texto cuando no hay suficiente espacio para mostrar la cadena completa.")]
        public override AdornoTexto AdornoTexto
        {
            get { return this.apariencia.AdornoTexto; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("AdornoTexto"));
                }
                this.apariencia.AdornoTexto = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("AdornoTexto"));
                }
            }
        }
        #endregion

        #region Métodos públicos
        public bool ShouldSerialize()
        {
            return
               (this.ShouldSerializeColorBorde() ||
                this.ShouldSerializeColorFondo() ||
                this.ShouldSerializeColorTexto() ||
                this.ShouldSerializeEstiloBorde() ||
                this.ShouldSerializeAlineacionTextoHorizontal() ||
                this.ShouldSerializeAlineacionTextoVertical() ||
                this.ShouldSerializeAdornoTexto());
        }
        public void Reset()
        {
            this.ResetColorBorde();
            this.ResetColorFondo();
            this.ResetColorTexto();
            this.ResetEstiloBorde();
            this.ResetAlineacionTextoHorizontal();
            this.ResetAlineacionTextoVertical();
            this.ResetAdornoTexto();
        }
        #endregion
    }
}
