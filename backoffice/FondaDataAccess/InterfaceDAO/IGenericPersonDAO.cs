using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IGenericPersonDAO<T> : INounBaseEntityDAO<T> 
        where T : GenericPerson
	{
		T FindBySsn (string ssn);
	}
}

