//***********************************************************************
// Assembly         : Orbita.PruebasUnitarias
// Author           : aibañez
// Created          : 13-02-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Orbita.Utiles;

namespace Orbita.PruebasUnitarias
{
    /// <summary>
    ///Se trata de una clase de prueba para OBoolTest y se pretende que
    ///contenga todas las pruebas unitarias OBoolTest.
    ///</summary>
    [TestClass()]
    public class OBoolTest
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
            "OBool_Bool", 
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OBool_Test_Bool()
        {
            this.OBool_Test();
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient", 
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita", 
            "OBool_String", 
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OBool_Test_String()
        {
            this.OBool_Test();
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient", 
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita", 
            "OBool_Int", 
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OBool_Test_Int()
        {
            this.OBool_Test();
        }

        /// <summary>
        ///Una prueba de Validar
        ///</summary>
        [DataSource("System.Data.SqlClient", 
            "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita", 
            "OBool_Double", 
            DataAccessMethod.Sequential),
        TestMethod()]
        public void OBool_Test_Decimal()
        {
            this.OBool_Test();
        }


        /// <summary>
        /// Prueba
        /// </summary>
        public void OBool_Test()
        {
            object valorActual = TestContext.DataRow["valorActual"];
            bool valorExpected = (bool)TestContext.DataRow["valorExpected"];
            string codigo = (string)TestContext.DataRow["codigo"];
            bool defecto = (bool)TestContext.DataRow["defecto"];
            string excepcion = TestContext.DataRow["excepcion"].ToString();
            EnumEstadoBoolRobusto enumEstado = new EnumEstadoBoolRobusto();
            EnumEstadoRobusto estadoExpected = enumEstado.Parse<EnumEstadoRobusto>(TestContext.DataRow["estadoExpected"].ToString());

            bool valor;
            EnumEstadoRobusto estadoActual;

            try
            {
                estadoActual = OBooleano.Validar(valorActual, codigo, defecto, false);
                Assert.AreEqual(estadoExpected, estadoActual);

                valor = OBooleano.Validar(valorActual, defecto);
                Assert.AreEqual(valorExpected, valor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            try
            {
                estadoActual = OBooleano.Validar(valorActual, codigo, defecto, true);
                Assert.AreEqual(estadoExpected, estadoActual);
            }
            catch (Exception e)
            {
                Assert.AreEqual(excepcion, e.GetType().Name);
            }
        }
    }
}
