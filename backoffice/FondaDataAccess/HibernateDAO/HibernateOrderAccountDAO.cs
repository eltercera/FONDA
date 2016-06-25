using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateOrderAccountDAO : HibernateBaseEntityDAO<Account>, IOrderAccountDao
    {
        /// <summary>
        /// Clase que tiene el manejo de los metodos de la base de datos de Order Account
        /// </summary>
        private FactoryDAO.FactoryDAO _facDAO;
        private IRestaurantDAO _restaurantDAO;

        public HibernateOrderAccountDAO()
        {
            this._facDAO = FactoryDAO.FactoryDAO.Intance;
        }

        /// <summary>
        /// Obtiene todas las ordenes del Sistema
        /// </summary>
        /// <returns>Una lista de Account</returns>
        public IList<Account> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Obtiene las cuentas abiertas de un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Un ID de Restaurant tipo int</param>
        /// <returns>Una List de Accounts</returns>
        public IList<Account> FindAccountByRestaurant(int _idRestaurant)
        {
            Restaurant _restaurant;

            try
            {
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
                _restaurant = _restaurantDAO.FindById(_idRestaurant);
                IList<Account> _list = new List<Account>();
                _list = _restaurant.Accounts;
                return _list;


            }
            catch (NullReferenceException ex)
            {
                FindAccountByRestaurantFondaDAOException exception =
                    new FindAccountByRestaurantFondaDAOException(OrderAccountResources.MessageFindAllAccountByRestaurantException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                FindAccountByRestaurantFondaDAOException exception =
                    new FindAccountByRestaurantFondaDAOException(OrderAccountResources.MessageFindAllAccountByRestaurantException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (Exception ex)
            {
                FindAccountByRestaurantFondaDAOException exception =
                    new FindAccountByRestaurantFondaDAOException(OrderAccountResources.MessageFindAllAccountByRestaurantException, ex);
                //Llamar al logger
                throw exception;
            }
        }

        public void ChangeStatusAccount(Account _account)
        {
            IOrderAccountDao _accountDao = _facDAO.GetOrderAccountDAO();

            try
            {
                _account.ChangeStatus();
                _accountDao.Save(_account);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ChangeStatusAccountFondaDAOException exception =
                    new ChangeStatusAccountFondaDAOException(OrderAccountResources.MessageChangeStatusAccountException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (Exception ex)
            {
                ChangeStatusAccountFondaDAOException exception =
                    new ChangeStatusAccountFondaDAOException(OrderAccountResources.MessageChangeStatusAccountException, ex);
                //Llamar al logger
                throw exception;
            }
        }

        /// <summary>
        /// cancela de invoices de Account
        /// </summary>
        /// <param name="Invoice, AccountId">Un objeto Invoice y un id de Account</param>
        /// <returns>Void</returns>
        public Invoice CancelInvoice(Invoice _invoice, int _accountId)
        {
            CanceledInvoiceStatus _cancelInvoice = _facDAO.GetCancelInvoiceStatusDAO();
            Account _account;
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            bool ok = false;
            try
            {
                _account = _accountDAO.FindById(_accountId);
                foreach (Invoice i in _account.ListInvoice)
                {
                    if (i.Id.Equals(_invoice.Id))
                    {
                        ok = true;
                    }
                }
                if (ok)
                {
                    _account.ListInvoice.Remove(_invoice);
                    _invoice.Status = _cancelInvoice;

                    // se le agrega la invoice a la cuenta
                    _account.ListInvoice.Add(_invoice);
                    //se salva la cuenta para registrar la nueva factura
                    _accountDAO.Save(_account);
                    //_restaurantDAO.Save(_restaurant);
                }

                return _invoice;

            }
            catch (ArgumentOutOfRangeException ex)
            {
                CancelInvoiceFondaDAOException exception =
                    new CancelInvoiceFondaDAOException(OrderAccountResources.MessageCancelInvoiceException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (Exception ex)
            {
                CancelInvoiceFondaDAOException exception =
                    new CancelInvoiceFondaDAOException(OrderAccountResources.MessageCancelInvoiceException, ex);
                //Llamar al logger
                throw exception;
            }
        }

        /// <summary>
        /// Agrega un invoice a la lista de invoices de Account
        /// </summary>
        /// <param name="Invoice, AccountId">Un objeto Invoice y un id de Account</param>
        /// <returns>Void</returns>
        public Invoice SaveInvoice(Invoice _invoice, int _accountId, int _restaurantId)
        {
            Account _account;
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            IInvoiceDao _invoiceDAO = _facDAO.GetInvoiceDao();
            int _number = 0;
            float tip = 0;
            Restaurant _restaurant = new Restaurant();
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            ICashPaymentDAO _cashPaymentDAO = _facDAO.GetCashPaymentDAO();
            ICreditCardPaymentDAO _creditPaymentDAO = _facDAO.GetCreditCardPaymentDAO();
            try
            {
                _restaurant = _restaurantDAO.FindById(_restaurantId);
                _number = _invoiceDAO.GenerateNumberInvoice(_restaurant);
                _account = _accountDAO.FindById(_accountId);

                InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
                String bla = _invoice.Payment.GetType().Name;
                if (_invoice.Payment.GetType().Name.Equals(OrderAccountResources.Cash))
                {
                    _cashPaymentDAO.Save((CashPayment)_invoice.Payment);
                }
                else if (_invoice.Payment.GetType().Name.Equals(OrderAccountResources.CreditCard))
                {
                    _creditPaymentDAO.Save((CreditCardPayment)_invoice.Payment);
                   // tip = ((CreditCardPayment)_invoice.Payment).Tip;
                }

                _invoice = (Invoice)EntityFactory.GetInvoice(_invoice.Payment, _invoice.Profile,
                    _invoice.Total, _invoice.Tax, _restaurant.Currency, _number, i);
                //Se le cambia el estatus de la orden a cerrada
                _account.ChangeStatus();
                // se le agrega la invoice a la cuenta
                _account.ListInvoice.Add(_invoice);
                //se salva la cuenta para registrar la nueva factura
                _accountDAO.Save(_account);
                //_restaurantDAO.Save(_restaurant);

                return _invoice;

            }
            catch (ArgumentOutOfRangeException ex)
            {
                SaveInvoiceFondaDAOException exception =
       new SaveInvoiceFondaDAOException(OrderAccountResources.MessageSaveInvoiceException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (Exception ex)
            {
                SaveInvoiceFondaDAOException exception =
       new SaveInvoiceFondaDAOException(OrderAccountResources.MessageSaveInvoiceException, ex);
                //Llamar al logger
                throw exception;
            }
        }

        /// <summary>
        /// Obtiene el numero unico de la orden
        /// </summary>
        /// <param name="Restaurant">Un objeto Restaurant</param>
        /// <returns>Un int que es el numero unico de Cuenta</returns>

        public int GenerateNumberAccount(Restaurant _restaurant)
        {
            try
            {
                IList<Account> _list = new List<Account>();
                _list = FindAccountByRestaurant(_restaurant.Id);
                int _length = 0;

                if (!(_list == null))
                {
                    _length = _list.Count;
                    _length = _length + 1;
                }

                return _length;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                GenerateNumberAccountFondaDAOException exception =
       new GenerateNumberAccountFondaDAOException(OrderAccountResources.MessageGenerateNumberAccountException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (Exception ex)
            {
                GenerateNumberAccountFondaDAOException exception =
       new GenerateNumberAccountFondaDAOException(OrderAccountResources.MessageGenerateNumberAccountException, ex);
                //Llamar al logger
                throw exception;
            }
        }

        public float CloseCashRegister(int restaurantId)
        {

            IInvoiceDao _invoiceDAO = _facDAO.GetInvoiceDao();
            DateTime _day = DateTime.Now.Date;
            float totalInvoice = 0;
            try
            {
                //TODO: Excepcion en caso de no encontrar restaurante
                Restaurant restaurant = Session.QueryOver<Restaurant>()
                    .Where(r => r.Id == restaurantId)
                    .Where(r => r.Status == ActiveSimpleStatus.Instance)
                    .SingleOrDefault();

                IList<Account> _dayOrders = new List<Account>();

                //TODO: Excepcion en caso de no encontrar lista llena
                foreach (Account _order in restaurant.Accounts)
                {
                    if (_order.Date.Equals(_day) && _order.Status.Equals(ClosedAccountStatus.Instance))
                    {
                        Invoice _invoice = _invoiceDAO.FindById(_order.Id);
                        totalInvoice = _invoice.Total + totalInvoice;
                    }
                }

                return totalInvoice;

            }
            catch (FondaIndexException ex)
            {
                CloseCashRegisterFondaDAOException exception =
       new CloseCashRegisterFondaDAOException(OrderAccountResources.MessageCloseCashRegisterException, ex);
                //Llamar al logger
                throw exception;
            }
            catch (Exception ex)
            {
                CloseCashRegisterFondaDAOException exception =
       new CloseCashRegisterFondaDAOException(OrderAccountResources.MessageCloseCashRegisterException, ex);
                //Llamar al logger
                throw exception;
            }
        }
    }
}
