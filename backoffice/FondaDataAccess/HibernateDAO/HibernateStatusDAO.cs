using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateStatusDAO<T> : HibernateBaseEntityDAO<T>, IStatusDAO<T>
        where T: Status

	{

	}
}

