using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
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
        private RestaurantCategory _restcat;
        private RestaurantCategory _restcatE;
        Object[] _modifylist;
        private string name;
        private string nameM;
        private int idCat;
        private Command _commandAddCategory;
        private Command _commandModifyCategory;
        private Command _commandSaveCategory;

        [SetUp]
        public void init()
        {
            _facDAO = FactoryDAO.Intance;
            _restaurantCategoryDAO = _facDAO.GetRestaurantCategoryDAO();
            _modifylist = new Object[2];
            _restcat = new RestaurantCategory();
            _restcatE = new RestaurantCategory();
            name = "Alemana";
            nameM = "Arabe";
            idCat = 5;
        }

        [TearDown]
        public void clean()
        {
            _facDAO = null;
        }

        #region Commands Test
        [Test]
        public void commandAddCategoryTest()
        {
            _commandAddCategory = CommandFactory.GetCommandAddCategory(name);
            _commandAddCategory.Execute();
            _restcat = (RestaurantCategory)_commandAddCategory.Receiver;
            _restcatE.Name = "Alemana";
            Assert.AreEqual(_restcat.Name, _restcatE.Name);

        }

        [Test]
        public void commandModifyCategory()
        {
            _modifylist[0] = idCat;
            _modifylist[1] = nameM;

            _commandModifyCategory = CommandFactory.GetCommandModifyCategory(_modifylist);
            _commandModifyCategory.Execute();
            _restcat = (RestaurantCategory)_commandModifyCategory.Receiver;
            _restcatE.Name = "Arabe";
            Assert.AreEqual(_restcat.Name, _restcatE.Name);
        }

        [Test]
        public void commandSaveCategoryTest()
        {
            _restcat = _restaurantCategoryDAO.FindById(2);

            _commandSaveCategory = CommandFactory.GetCommandSaveCategory(_restcat);
            _commandSaveCategory.Execute();

            _restcatE = _restaurantCategoryDAO.FindById(2);
            Assert.AreEqual(_restcatE.Name, _restcat.Name);
        }
        #endregion

        #region Exceptions Test
        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void AddCategoryNullExceptionTest()
        {
            _commandAddCategory = CommandFactory.GetCommandAddCategory(null);
            _commandAddCategory.Execute();

        }

        [ExpectedException(typeof(InvalidCastException))]
        [Test]
        public void AddCategoryInvalidExceptionTest()
        {
            _commandAddCategory = CommandFactory.GetCommandAddCategory(1325);
            _commandAddCategory.Execute();

        }

        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void ModifyCategoryNullExceptionTest()
        {
            _modifylist[0] = idCat;
            _commandModifyCategory = CommandFactory.GetCommandModifyCategory(_modifylist);
            _commandModifyCategory.Execute();
        }

        [ExpectedException(typeof(InvalidCastException))]
        [Test]
        public void ModifyCategoryInvalidExceptionTest()
        {
            _modifylist[0] = "prueba";
            _commandModifyCategory = CommandFactory.GetCommandModifyCategory(_modifylist);
            _commandModifyCategory.Execute();
        }

        #endregion 
    }
}
