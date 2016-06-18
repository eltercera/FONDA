using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Factory;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class GetEmailCommensalManagementTest
	{
        Commensal commensal;
        ICommand getEmail;

        [SetUp]
        public void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Email = "prueba@gmail.com";
            commensal.Password = "fondam12345";
            getEmail = BackendFactoryCommand.Instance.GetCommensalEmailCommand();
        }

        [TearDown]
        public void Clean()
        {
            commensal = null;  
        }
		
		[Test]
		public void GetEmailCommensalCommandTest()
		{
            getEmail.SetParameter(0, commensal);
            getEmail.Run();

			UserAccount result = (UserAccount)getEmail.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Email, result.Email);
		}

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetEmailCommensalCommandNullReferenceTest()
        {
            getEmail.SetParameter(0, commensal);
            UserAccount result = (UserAccount)getEmail.Result;
        
            Assert.AreNotEqual(commensal.Email, result.Email);
            Assert.IsNull(result.Email);
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetEmailCommensalCommandBadParameter0Test()
        {
            getEmail.SetParameter(0, "2");
        }


        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void GetEmailCommensalCommandOfRangePaametersTest()
        {
            getEmail.SetParameter(1, commensal);
            getEmail.Run();
        }

        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void GetEmailCommensalCommandRequieredPaametersTest()
        {
            getEmail.Run();
        }
	}
}

