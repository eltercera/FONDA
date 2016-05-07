using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess
{
	public class InsertedStatusMap
		: SubclassMap<com.ds201625.fonda.Domain.InsertedStatus>
	{
		public InsertedStatusMap ()
		{
			DiscriminatorValue (@"InsertedStatus");
		}
	}
}

