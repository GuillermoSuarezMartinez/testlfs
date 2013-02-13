using Orbita.VA.Comun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Orbita.Utiles;

namespace Orbita.VA.PruebasUnitarias
{       
    /// <summary>
    ///Se trata de una clase de prueba para OIntervaloTiempoTest y se pretende que
    ///contenga todas las pruebas unitarias OIntervaloTiempoTest.
    ///</summary>
    [TestClass()]
    public class OIntervaloTiempoTest
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
        /// Timespan
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OIntervaloTiempo_Double",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OIntervaloTiempo_Test_TimeSpan()
        {
            object valorActual = null;

            object aux = TestContext.DataRow["valorActual"];
            if (aux is double)
            {
                valorActual = TimeSpan.FromDays((double)TestContext.DataRow["valorActual"]);
            }

            this.OIntervaloTiempo_Test(valorActual);
        }

        /// <summary>
        /// Double
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OIntervaloTiempo_Double",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OIntervaloTiempo_Test_Double()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            this.OIntervaloTiempo_Test(valorActual);
        }

        /// <summary>
        /// Integer
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OIntervaloTiempo_Int",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OIntervaloTiempo_Test_Int()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            this.OIntervaloTiempo_Test(valorActual);
        }

        /// <summary>
        /// Integer
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OIntervaloTiempo_String",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OIntervaloTiempo_Test_String()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            this.OIntervaloTiempo_Test(valorActual);
        }

        /// <summary>
        /// Timespan
        ///</summary>
        public void OIntervaloTiempo_Test(object valorActual)
        {
            TimeSpan valorExpected = TimeSpan.FromDays((double)TestContext.DataRow["valorExpected"]);
            string codigo = (string)TestContext.DataRow["codigo"];
            TimeSpan min = TimeSpan.FromDays((double)TestContext.DataRow["min"]);
            TimeSpan max = TimeSpan.FromDays((double)TestContext.DataRow["max"]);
            TimeSpan defecto = TimeSpan.FromDays((double)TestContext.DataRow["defecto"]);
            string excepcion = TestContext.DataRow["excepcion"].ToString();
            EnumEstadoIntervaloTiempoRobusto enumEstado = new EnumEstadoIntervaloTiempoRobusto();
            EnumEstadoRobusto estadoExpected = enumEstado.Parse<EnumEstadoRobusto>(TestContext.DataRow["estadoExpected"].ToString());

            TimeSpan valor;
            EnumEstadoRobusto estadoActual;

            try
            {
                estadoActual = OIntervaloTiempo.Validar(valorActual, codigo, min, max, defecto, false);
                Assert.AreEqual(estadoExpected, estadoActual);

                valor = OIntervaloTiempo.Validar(valorActual, min, max, defecto);
                Assert.AreEqual(valorExpected, valor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            try
            {
                estadoActual = OIntervaloTiempo.Validar(valorActual, codigo, min, max, defecto, true);
                Assert.AreEqual(estadoExpected, estadoActual);
            }
            catch (Exception e)
            {
                Assert.AreEqual(excepcion, e.GetType().Name);
            }
        }
    }
}
