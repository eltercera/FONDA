using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class RestaurantMap : ClassMap<com.ds201625.fonda.Domain.Restaurant>
    {
        public RestaurantMap()
        {
            Table("RESTAURANT");

            Id(x => x.Id)
              .Column("res_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Logo)
              .Column("res_logo")
              .Not.Nullable();

            References(x => x.Status)
                .Column("res_status")
                .Not.Nullable();

            References(x => x.coordinate.Id)
              .Column("fk_res_coordinate")
              .Not.Nullable();

            References(x => x.Currency.Id)
              .Column("fk_res_currency")
              .Not.Nullable();

            References(x => x.RestaurantCategory.Id)
               .Column("fk_res_restaurantCategory")
               .Not.Nullable();

            References(x => x.Zone.Id)
               .Column("fk_res_zone")
               .Not.Nullable();

            References(x => x.Schedule)
               .Column("fk_res_schedule")
               .Not.Nullable();

        }
    }
}
