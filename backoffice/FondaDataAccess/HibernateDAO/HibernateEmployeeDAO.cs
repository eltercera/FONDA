using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateEmployeeDAO : HibernateGenericPersonDAO<Employee>,IEmployeeDAO
    {
        public IList<Employee> GetAll()
        {
            return FindAll();
        }

        public Employee FindByusername(string user)
        {
            return FindBy("Username", user);
        }
    }
}
