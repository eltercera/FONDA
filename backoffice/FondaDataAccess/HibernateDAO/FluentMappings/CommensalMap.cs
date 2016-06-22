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

			HasMany (x => x.Profiles)
				.KeyColumn("fk_commensal_id")
				.ExtraLazyLoad()
				.Cascade.All();

			HasMany (x => x.SesionTokens)
				.LazyLoad ()
				.Inverse()
				.Cascade.AllDeleteOrphan();
            
            HasManyToMany(x => x.FavoritesRestaurants)
                .Cascade.All()
                .ExtraLazyLoad()
                .Table("RESTAURANT_COMMENSAL");

            #region Reservation

            HasMany(x => x.Reservations)
                .KeyColumn("fk_commensal_reservations")
                .ExtraLazyLoad()
                .Cascade.All();

            #endregion

        }
    }
}

