using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Tests.DataAccess
{
    [TestFixture()]
    public class BOCommandOrdersTest
    {
        #region fields
        private int _restaurantId, _orderId, _profileId, _comensalId;
        private Command _command;
        private IList<Account> _listAccount;
        private IList<Account> _listClosedOrders;
        private IList<DishOrder> _listDishOrder;
        private IList<Invoice> _listInvoices;
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private IInvoiceDao _invoiceDAO;
        private string _totalOrders;
        private List<int> parameters;
        List<Object> result;
        private string _currency;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;
        private Commensal _comensal;
        private ICommensalDAO _comensalDAO;
        private UserAccount _user;
        #endregion
        #region
        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;

            
            _orderAccountDAO = _facDAO.GetOrderAccountDAO();
            _restaurant = new Restaurant();
            _listClosedOrders = new List<Account>();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            _restaurantId = _orderId = 1;
            _comensalId = 20;
            _account = new Account();
            _invoice = new Invoice();
            _account.Id = 2;
            _invoiceDAO = _facDAO.GetInvoiceDao();
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            _account = _accountDAO.FindById(_account.Id);
            _listInvoices = new List<Invoice>();
            _totalOrders = null;
            parameters = new List<int> { _orderId, _restaurantId };
            _listDishOrder = new List<DishOrder>();
            result = null;
            _currency = null;
            _cashPayment = EntityFactory.GetCashPayment(11000);
            _creditPayment = EntityFactory.GetCreditCardPayment(11000,123,100);
            _comensal = new Commensal();
            _comensalDAO = _facDAO.GetCommensalDAO();
        }
        #endregion

        #region
        [Test(Description = "Se cierra la caja")]
        public void CommandCloseCashRegisterTest()
        {
            _command = CommandFactory.GetCommandCloseCashRegister(_restaurantId);

            _command.Execute();

            _totalOrders = (string)_command.Receiver;

            Assert.IsNotNull(_totalOrders);
            Assert.AreEqual(_totalOrders, "€ 13900");
        }

        [Test(Description = "Prueba de excepcion CommandExceptionCloseCashRegister")]
        [ExpectedException(typeof(CommandExceptionCloseCashRegister))]
        public void CommandCloseCashRegisterExceptionTest()
        {
            _command = CommandFactory.GetCommandCloseCashRegister(0);

            _command.Execute();

            _totalOrders = (string)_command.Receiver;

            Assert.IsNotNull(_totalOrders);
            Assert.AreEqual(_totalOrders, "€ 13900");
        }
        #endregion

        [Test(Description = "Se paga la orden")]
        public void CommandPayOrderTest()
        {
            _user = _comensalDAO.FindById(_comensalId);
            _comensal = (Commensal)_comensalDAO.FindById(_comensalId);
            IList<object> _result = new List<object>();
            _result.Add(_restaurantId);//1
            _result.Add(_orderId);//1
            _result.Add(1);//1 profile
            _result.Add(_cashPayment);
            _result.Add(_comensal);
            _command = CommandFactory.GetCommandPayOrder(_result);
            _command.Execute();
            _invoice = (Invoice)_command.Receiver;
            Assert.IsNotNull(_invoice);
            //Assert.AreEqual(_total, 10192f);
        }

        [Test(Description = "Obtiene el total de la orden, es decir, el costo de los platillos por la cantidad")]
        public void CommandTotalOrderTest()
        {
            IList<int> _list = new List<int>();
            int _accountId = 3;
            float _total = 0;
            _list.Add(_restaurantId); //1
            _list.Add(_accountId); //3
            _command = CommandFactory.GetCommandTotalOrder(_list);
            _command.Execute();
            _total = (float)_command.Receiver;
            Assert.IsNotNull(_total);
            Assert.AreEqual(_total, 10192f);
        }

        [Test(Description = "Obtiene el total de la orden, es decir, el costo de los platillos por la cantidad")]
        public void BadRequestCommandTotalOrderTest()
        {
            IList<int> _list = new List<int>();
            int _accountId = 3;
            float _total = 0;
            _list.Add(0); //1
            _list.Add(_accountId); //3
            _command = CommandFactory.GetCommandTotalOrder(_list);
            _command.Execute();
            _total = (float)_command.Receiver;
            //Assert.IsNotNull(_total);
            //Assert.AreEqual(_total, 9100);
        }

        [Test(Description = "Cambia el estado a la mesa")]
        public void CommandReleaseTableByRestaurantTest()
        {
            int _tableId = 3;
            ITableDAO _tableDAO = _facDAO.GetTableDAO();
            IList<object> _list = new List<object>();
            Table _table = new Table();
            _list.Add(_restaurant); //1
            _list.Add(_tableId); //3

            _command = CommandFactory.GetCommandReleaseTableByRestaurant(_list);

            _command.Execute();

            _table = _tableDAO.FindById(_tableId);
            Assert.AreEqual(_table.Id, _tableId);
            //Assert.AreEqual(_table.Status,);
        }

        [Test(Description = "Obtiene las ordenes de un restaurante")]
        public void CommandGetOrdersTest()
        {

            _command = CommandFactory.GetCommandGetOrders(_restaurantId);

            _command.Execute();

            _listAccount = (IList<Account>)_command.Receiver;

            Assert.IsNotNull(_listAccount);

        }

        [Test(Description = "Obtiene las ordenes cerradas de un restaurante")]
        public void CommandGetClosedOrdersTest()
        {

            _command = CommandFactory.GetCommandClosedOrders(_restaurantId);

            _command.Execute();

            _listAccount = (IList<Account>)_command.Receiver;

            Assert.IsNotNull(_listAccount);
            Assert.AreEqual(_listAccount[0].Id, 2);

        }

        [Test(Description = "Obtiene la unidad monetaria de un restaurante")]
        public void CommandGetCurrencyByRestaurantTest()
        {

            _command = CommandFactory.GetCommandGetCurrency(_restaurantId);

            _command.Execute();

            _currency = (string)_command.Receiver;

            Assert.AreEqual(_currency, "€");

        }

        [Test]
        public void CommandGetOrdersNullTest()
        {
            _command = CommandFactory.GetCommandGetOrders(100);

            _command.Execute();

            IList<Account> list = (IList<Account>)_command.Receiver;

            Assert.IsNotNull(list);
            Assert.Greater(list.Count, 0);
        }



        [Test(Description = "Obtiene la orden dado un id")]
        public void CommandGetOrderTest()
        {
            _command = CommandFactory.GetCommandGetOrder(_orderId);

            _command.Execute();

            _account = (Account)_command.Receiver;

            Assert.IsNotNull(_account);

        }

        [Test(Description = "Obtiene el detalle de una orden")]
        public void CommandGetDetailOrderTest()
        {
            _command = CommandFactory.GetCommandGetDetailOrder(parameters);

            _command.Execute();

            result = (List<Object>)_command.Receiver;
            _listDishOrder = (IList<DishOrder>)result[0];
            _account = (Account)result[1];
            _currency = (string)result[2];

            Assert.IsNotNull(result);
            Assert.AreEqual(_listDishOrder.Count, 2);
            Assert.AreEqual(_currency, "€");
        }
        [Test(Description = "Obtiene el detalle de una orden por id de la orden")]
        public void CommandGetDishOrderByAccountTest()
        {
            _command = CommandFactory.GetCommandGetDishOrdersByAccountId(_account.Id);

            _command.Execute();
            
            _listDishOrder = (IList<DishOrder>)_command.Receiver;

            Assert.IsNotNull(_listDishOrder);
            Assert.AreEqual(_listDishOrder.Count, 2);
        }

    }
}
