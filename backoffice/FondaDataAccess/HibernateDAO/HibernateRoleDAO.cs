using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.Exceptions;
namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRoleDAO : HibernateNounBaseEntityDAO<Role>, IRoleDAO
    {
        public IList<Role> GetAll()
        {
            try
            {
                return FindAll();
            }
            catch (FindAllFondaDAOException e)
            {
                throw new GetAllRoleFondaDAOException(
                    "Excepción al consultar Lista de Roles ",
                    e);
            }
        }
    }
}
