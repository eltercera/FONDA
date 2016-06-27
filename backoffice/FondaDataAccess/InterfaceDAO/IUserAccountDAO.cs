using System;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IUserAccountDAO : IBaseEntityDAO <UserAccount>
	{
		/// <summary>
		/// Obtiene una cuenta de usuario por su Email
		/// </summary>
		/// <param name="email">Email.</param>
		/// <returns>La cuenta de usuario.</returns>
		UserAccount FindByEmail (string email);

        /// <summary>
		/// Obtiene todas las cuentas de usuario
		/// </summary>
		/// <returns>List UserAccount.</returns>
        IList<UserAccount> GetAll();

	}
}

