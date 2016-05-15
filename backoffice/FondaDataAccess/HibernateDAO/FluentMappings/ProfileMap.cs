using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class ProfileMap
		: ClassMap<com.ds201625.fonda.Domain.Profile>
	{
		public ProfileMap ()
		{
			Table ("PROFILE");

			Id (x => x.Id)
				.Column("pro_id")
				.Not.Nullable()
				.GeneratedBy.Increment();

			Map (x => x.ProfileName)
				.Column ("pro_profile_name")
				.Not.Nullable ();

			References (x => x.Person)
				.Column ("fk_person_id")
				.Unique ()
				.Not.LazyLoad ()
				.Not.Nullable ()
				.Cascade.All();

			References (x => x.Status)
				.Column ("fk_sinple_status_id")
				.Not.Nullable ()
				.Cascade.Persist();

		}
	}
}

