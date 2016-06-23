using com.ds201625.fonda.BackEndLogic;
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
    /// del Commando TokenCommand
    /// </summary>
    [TestFixture]
    public class TokenCommandManagementTest : HelpTestCommand
    {
        /// <summary>
        /// Atributos de la clase prueba
        /// </summary>
        private ICommand _getToken;
        private ICommand _getTokenStr;
        private ICommand _deleteToken;
        private Commensal _commensal;
        private int _idToken;
        private Token _token;
        private ICommensalDAO _commensalDAO;

        /// <summary>
        /// Inicializacion de variables antes de cada prueba
        /// </summary>
        [SetUp]
        protected void Init()
        {
            _commensal = EntityFactory.GetCommensal();
            _token = null;
            _commensalDAO = FactoryDAO.Intance.GetCommensalDAO();
            _commensal = (Commensal)_commensalDAO.FindById(1);
            _idToken = 0;
        }

        /// <summary>
        /// Prueba del comando GetToken
        /// </summary>
        [Test]
        public void GetTokenCommandTest()
        {
            int _length = _commensal.SesionTokens.Count;
            _getToken = BackendFactoryCommand.Instance.GetTokenCommand();
            _getToken.SetParameter(0, _commensal);
            _getToken.Run();

            Token _result = (Token)_getToken.Result;
            _idToken = _result.Id;
            _token = _result;
            Assert.AreNotEqual(0, _result.Id);
            Assert.AreNotEqual(_length, _commensal.SesionTokens.Count);
        }

        /// <summary>
        /// Prueba del comando DeleteToken
        /// </summary>
        [Test]
        public void DeleteTokenCommandTest()
        {
            _token = EntityFactory.GetToken();
            Assert.False(_commensal.SesionTokens.Contains(_token));
            //Se agrega el Token al commensal
            _commensal.AddToken(_token);

            //Se guardan los cambios
            _commensalDAO.Save(_commensal);
            
            Assert.True(_commensal.SesionTokens.Contains(_token));
            int _length = _commensal.SesionTokens.Count;
            _deleteToken = BackendFactoryCommand.Instance.DeleteTokenCommensalCommand();
            _deleteToken.SetParameter(0, _commensal);
            _deleteToken.SetParameter(1, _token);
            _deleteToken.Run();

            Assert.False(_commensal.SesionTokens.Contains(_token));
            Assert.AreNotEqual(_length, _commensal.SesionTokens.Count);
        }

        /// <summary>
        /// Prueba del comando GetTokenStr
        /// </summary>
        [Test]
        public void GetTokenStrCommandTest()
        {
            _token = EntityFactory.GetToken();
            //Se agrega el Token al commensal
            _commensal.AddToken(_token);

            //Se guardan los cambios
            _commensalDAO.Save(_commensal);

            string _strToken = _token.StrToken;
            _getTokenStr = BackendFactoryCommand.Instance.GetTokenStrCommands();
            _getTokenStr.SetParameter(0, _strToken);
            _getTokenStr.Run();

            Token _result = (Token)_getTokenStr.Result;
            _idToken = _result.Id;
            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_token.Id, _result.Id);
            Assert.AreEqual(_strToken, _result.StrToken);
        }

        /// <summary>
        /// Limpiar las variables al final de cada prueba
        /// </summary>
        [TearDown]
        protected void Clean()
        {
            if (_idToken != 0)
            {
                _commensal.RemoveToken(_token);
                _commensalDAO.Save(_commensal);
            }
            _getToken = null;
            _getTokenStr = null;
            _deleteToken = null;
            _commensal = null;
            _idToken = 0;
            _token = null;
            _commensalDAO = null;
        }
    }
}
