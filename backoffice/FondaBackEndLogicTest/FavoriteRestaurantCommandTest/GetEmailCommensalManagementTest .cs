using NUnit.Framework;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Factory;

namespace FondaBackEndLogicTest
{
    /// <summary>
    /// class GetEmailCommensalManagementTest
    /// Clase que realiza las pruebas unitarias del comando obtener email de un commensal.
    /// </summary>
	[TestFixture]
	public class GetEmailCommensalManagementTest
	{
        private Commensal commensal;
        private ICommand getEmail;
        
        /// <summary>
        /// metodo que instancia e inicializa el objeto y variables respectivamente.
        /// </summary>
        [SetUp]
        protected void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Email = "prueba@gmail.com";
            commensal.Password = "fondam12345";
            getEmail = BackendFactoryCommand.Instance.GetCommensalEmailCommand();
        }

        /// <summary>
        /// metodo que se encarga de limpiar el objeto.
        /// </summary>
        [TearDown]
        protected void Clean()
        {
            commensal = null;  
        }

        /// <summary>
        /// prueba unitaria de obtnerer el email de un comensal.
        /// </summary>
		[Test]
		public void GetEmailCommensalCommandTest()
		{
            getEmail.SetParameter(0, commensal);
            getEmail.Run();

			UserAccount result = (UserAccount)getEmail.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Email, result.Email);
		}


        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetEmailCommensalCommandBadParameter0Test()
        {
            getEmail.SetParameter(0, "2");
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void GetEmailCommensalCommandOfRangePaametersTest()
        {
            getEmail.SetParameter(1, commensal);
            getEmail.Run();
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void GetEmailCommensalCommandRequieredPaametersTest()
        {
            getEmail.Run();
        }
	}
}

