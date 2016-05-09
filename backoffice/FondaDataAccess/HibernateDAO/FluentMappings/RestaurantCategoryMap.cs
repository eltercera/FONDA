using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class RestaurantCategoryMap : ClassMap<com.ds201625.fonda.Domain.RestaurantCategory>
    {
        public RestaurantCategoryMap()
        {
            Table("RESTAURANTCATEGORY");

            Id(x => x.Id)
              .Column("res_cat_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("fk_res_cat_name")
              .Not.Nullable();

        }
    }
}
