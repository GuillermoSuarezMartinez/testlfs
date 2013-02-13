using Orbita.VA.Comun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Orbita.Utiles;

namespace Orbita.VA.PruebasUnitarias
{
    /// <summary>
    ///Se trata de una clase de prueba para OEnumeradoTest y se pretende que
    ///contenga todas las pruebas unitarias OEnumeradoTest.
    ///</summary>
    [TestClass()]
    public class OEnumeradoTest
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
            "OEnumerado_String",
            DataAccessMethod.Sequential),
        TestMethod()]

        public void OEnumerado_Enum()
        {
            object valorActual = null;
            DemoEnum1 enumAux;
            if (!Enum.TryParse<DemoEnum1>(TestContext.DataRow["valorActual"].ToString(), out enumAux))
            {
                valorActual = null;
            }
            else
            {
                valorActual = enumAux;
            }
            ODecimal_Test<DemoEnum1>(valorActual);
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OEnumerado_String",
            DataAccessMethod.Sequential),
        TestMethod()]

        public void OEnumerado_String()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            ODecimal_Test<DemoEnum1>(valorActual);
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OEnumerado_Int",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OEnumerado_Int()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            ODecimal_Test<DemoEnum1>(valorActual);
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient",
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita",
            "OEnumerado_Int",
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OEnumerado_Int2()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            ODecimal_Test<DemoEnum2>(valorActual);
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        public void ODecimal_Test<T>(object valorActual)
        {
            T valorExpected = (T)Enum.Parse(typeof(T), (string)TestContext.DataRow["valorExpected"]);
            string codigo = (string)TestContext.DataRow["codigo"];
            T defecto = (T)Enum.Parse(typeof(T), (string)TestContext.DataRow["defecto"]);
            string excepcion = TestContext.DataRow["excepcion"].ToString();
            EnumEstadoEnumRobusto enumEstado = new EnumEstadoEnumRobusto();
            EnumEstadoRobusto estadoExpected = enumEstado.Parse<EnumEstadoRobusto>(TestContext.DataRow["estadoExpected"].ToString());

            T valor;
            EnumEstadoRobusto estadoActual;

            try
            {
                estadoActual = OEnumerado<T>.Validar(valorActual, codigo, defecto, false);
                Assert.AreEqual(estadoExpected, estadoActual);

                valor = OEnumerado<T>.Validar(valorActual, defecto);
                Assert.AreEqual(valorExpected, valor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            try
            {
                estadoActual = OEnumerado<T>.Validar(valorActual, codigo, defecto, true);
                Assert.AreEqual(estadoExpected, estadoActual);
            }
            catch (Exception e)
            {
                Assert.AreEqual(excepcion, e.GetType().Name);
            }
        }
    }

    internal enum DemoEnum1
    {
        uno = 0,
        dos = 1,
        tres = 2
    }

    internal enum DemoEnum2
    {
        uno,
        dos,
        tres
    }

}
