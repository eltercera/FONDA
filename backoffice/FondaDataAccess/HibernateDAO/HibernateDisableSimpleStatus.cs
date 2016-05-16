using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateDisableSimpleStatus : 
		HibernateStatusDAO<DisableSimpleStatus>, IDisableSimpleStatusDAO
	{
		public HibernateDisableSimpleStatus () { }

		public DisableSimpleStatus getDisableSimpleStatus()
		{
			DisableSimpleStatus status = FindById (2);
			if (status == null)
			{
				status = DisableSimpleStatus.Instance;
				Save (status);
			}

			return status;
		}

	}
}

