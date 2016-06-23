using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class DishOrderMap : ClassMap<com.ds201625.fonda.Domain.DishOrder>
    {
        public DishOrderMap()
        {
            Table("DISH_ORDER");

            Id(x => x.Id)
                .Column("do_id")
                .Not.Nullable()
                .GeneratedBy.Increment();

            Map(x => x.Count)
                .Column("do_count")
                .Not.Nullable();

            References(x => x.Dish)
                .Column("fk_dish_id")
                .Not.LazyLoad()
                .Cascade.Delete()
                .Not.Nullable();

        }
    }
}
