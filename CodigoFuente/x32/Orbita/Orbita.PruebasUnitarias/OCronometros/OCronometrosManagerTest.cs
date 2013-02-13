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
using System.Threading;
using Orbita.Utiles;

namespace Orbita.PruebasUnitarias
{
    /// <summary>
    ///Se trata de una clase de prueba para OCronometrosManagerTest y se pretende que
    ///contenga todas las pruebas unitarias OCronometrosManagerTest.
    ///</summary>
    [TestClass()]
    public class OCronometrosManagerTest
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
            OCronometrosManager.Constructor();
            OCronometrosManager.Inicializar();
        }
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            OVALogsManager.Finalizar();
            OVALogsManager.Destructor();
            OCronometrosManager.Finalizar();
            OCronometrosManager.Destructor();
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
        ///Una prueba de Start
        ///</summary>
        [DataSource("System.Data.SqlClient", "Data Source=01P0039\\SQLEXPRESS;Initial Catalog=PruebasUnitariasOrbitaVA;Persist Security Info=True;User ID=desarrollo;Password=orbita", "OCronometros", DataAccessMethod.Random),
        TestMethod()]
        public void OCronometros_Test()
        {
            string codigo = (string)TestContext.DataRow["codigo"];
            string nombre = (string)TestContext.DataRow["nombre"];
            string descripcion = (string)TestContext.DataRow["descripcion"];
            bool startPaused = (bool)TestContext.DataRow["startPaused"];
            int espera1 = (int)TestContext.DataRow["espera1"];
            int espera2 = (int)TestContext.DataRow["espera2"];
            int espera3 = (int)TestContext.DataRow["espera3"];
            int elapsed = (int)TestContext.DataRow["elapsed"];
            int elapsedError = (int)TestContext.DataRow["elapsedError"];
            int iteraciones = (int)TestContext.DataRow["iteraciones"];
            DateTime momentoEjecucion = DateTime.Now;

            Assert.IsFalse(OCronometrosManager.ExisteCronometro(codigo));
            OCronometrosManager.NuevoCronometro(codigo, nombre, descripcion);
            Assert.IsTrue(OCronometrosManager.ExisteCronometro(codigo));
            for (int i = 0; i < iteraciones; i++)
			{
                if (startPaused)
                {
                    OCronometrosManager.StartPaused(codigo);
                }
                else
                {
                    OCronometrosManager.Start(codigo);
                }
                momentoEjecucion = DateTime.Now;
                Assert.AreNotEqual(OCronometrosManager.Ejecutando(codigo), startPaused);

                Thread.Sleep(espera1);

                OCronometrosManager.Pause(codigo);

                Thread.Sleep(espera2);

                OCronometrosManager.Resume(codigo);
                Assert.IsTrue(OCronometrosManager.Ejecutando(codigo));

                Thread.Sleep(espera3);

                OCronometrosManager.Stop(codigo);
                Assert.IsFalse(OCronometrosManager.Ejecutando(codigo));

                bool okUltima = OIntervaloTiempo.InRange(OCronometrosManager.DuracionUltimaEjecucion(codigo), TimeSpan.FromMilliseconds(elapsed - elapsedError), TimeSpan.FromMilliseconds(elapsed + elapsedError));
                Assert.IsTrue(okUltima, "Duración estimada: {0}. Duración real: {1}", elapsed, OCronometrosManager.DuracionUltimaEjecucion(codigo));

                bool okMomentoUltima = OFechaHora.InRange(OCronometrosManager.MomentoUltimaEjecucion(codigo), momentoEjecucion.AddMilliseconds(-elapsedError), momentoEjecucion.AddMilliseconds(elapsedError));
                Assert.IsTrue(okMomentoUltima);
            }

            bool okPromedio = OIntervaloTiempo.InRange(OCronometrosManager.DuracionPromedioEjecucion(codigo), TimeSpan.FromMilliseconds(elapsed - elapsedError), TimeSpan.FromMilliseconds(elapsed + elapsedError));
            Assert.IsTrue(okPromedio);

            bool okTotal = OIntervaloTiempo.InRange(OCronometrosManager.DuracionTotalEjecucion(codigo), TimeSpan.FromMilliseconds(iteraciones * (elapsed - elapsedError)), TimeSpan.FromMilliseconds(iteraciones * (elapsed + elapsedError)));
            Assert.IsTrue(okTotal);

            Assert.AreEqual(OCronometrosManager.ContadorEjecuciones(codigo), iteraciones);

            OCronometro crono = OCronometrosManager.BuscaCronometro(codigo);
            Assert.AreEqual(crono.Nombre, nombre);
            Assert.AreEqual(crono.Descripcion, descripcion);

            OCronometrosManager.EliminaCronometro(codigo);
            Assert.IsFalse(OCronometrosManager.ExisteCronometro(codigo));
        }
    }
}
