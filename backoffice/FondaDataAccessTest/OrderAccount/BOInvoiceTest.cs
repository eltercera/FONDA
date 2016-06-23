using NUnit.Framework;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace FondaDataAccessTest
{
    
    
    [TestFixture()]
    public class BOInvoiceTests
    {
        #region Fields

        private FactoryDAO _facDAO;
        private IInvoiceDao _invoiceDAO;
        private IOrderAccountDao _accountDAO;
        private IProfileDAO _profileDao;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant, _resultRestaurant;
        private Invoice _invoice;
        private Account _account;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;
        private Profile _profile;
        private IList<Invoice> _listInvoices;
        private int _number, _accountId, _restaurantId, _profileId, _tableId, _invoiceId ;
        private float _amount, _tax;

        #endregion

        #region Initialzation

        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;

            //Llama a interfaces DAO
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            _accountDAO = _facDAO.GetOrderAccountDAO();
            _invoiceDAO = _facDAO.GetInvoiceDao();
            _profileDao = _facDAO.GetProfileDAO();

            //Inicializa variables
            _invoiceId = 1;
            _accountId = 2;
            _restaurantId = 1;
            _tableId = 3;
            _profileId = 1;
            _tax = _amount * 0.12F;

            //Consigue eventos de la Base de Datos
            _restaurant = _restaurantDAO.FindById(_restaurantId);
            _account = _accountDAO.FindById(_accountId);
            _profile = _profileDao.FindById(_profileId);

            _number = _invoiceDAO.GenerateNumberInvoice(_restaurant);
            
            //Instancia objetos a utilizar
            _cashPayment = EntityFactory.GetCashPayment(_amount);
            _invoice = EntityFactory.GetInvoice(
                _cashPayment, _profile, _amount, _tax, _restaurant.Currency, _number);

            
            _listInvoices = new List<Invoice>();
        }
        #endregion

        #region Pruebas de DataAccess/HibernateDAO/FindInvoiceByRestaurant

        [Test(Description = "Busca las facturas de un restaurante")]
        public void FindInvoiceByRestaurantTest()
        {

            _listInvoices = _invoiceDAO.FindInvoicesByRestaurant(_restaurant);
            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(_listInvoices[0].Id, 1);
            Assert.AreEqual(_listInvoices[1].Id, 2);
            Assert.AreEqual(_listInvoices[2].Number, 3);
        }

        [Test(Description = "Busca las facturas de un restaurante")]
        [ExpectedException(typeof(FindInvoicesByRestaurantFondaDAOException))]
        public void ErrorFindInvoiceByRestaurantTest()
        {

            _listInvoices = _invoiceDAO.FindInvoicesByRestaurant(null);
            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(_listInvoices[0].Id, 1);
            Assert.AreEqual(_listInvoices[1].Id, 2);
            Assert.AreEqual(_listInvoices[2].Number, 3);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateDAO/FindAllInvoices

        [Test(Description  ="Trae una lista de facturas pagadas a un usuario")]
        public void FindAllInvoiceByProfileTest()
        {
            _listInvoices =  _invoiceDAO.findAllInvoice(_profile);

            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(3, _listInvoices.Count);
        }

        [Test(Description ="Caso de error en que se envie un perfil vacio")]
        public void NullReferenceExceptionFindAllInvoiceByProfileTest()
        {
            _listInvoices = _invoiceDAO.findAllInvoice(null);

            Assert.AreEqual(0, _listInvoices.Count);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateDAO/GenerateNumberInvoice

        [Test(Description = "Prueba el numero generado de la factura (Numero único de factura por restaurante)")]
        public void GenerateNumberInvoiceTest()
        {

            _number = _invoiceDAO.GenerateNumberInvoice(_restaurant);
            //Hay 6 facturas insertadas 
            Assert.IsNotNull(_number);
            Assert.AreEqual(_number,7);
        }

        [Test(Description = "Caso de error cuando genera el numero de la factura (Numero único de factura por restaurante)")]
        [ExpectedException(typeof(GenerateNumberInvoiceFondaDAOException))]
        public void ErrorGenerateNumberInvoiceTest()
        {

            _number = _invoiceDAO.GenerateNumberInvoice(null);
            //Hay 6 facturas insertadas 
            Assert.IsNotNull(_number);
            Assert.AreEqual(_number, 7);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateDAO/FindGenerateInvoiceByAccount

        [Test(Description ="Prueba que trae una factura pagada de la Base de datos")]
        public void FindGenerateInvoiceByAccountTest()
        {
            _invoice = _invoiceDAO.FindGenerateInvoiceByAccount(_account.Id);
            Assert.IsNotNull(_invoice);
            Assert.AreEqual(1,_invoice.Id);
            Assert.AreEqual(1,_invoice.Number);
            Assert.AreEqual(5950,_invoice.Total);
            Assert.AreEqual(GeneratedInvoiceStatus.Instance, _invoice.Status);
            Assert.IsInstanceOf<CreditCardPayment>(_invoice.Payment);
        }

        [Test(Description = "Caso de error que trae una factura pagada de la Base de datos")]
        [ExpectedException(typeof(FindGenerateInvoiceByAccountFondaDAOException))]
        public void ErrorFindGenerateInvoiceByAccountTest()
        {
            _invoice = _invoiceDAO.FindGenerateInvoiceByAccount(-1);
            Assert.IsNull(_invoice);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateDAO/FindInvoicesByAccount

        [Test(Description ="Prueba que traiga la lista de facturas de una orden")]
        public void FindInvoicesByAccountTest()
        {
            _listInvoices = _invoiceDAO.FindInvoicesByAccount(_accountId);
            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(1,_listInvoices[0].Id);
        }

        [Test(Description = "Caso de error al traer la lista de facturas de una orden")]
        [ExpectedException(typeof(FindInvoicesByAccountFondaDAOException))]
        public void ErrorFindInvoicesByAccountTest()
        {
            _listInvoices = _invoiceDAO.FindInvoicesByAccount(-1);
            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(0, _listInvoices.Count);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateDAO/ReleaseTable

        [Test(Description = "Prueba que el estado de un Restaurante cambie de ocupado a libre")]
        public void ReleaseTableTest()
        {

            _restaurantDAO.ReleaseTable(_restaurant, 2);
            _resultRestaurant = _restaurantDAO.FindById(_restaurantId);

            Assert.AreEqual(_restaurant.Tables[_tableId - 1].Id, _resultRestaurant.Tables[_tableId - 1].Id);
            Assert.AreEqual(_restaurant.Tables[_tableId - 1].Capacity, _resultRestaurant.Tables[_tableId - 1].Capacity);
            Assert.AreEqual(_restaurant.Tables[_tableId - 1].Number, _resultRestaurant.Tables[_tableId - 1].Number);
            Assert.AreNotEqual(_restaurant.Tables[_tableId - 1].Status.Change(), _resultRestaurant.Tables[_tableId - 1].Status);
        }

        [Test(Description = "Caso de error cuando el estado de un Restaurante cambie de ocupado a libre")]
        [ExpectedException(typeof(ReleaseTableFondaDAOException))]
        public void ErrorReleaseTableTest()
        {

            _restaurantDAO.ReleaseTable(null, 0);
            _resultRestaurant = _restaurantDAO.FindById(_restaurantId);

            Assert.AreNotEqual(_restaurant.Tables[_tableId - 1].Status.Change(), _resultRestaurant.Tables[_tableId - 1].Status);
        }

        #endregion

        [TearDown]
        public void EndTests()
        {
            _restaurantDAO = null;
            _accountDAO = null;
            _invoiceDAO = null;
            _profileDao = null;

            _invoiceId = _accountId = 
                _restaurantId = _tableId = 
                    _profileId = _number = 0;

            _tax = 0;

            _restaurant = null;
            _account = null;
            _profile = null;
            _cashPayment = null;
            _invoice = null;
            _listInvoices = null;
        }
    }
}

