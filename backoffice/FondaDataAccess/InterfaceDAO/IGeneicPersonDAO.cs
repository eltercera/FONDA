using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IGeneicPersonDAO<GenericPerson> : INounBaseEntityDAO<GenericPerson>
	{
		GenericPerson FindBySsn (string ssn);
	}
}

