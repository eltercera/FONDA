using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class EmployeeMap : SubclassMap<com.ds201625.fonda.Domain.Employee>
    {
        public EmployeeMap()
        {
            Table("EMPLOYEE");

            DiscriminatorValue(@"Employee");

            Map(x => x.Username)
                .Column("emp_username");

            References(x => x.UserAccount)
            .Column("fk_useraccount_id");

            References(x => x.Role)
               .Column("fk_role_employee");

          References(x => x.Restaurant)
               .Column("fk_restaurant_id");
        }
    }
}