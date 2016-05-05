using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class MenuCategoryMap : ClassMap<com.ds201625.fonda.Domain.MenuCategory>
    {
        public MenuCategoryMap()
        {
            Table("MENUCATEGORY");

            Id(x => x.Id)
              .Column("cat_menu_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("cat_menu_name")
              .Not.Nullable();

            References(x => x.Status)
                .Column("cat_menu_status")
                .Not.Nullable();

            References(x => x.RecordStatus)
              .Column("cat_menu_status")
              .Not.Nullable();

            HasMany(x => x.ListDish)
                .KeyColumn("fk_menu_dish")
                .Inverse()
                .Cascade.Persist();

        }
    }
}
