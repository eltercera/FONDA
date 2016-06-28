using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using NUnit.Framework;

namespace FondaBackEndLogicTest
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias 
    /// del Commando CommensalCommand
    /// </summary>
    [TestFixture]
    public class CommensalCommandManagementTest : HelpTestCommand
    {
        /// <summary>
        /// Atributos de la clase prueba
        /// </summary>
        private ICommand _createCommensal;
        private ICommand _getCommensal;
        private Commensal _commensal;
        private ICommensalDAO _commensalDAO;
        private int _idCommensal;

        /// <summary>
        /// Inicializacion de variables antes de cada prueba
        /// </summary>
        [SetUp]
        protected void Init()
        {
            _commensal = EntityFactory.GetCommensal();
            //se genera el commensal
            _commensal = generateCommensal();
            _createCommensal = BackendFactoryCommand.Instance.GetCreateCommensalCommand();
            _getCommensal = BackendFactoryCommand.Instance.GetCommensalCommand();
            _commensalDAO = FactoryDAO.Intance.GetCommensalDAO();
            _idCommensal = 0;
        }
        
        /// <summary>
        /// Prueba del comando CreateCommensal
        /// </summary>
        [Test]
        public void CreateCommensalCommandTest()
        {

            _createCommensal.SetParameter(0, _commensal);
            _createCommensal.Run();
            
            Commensal _result = (Commensal)_createCommensal.Result;
            _idCommensal = _result.Id;

            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_result.Email,_commensal.Email);
        }

        /// <summary>
        /// Prueba del comando GetCommensal
        /// </summary>
        [Test]
        public void GetCommensalCommandTest()
        {
            _commensalDAO.Save(_commensal);
            _idCommensal = _commensal.Id;
            _getCommensal.SetParameter(0, _commensal);
            _getCommensal.Run();
            Commensal _result = (Commensal)_getCommensal.Result;

            Assert.NotNull(_result);
            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_idCommensal, _result.Id);
        }

        /// <summary>
        /// Prueba de la excepcion InvalidTypeOfParameterException
        /// en el Comando CreateCommensalCommand
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void CreateCommensalCommandBadParameterTest()
        {
            _createCommensal.SetParameter(0, "commensal");
            _createCommensal.Run();
        }

        /// <summary>
        /// Prueba de la excepcion ParameterIndexOutOfRangeException
        /// en el Comando CreateCommensalCommand
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void CreateCommensalCommandOfRangeParametersTest()
        {
            _createCommensal.SetParameter(1, "commensal");
            _createCommensal.Run();
        }

        /// <summary>
        /// Prueba de la excepcion RequieredParameterNotFoundException
        /// en el Comando CreateCommensalCommand
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void CreateCommensalCommandRequieredParametersTest()
        {
            _createCommensal.Run();
        }

        /// <summary>
        /// Prueba de la excepcion InvalidTypeOfParameterException
        /// en el Comando GetCommensalCommand
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetCommensalCommandBadParameterTest()
        {
            _getCommensal.SetParameter(0, "commensal");
            _getCommensal.Run();
        }

        /// <summary>
        /// Prueba de la excepcion ParameterIndexOutOfRangeException
        /// en el Comando GetCommensalCommand
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void GetCommensalCommandOfRangeParametersTest()
        {
            _getCommensal.SetParameter(1, "commensal");
            _getCommensal.Run();
        }

        /// <summary>
        /// Prueba de la excepcion RequieredParameterNotFoundException
        /// en el Comando GetCommensalCommand
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void GetCommensalCommandRequieredParametersTest()
        {
            _getCommensal.Run();
        }

        /// <summary>
        /// metodo que se encarga de limpiar el objeto.
        /// </summary>
        [TearDown]
        protected void Clean()
        {
            if (_idCommensal != 0)
            {
                _commensalDAO.Delete(_commensal);
            }
            _createCommensal = null;
            _getCommensal = null;
            _commensal = null;
            _commensalDAO = null;
            _idCommensal = 0;
        }
    }
}
