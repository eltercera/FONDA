using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class DisableSimpleStatus
		: SubclassMap<com.ds201625.fonda.Domain.DisableSimpleStatus>
	{
		public DisableSimpleStatus ()
		{
			DiscriminatorValue (@"DisableSimpleStatus");
		}
	}
}

