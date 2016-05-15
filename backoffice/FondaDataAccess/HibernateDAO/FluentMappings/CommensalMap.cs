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

			Map (x => x.SesionToken)
				.Column ("gp_email_c")
				.Nullable();

			HasMany (x => x.Profiles)
				.KeyColumn("fk_profile")
				.Inverse()
				.Cascade.All();

            // TODO: Mapedo Many-To-Many a Restaurant
            // TODO: Mapedo a Reservation
            
            HasManyToMany(x => x.FavoritesRestaurants)
                .Cascade.All()
                .ExtraLazyLoad()
                .Table("RESTAURANT_COMMENSAL");

        }
	}
}

