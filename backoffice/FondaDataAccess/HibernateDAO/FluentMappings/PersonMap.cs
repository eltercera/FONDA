using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class PersonMap 
		: SubclassMap<com.ds201625.fonda.Domain.Person>
	{
		public PersonMap ()
		{
			DiscriminatorValue(@"Person");

			Map (x => x.LastName)
				.Column ("per_last_name")
				.Not.Nullable();
			
			Map (x => x.Gender)
				.Column ("per_Gender")
				.Nullable();
			
			Map (x => x.BirthDate)
				.Column ("per_birt_date")
				.Nullable();
		}
	}
}

