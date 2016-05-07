using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface ICommensalDAO : IUserAccountDAO
	{

		/// <summary>
		/// Obtiene una cuenta de usuario comensal por un token
		/// </summary>
		/// <returns>La cuenta de usuario Commensal.</returns>
		/// <param name="email">El token</param>
		Commensal FindByToken (string token);

	}
}

