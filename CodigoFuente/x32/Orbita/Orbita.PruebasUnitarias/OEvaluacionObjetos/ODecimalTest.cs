using Orbita.VA.Comun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Orbita.Utiles;

namespace Orbita.VA.PruebasUnitarias
{
    /// <summary>
    ///Se trata de una clase de prueba para ODecimalTest y se pretende que
    ///contenga todas las pruebas unitarias ODecimalTest.
    ///</summary>
    [TestClass()]
    public class ODecimalTest
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

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            OSistemaManager.Constructor(new OSistema(@"C:\PROYECTOS\OrbitaSoftware\OrbitaAplicacionDemo\Codigo Fuente\x32\Bin\ConfiguracionOrbitaVA.xml"), null, false);
            OVALogsManager.Constructor(null, null);
            OVALogsManager.Inicializar();
        }
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            OVALogsManager.Finalizar();
            OVALogsManager.Destructor();
        }
        //
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
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "ODecimal_Double",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void ODecimal_Test_Decimal()
        {
            this.ODecimal_Test();
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "ODecimal_String",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void ODecimal_Test_String()
        {
            this.ODecimal_Test();
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "ODecimal_Int",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void ODecimal_Test_Entero()
        {
            this.ODecimal_Test();
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        public void ODecimal_Test()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            double valorExpected = (double)TestContext.DataRow["valorExpected"];
            string codigo = (string)TestContext.DataRow["codigo"];
            double min = (double)TestContext.DataRow["min"];
            double max = (double)TestContext.DataRow["max"];
            double defecto = (double)TestContext.DataRow["defecto"];
            string excepcion = TestContext.DataRow["excepcion"].ToString();
            EnumEstadoDecimalRobusto enumEstado = new EnumEstadoDecimalRobusto();
            EnumEstadoRobusto estadoExpected = enumEstado.Parse<EnumEstadoRobusto>(TestContext.DataRow["estadoExpected"].ToString());

            double valor;
            EnumEstadoRobusto estadoActual;

            try
            {
                estadoActual = ODecimal.Validar(valorActual, codigo, min, max, defecto, false);
                Assert.AreEqual(estadoExpected, estadoActual);

                valor = ODecimal.Validar(valorActual, min, max, defecto);
                Assert.AreEqual(valorExpected, valor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            try
            {
                estadoActual = ODecimal.Validar(valorActual, codigo, min, max, defecto, true);
                Assert.AreEqual(estadoExpected, estadoActual);
            }
            catch (Exception e)
            {
                Assert.AreEqual(excepcion, e.GetType().Name);
            }
        }
    }
}
