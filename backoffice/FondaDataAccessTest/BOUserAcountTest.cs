using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{
     [TestFixture]
    class BOUserAcountTest
    {
        private FactoryDAO _facDAO;
        private IUserAccountDAO _userAcountDAO;
        private UserAccount _userAcount;
        private int _userAcountId;

        /// <summary>
        /// Prueba de Rol Dominio
        /// Crea un rol y verifica si correcto
        /// </summary>
        [Test]
        public void UserAcountTest()
        {
            generateUserAcount();
            UserAcountAssertions();
        }


        /// <summary>
        /// Prueba de Acceso a Datos.
        /// </summary>
        [Test]

        public void UserAcountSave()
        {
            getUserAcountDao();
            generateUserAcount();

            _userAcountDAO.Save(_userAcount);

            Assert.AreNotEqual(_userAcount.Id, 0);
            _userAcountId = _userAcount.Id;

            generateUserAcount(true);

            _userAcountDAO.Save(_userAcount);

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
            _userAcount.Email = "josefg19@gmail.com";
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
            Assert.AreEqual(_userAcount.Email, "josefg19@gmail.com");
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
