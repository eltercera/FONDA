using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackOfficeLogicTest.Restaurante
{
    class BOCommandCategoryTest
    {
        private FactoryDAO _facDAO;
        private IRestaurantCategoryDAO _restaurantCategoryDAO;

        [SetUp]
        public void init()
        {
            _facDAO = FactoryDAO.Intance;
        }

        [TearDown]
        public void clean()
        {
            _facDAO = null;
        }


    }
}
