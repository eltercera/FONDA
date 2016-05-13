using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class EmployeeMap : ClassMap<com.ds201625.fonda.Domain.Employee>
    {
        public EmployeeMap()
        {
            Table("EMPLOYEE");

            Id(x => x.Id)
                .Column("emp_id")
                .Not.Nullable()
                .GeneratedBy.Increment();

            Map(x => x.Address)
             .Column("emp_address")
             .Not.Nullable();

            Map(x => x.PhoneNumber)
             .Column("emp_phoenumber")
             .Not.Nullable();

            Map(x => x.Ssn)
              .Column("emp_ssn")
              .Not.Nullable();

            Map(x => x.LastName)
                .Column("emp_lastname")
                .Not.Nullable();

            Map(x => x.Gender)
                .Column("emp_gender")
                .Not.Nullable();

            Map(x => x.BirthDate)
                .Column("emp_birthdate")
                .Not.Nullable();

            Map(x => x.Name)
                 .Column("emp_name")
                 .Not.Nullable();

            References(x => x.UserAccount)
                 .Column("fk_useraccount_id")
                 .Not.Nullable();
          
            References(x => x.Status)
        .Column("fk_simple_status_id")
        .Not.Nullable()
        .Cascade.Persist();
			
            References (x => x.Role)
                .Column("fk_rol_id")
                    .Not.Nullable()
                .Cascade.Persist();

        /*    References(x => x.Restaurant)
               .Column("fk_restaurant_id")
                   .Not.Nullable()
               .Cascade.Persist();
            */
        }
    }
}