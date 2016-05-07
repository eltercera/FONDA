using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class CommensalMap
		: SubclassMap<com.ds201625.fonda.Domain.Commensal>
	{
		public CommensalMap ()
		{
			DiscriminatorValue (@"Commensal");

			References (x => x.SesionToken)
				.Column ("fk_token_id")
				.Nullable()
				.Cascade.All();

			HasMany (x => x.Profiles)
				.KeyColumn("fk_profile")
				.ExtraLazyLoad()
				.Cascade.All();

			// TODO: Mapedo Many-To-Many a Restaurant
			// TODO: Mapedo a Reservation
		}
	}
}

