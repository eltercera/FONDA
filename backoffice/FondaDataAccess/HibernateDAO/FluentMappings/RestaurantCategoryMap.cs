using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class RestaurantCategoryMap : ClassMap<com.ds201625.fonda.Domain.RestaurantCategory>
    {
        public RestaurantCategoryMap()
        {
            Table("RESTAURANT_CATEGORY");

            Id(x => x.Id)
              .Column("rc_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("rc_name")
              .Not.Nullable();

        }
    }
}
