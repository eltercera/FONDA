using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate.Criterion;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateInvoiceDAO : HibernateBaseEntityDAO<Invoice>, IInvoiceDao
    {
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
        /// Obtiene la factura de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Un objeto Invoice</returns>
        public Invoice FindGenerateInvoiceByAccount(Account _account)
        {
            ICriterion criterion = Expression.And(Expression.Eq("Account.Id", _account.Id), Expression.Eq("Status", GeneratedInvoiceStatus.Instance));
            try
            {
                Invoice _invoice = new Invoice();
                _invoice = (Invoice)(FindAll(criterion)[0]);
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
        public IList<Invoice> FindInvoiceByRestaurant(Restaurant _restaurant)
        {
            ICriterion criterion =(Expression.Eq("Restaurant.Id", _restaurant.Id));
            try
            {
                IList<Invoice> _list = new List<Invoice>();
                _list = (FindAll(criterion));
                return _list;
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
                _list = FindInvoiceByRestaurant(_restaurant);
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
