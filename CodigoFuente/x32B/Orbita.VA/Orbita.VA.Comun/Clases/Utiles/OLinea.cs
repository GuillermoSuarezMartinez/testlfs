//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : jbelenguer
// Created          : 02-05-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Orbita.VA.Comun
{
    public class OLinea
    {
        #region Atributos
        private PointF punto1;
        private PointF punto2;
        #endregion

        #region Propiedades
        public PointF Punto1
        {
            get { return punto1; }
        }
        public PointF Punto2
        {
            get { return punto2; }
        }
        #endregion

        #region Constructores
        public OLinea()
        {
            punto1 = new PointF();
            punto2 = new PointF();
        }
        public OLinea(PointF p1, PointF p2)
        {
            punto1 = p1;
            punto2 = p2;
        }
        public OLinea(float x1, float y1, float x2, float y2)
        {
            punto1 = new PointF(x1, y1);
            punto2 = new PointF(x2, y2);
        }
        #endregion

        #region Métodos públicos
        
        
        #endregion
    }
}
