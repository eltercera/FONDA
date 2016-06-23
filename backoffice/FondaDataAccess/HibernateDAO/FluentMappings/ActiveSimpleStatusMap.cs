using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class ActiveSimpleStatusMap
		: SubclassMap<com.ds201625.fonda.Domain.ActiveSimpleStatus>
	{
		public ActiveSimpleStatusMap ()
		{
			DiscriminatorValue (@"ActiveSimpleStatus");
		}
	}
}

