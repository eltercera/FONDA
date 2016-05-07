using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Implementation
{
    public class RestaurantCategory : com.ds201625.fonda.Domain.RestaurantCategory
    {
        public RestaurantCategory()
        {

        }

        public RestaurantCategory InsertNewCategory(String nameCategory)
        {
            RestaurantCategory category = new RestaurantCategory();
            category.Name = nameCategory;

            return category;
        }

        public bool CategoryExist(String nameCategory)
        {
            List<String> _ListNameCategory;
            return true;
        }
    }
}
