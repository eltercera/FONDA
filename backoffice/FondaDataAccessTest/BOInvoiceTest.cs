using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    
    
    [TestFixture()]
    public class BOInvoiceTests
    {

		private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;

        private IInvoiceDao _invoiceDAO;
        private Invoice _invoice;
        private int _invoiceId;
        private IOrderAccountDao _orderAccountDao;
        private ICreditCardPaymentDAO _paymentDao;
        private DateTime _invoiceDate = Convert.ToDateTime("10/05/2016");
        private float total;

        /// <summary>
        /// Prueba de Dominio.
        /// Solo crea a una persona y se veridica si los campos
        /// estan correctamente asignados.
        /// </summary>
        [Test()]
        public void InvoiceDomainTerst()
        {
            generateInvoice();
            InvoiceAssertions();
        }

        /// <summary>
        /// Prueba de Acceso a Datos.
        /// Genera una persona, La persiste, la edita, la guarda,
        /// la obtiene y verifica si los cambios son correctos.
        /// </summary>
        [Test()]
        public void InvoiceSave()
        {
            // Genera una persona
            getInvoiceDao();
            generateInvoice();

            // La persiste
            _invoiceDAO.Save(_invoice);

            // Verificación de la asignacion de Identificador de DB
            Assert.AreNotEqual(_invoice.Id, 0);
            _invoiceId = _invoice.Id;

            // Agrega los cambio a propiedades
            generateInvoice(true);

            // Se Guarda
            _invoiceDAO.Save(_invoice);

            // Reinicio de session de DAO
            _invoiceDAO.ResetSession();

            _invoice = null;

            // Obencion del la persona por su identificador
            _invoice = _invoiceDAO.FindById(_invoiceId);

            // Verificacion de los cambios.
            InvoiceAssertions(true);

        }

        private void getInvoiceDao()
        {
            getDao();
            if (_invoiceDAO == null)
                _invoiceDAO = _facDAO.GetInvoiceDao();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO.Intance;
        }

        private void generateInvoice(bool edit = false)
        {
            if (_invoice != null & !edit)
                return;

            if ((edit & _invoice == null) | _invoice == null)
                _invoice = new Invoice();

            if (_facDAO == null)
                getDao();

            _orderAccountDao = _facDAO.GetOrderAccountDAO();
                
            Account orderAccount;
            Payment payment;
                          
            orderAccount = _orderAccountDao.FindById(1);
               
                
                _paymentDao = _facDAO.GetCreditCardPaymentDAO();
                payment = _paymentDao.FindById(1);

        System.Collections.Generic.IList<DishOrder> list = orderAccount.ListDish;

        total = 0;
        for (int i = 0; i < list.Count; i++)
        {
            DishOrder dishOrder=list[i];
            total = total + (dishOrder.Dish.Cost*dishOrder.Count);
        }
                

            _invoice.Payment = payment;
            _invoice.Date = _invoiceDate;
            _invoice.Status = GeneratedInvoiceStatus.Instance;
            _invoice.Tax = 24;
            _invoice.Tip = 200;
            _invoice.Total = total;
            _invoice.Account = orderAccount;

        }

        private void InvoiceAssertions(bool edit = false)
        {
   
            Assert.IsNotNull(_invoice.Payment);
            Assert.AreEqual(_invoice.Payment.Id, 1);
                
               

            Assert.IsNotNull(_invoice);
            Assert.AreEqual(_invoice.Tax, 24);
            Assert.AreEqual(_invoice.Tip, 200);
            Assert.AreEqual(_invoice.Total, total );
            Assert.AreEqual(_invoice.Status, GeneratedInvoiceStatus.Instance);
            Assert.AreEqual(_invoice.Date, _invoiceDate);
            Assert.AreEqual(_invoice.Account.Id, 1);
                

        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            if (_invoiceId != 0)
            {
                getInvoiceDao();
                // Eliminacion de la Persona al finalidar todo.
                //_personDAO.Delete(_person);
            }
            _invoiceDAO.ResetSession();
        }
    }
}

