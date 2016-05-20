using System;
using NHibernate;
using NHibernate.Criterion;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateOrderAccountDAO : HibernateBaseEntityDAO<Account>, IOrderAccountDao
    {
        public Account FindByCommensal(Commensal commensal)
        {
            ICriterion criterion = Expression.And(Expression.Eq("Commensal", commensal), Expression.Eq("Status", OpenAccountStatus.Instance));
            return (Account) (FindAll(criterion)[0]);
        }
    }
}
