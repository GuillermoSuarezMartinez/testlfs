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
using Emgu.CV;
using Orbita.VA.Comun;
using System.Drawing;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Orbita.Utiles;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase que implementa la detección y medición de edges en la region determinada de una imagen
    /// </summary>
    public class OrbitaCaliper
    {
        #region Atributos
        /// <summary>
        /// Imagen de entrada
        /// </summary>
        private OImagenOpenCVMonocromo<byte> inputSource;
        /// <summary>
        /// Listado de resultados
        /// </summary>
        private List<OEdgeResult> edges;
        /// <summary>
        /// Umbral de detección
        /// </summary>
        private double threshold;
        /// <summary>
        /// Kernel de convolución (filtrado)
        /// </summary>
        private ConvolutionKernelF kernel;
        /// <summary>
        /// Polaridad del primer edge (o del single edge)
        /// </summary>
        private PolaridadEdges tipo1;
        /// <summary>
        /// Polaridad del segundo edge (para pares de edges)
        /// </summary>
        private PolaridadEdges tipo2;
        /// <summary>
        /// Listado de métodos de puntuación del OrbitaCaliper
        /// </summary>
        private List<OMetodoPuntuacion> metodos;
        /// <summary>
        /// Máximo de resultados devueltos (calcula siempre todos, es el máximo que devuelve)
        /// </summary>
        private int MaxResultados;
        /// <summary>
        /// Matriz de transformación inversa (para devolver a las coordenadas originales)
        /// </summary>
        private Matrix<float> inverseMatrix;
        /// <summary>
        /// Area de interés
        /// </summary>
        private OImagenOpenCVMonocromo<byte> proyeccion;
        /// <summary>
        /// Proyección rectangular del AOI
        /// </summary>
        private OImagenOpenCVMonocromo<float> contrastes;
        /// <summary>
        /// Datos de contraste filtrados (datos a procesar)
        /// </summary>
        private OImagenOpenCVMonocromo<float> contrastesFiltrados;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el listado de resultados
        /// </summary>
        public List<OEdgeResult> EdgeResults
        {
            get { return edges; }
        }
        /// <summary>
        /// Obtiene si el OrbitaCaliper está configurado para encontrar pares de edges
        /// </summary>
        public bool BuscaPares
        {
            get { return tipo2 != PolaridadEdges.Ninguno; }
        }
        /// <summary>
        /// Obtiene la cantidad de puntos del caliper
        /// </summary>
        public int NumeroDatos
        {
            get { return contrastesFiltrados.Width; }
        }
        /// <summary>
        /// Obtiene los puntos del OrbitaCaliper
        /// </summary>
        public float[, ,] DatosFiltrados
        {
            get { return ((Image<Gray, float>)contrastesFiltrados.Image).Data; }
        }
        /// <summary>
        /// Obtiene los puntos de la proyección
        /// </summary>
        public float[, ,] DatosContraste
        {
            get { return ((Image<Gray, float>)contrastes.Image).Data; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de OrbitaCaliper con SingleEdge. Por defecto añade el método de puntuación por contraste
        /// </summary>
        /// <param name="polaridad">Polaridad de los edges a buscar</param>
        /// <param name="threshold">Umbral de contraste para la detección de un edge</param>
        /// <param name="kernel">Tamaño del filtro</param>
        /// <param name="maxResultados">Máximo de resultados a devolver</param>
        public OrbitaCaliper(PolaridadEdges polaridad, FilterSize kernel, int maxResultados)
        {
            if (threshold < 0)
            {
                throw new ArgumentException("El umbral debe estar en el rango [0-255]", "threshold");
            }
            int kernelSize = (int)kernel;

            //Generamos el kernel de convolución
            this.kernel = new ConvolutionKernelF(1, kernelSize * 2 + 1);
            for (int k = 0; k < kernelSize; k++)
            {
                this.kernel[0, k] = -1;
                this.kernel[0, kernelSize * 2 - k] = +1;
            }
            this.kernel.Center = new Point(kernelSize, 0);

            this.tipo1 = polaridad;
            this.tipo2 = PolaridadEdges.Ninguno;
            this.MaxResultados = maxResultados;

            edges = new List<OEdgeResult>();
            metodos = new List<OMetodoPuntuacion>();

            //Añadimos el método de puntuación por defecto
            AgregarContraste();
        }
        /// <summary>
        /// Constructor de OrbitaCaliper con PairEdge. Por defecto añade el método de puntuación por distancia entre edges
        /// </summary>
        /// <param name="polaridad1">Polaridad del primer edge de cada par</param>
        /// <param name="polaridad2">Polaridad del segundo edge de cada par</param>
        /// <param name="threshold">Umbral para considerar un edge</param>
        /// <param name="distance">Distancia esperada entre el par de edges</param>
        /// <param name="kernel">Tamaño del filtro</param>
        /// <param name="maxResultados">Máximo de resultados a devolver</param>
        public OrbitaCaliper(PolaridadEdges polaridad1, PolaridadEdges polaridad2, double distance, FilterSize kernel, int maxResultados)
        {
            if (threshold < 0)
            {
                throw new ArgumentException("El umbral debe ser positivo", "threshold");
            }

            int kernelSize = (int)kernel;

            //Generamos el kernel de convolución
            this.kernel = new ConvolutionKernelF(1, kernelSize * 2 + 1);
            for (int k = 0; k < kernelSize; k++)
            {
                this.kernel[0, k] = -1;
                this.kernel[0, kernelSize * 2 - k] = +1;
            }
            this.kernel.Center = new Point(kernelSize, 0);

            this.tipo1 = polaridad1;
            this.tipo2 = polaridad2;
            this.MaxResultados = maxResultados;

            edges = new List<OEdgeResult>();
            metodos = new List<OMetodoPuntuacion>();

            //Añadimos el método de puntuación por defecto
            AgregarDistancia(distance);
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtiene y devuelve un listado de edges en el área de interes de la imagen pasada como parámetro (en formato de 3 puntos)
        /// </summary>
        /// <param name="input">Imagen sobre la que buscar</param>
        /// <param name="origen">Punto de origen del AOI</param>
        /// <param name="extremoX">Extremo en anchura del AOI</param>
        /// <param name="extremoY">Extremo en altura del AOI</param>
        /// <returns>Listado de resultados</returns>
        public List<OEdgeResult> BuscarEdges(OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, double threshold)
        {
            this.threshold = threshold;

            //Comprobación de los argumentos de entrada
            if (origen.X > input.Width || extremoX.X > input.Width || extremoY.X > input.Width || origen.Y > input.Height || extremoX.Y > input.Height || extremoY.Y > input.Height)
            {
                throw new ArgumentException("Alguno de los puntos pasados a la herramienta OrbitaCaliper, se encuentran fuera de la imagen de entrada");
            }
            this.edges.Clear();
            this.inputSource = input;

            //Realizamos la proyección del área del caliper, guardando la matriz de transformación inversa para obtener coordenadas reales
            inverseMatrix = new Matrix<float>(2, 3);
            proyeccion = new OImagenOpenCVMonocromo<byte>();
            proyeccion.Image = input.Proyeccion(origen, extremoX, extremoY, out inverseMatrix).Image;
            inverseMatrix = OHerramientasOpenCV.Invertir(inverseMatrix);

            //Obtenemos una media de valores de contraste en la proyección
            if (proyeccion.Height > 1)
            {
                contrastes = proyeccion.Reducir();
            }
            else
            {
                contrastes = new OImagenOpenCVMonocromo<float>();
                contrastes.Image = ((Image<Gray, byte>)proyeccion.Image).Convert<Gray, float>();
            }

            //Filtramos la imagen 
            contrastesFiltrados = new OImagenOpenCVMonocromo<float>();
            contrastesFiltrados.Image = ((Image<Gray, float>)contrastes.Image).Convolution(kernel);

            //Método alternativo de filtrado, seleccionar el mejor
            //Image<Gray, float> filteredAlt = new Image<Gray,float>(filteredImage.Size);
            //int HalfSizePixels = (kernel.Width - 1) / 2;

            //for (int i = HalfSizePixels; i < projectionImage.Width - HalfSizePixels; i++)
            //{
            //    float acum = 0;
            //    for (int k = 0; k < HalfSizePixels; k++)
            //    {
            //        acum += projectionImage.Data[0, i - HalfSizePixels + k, 0]  * kernel.Data[0, k];
            //        acum += projectionImage.Data[0, i + HalfSizePixels - k, 0]  * kernel.Data[0,HalfSizePixels * 2 - k];
            //    }
            //    filteredAlt.Data[0, i, 0] = acum;
            //}

            //Buscamos máximos y mínimos (edges) en la imagen filtrada
            algoritmoBusquedaEdges();

            //Ordenamos los edges por su puntuación
            edges.Sort(delegate(OEdgeResult e1, OEdgeResult e2) { return e2.ResultScore.CompareTo(e1.ResultScore); });

            //Devolvemos mejores edges según la variable MaxResultados (en lugar de encontrar todos y luego devolver los mejores, se debería optimizar la búsqueda para que sólo encuentre los n mejores)
            if (this.MaxResultados >= edges.Count)
            {
                return edges;
            }
            else
            {
                return edges.GetRange(0, this.MaxResultados);
            }
        }
        /// <summary>
        /// Agrega un método de puntuación por contraste (método individual)
        /// </summary>
        /// <returns>True si se añadió correctamente</returns>
        public bool AgregarContraste()
        {
            OMetodoPuntuacion metodo = new ContrastMethod();
            return AgregarMetodoPuntuacion(metodo);
        }
        /// <summary>
        /// Agrega un método de puntuación por distancia (método de pares)
        /// </summary>
        /// <param name="distance">Ancho esperado entre los edges</param>
        /// <returns>True si se añadió correctamente</returns>
        public bool AgregarDistancia(double distance)
        {
            OMetodoPuntuacion metodo = new SizeDiffNormMethod(distance);
            return AgregarMetodoPuntuacion(metodo);
        }
        /// <summary>
        /// Pinta los edges encontrados por el caliper
        /// </summary>
        /// <param name="color">Color para pintar los edges</param>
        /// <param name="grosor">Grosor del marcado de edges</param>
        /// <param name="todos">Indica si se debe buscar sobre todos los edges, o solo sobre los resultados devueltos</param>
        /// <returns>Imagen del caliper con los edges marcados</returns>
        public OImagenOpenCVColor<byte> PintarEdges(Color color, int grosor, bool todos = false)
        {
            OImagenOpenCVColor<byte> res = new OImagenOpenCVColor<byte>();
            res.Image = new Image<Bgr, byte>(this.proyeccion.Width, proyeccion.Height);
            res.Image.ConvertFrom<Gray, byte>(this.proyeccion.Image);

            int resultsToPaint = MaxResultados > edges.Count ? this.edges.Count : MaxResultados;

            foreach (OEdgeResult edge in (todos ? this.edges : this.edges.GetRange(0, resultsToPaint)))
            {
                PointF ptoEdgeI = new PointF(edge.Edge1.X, 0);
                PointF ptoEdgeF = new PointF(edge.Edge1.X, proyeccion.Height);

                LineSegment2DF edgeLine = new LineSegment2DF(ptoEdgeI, ptoEdgeF);
                res.Image.Draw(edgeLine, new Bgr(color), grosor);

                if (edge.IsPair)
                {
                    ptoEdgeI = new PointF(edge.Edge2.X, 0);
                    ptoEdgeF = new PointF(edge.Edge2.X, proyeccion.Height);

                    edgeLine = new LineSegment2DF(ptoEdgeI, ptoEdgeF);
                    res.Image.Draw(edgeLine, new Bgr(color), grosor);
                }
            }

            return res;
        }
        /// <summary>
        /// Limpia la lista de métodos de puntuación
        /// </summary>
        public void EliminarMetodosPuntuacion()
        {
            this.metodos.Clear();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Encuentra los máximos y mínimos de una función discretizada en un array
        /// </summary>
        /// <param name="contrastesFiltrados">Datos de la imagen filtrada</param>
        private void algoritmoBusquedaEdges()
        {
            List<OEdge> listaCandidatos = new List<OEdge>();

            //Cálculo del centro del caliper
            float centerY = (this.proyeccion.Height > 1) ? this.proyeccion.Height / 2 : 1;
            float centerX = (this.proyeccion.Width > 1) ? this.proyeccion.Width / 2 : 1;

            //Variables que almacenan valores 
            float siguienteContraste;
            float actualContraste;

            //Flags para búsqueda de máximos o mínimos
            bool buscandoPositivos = this.DatosFiltrados[0, kernel.Width, 0] > 0;
            bool buscandoNegativos = this.DatosFiltrados[0, kernel.Width, 0] < 0;

            //Flags para conocer el estado de la función
            bool empiezoCrecer = false;
            bool empiezoDecrecer = false;

            //Flags que indican si se ha encontrado un pico
            bool max = false;
            bool min = false;

            //Apuntador a la posición inicial del ciclo (positivo o negativo)
            int ini = kernel.Width;

            //Recorrido de la función convolución
            for (int i = kernel.Width; i < contrastesFiltrados.Width - kernel.Width; i++)
            {
                //Actualización de valores
                actualContraste = this.DatosFiltrados[0, i, 0];
                siguienteContraste = this.DatosFiltrados[0, i + 1, 0];

                //Miro la tendencia futura de la función
                empiezoDecrecer = !empiezoDecrecer && siguienteContraste < actualContraste;
                empiezoCrecer = !empiezoCrecer && siguienteContraste > actualContraste;

                //Compruebo si he encontrado un máximo
                min = min || (buscandoNegativos && empiezoCrecer);
                max = max || (buscandoPositivos && empiezoDecrecer);

                //Si tenemos un pico y cambiamos el sentido de crecimiento o el signo, tenemos un edge
                if ((max && (empiezoCrecer || siguienteContraste <= 0)) || min && (empiezoDecrecer || siguienteContraste >= 0))
                {
                    //Cálculo de la posición del edge (a nivel subpíxel) y su contraste en la imagen
                    float xPos = Centroide(ini, i, this.DatosFiltrados);

                    PointF puntoEdge = new PointF(xPos, centerY);
                    puntoEdge = OHerramientasOpenCV.Proyeccion(puntoEdge, this.inverseMatrix);

                    double contraste = InterpolacionLineal(xPos, this.DatosFiltrados);

                    double div = this.kernel.Width / 2.0;
                    double nuevoCont = contraste / Math.Max(div, 1);

                    //Verifico que el contraste supera el umbral
                    if (Math.Abs(nuevoCont) > this.threshold)
                    {
                        //Genero el candidato
                        OEdge candidato = new OEdge(listaCandidatos.Count, xPos - centerX, puntoEdge, contraste);

                        if (this.BuscaPares)
                        {
                            int num = EvaluarCandidatoPares(candidato, listaCandidatos);
                        }
                        else
                        {
                            bool res = EvaluarCandidatoSingle(candidato);
                        }
                        //Añadimos el edge a los candidatos posibles
                        listaCandidatos.Add(candidato);
                    }

                    //Iniciamos un nuevo ciclo
                    ini = i;

                    //Si además cambiamos de signo, iniciamos ciclo en el primer elemento del nuevo signo
                    if ((buscandoNegativos && siguienteContraste > 0) || (buscandoPositivos && siguienteContraste < 0))
                    {
                        ini++;
                    }

                    //Reiniciamos los flags de mínimo y máximo encontrados
                    min = false;
                    max = false;
                }
                else if (actualContraste == 0)
                {
                    ini++;
                }

                //Actualizamos nuestra próxima búsqueda
                buscandoPositivos = (siguienteContraste > 0) ? true : false;
                buscandoNegativos = (siguienteContraste < 0) ? true : false;
            }
        }
        /// <summary>
        /// Decide si un edge candidato es válido y su puntuación, con cada uno de los edges del array candidatos. En caso afirmativo lo añade.
        /// </summary>
        /// <param name="candidato">Edge candidato</param>
        /// <param name="listaCandidatos">Lista de candidatos previos</param>
        /// <returns>Número de resultados añadidos</returns>
        private int EvaluarCandidatoPares(OEdge candidato, List<OEdge> listaCandidatos)
        {
            int numEdges = 0;

            //Compruebo si el candidato es viable como segundo edge según la polaridad
            if (tipo2 == PolaridadEdges.Cualquiera || (candidato.NegroBlanco && tipo2 == PolaridadEdges.NegroBlanco) || (!candidato.NegroBlanco && tipo2 == PolaridadEdges.BlancoNegro))
            {
                //Emparejamiento del edge con el resto de candidatos viables por polaridad
                for (int j = listaCandidatos.Count - 1; j >= 0; j--)
                {
                    OEdge comparador = listaCandidatos[j];
                    if (tipo1 == PolaridadEdges.Cualquiera || (comparador.NegroBlanco && tipo1 == PolaridadEdges.NegroBlanco) || (!comparador.NegroBlanco && tipo1 == PolaridadEdges.BlancoNegro))
                    {
                        //Creamos el resultado
                        OEdgeResult par = new OEdgeResult(candidato);
                        //Calculamos la puntuación con el edge viable actual
                        par.Edge2 = new OEdge(comparador);
                        double puntuacion = Puntuar(par);

                        //Si la puntuación es mayor que 0, anotamos el resultado
                        if (puntuacion > 0.0)
                        {
                            edges.Add(par);
                            numEdges++;
                        }
                        else
                        {
                            //Paramos con el primer edge que puntúe 0 
                            break;
                        }
                    }
                }
            }
            return numEdges;
        }
        /// <summary>
        /// Decide si un edge candidato es válido y su puntuación. En caso afirmativo lo añade
        /// </summary>
        /// <param name="candidato">Edge candidato</param>
        /// <returns>Cierto si el edge se ha añadido</returns>
        private bool EvaluarCandidatoSingle(OEdge candidato)
        {
            if (tipo1 == PolaridadEdges.Cualquiera || (candidato.NegroBlanco && tipo2 == PolaridadEdges.NegroBlanco) || (!candidato.NegroBlanco && tipo2 == PolaridadEdges.BlancoNegro))
            {
                //Creamos el resultado
                OEdgeResult resultado = new OEdgeResult(candidato);

                //Calculamos la puntuación con el edge viable actual
                double puntuacion = Puntuar(resultado);

                //Si la puntuación es mayor que 0, anotamos el resultado
                if (puntuacion > 0)
                {
                    edges.Add(resultado);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Puntua un candidato a edge en función de los parámetros de puntuación activos del algoritmo
        /// </summary>
        /// <param name="resultado">Resultado a puntuar</param>
        /// <returns>Puntuación según todos los métodos activos</returns>
        private double Puntuar(OEdgeResult resultado)
        {
            double prodScore = 1;
            int numMetodos = 0;

            foreach (OMetodoPuntuacion metodo in metodos)
            {
                //Comprobamos que se pueda ejecutar el método de puntuación
                if (!metodo.OnlyPairMethod || resultado.IsPair)
                {
                    prodScore *= metodo.Puntuar(resultado);

                    if (prodScore == 0)
                    {
                        resultado.ResultScore = 0;
                        return 0;
                    }
                    numMetodos++;
                }
            }
            if (numMetodos > 1)
            {
                resultado.ResultScore = Math.Pow(prodScore, -numMetodos);
            }
            else
            {
                resultado.ResultScore = numMetodos * prodScore;
            }
            return resultado.ResultScore;
        }
        /// <summary>
        /// Obtiene el centroide (promedio) en x, en un intervalo dado
        /// </summary>
        /// <param name="ini">Inicio del intervalo</param>
        /// <param name="fin">Final del intervalo</param>
        /// <returns>Punto en X donde se encuentra el centroide</returns>
        private float Centroide(int ini, int fin, float[, ,] array)
        {
            float Xc = ini;
            float C0 = 0;
            int n = fin - ini;

            //Encontramos el máximo
            for (int i = ini; i <= fin; i++)
            {
                float valor = array[0, i, 0];
                if (Math.Abs(valor) > Math.Abs(C0))
                {
                    Xc = i;
                    C0 = valor;
                }
                else if (Math.Abs(valor) == Math.Abs(C0))
                {
                    Xc = (Xc + i) / 2;
                }
            }

            if (fin - ini + 1 < 3)
            {
                return Xc;
            }
            else
            {
                //Obtenemos sus valores vecinos
                int ant = (int)Math.Floor(Xc);
                ant = (ant == 0) ? ant : ant - 1;
                int sig = (int)Math.Ceiling(Xc);
                sig = (sig == array.GetUpperBound(1)) ? sig : sig + 1;

                float C_1 = array[0, ant, 0];
                float C1 = array[0, sig, 0];

                //Saturación de los valores vecinos para que no puedan ser superiores al máximo encontrado. Esta fórmula funciona
                //solamente si el valor C0 es máximo dentro del rango de búsqueda. Existen casos al inicio y final del array donde esto
                //no tiene por qué ser cierto
                if (Math.Abs(C_1) > C0)
                {
                    C_1 = C0;
                }
                if (Math.Abs(C1) > C0)
                {
                    C1 = C0;
                }

                //Calculamos el centroide
                float denominador = C1 + C_1 - 2 * C0;
                if (denominador == 0)
                {
                    return Xc;
                }
                else
                {
                    return Xc - ((0.5f * (C1 - C_1)) / denominador);
                }
            }
        }
        /// <summary>
        /// Devuelve el valor interpolado para xPos en el array
        /// </summary>
        /// <param name="xPos">Posición a interpolar</param>
        /// <param name="array">Función</param>
        /// <returns>Valor interpolado en Y</returns>
        private double InterpolacionLineal(float xPos, float[, ,] array)
        {
            int x0 = (int)Math.Floor(xPos);
            int x1 = (int)Math.Ceiling(xPos);

            double y0 = array[0, x0, 0];
            double y1 = array[0, x1, 0];

            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return y0 + (xPos - x0) * (y1 - y0) / (x1 - x0);

        }
        /// <summary>
        /// Intenta añadir un nuevo método de puntuación a la lista
        /// </summary>
        /// <param name="met">Método de puntuación a añadir</param>
        /// <returns>Cierto si se pudo añadir</returns>
        private bool AgregarMetodoPuntuacion(OMetodoPuntuacion met)
        {
            metodos.Add(met);
            return true;
        }
        #endregion
    }

    /// <summary>
    /// Tipos de filtro para detección de edges disponibles. Los filtros son simétricos del tipo -1,0,+1
    /// </summary>
    public enum FilterSize
    {
        /// <summary>
        /// Filtro de tamaño 3: -1,0,+1
        /// </summary>
        filter3 = 1,
        /// <summary>
        /// Filtro de tamaño 5: -1,-1,0,+1,+1
        /// </summary>
        filter5 = 2,
        /// <summary>
        /// Filtro de tamaño 7: -1,-1,-1,0,+1,+1,+1
        /// </summary>
        filter7 = 3,
        /// <summary>
        /// Filtro de tamaño 9: -1,-1,-1,-1,0,+1,+1,+1,+1
        /// </summary>
        filter9 = 4,
        /// <summary>
        /// Filtro de tamaño 11: -1,-1,-1,-1,-1,0,+1,+1,+1,+1,+1
        /// </summary>
        filter11 = 5,
        /// <summary>
        /// Filtro de tamaño 13: -1,-1,-1,-1,-1,-1,0,+1,+1,+1,+1,+1,+1
        /// </summary>
        filter13 = 6,
        /// <summary>
        /// Filtro de tamaño 15: -1,-1,-1,-1,-1,-1,-1,0,+1,+1,+1,+1,+1,+1,+1
        /// </summary>
        filter15 = 7,
        /// <summary>
        /// Filtro de tamaño 17: -1,-1,-1,-1,-1,-1,-1,-1,0,+1,+1,+1,+1,+1,+1,+1,+1
        /// </summary>
        filter17 = 8,
        /// <summary>
        /// Filtro de tamaño 19: -1,-1,-1,-1,-1,-1,-1,-1,-1,0,+1,+1,+1,+1,+1,+1,+1,+1,+1
        /// </summary>
        filter19 = 9,
        /// <summary>
        /// Filtro de tamaño 21: -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,+1,+1,+1,+1,+1,+1,+1,+1,+1,+1
        /// </summary>
        filter21 = 10
    }
}