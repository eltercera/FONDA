using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic;
using FondaLogic.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackOfficeLogicTest
{
    class BOCommandLoginTest
    {
        private FactoryDAO _facDAO;
        private IUserAccountDAO _userAcountDAO;
        private IRoleDAO _roleDAO;
        private IEmployeeDAO _employeeDAO;
        private static UserAccount _userAcount;
        private static Employee _employee;
        private DateTime _employeeBirthDate = Convert.ToDateTime("03/09/1992");
        private int _userAcountId = 0;
        private Command _commandSaveUserAccount;
        private Command _commandFindUserbyEmail;
        private Command _commandSaveEmployee;
        private Command _commandFindEmployeebyId;
        private Command _commandFindEmployeebyUser;
        private Command _commandFindAllRoles;

        [Test]
        public void InitUserAccount()
        {
            generateUserAccount();
            Assert.AreEqual(_userAcount.Email, "fondauser2@gmail.com");
            Assert.AreEqual(_userAcount.Password, "abc123ghj54");
            Assert.AreEqual(_userAcount.Status.StatusId.ToString(), "1");
            
        }

        [Test]
        public void InitEmployee()
        {
            
            generateEmployee();
            Assert.AreEqual( _employee.Name ,"Rafael" );
            Assert.AreEqual( _employee.LastName ,"Jimenez" );
            Assert.AreEqual( _employee.Ssn , "242871509" );
            Assert.AreEqual( _employee.PhoneNumber , "0424-248-63-95" );
            Assert.AreEqual( _employee.Address , "Los Samanes" );
            Assert.AreEqual( _employee.Gender , 'M');
            //Assert.AreEqual( _employee.BirthDate , "1992-09-03 00:00:00.000");
            Assert.AreEqual( _employee.Username , "rejimenez.12" );
            //Assert.AreEqual( _employee.Role , "Caja" );
            Assert.AreEqual(_employee.Status.StatusId.ToString() , "1");
            
            


        }

        public void generateUserAccount()
        {
            _userAcount = new UserAccount();
            _userAcount.Email = "fondauser2@gmail.com";
            _userAcount.Password = "abc123ghj54";
            _userAcount.Status = ActiveSimpleStatus.Instance;

        }


        public void generateEmployee()
        {
            _employee = new Employee();

            _employee.Name = "Rafael";
            _employee.LastName = "Jimenez";
            _employee.Ssn = "242871509";
            _employee.PhoneNumber = "0424-248-63-95";
            _employee.Address = "Los Samanes";
            _employee.Gender = 'M';
            _employee.BirthDate = _employeeBirthDate;
            _employee.Username = "rejimenez.12";
            _employee.UserAccount = _userAcount;
            //_employee.Role = _roleDAO.FindById(1);
            _employee.Status = ActiveSimpleStatus.Instance;
            
        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        private void getRoleDao()
        {
            getDao();
            if (_roleDAO == null)
                _roleDAO = _facDAO.GetRoleDAO();

        }
        
        [Test]
        //[ExpectedException(typeof(NullReferenceException))]
        public void CommandUserAccountTest()
        {

            _commandSaveUserAccount = CommandFactory.GetCommandSaveEntity(_userAcount);
            _commandSaveUserAccount.Execute();
            
            _commandFindUserbyEmail = CommandFactory.GetComandoGetUserAcountByEmail(_userAcount.Email);
            _commandFindUserbyEmail.Execute();
            UserAccount _userTest = (UserAccount)_commandFindUserbyEmail.Receiver;
            Assert.AreEqual( _userTest.Email , "fondauser2@gmail.com" );
            Assert.AreEqual( _userTest.Password , "abc123ghj54" );
            //Assert.AreEqual( _userTest.Status.StatusId.ToString() , "1" );

        }

        [Test]
        public void CommandEmployeeTest()
        {
            _commandSaveEmployee = CommandFactory.GetCommandSaveEmployee(_employee);
            _commandSaveEmployee.Execute();
            Assert.AreNotEqual(_employee,null);
            Assert.AreNotEqual(_employee.Id , 0);
 
        }

        [Test]
        public void CommandEmployeeByIdTest()
        {
            Assert.AreNotEqual(_employee,null);
            /*_commandFindEmployeebyId = CommandFactory.GetCommandGetEmployeeById(_employee.Id);
            _commandFindEmployeebyId.Execute();
            Employee employeeTest = (Employee)_commandFindEmployeebyId.Receiver;
            Assert.AreEqual(employeeTest.Name, "Rafael");
            Assert.AreEqual(employeeTest.LastName, "Jimenez");
            Assert.AreEqual(employeeTest.Ssn, "242871509");
            Assert.AreEqual(employeeTest.PhoneNumber, "0424-248-63-95");
            Assert.AreEqual(employeeTest.Address, "Los Samanes");
            Assert.AreEqual(employeeTest.Gender, 'M');
            //Assert.AreEqual(employeeTest.BirthDate, "03-09-1992");
            Assert.AreEqual(employeeTest.Username, "rejimenez.12");
            //Assert.AreEqual(employeeTest.Role, "Caja");
            Assert.AreEqual(employeeTest.Status.StatusId.ToString(), "1");
            */

        }

        [Test]
        //[ExpectedException(typeof(NullReferenceException))]
        public void CommandEmployeeByUserTest()
        {

            _commandFindEmployeebyUser = CommandFactory.GetCommandGetEmployeeByUser(_employee.Username);
            _commandFindEmployeebyUser.Execute();
            Employee employeeTest = (Employee)_commandFindEmployeebyUser.Receiver;
            Assert.AreEqual(employeeTest.Name, "Rafael");
            Assert.AreEqual(employeeTest.LastName, "Jimenez");
            Assert.AreEqual(employeeTest.Ssn, "242871509");
            Assert.AreEqual(employeeTest.PhoneNumber, "0424-248-63-95");
            Assert.AreEqual(employeeTest.Address, "Los Samanes");
            Assert.AreEqual(employeeTest.Gender, 'M');
           // Assert.AreEqual(employeeTest.BirthDate, "03-09-1992");
            Assert.AreEqual(employeeTest.Username, "rejimenez.12");
            //Assert.AreEqual(employeeTest.Role, "Caja");
            Assert.AreEqual(employeeTest.Status.StatusId.ToString(), "1");

        }

        [Test]
        public void CommandRolTest()
        {
            _commandFindAllRoles = CommandFactory.GetCommandGetAllRoles("null");
            _commandFindAllRoles.Execute();
            List<Role> _role = (List<Role>)_commandFindAllRoles.Receiver;

            foreach (Role item in _role)
            {
                if (item.Id == 1)
                {
                    Assert.AreEqual( item.Id , 1 );
                    Assert.AreEqual( item.Name , "Caja" );
                    Assert.AreEqual(item.Descripcion, "Es el encargado de llevar toda la gestión de Caja");

                    
                }
                else if (item.Id == 2)
                {
                    Assert.AreEqual(item.Id, 2);
                    Assert.AreEqual(item.Name, "Restaurante");
                    Assert.AreEqual(item.Descripcion, "Es el encargado a todo lo referente a la labor interna del restaurante");
                    

                }
                else if (item.Id == 3)
                {
                    Assert.AreEqual(item.Id, 3);
                    Assert.AreEqual(item.Name, "Sistema");
                    Assert.AreEqual(item.Descripcion, "Es el encargado de la gestión de restaurantes");
                    

                }


            }



        }


        /*  /// <summary>
          /// prueba unitaria de excepcion de parametros invalidos
          /// </summary>
          [Test]
          //[ExpectedException(typeof(InvalidTypeOfParameterException))]
          public void CreateFavoriteRestaurantCommandBadParameter0Test()
          {

          }

          /// <summary>
          /// prueba unitaria de excepcion de parametros invalidos
          /// </summary>
          [Test]
          //[ExpectedException(typeof(RequieredParameterNotFoundException))]
          public void CreateFavoriteRestaurantCommandRequieredParametersTest()
          {

          }*/
        private void getUserAcountDao()
        {
            getDao();
            if (_userAcountDAO == null)
                _userAcountDAO = _facDAO.GetUserAccountDAO();

        }
        private void getEmployeeDao()
        {
            getDao();
            if (_employeeDAO == null)
                _employeeDAO = _facDAO.GetEmployeeDAO();

        }

        [Test]
        public void finishTest()
        {
            getEmployeeDao();
            getUserAcountDao();
            _employeeDAO.Delete(_employee);
            Assert.AreEqual(_userAcount.Email,"fondauser2@gmail.com");
            _userAcountDAO.Delete(_userAcount);
            //_employee = null;
            //Assert.AreEqual( _employee , null );
            _employee = null;
            _userAcount = null;
            Assert.AreEqual( _employee , null );
            Assert.AreEqual( _userAcount , null );
        }

    }
}
