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

            Map(x => x.coordinate.)
              .Column("res_latitud")
              .Not.Nullable();

            References(x => x.Currency.Id)
              .Column("fk_res_currency")
              .Not.Nullable();

            References(x => x.Status)
                .Column("fk_cat_status")
                .Not.Nullable();

            References(x => x.RecordStatus)
              .Column("fk_cat_record")
              .Not.Nullable();

            HasMany(x => x.ListDish)
                .KeyColumn("fk_menu_dish")
                .Inverse()
                .Cascade.Persist();

        }
    }
}
