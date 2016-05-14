using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateActiveSimpleStatus : 
		HibernateStatusDAO<ActiveSimpleStatus>, IActiveSimpleStatusDAO
	{
		public HibernateActiveSimpleStatus () { }

		public ActiveSimpleStatus getActiveSimpleStatus()
		{
			ActiveSimpleStatus status = FindById (1);
			if (status == null)
			{
				status = ActiveSimpleStatus.Instance;
				Save (status);
			}

			return status;
		}

	}
}

