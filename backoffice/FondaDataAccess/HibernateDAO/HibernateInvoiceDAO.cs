using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateInvoiceDAO : HibernateBaseEntityDAO<Invoice>, IInvoiceDao
    {
        public IList<Invoice> findAllInvoice(Profile profile)
        {
            ICriterion criterion = Expression.And(Expression.Eq("Profile", profile), Expression.Eq("Status", GeneratedInvoiceStatus.Instance));
            return FindAll(criterion);
        }
    }
}
