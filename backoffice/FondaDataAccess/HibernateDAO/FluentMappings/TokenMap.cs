using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess
{
	public class TokenMap
		: ClassMap<com.ds201625.fonda.Domain.Token>
	{
		public TokenMap ()
		{
			Table ("TOKEN");

			Id (x => x.Id)
				.Column("tok_id")
				.Not.Nullable()
				.GeneratedBy.Increment();

			Map (x => x.StrToken)
				.Column("tok_str_token")
				.Not.Nullable()
				.Unique();

			Map (x => x.Created)
				.Column ("tok_created")
				.Not.Nullable ();

			Map (x => x.Expiration)
				.Column ("tok_expiration")
				.Not.Nullable ();

			References (x => x.Commensal);


		}
	}
}

