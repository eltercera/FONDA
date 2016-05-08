using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateGeneicPersonDAO<GenericPerson>
		: HibernetNounBaseEntityDAO<GenericPerson>,IGeneicPersonDAO<GenericPerson>
	{
		public GenericPerson FindBySsn (string ssn)
		{
			return FindBy ("Ssn", ssn);
		}
	}
}

