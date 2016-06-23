using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate.Criterion;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.Log;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    /// <summary>
    /// Clase que maneja los metodos relacionados con Invoice en la base de datos
    /// </summary>
    public class HibernateInvoiceDAO : HibernateBaseEntityDAO<Invoice>, IInvoiceDao
    {
        private FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

        /// <summary>
        /// Obtiene todas las facturas
        /// </summary>
        /// <param name="profile">Un objeto de tipo Perfil</param>
        /// <returns>Un Lista de Invoice</returns>
        public IList<Invoice> findAllInvoice(Profile profile)
        {
            ICriterion criterion;
            IList<Invoice> listInvoices;
            try
            {
                criterion = Expression.And(Expression.Eq("Profile", profile), Expression.Eq("Status", GeneratedInvoiceStatus.Instance));
                listInvoices = FindAll(criterion);
            }
            catch (Exception ex)
            {
                FindAllInvoiceFondaDAOException exception =
                    new FindAllInvoiceFondaDAOException(OrderAccountResources.MessagefindAllInvoiceException,
                    ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameInvoiceDAO,
                OrderAccountResources.SuccessMessagefindAllInvoice,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return listInvoices;
        }

        /// <summary>
        /// Obtiene las facturas de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Un objeto Invoice</returns>
        public IList<Invoice> FindInvoicesByAccount(int _accountId)
        {
            IOrderAccountDao _accountDAO;
            Account _account;
            IList<Invoice> _invoices;

           try
            {
                _accountDAO = _facDAO.GetOrderAccountDAO();
                _account = _accountDAO.FindById(_accountId);

                _invoices = new List<Invoice>();
                _invoices = _account.ListInvoice;
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                FindInvoicesByAccountFondaDAOException exception = new
                    FindInvoicesByAccountFondaDAOException(
                        OrderAccountResources.MessageFindInvoicesByRestaurantFondaDAOException,
                        ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch(Exception e)
            {
                FindInvoicesByAccountFondaDAOException exception = 
                    new FindInvoicesByAccountFondaDAOException
                    (OrderAccountResources.MessageFindInvoicesByAccountFondaDAOException, e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception; 

            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameInvoiceDAO,
                OrderAccountResources.SuccessMessageFindInvoicesByAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _invoices;
        }

        /// <summary>
        /// Genera la factura de una orden
        /// </summary>
        /// <param name="accountId">Id de la orden</param>
        /// <returns>Invoice generada</returns>
        public Invoice FindGenerateInvoiceByAccount(int accountId)
        {
            Invoice payInvoice = new Invoice();

            try
            {
                Account account = Session.QueryOver<Account>()
                    .Where(a => a.Id == accountId)
                    .Where(a => a.Status == ClosedAccountStatus.Instance)
                    .SingleOrDefault();

                foreach (Invoice invoice in account.ListInvoice)
                {
                    if (invoice.Status.Equals(GeneratedInvoiceStatus.Instance))
                    {
                        payInvoice = invoice;
                    }
                }


            }
            catch (ArgumentOutOfRangeException ex)
            {
                FindGenerateInvoiceByAccountFondaDAOException exception = new
                    FindGenerateInvoiceByAccountFondaDAOException(
                        OrderAccountResources.MessageFindInvoicesByRestaurantFondaDAOException,
                        ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch(Exception e)
            {
                FindGenerateInvoiceByAccountFondaDAOException exception =
                    new FindGenerateInvoiceByAccountFondaDAOException(
                        OrderAccountResources.MessageFindGenerateInvoiceByAccountFondaDAOException,
                        e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameInvoiceDAO,
                OrderAccountResources.SuccessMessageFindGenerateInvoiceByAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return payInvoice;
        }

        /// <summary>
        /// Obtiene la factura de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Un objeto Invoice</returns>
        public IList<Invoice> FindInvoicesByRestaurant(Restaurant _restaurant)
        {
            IOrderAccountDao _accountDAO;
            _facDAO = FactoryDAO.FactoryDAO.Intance;
            _accountDAO = _facDAO.GetOrderAccountDAO();
            IList<Account> _listAccount = new List<Account>();
            IList<Invoice> _listInvoiceByRestaurnat = new List<Invoice>();
            Invoice _invoice;
            try
            {
                _listAccount = _accountDAO.FindAccountByRestaurant(_restaurant.Id);
                ICriterion criterion =(Expression.Eq("Restaurant.Id", _restaurant.Id));
                
                foreach (Account account in _listAccount)
                {
                    IList<Invoice> _list = new List<Invoice>();
                    _list = account.ListInvoice;
                    foreach (Invoice invoice in _list)
                    {
                        _invoice = EntityFactory.GetInvoice(invoice.Id,invoice.Payment, 
                            invoice.Profile, invoice.Total, invoice.Tax, invoice.Currency, invoice.Number);
                        _listInvoiceByRestaurnat.Add(_invoice);
                    }
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                FindInvoicesByRestaurantFondaDAOException exception = new
                    FindInvoicesByRestaurantFondaDAOException(
                        OrderAccountResources.MessageFindInvoicesByRestaurantFondaDAOException,
                        ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (FindAccountByRestaurantFondaDAOException ex)
            {
                FindInvoicesByRestaurantFondaDAOException exception = new
                    FindInvoicesByRestaurantFondaDAOException(
                        OrderAccountResources.MessageFindInvoicesByRestaurantFondaDAOException,
                        ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception ex)
            {
                FindInvoicesByRestaurantFondaDAOException exception = new 
                    FindInvoicesByRestaurantFondaDAOException(
                        OrderAccountResources.MessageFindInvoicesByRestaurantFondaDAOException,
                        ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameInvoiceDAO,
                OrderAccountResources.SuccessMessageFindInvoicesByRestaurant,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            return _listInvoiceByRestaurnat;
        }

        /// <summary>
        /// Obtiene el numero unico de la factura
        /// </summary>
        /// <param name="Restaurant">Un objeto Restaurant</param>
        /// <returns>Un int que es el numero unico del invoice</returns>

        public int GenerateNumberInvoice(Restaurant _restaurant)
        {
            int _length = 0;
             try
            {
                IList<Invoice> _list = new List<Invoice>();
                _list = FindInvoicesByRestaurant(_restaurant);

                if (!(_list==null))
                {
                    _length = _list.Count;
                    _length = _length + 1;
                }
                
            }
            catch (ArgumentOutOfRangeException e)
            {
                GenerateNumberInvoiceFondaDAOException exception =
                    new GenerateNumberInvoiceFondaDAOException
                    (OrderAccountResources.MessageGenerateNumberInvoiceFondaDAOException,
                    e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (FindInvoicesByRestaurantFondaDAOException e)
            {
                GenerateNumberInvoiceFondaDAOException exception =
                    new GenerateNumberInvoiceFondaDAOException
                    (OrderAccountResources.MessageGenerateNumberInvoiceFondaDAOException,
                    e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception e)
            {
                GenerateNumberInvoiceFondaDAOException exception =
                    new GenerateNumberInvoiceFondaDAOException
                    (OrderAccountResources.MessageGenerateNumberInvoiceFondaDAOException,
                    e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameInvoiceDAO,
                OrderAccountResources.SuccessMessageFindGenerateInvoiceByAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            return _length;
        }
    }
}
