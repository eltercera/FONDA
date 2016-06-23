using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class CompanyMap 
		: SubclassMap<com.ds201625.fonda.Domain.Company>
	{
		public CompanyMap ()
		{
			DiscriminatorValue(@"Company");
		}
	}
}

