//***********************************************************************
// Assembly         : Orbita.Controles.Gantt
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Gantt
{
    public class OColumnHeaderCollection
    {
        #region Atributos públicos
        /// <summary>
        /// Descripción.
        /// </summary>
        OColumnHeader descripcion;
        /// <summary>
        /// Comentarios.
        /// </summary>
        OColumnHeader comentarios;
        /// <summary>
        /// Inicio.
        /// </summary>
        OColumnHeader inicio;
        /// <summary>
        /// Fin.
        /// </summary>
        OColumnHeader fin;
        /// <summary>
        /// Completado.
        /// </summary>
        OColumnHeader completado;
        /// <summary>
        /// Duración.
        /// </summary>
        OColumnHeader duracion;
        /// <summary>
        /// Limite.
        /// </summary>
        OColumnHeader limite;
        /// <summary>
        /// Info1.
        /// </summary>
        OColumnHeader info1;
        /// <summary>
        /// Info2.
        /// </summary>
        OColumnHeader info2;
        /// <summary>
        /// Info3.
        /// </summary>
        OColumnHeader info3;
        /// <summary>
        /// Info4.
        /// </summary>
        OColumnHeader info4;
        /// <summary>
        /// Info5.
        /// </summary>
        OColumnHeader info5;
        /// <summary>
        /// Info6.
        /// </summary>
        OColumnHeader info6;
        /// <summary>
        /// Info7.
        /// </summary>
        OColumnHeader info7;
        /// <summary>
        /// Info8.
        /// </summary>
        OColumnHeader info8;
        /// <summary>
        /// Info9.
        /// </summary>
        OColumnHeader info9;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Gantt.OrbitaColumnHeaderCollection.
        /// </summary>
        public OColumnHeaderCollection()
        {
            descripcion = null;
            comentarios = null;
            inicio = null;
            fin = null;
            completado = null;
            duracion = null;
            limite = null;
            info1 = null;
            info2 = null;
            info3 = null;
            info4 = null;
            info5 = null;
            info6 = null;
            info7 = null;
            info8 = null;
            info9 = null;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Descripción.
        /// </summary>
        public OColumnHeader Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        /// <summary>
        /// Comentarios.
        /// </summary>
        public OColumnHeader Comentarios
        {
            get { return this.comentarios; }
            set { this.comentarios = value; }
        }
        /// <summary>
        /// Inicio.
        /// </summary>
        public OColumnHeader Inicio
        {
            get { return this.inicio; }
            set { this.inicio = value; }
        }
        /// <summary>
        /// Fin.
        /// </summary>
        public OColumnHeader Fin
        {
            get { return this.fin; }
            set { this.fin = value; }
        }
        /// <summary>
        /// Completado.
        /// </summary>
        public OColumnHeader Completado
        {
            get { return this.completado; }
            set { this.completado = value; }
        }
        /// <summary>
        /// Duracion.
        /// </summary>
        public OColumnHeader Duracion
        {
            get { return this.duracion; }
            set { this.duracion = value; }
        }
        /// <summary>
        /// Limite.
        /// </summary>
        public OColumnHeader Limite
        {
            get { return this.limite; }
            set { this.limite = value; }
        }
        /// <summary>
        /// Info1.
        /// </summary>
        public OColumnHeader Info1
        {
            get { return this.info1; }
            set { this.info1 = value; }
        }
        /// <summary>
        /// Info2.
        /// </summary>
        public OColumnHeader Info2
        {
            get { return this.info2; }
            set { this.info2 = value; }
        }
        /// <summary>
        /// Info3.
        /// </summary>
        public OColumnHeader Info3
        {
            get { return this.info3; }
            set { this.info3 = value; }
        }
        /// <summary>
        /// Info4.
        /// </summary>
        public OColumnHeader Info4
        {
            get { return this.info4; }
            set { this.info4 = value; }
        }
        /// <summary>
        /// Info5.
        /// </summary>
        public OColumnHeader Info5
        {
            get { return this.info5; }
            set { this.info5 = value; }
        }
        /// <summary>
        /// Info6.
        /// </summary>
        public OColumnHeader Info6
        {
            get { return this.info6; }
            set { this.info6 = value; }
        }
        /// <summary>
        /// Info7.
        /// </summary>
        public OColumnHeader Info7
        {
            get { return this.info7; }
            set { this.info7 = value; }
        }
        /// <summary>
        /// Info8.
        /// </summary>
        public OColumnHeader Info8
        {
            get { return this.info8; }
            set { this.info8 = value; }
        }
        /// <summary>
        /// Info9.
        /// </summary>
        public OColumnHeader Info9
        {
            get { return this.info9; }
            set { this.info9 = value; }
        }
        #endregion
    }
}