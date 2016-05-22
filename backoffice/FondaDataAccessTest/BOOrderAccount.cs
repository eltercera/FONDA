using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;


namespace FondaDataAccessTest
{
    [TestFixture()]
    class BOOrderAccount
    {
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private IDishOrderDAO _dishOrderDAO;
        private ICommensalDAO _commensalDAO;
        private Account account;
        private int _OrderAccountID;

        /// <summary>
        /// Prueba de Dominio.
        /// crea a una orden, luego verifica
        /// si esta correctamente creada.
        /// </summary>
		[Test()]
        public void OrderAccountTest()
        {
            generateOrderAccount();
            OrderAccountAssertion();
        }

        [Test()]
        public void OrderAccountSave()
        {
            // Se vuelve a generar una orden
            GetOrderAccountDAO();
            generateOrderAccount();

            // La guardo
            _orderAccountDAO.Save(account);

            // revision del ID de la DB
            Assert.AreNotEqual(account.Id, 0);
            _OrderAccountID = account.Id;
			/*
            // Editar la orden
            generateOrderAccount(true);

            // guardar la orden
            _orderAccountDAO.Save(account);
			*/
            // Reiniciar y borrar la orden de memoria
            _orderAccountDAO.ResetSession();
            account = null;

            // Buscar la orden creada en la DB
            account = _orderAccountDAO.FindById(_OrderAccountID);

            // Verificar los cambios
            OrderAccountAssertion();

        }

        private void generateOrderAccount(bool edit = false)
        {
            if (account != null & !edit)
                return;

            if ((edit & account == null) | account == null)
                account = new Account();

            _dishOrderDAO = _facDAO.GetDishOrderDAO();
            _commensalDAO = _facDAO.GetCommensalDAO();
            ITableDAO tableDAO = _facDAO.GetTableDAO();
            Commensal owner = (Commensal) _commensalDAO.FindById(13);

            DishOrder dishOrder =_dishOrderDAO.FindById(1);
            Assert.IsNotNull(dishOrder);
            DishOrder dishOrder2 = _dishOrderDAO.FindById(2);
            Assert.IsNotNull(dishOrder2);

            account.addDish(dishOrder);
            account.addDish(dishOrder2);

            account.Commensal = owner ;
            account.Table = tableDAO.FindById(1);
            account.Status = OpenAccountStatus.Instance;

        }

        private void OrderAccountAssertion()
        {
            Assert.IsNotNull(account);
            Assert.IsNotNull(account.ListDish);
        }

        private void GetOrderAccountDAO()
        {
            getDao();
            if (_orderAccountDAO == null)
                _orderAccountDAO = _facDAO.GetOrderAccountDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            if (_OrderAccountID != 0)
            {
                GetOrderAccountDAO();
                // Eliminacion de la Persona al finalidar todo.
                // _orderDAO.Delete(account);

            }
            _orderAccountDAO.ResetSession();
        }


    }
}
