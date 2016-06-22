using System;
using NHibernate;
using NHibernate.Criterion;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Factory;
using FondaResources.OrderAccount;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateOrderAccountDAO : HibernateBaseEntityDAO<Account>, IOrderAccountDao
    {
        private FactoryDAO.FactoryDAO _facDAO;
        private IRestaurantDAO _restaurantDAO;

        public HibernateOrderAccountDAO()
        {
            this._facDAO = FactoryDAO.FactoryDAO.Intance;
        }

        
        /// <summary>
        /// Obtiene la orden de un comensal
        /// </summary>
        /// <param name="commensal">Un objeto de tipo Commensal</param>
        /// <returns>Un objeto Account</returns>
        public Account FindByCommensal(Commensal commensal)
        {
            ICriterion criterion = Expression.And(Expression.Eq("Commensal", commensal), Expression.Eq("Status", OpenAccountStatus.Instance));
            try
            {
                return (Account)(FindAll(criterion)[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found order account", e);
            }
        }

        /// <summary>
        /// Obtiene las ordenes de un Restaurante
        /// </summary>
        /// <param name="restaurant">Un objeto de tipo Restaurant</param>
        /// <returns>Una lista de Account</returns>
        //public IList<Account> FindByRestaurant(Restaurant restaurant)
        //{
        //    ICriterion criterion = Expression.Eq("Status", OpenAccountStatus.Instance);
        //    try
        //    {
        //        IList<Account> list = new List<Account>();
        //        list = (FindAll(criterion));
        //        return list;
        //    }
        //    catch (ArgumentOutOfRangeException e)
        //    {
        //        throw new FondaIndexException("No se encontraron ordenes", e);
        //    }
        //}



        /// <summary>
        /// Obtiene Todas las ordenes de un Restaurante
        /// </summary>
        /// <param name="restaurant">Un objeto de tipo Restaurant</param>
        /// <returns>Una lista de Account</returns>
        public IList<Account> FindAllAccountByRestaurant(Restaurant _restaurant)
        {
            try
            {
                IList<Account> list = new List<Account>();
                list = _restaurant.Accounts;
                return list;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("No se encontraron ordenes", e);
            }
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
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

            try
            {
                _restaurant = _restaurantDAO.FindById(_idRestaurant);
                IList<Account> _list = new List<Account>();
                _list = _restaurant.Accounts;
                return _list;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
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
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("No se pudo cambiar el estatus", e);
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
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("No se pudo insertar", e);
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
                _account.ChangeStatus();
                // se le agrega la invoice a la cuenta
                _account.ListInvoice.Add(_invoice);
                //se salva la cuenta para registrar la nueva factura
                _accountDAO.Save(_account);
                //_restaurantDAO.Save(_restaurant);

                return _invoice;

            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("No se pudo insertar", e);
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
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
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
            catch (FondaIndexException e)
            {
                throw new FondaIndexException("No se puede cerrar caja con cuentas por pagar");
            }
        }
    }
}
