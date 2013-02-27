//***********************************************************************
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
using System.ComponentModel;
namespace Orbita.Controles.Comunes
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
        Orbita.Controles.Shared.TipoBoton tipo;
        EstiloBoton estilo;
        #endregion

        #region Constructor
        public OUltraButton(object control)
            : base()
        {
            this.control = (OrbitaUltraButton)control;
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("")]
        public Orbita.Controles.Shared.TipoBoton Tipo
        {
            get { return this.tipo; }
            set
            {
                this.tipo = value;
                //switch (this.tipo)
                //{
                //    case Orbita.Controles.Shared.TipoBoton.Aceptar:
                //    case Orbita.Controles.Shared.TipoBoton.Cancelar:
                //    case Orbita.Controles.Shared.TipoBoton.Cerrar:
                //    case Orbita.Controles.Shared.TipoBoton.Guardar:
                //    case Orbita.Controles.Shared.TipoBoton.Descartar:
                //        int altoAncho = 18;
                //        if (this.estilo != EstiloBoton.Pequeño)
                //        {
                //            altoAncho = 20;
                //        }
                //        this.control.ImageSize = new System.Drawing.Size(altoAncho, altoAncho);
                //        break;
                //    case Orbita.Controles.Shared.TipoBoton.Normal:
                //    default:
                //        this.control.ImageSize = System.Drawing.Size.Empty;
                //        break;
                //}
                switch (this.tipo)
                {
                    case Orbita.Controles.Shared.TipoBoton.Aceptar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnAceptarEstandar24;
                        this.control.Text = "Aceptar";
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Cancelar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnCerrarEstandar24;
                        this.control.Text = "Cancelar";
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Cerrar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnCerrarEstandar24;
                        this.control.Text = "Cerrar";
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Guardar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnGuardarEstandar24;
                        this.control.Text = "Guardar";
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Descartar:
                        this.control.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnDescartarEstandar24;
                        this.control.Text = "Descartar";
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Normal:
                    default:
                        this.control.Appearance.Image = null;
                        this.control.Text = this.control.ToString();
                        break;
                }
            }
        }
        [System.ComponentModel.Description("")]
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
                        alto = 23;
                        tamañoImagen = 18;
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
        protected bool ShouldSerializeTipo()
        {
            return (this.Tipo != Orbita.Controles.Shared.TipoBoton.Normal);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != EstiloBoton.Pequeño);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetTipo()
        {
            this.Tipo = Orbita.Controles.Shared.TipoBoton.Normal;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstilo()
        {
            this.Estilo = EstiloBoton.Pequeño;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Determina el número de propiedades modificadas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}