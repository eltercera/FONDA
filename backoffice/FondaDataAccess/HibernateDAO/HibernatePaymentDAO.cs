using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernatePaymentDAO<T>: HibernateBaseEntityDAO<T>, IPaymentDao<T>
        where T: Payment
    {
		public T FindBySsn(string ssn)
        {
            return FindBy("Ssn", ssn);
        }
    }
}

