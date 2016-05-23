using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
     [TestFixture]
    class BOUserAcountTest
    {
        private FactoryDAO _facDAO;
        private IUserAccountDAO _userAcountDAO;
        private UserAccount _userAcount;
        private int _userAcountId = 0;

        /// <summary>
        /// Prueba del constructor de la clase UserAccount
        /// </summary>
        [Test]
        public void TestBuilderUsercount()
        {
            UserAccount useraccount = new  UserAccount();
            Assert.AreEqual(useraccount.Id, 0);
            Assert.AreEqual(useraccount.Email, null);
            Assert.AreEqual(useraccount.Password, null);
        }

        /// <summary>
        /// Prueba de Rol Dominio
        /// Crea un rol y verifica si es  correcto
        /// </summary>
        [Test]
        public void UserAcountTest()
        {
            generateUserAcount();
            UserAcountAssertions();
        }


        /// <summary>
        /// Prueba de Acceso a Datos.guarda el userAcount y verifica que sea correcto
        /// </summary>
        [Test]

        public void UserAcountSave()
        {
            UserAccount usert = new UserAccount();
            getUserAcountDao();
            generateUserAcount();
            _userAcountDAO.Save(_userAcount);
            Assert.AreNotEqual(_userAcount.Id, 0);
            usert = _userAcountDAO.FindById(_userAcount.Id);
            Assert.IsNotNull(usert);
            Assert.AreEqual(usert.Email, "Pruebauser@gmail.com");
            Assert.AreEqual(usert.Password, "12345");
            _userAcountDAO.Delete(_userAcount);
            _userAcountDAO.ResetSession();
            _userAcount = null;

        }
         /// <summary>
        /// Prueba de Acceso a Datos verifica la modifacion de un usuario 
         /// </summary>
           [Test]
        public void UserAcountModifi()
        {
            UserAccount usert = new UserAccount();
            getUserAcountDao();
            generateUserAcount();
            _userAcountDAO.Save(_userAcount);
            Assert.AreNotEqual(_userAcount.Id, 0);
            _userAcountDAO.Save(_userAcount);
            usert = _userAcountDAO.FindById(_userAcount.Id);
            //se valida que el useracont creado fue de manera correcta
            Assert.IsNotNull(usert);
            Assert.AreEqual(usert.Email, "Pruebauser@gmail.com");
            Assert.AreEqual(usert.Password, "12345");
            usert = _userAcountDAO.FindById(usert.Id);
            //Se realizan los cambios y son guardados 
            usert.Email = "Nuevo@gmail.com";
            usert.Password = "12nueva";
            _userAcountDAO.Save(usert);
            // se trae las modificaciones y se verifican que fueron correctas
            usert = _userAcountDAO.FindById(_userAcount.Id);
            Assert.IsNotNull(usert);
            Assert.AreEqual(usert.Email, "Nuevo@gmail.com");
            Assert.AreEqual(usert.Password, "12nueva");
            _userAcountDAO.Delete(_userAcount);
            _userAcountDAO.ResetSession();
            _userAcount = null;
        }

        /// <summary>
        /// Se encarga de crear un rol en caso que no exista.
        /// </summary>
        /// <param name="edit"></param>
        private void generateUserAcount(bool edit = false)
        {
            if (_userAcount != null)
                return;
            if ((edit & _userAcount == null) | _userAcount == null)
                _userAcount = new UserAccount();
            _userAcount.Email = "Pruebauser@gmail.com";
            _userAcount.Password = "12345";
            _userAcount.Status = ActiveSimpleStatus.Instance;
        }
        /// <summary>
        /// Verifica que el contenio de rol sea igual.
        /// </summary>
        /// <param name="edit"></param>
        private void UserAcountAssertions(bool edit = false)
        {
            Assert.IsNotNull(_userAcount);
            Assert.AreEqual(_userAcount.Email, "Pruebauser@gmail.com");
            Assert.AreEqual(_userAcount.Password, "12345");
            Assert.AreEqual(_userAcount.Status, ActiveSimpleStatus.Instance);
        }


        private void getUserAcountDao()
        {
            getDao();
            if (_userAcountDAO == null)
                _userAcountDAO = _facDAO.GetUserAccountDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

    }
}
