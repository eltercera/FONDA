using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateTokenDAO : HibernateBaseEntityDAO<Token>, ITokenDAO
	{
        /// <summary>
        /// constructor de la clase HibernateTokenDAO
        /// </summary>
		public HibernateTokenDAO () { }

        /// <summary>
        /// Obtiene un Token por la propiedad StrToken
        /// </summary>
        /// <param name="property">propiedad</param>
        /// <param name="strToken">valor a buscar</param>
        /// <returns>retorna un token</returns>
		public Token FindByStrToken (string property, string strToken)
		{
            Token token = null;
            try
            {
                 token = FindBy(property, strToken);
            }
            catch (FindByIdFondaDAOException e)
            {
                throw new FindByStrTokenFondaDAOException(ResourceMessagesDAO.FindByFondaDAOExceptionProperty
                    + property + ResourceMessagesDAO.FindByFondaDAOExceptionValue + strToken, e);
            }
            return token;
		}
	}
}

