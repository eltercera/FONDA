using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateStatusDAO : HibernateBaseEntityDAO<Status>, IStatusDAO
	{
		public Status FindByStatusId (int id)
		{
			return FindById (id);
		}
	}
}

