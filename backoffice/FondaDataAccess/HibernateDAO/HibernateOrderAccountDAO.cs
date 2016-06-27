using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.Log;

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
            IList<Account> _list = new List<Account>();
            try
            {
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
                _restaurant = _restaurantDAO.FindById(_idRestaurant);
                _list = _restaurant.Accounts;

            }
            catch (NullReferenceException ex)
            {
                FindAccountByRestaurantFondaDAOException exception =
                    new FindAccountByRestaurantFondaDAOException(OrderAccountResources.MessageFindAllAccountByRestaurantException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                FindAccountByRestaurantFondaDAOException exception =
                    new FindAccountByRestaurantFondaDAOException(OrderAccountResources.MessageFindAllAccountByRestaurantException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                FindAccountByRestaurantFondaDAOException exception =
                    new FindAccountByRestaurantFondaDAOException(OrderAccountResources.MessageFindAllAccountByRestaurantException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageFindAccountByRestaurant,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _list;

        }

        /// <summary>
        /// Cambia el estado de la Cuenta
        /// </summary>
        /// <param name="_account">Account</param>
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
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                ChangeStatusAccountFondaDAOException exception =
                    new ChangeStatusAccountFondaDAOException(OrderAccountResources.MessageChangeStatusAccountException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageGetOrderAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
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
                }


            }
            catch (ArgumentOutOfRangeException ex)
            {
                CancelInvoiceFondaDAOException exception =
                    new CancelInvoiceFondaDAOException(OrderAccountResources.MessageCancelInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                CancelInvoiceFondaDAOException exception =
                    new CancelInvoiceFondaDAOException(OrderAccountResources.MessageCancelInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageCancelInvoice,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _invoice;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Account GetOrderAccountByInvoice(Invoice _invoice, int _restaurantId)
        {
            IList<Account> _listaccount= new List<Account>();
            IList<Invoice> _listinvoice = new List<Invoice>();
            Account _account=  EntityFactory.GetAccount();
            Restaurant _restaurant;
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            try
            {
                _restaurant = _restaurantDAO.FindById(_restaurantId);
                _listaccount = _restaurant.Accounts;

                for (int i = 0; i < _listaccount.Count; i++)
                {
                    _listinvoice = _listaccount[i].ListInvoice;

                    foreach (Invoice invoice in _listinvoice)
                    {
                        if (invoice.Id.Equals(_invoice.Id))
                        {
                            _account = _listaccount[i];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                GetOrderAccountFondaDAOException exception = new GetOrderAccountFondaDAOException(
                    OrderAccountResources.MessageCanceledInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageGetOrderAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _account;
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
                }

                _invoice = (Invoice)EntityFactory.GetInvoice(_invoice.Payment, _invoice.Profile,
                    _invoice.Total, _invoice.Tax, _restaurant.Currency, _number, i);
                //Se le cambia el estatus de la orden a cerrada
                if (_account.Status.Equals(OpenAccountStatus.Instance))
                {
                    _account.ChangeStatus();
                }
                
                // se le agrega la invoice a la cuenta
                _account.ListInvoice.Add(_invoice);
                //se salva la cuenta para registrar la nueva factura
                _accountDAO.Save(_account);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                SaveInvoiceFondaDAOException exception =
       new SaveInvoiceFondaDAOException(OrderAccountResources.MessageSaveInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                SaveInvoiceFondaDAOException exception =
       new SaveInvoiceFondaDAOException(OrderAccountResources.MessageSaveInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageSaveInvoice,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _invoice;

        }

        /// <summary>
        /// Obtiene el numero unico de la orden
        /// </summary>
        /// <param name="Restaurant">Un objeto Restaurant</param>
        /// <returns>Un int que es el numero unico de Cuenta</returns>
        public int GenerateNumberAccount(Restaurant _restaurant)
        {
            int _length;
            try
            {
                IList<Account> _list = new List<Account>();
                _list = FindAccountByRestaurant(_restaurant.Id);
                _length = 0;

                if (!(_list == null))
                {
                    _length = _list.Count;
                    _length = _length + 1;
                }


            }
            catch (ArgumentOutOfRangeException ex)
            {
                GenerateNumberAccountFondaDAOException exception =
       new GenerateNumberAccountFondaDAOException(OrderAccountResources.MessageGenerateNumberAccountException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                GenerateNumberAccountFondaDAOException exception =
       new GenerateNumberAccountFondaDAOException(OrderAccountResources.MessageGenerateNumberAccountException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
    OrderAccountResources.SuccessMessageGenerateNumberAccount,
    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _length;
        }

        /// <summary>
        /// Metodo encargado de registrar el cierre de caja
        /// </summary>
        /// <param name="restaurantId">Id del Restaurante</param>
        /// <returns>El total acumulado en ese dia</returns>
        public float CloseCashRegister(int restaurantId)
        {

            IInvoiceDao _invoiceDAO = _facDAO.GetInvoiceDao();
            DateTime _day = DateTime.Now.Date;
            float totalInvoice = 0;
            try
            {
                Restaurant restaurant = Session.QueryOver<Restaurant>()
                    .Where(r => r.Id == restaurantId)
                    .Where(r => r.Status == ActiveSimpleStatus.Instance)
                    .SingleOrDefault();

                IList<Account> _dayOrders = new List<Account>();

                foreach (Account _order in restaurant.Accounts)
                {
                    if (_order.Date.Equals(_day) && _order.Status.Equals(ClosedAccountStatus.Instance))
                    {
                        Invoice _invoice = _invoiceDAO.FindGenerateInvoiceByAccount(_order.Id);
                        totalInvoice = _invoice.Total + totalInvoice;
                    }
                    else if (!_order.Date.Equals(_day) && _order.Status.Equals(ClosedAccountStatus.Instance))
                        totalInvoice = 0;
                }



            }
            catch (FondaIndexException ex)
            {
                CloseCashRegisterFondaDAOException exception =
       new CloseCashRegisterFondaDAOException(OrderAccountResources.MessageCloseCashRegisterException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                CloseCashRegisterFondaDAOException exception =
       new CloseCashRegisterFondaDAOException(OrderAccountResources.MessageCloseCashRegisterException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageCloseCashRegister,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return totalInvoice;
        }
    }
}
