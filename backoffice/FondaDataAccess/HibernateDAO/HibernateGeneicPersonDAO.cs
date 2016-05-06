using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateGeneicPersonDAO<T>
		: HibernetNounBaseEntityDAO<T>,IGeneicPersonDAO<T>
		where T : GenericPerson
	{
		public T FindBySsn (string ssn)
		{
			return FindBy ("Ssn", ssn);
		}
	}
}

