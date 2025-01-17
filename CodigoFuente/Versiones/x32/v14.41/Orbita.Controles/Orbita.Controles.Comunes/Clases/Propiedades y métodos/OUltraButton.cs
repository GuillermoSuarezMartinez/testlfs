﻿//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Comunes
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OUltraButton
    {
        #region Atributos
        /// <summary>
        /// Control (sender).
        /// </summary>
        OrbitaUltraButton control;
        /// <summary>
        /// Tipo de botón.
        /// </summary>
        TipoBoton tipo;
        /// <summary>
        /// Estilo de botón.
        /// </summary>
        EstiloBoton estilo;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraButton.
        /// </summary>
        /// <param name="control">Control Orbita asociado a la clase actual.</param>
        public OUltraButton(object control)
            : base()
        {
            this.control = (OrbitaUltraButton)control;
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Tipo de botón.")]
        public TipoBoton Tipo
        {
            get { return this.tipo; }
            set
            {
                this.tipo = value;
                switch (this.tipo)
                {
                    case TipoBoton.Aceptar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnAceptarEstandar24;
                        this.control.Text = "Aceptar";
                        break;
                    case TipoBoton.Cancelar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnCerrarEstandar24;
                        this.control.Text = "Cancelar";
                        break;
                    case TipoBoton.Cerrar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnCerrarEstandar24;
                        this.control.Text = "Cerrar";
                        break;
                    case TipoBoton.Guardar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnGuardarEstandar24;
                        this.control.Text = "Guardar";
                        break;
                    case TipoBoton.Descartar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnDescartarEstandar24;
                        this.control.Text = "Descartar";
                        break;
                    case TipoBoton.Normal:
                    default:
                        this.control.Appearance.Image = null;
                        this.control.Text = this.control.ToString();
                        break;
                }
            }
        }
        [System.ComponentModel.Description("Estilo de botón.")]
        public EstiloBoton Estilo
        {
            get { return this.estilo; }
            set
            {
                this.estilo = value;
                int alto = 23;
                int tamañoImagen = 18;
                switch (this.estilo)
                {
                    case EstiloBoton.Mediano:
                        alto = 26;
                        tamañoImagen = 20;
                        break;
                    case EstiloBoton.Grande:
                        alto = 29;
                        tamañoImagen = 20;
                        break;
                    case EstiloBoton.Extragrande:
                        alto = 33;
                        tamañoImagen = 24;
                        break;
                    case EstiloBoton.Pequeño:
                    default:
                        break;
                }
                this.control.ImageSize = new System.Drawing.Size(tamañoImagen, tamañoImagen);
                this.control.Size = new System.Drawing.Size(98, alto);
            }
        }
        internal OrbitaUltraButton Control
        {
            get { return this.control; }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetTipo()
        {
            this.Tipo = TipoBoton.Normal;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstilo()
        {
            this.Estilo = EstiloBoton.Pequeño;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTipo()
        {
            return (this.Tipo != TipoBoton.Normal);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != EstiloBoton.Pequeño);
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>El nombre de tipo completo del objeto.</returns>
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}