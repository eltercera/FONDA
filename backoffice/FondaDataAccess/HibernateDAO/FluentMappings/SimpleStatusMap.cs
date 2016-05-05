using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class SimpleStatusMap
		: SubclassMap<com.ds201625.fonda.Domain.SimpleStatus>
	{
		public SimpleStatusMap ()
		{
			DiscriminatorValue (@"SimpleStatus");
		}
	}
}

