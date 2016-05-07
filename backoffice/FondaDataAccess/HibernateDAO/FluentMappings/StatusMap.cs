using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class StatusMap : ClassMap<com.ds201625.fonda.Domain.Status>
	{
		public StatusMap () 
		{
			Table ("STATUS");

			Id (x => x.StatusId)
				.Column("sta_id")
				.Not.Nullable()
				.GeneratedBy.Assigned();

			DiscriminateSubClassesOnColumn ("sta_type")
				.Not.Nullable ()
				.Unique();

			Map (x => x.Description)
				.Column ("sta_description");
			
		}
	}
}

