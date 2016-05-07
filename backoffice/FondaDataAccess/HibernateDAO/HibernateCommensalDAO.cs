using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;


namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateCommensalDAO : HibernateUserAccountDAO,ICommensalDAO
	{

		/// <summary>
		/// Obtiene una cuenta de usuario comensal por un token
		/// </summary>
		/// <returns>La cuenta de usuario Commensal.</returns>
		/// <param name="email">El token</param>
		public Commensal FindByToken (string token)
		{
			ITokenDAO tokDAO = FactoryDAO.FactoryDAO.Intance.GetTokenDAO();

			Token tk = tokDAO.FindByStrToken (token);

			if (tk == null)
				return null;

			return (Commensal)FindBy ("SesionToken", tk);
		}

	}
}

