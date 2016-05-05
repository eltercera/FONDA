using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class EntityRecordStatusMap
		: SubclassMap<com.ds201625.fonda.Domain.EntityRecordStatus>
	{
		public EntityRecordStatusMap ()
		{
			DiscriminatorValue (@"EntityRecordStatus");
		}
	}
}

