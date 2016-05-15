using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IPaymentDao<T> : IBaseEntityDAO <T>
            where T : Payment
    {       
		T FindBySsn(string Ssn);
    }
}

