using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
	public class DeletedStatusMap : 
		SubclassMap<com.ds201625.fonda.Domain.DeletedStatus>
	{
		public DeletedStatusMap ()
		{
			DiscriminatorValue (@"DeletedStatus");
		}
	}
}

