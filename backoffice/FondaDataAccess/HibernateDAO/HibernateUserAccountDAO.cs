using System;
using com.ds201625.fonda.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

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
            try
            {
                return FindBy("Email", email);
            }
            catch (FindByFondaDAOException e)
            {
                throw new FindByEmailUserAccountFondaDAOException(ResourceMessagesDAO.FindByEmailUserAccountFondaDAOException 
                    + email,e);
            }
            catch (Exception e)
            {
                throw new FindByEmailUserAccountFondaDAOException(ResourceMessagesDAO.FindByEmailUserAccountFondaDAOException
                   + email, e);
            }
		}

	}
}

