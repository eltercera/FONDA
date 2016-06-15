using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate.Criterion;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.Factory;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateInvoiceDAO : HibernateBaseEntityDAO<Invoice>, IInvoiceDao
    {
        private FactoryDAO.FactoryDAO _facDAO;
        /// <summary>
        /// Obtiene todas las facturas
        /// </summary>
        /// <param name="profile">Un objeto de tipo Perfil</param>
        /// <returns>Un Lista de Invoice</returns>
        public IList<Invoice> findAllInvoice(Profile profile)
        {
            ICriterion criterion = Expression.And(Expression.Eq("Profile", profile), Expression.Eq("Status", GeneratedInvoiceStatus.Instance));
            return FindAll(criterion);
        }

        /// <summary>
        /// Obtiene las facturas de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Un objeto Invoice</returns>
        public IList<Invoice> FindInvoicesByAccount(Account _account)
        {
           try
            {
                IList<Invoice> _invoices = new List<Invoice>();
                _invoices = _account.ListInvoice;
                return _invoices;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
            }
        }

        /// <summary>
        /// Obtiene la factura genarda de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Un objeto Invoice</returns>
        public Invoice FindGenerateInvoiceByAccount(Account _account)
        {
            try
            {
                Invoice _invoice = new Invoice();

                if (_account.Status.Equals(ClosedAccountStatus.Instance))
                {
                    IList<Invoice> _invoices = new List<Invoice>();
                    _invoices = _account.ListInvoice;

                    foreach (var i in _invoices)
                    {
                        if (i.Status.Equals(GeneratedInvoiceStatus.Instance))
                        {
                            _invoice = i;
                        }
                    }
                }
                
                return _invoice;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
            }
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
            _listAccount = _accountDAO.FindAllAccountByRestaurant(_restaurant);
            ICriterion criterion =(Expression.Eq("Restaurant.Id", _restaurant.Id));
            Invoice _invoice;
            try
            {
                IList<Invoice> _listInvoiceByRestaurnat = new List<Invoice>();
                foreach (Account account in _listAccount)
                {
                    IList<Invoice> _list = new List<Invoice>();
                    _list = account.ListInvoice;
                    foreach (Invoice invoice in _list)
                    {
                        _invoice = (Invoice)EntityFactory.GetInvoice(invoice.Id,invoice.Payment, 
                            invoice.Profile,invoice.Tip, invoice.Total, invoice.Tax, invoice.Number);
                        _listInvoiceByRestaurnat.Add(_invoice);
                    }
                }


                return _listInvoiceByRestaurnat;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
            }
        }

        /// <summary>
        /// Obtiene el numero unico de la factura
        /// </summary>
        /// <param name="Restaurant">Un objeto Restaurant</param>
        /// <returns>Un int que es el numero unico del invoice</returns>

        public int GenerateNumberInvoice(Restaurant _restaurant)
        {
             try
            {
                IList<Invoice> _list = new List<Invoice>();
                _list = FindInvoicesByRestaurant(_restaurant);
                int _length = 0;

                if (!(_list==null))
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
    }
}
