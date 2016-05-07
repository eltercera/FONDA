using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateTokenDAO : HibernateBaseEntityDAO<Token>, ITokenDAO
	{
		public HibernateTokenDAO () { }

		public Token FindByStrToken (string strToken)
		{
			return FindBy ("StrToken", strToken);
		}
	}
}

