using System;
using com.ds201625.fonda.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateUserAccountDAO
		: HibernateBaseEntityDAO<UserAccount>,IUserAccountDAO
	{
		/// <summary>
		/// Obtiene una cuenta de usuario por su Email
		/// </summary>
		/// <param name="email">Email.</param>
		/// <returns>La cuenta de usuario.</returns>
		public UserAccount FindByEmail (string email)
		{
			return FindBy("Email", email);
		}

	}
}

