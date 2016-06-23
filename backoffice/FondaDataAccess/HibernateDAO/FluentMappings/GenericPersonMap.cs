using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class GenericPersonMap 
		: ClassMap<com.ds201625.fonda.Domain.GenericPerson>
	{
		public GenericPersonMap ()
		{
			Table ("GENERIC_PERSON");

			Id (x => x.Id)
				.Column("gp_id")
				.Not.Nullable()
				.GeneratedBy.Increment();

			DiscriminateSubClassesOnColumn ("gp_type")
				.Not.Nullable ();

			Map (x => x.Name)
				.Column ("gp_name")
				.Not.Nullable ();
			
			Map (x => x.Address)
				.Column ("gp_address")
				.Nullable ();
			
			Map (x => x.PhoneNumber)
				.Column ("gp_phone_number")
				.Nullable ();
			
			Map (x => x.Ssn)
				.Column ("gp_ssn")
				.Not.Nullable ();

			References (x => x.Status)
				.Column ("fk_sinple_status_id")
				.Not.Nullable ()
				.Cascade.Persist();
			

		}
	}
}

