using Orbita.VA.Comun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Orbita.VA.PruebasUnitarias
{
    /// <summary>
    ///Se trata de una clase de prueba para OPriorityQueueTest y se pretende que
    ///contenga todas las pruebas unitarias OPriorityQueueTest.
    ///</summary>
    [TestClass()]
    public class OPriorityQueueTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private static OPriorityQueue<int, int> OPriorityQueueIntInt;
        private static OPriorityQueue<double, string> OPriorityQueueDoubleString;
        private static OPriorityQueue<string, double> OPriorityQueueStringDouble;

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            OPriorityQueueIntInt = new OPriorityQueue<int, int>();
            OPriorityQueueDoubleString = new OPriorityQueue<double, string>();
            OPriorityQueueStringDouble = new OPriorityQueue<string, double>();
        }
        
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            OPriorityQueueIntInt.Clear();
            OPriorityQueueDoubleString.Clear();
            OPriorityQueueStringDouble.Clear();
        }
        
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        /// Test
        /// </summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OPriorityQueue_Int_Int",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OPriorityQueue_Test_Int_Int()
        {
            OPriorityQueue_Test<int, int>(OPriorityQueueIntInt);
        }

        /// <summary>
        /// Test
        /// </summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OPriorityQueue_Double_String",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OPriorityQueue_Test_Double_String()
        {
            OPriorityQueue_Test<double, string>(OPriorityQueueDoubleString);
        }

        /// <summary>
        /// Test
        /// </summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OPriorityQueue_String_Double",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OPriorityQueue_Test_String_Double()
        {
            OPriorityQueue_Test<string, double>(OPriorityQueueStringDouble);
        }

        public void OPriorityQueue_Test<TValue, TPriority>(OPriorityQueue<TValue, TPriority> cola) where TPriority : IComparable
        {
            TValue valor = (TValue)TestContext.DataRow["valor"];
            TPriority prioridad = (TPriority)TestContext.DataRow["prioridad"];
            int desencolados = (int)TestContext.DataRow["desencolados"];
            TValue primerValor = (TValue)TestContext.DataRow["primerValor"];
            int total = (int)TestContext.DataRow["total"];

            cola.Enqueue(valor, prioridad);
            for (int i = 0; i < desencolados; i++)
            {
                cola.Dequeue();
            }
            TValue ultimoValorReal = cola.Peek();
            Assert.AreEqual(primerValor, ultimoValorReal);

            int totalReal = cola.Count;
            Assert.AreEqual(total, totalReal);
        }
    }
}
