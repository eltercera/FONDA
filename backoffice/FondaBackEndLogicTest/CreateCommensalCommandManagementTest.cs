using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackEndLogicTest
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias 
    /// del Commando CreateCommensalCommand
    /// </summary>
    [TestFixture]
    public class CreateCommensalCommandManagementTest : HelpTestCommand
    {

        private ICommand _createCommensal;
        private Commensal _commensal;
        private ICommensalDAO _commensalDAO;

        [SetUp]
        protected void Init()
        {
            _commensal = EntityFactory.GetCommensal();
            //se genera el commensal
            _commensal = generateCommensal();
            _createCommensal = BackendFactoryCommand.Instance.GetCreateCommensalCommand();
            _commensalDAO = FactoryDAO.Intance.GetCommensalDAO();
        }

        //teardown

        /// <summary>
        /// prueba unitaria de crear un restaurant favorito 
        /// </summary>
        [Test]
        public void CreateFavoriteRestaurantCommandTest()
        {

            _createCommensal.SetParameter(0, _commensal);
            _createCommensal.Run();

            Commensal _result = (Commensal)_createCommensal.Result;
            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_result.Email,_commensal.Email);
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void CreateCommensalCommandBadParameterTest()
        {
            _createCommensal.SetParameter(0, "commensal");
            _createCommensal.Run();
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void CreateCommensalCommandOfRangeParametersTest()
        {
            _createCommensal.SetParameter(1, "commensal");
            _createCommensal.Run();
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void CreateCommensalCommandRequieredParametersTest()
        {
            _createCommensal.Run();
        }

        /// <summary>
        /// metodo que se encarga de limpiar el objeto.
        /// </summary>
        [TearDown]
        protected void Clean()
        {
            _commensalDAO.Delete(_commensal);
            _createCommensal = null;
            _commensal = null;
            _commensalDAO = null;
        }
    }
}
