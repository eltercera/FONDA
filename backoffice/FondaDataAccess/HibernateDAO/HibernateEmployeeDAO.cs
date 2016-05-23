using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateEmployeeDAO : HibernateGenericPersonDAO<Employee>,IEmployeeDAO
    {
        public IList<Employee> GetAll()
        {
            try
            {
                return FindAll();
            }
            catch (FindAllFondaDAOException e)
            {
                throw new GetAllEmployeFondaDAOException(
                    "Excepción al consultar Lista de Employees ",
                    e);
            }
        }

        public Employee FindByusername(string user)
        {
            try
            {
                return FindBy("Username", user);
            }
            catch (FindByFondaDAOException e)
            {
                throw new FindByusernameEmployeFondaDAOException(
                    "Excepción al consultar UserName "+ user + " de un Employee",
                    e);
            }
            catch (Exception e)
            {
                throw new GetAllRoleFondaDAOException(
                    "Excepción al consultar UserName " + user + " de un Employee",
                    e);
            }
        }
    }
}
