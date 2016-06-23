using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class UserAccountMap
		: ClassMap<com.ds201625.fonda.Domain.UserAccount>
	{
		public UserAccountMap ()
		{

			Table ("USER_ACCOUNT");

			Id (x => x.Id)
				.Column("ua_id")
				.Not.Nullable()
				.GeneratedBy.Increment();

			DiscriminateSubClassesOnColumn ("ua_type")
				.Not.Nullable ();

			Map (x => x.Email)
				.Column ("gp_email")
				.Unique()
				.Not.Nullable ();

			Map (x => x.Password)
				.Column ("gp_password")
				.Not.Nullable ();

		}
	}
}

