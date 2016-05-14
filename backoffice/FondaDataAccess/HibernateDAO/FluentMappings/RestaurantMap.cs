using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class RestaurantMap : ClassMap<com.ds201625.fonda.Domain.Restaurant>
    {
        public RestaurantMap()
        {
            Table("RESTAURANT");

            Id(x => x.Id)
              .Column("res_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
                .Column("res_name")
                .Not.Nullable();

            Map(x => x.Nationality)
                .Column("res_name")
                .Not.Nullable();

            Map(x => x.Ssn)
                .Column("res_rif")
                .Not.Nullable();

            Map(x => x.Address)
                .Column("res_address");                

            Map(x => x.Logo)
              .Column("res_logo")
              .Not.Nullable();

            References(x => x.Status)
                .Column("res_status")
                .Not.Nullable()
                .Cascade.Persist();

            References(x => x.Coordinate)
              .Column("fk_res_coordinate")
              .Not.Nullable()
              .Cascade.Persist();

            References(x => x.Currency)
              .Column("fk_res_currency")
              .Not.Nullable()
              .Cascade.Persist();

            References(x => x.RestaurantCategory)
               .Column("fk_res_restaurantCategory")
               .Not.Nullable()
               .Cascade.Persist();

           /* References(x => x.Zone)
               .Column("fk_res_zone")
               .Not.Nullable();*/

            References(x => x.Schedule)
               .Column("fk_res_schedule")
               .Not.Nullable()
               .Cascade.Persist();

            HasMany(x => x.MenuCategories)
                .KeyColumn("fk_res_mencat")
                .ExtraLazyLoad()
                .Cascade.All();

           /* HasMany(x => x.Employees)
                .KeyColumn("fk_res_employee")
                .ExtraLazyLoad()
                .Cascade.All();
                */
            HasMany(x => x.Tables)
                .KeyColumn("fk_res_table")
                .ExtraLazyLoad()
                .Cascade.All();
                

        }
    }
}
