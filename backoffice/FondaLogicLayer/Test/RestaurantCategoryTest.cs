using com.ds201625.fonda.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.LogicLayer.Test
{
    [TestFixture]
    public class RestaurantCategoryTest
    {
        RestaurantCategory category;
        [SetUp]
        public void Init()
        {
            category = new RestaurantCategory();
            //category.NameCategory = "Japonesa";
        }

        [Test]
        [Ignore("")]
        public void InsertNewCategory()
        {
            category = category.InsertNewCategory("Hola");
            Assert.AreEqual("Hola", category.Name);
        }
    }
}
