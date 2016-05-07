using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class DayMap : ClassMap<com.ds201625.fonda.Domain.MenuCategory>
    {
        public DayMap()
        {
            Table("DAY");

            Id(x => x.Id)
              .Column("day_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("day_name")
              .Not.Nullable();

        }
    }
}
