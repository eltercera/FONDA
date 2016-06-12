using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture()]
    public class BOOrderAccount
    {
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private IDishOrderDAO _dishOrderDAO;
        private ICommensalDAO _commensalDAO;
        private Account _account;
        private Table _table;
        private Commensal _commensal;
        private IList<DishOrder> _listOrder;
        private int _orderAccountId, _number;

        [SetUp]
        public void Init()
        {
            _table = new Table();
            _commensal = new Commensal();
            _listOrder = new List<DishOrder>();
            _number = 0;

            _account = (Account)EntityFactory.GetAccount(_table, _commensal, _listOrder, _number);
        }

        [Test]
        public void SaveAccount()
        {

        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            //if (_OrderAccountID != 0)
            //{
            //    GetOrderAccountDAO();
            //    // Eliminacion de la Persona al finalidar todo.
            //    // _orderDAO.Delete(account);

            //}
            _orderAccountDAO.ResetSession();
        }


    }
}
