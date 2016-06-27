using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackOfficeLogicTest
{
    class BODAOLogin
    {
        
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IUserAccountDAO _userAcountDAO;
        private IRoleDAO _roleDAO;
        private IEmployeeDAO _employeeDAO;
        private static UserAccount _userAcount;
        private static Employee _employee;
        private DateTime _employeeBirthDate = Convert.ToDateTime("03/09/1992");
        private int _userAcountId = 0;



        /// <summary>
        /// Void: aInitUserAccount()
        /// Explicación: Se llama al metodo generateUserAccount() para asi instanciar un objeto de tipo
        /// UserAccount con todos los datos de prueba.
        /// </summary>

        [Test]
        public void aInitUserAccount()
        {
            generateUserAccount();
            Assert.AreNotEqual(_userAcount, null);
            Assert.AreEqual(_userAcount.Email, "fondauser2@gmail.com");
            Assert.AreEqual(_userAcount.Password, "abc123ghj54");
            Assert.AreEqual(_userAcount.Status.StatusId.ToString(), "1");

        }

        /// <summary>
        /// Void: bInitEmployee()
        /// Explicación: Se llama al metodo generateEmployee() para asi instanciar un objeto de tipo
        /// Employee con todos los datos de prueba.
        /// </summary>

        [Test]
        public void bInitEmployee()
        {

            generateEmployee();
            Assert.AreNotEqual(_employee, null);
            Assert.AreEqual(_employee.Name, "Rafael");
            Assert.AreEqual(_employee.LastName, "Jimenez");
            Assert.AreEqual(_employee.Ssn, "242871509");
            Assert.AreEqual(_employee.PhoneNumber, "0424-248-63-95");
            Assert.AreEqual(_employee.Address, "Los Samanes");
            Assert.AreEqual(_employee.Gender, 'M');
            Assert.AreEqual(_employee.Username, "rejimenez.12");
            Assert.AreEqual(_employee.Status.StatusId.ToString(), "1");




        }

        /// <summary>
        /// Void: generateUserAccount()
        /// Explicación: Metodo que instancia un objeto de tipo UserAccount y lo inicializa con
        /// valores de prueba.
        /// </summary>

        public void generateUserAccount()
        {
            _userAcount = new UserAccount();
            _userAcount.Email = "fondauser2@gmail.com";
            _userAcount.Password = "abc123ghj54";
            _userAcount.Status = ActiveSimpleStatus.Instance;

        }

        /// <summary>
        /// Void: generateEmployee()
        /// Explicación: Metodo que instancia un objeto de tipo Employee y lo inicializa con
        /// valores de prueba.
        /// </summary>

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

        /// <summary>
        /// Void: getDao()
        /// Explicación: Se llama a la fabrica de dao para instanciarla.
        /// </summary>


        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        /// <summary>
        /// Void: getRoleDao()
        /// Explicación: Se llama a la fabrica dao de roles para instanciarla.
        /// </summary>

        private void getRoleDao()
        {
            getDao();
            if (_roleDAO == null)
                _roleDAO = _facDAO.GetRoleDAO();

        }

        /// <summary>
        /// Void: UserAccountDAOTest()
        /// Explicación: Se llama a la fabrica de comandos para instanciar el DAO de userccount
        /// y guardar un objeto de tipo UserAccount luego se
        ///  verificar si ese dato se guardo correctamente
        /// y probarlo con el dao de useraccount .
        /// </summary>

        [Test]
        public void cUserAccountDAOTest()
        {
            _userAcountDAO = _facDAO.GetUserAccountDAO();
            _userAcountDAO.Save(_userAcount);
            Assert.AreNotEqual(_userAcount, null);
            Assert.AreNotEqual(_userAcount.Id, 0);
            /*_commandFindUserbyEmail = CommandFactory.GetComandoGetUserAcountByEmail(_userAcount.Email);
            _commandFindUserbyEmail.Execute();*/
            UserAccount _userTest = (UserAccount)_userAcountDAO.FindByEmail(_userAcount.Email);

            Assert.AreEqual(_userTest.Email, "fondauser2@gmail.com");
            Assert.AreEqual(_userTest.Password, "abc123ghj54");
            Assert.AreEqual(_userTest.Status.StatusId.ToString(), "1");

        }

        /// <summary>
        /// Void: EmployeeDAOTest()
        /// Explicación: Se guardar un objeto de tipo Employee luego se 
        /// verificar si ese dato se guardo correctamente
        /// y probarlo., se utilizan metodos del EmployeeDAO para guardar el empleado 
        /// y buscarlo
        /// /// NOTA: Para poder traer los datos obtenidos por el DAO debes guardalo
        /// en una variable de tipo Employee y que sea igual al atributo  casteado.
        /// </summary>

        [Test]
        public void dEmployeeDAOTest()
        {

            _employeeDAO = _facDAO.GetEmployeeDAO();
            _employeeDAO.Save(_employee);
            Assert.AreNotEqual(_employee, null);
            Assert.AreNotEqual(_employee.Id, 0);


            Employee employeeTest =  _employeeDAO.FindById(_employee.Id);
            Assert.AreEqual(employeeTest.Name, "Rafael");
            Assert.AreEqual(employeeTest.LastName, "Jimenez");
            Assert.AreEqual(employeeTest.Ssn, "242871509");
            Assert.AreEqual(employeeTest.PhoneNumber, "0424-248-63-95");
            Assert.AreEqual(employeeTest.Address, "Los Samanes");
            Assert.AreEqual(employeeTest.Gender, 'M');
            Assert.AreEqual(employeeTest.Username, "rejimenez.12");
            Assert.AreEqual(employeeTest.Status.StatusId.ToString(), "1");



        }

        /// <summary>
        /// Void: EmployeeDAOByUserTest()
        /// Explicación: Se guardar un objeto de tipo Employee luego se 
        /// verificar si ese dato se guardo correctamente
        /// y probarlo., se utilizan metodos del EmployeeDAO para guardar el empleado 
        /// y buscarlo
        /// /// NOTA: Para poder traer los datos obtenidos por el DAO debes guardalo
        /// en una variable de tipo Employee y que sea igual al atributo  casteado, en este caso se busco 
        /// por el username del dao.
        /// </summary>

        [Test]

        public void EmployeeDAOByUserTest()
        {


            _employeeDAO = _facDAO.GetEmployeeDAO();
            Employee employeeTest = _employeeDAO.FindByusername(_employee.Username);
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

        /// <summary>
        /// Void: commandRolTest()
        /// Explicación: Se llama a la fabrica de comandos para instanciar el comando 
        /// GetCommandGetAllRoles y buscar todos los roles disponibles para  
        /// verificar correctamente con las respectivas pruebas.
        /// y probarlo.
        /// NOTA: Para poder traer los datos obtenidos por el comando debes guardalo
        /// en una variable de tipo List<Role> y que sea igual al atributo Receiver casteado.
        /// </summary>

        [Test]

        public void fRolDAOTest()
        {

            _roleDAO = _facDAO.GetRoleDAO();
            List<Role> _role = (List<Role>)_roleDAO.GetAll();

            foreach (Role item in _role)
            {
                if (item.Id == 1)
                {
                    Assert.AreEqual(item.Id, 1);
                    Assert.AreEqual(item.Name, "Caja");
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



        private void getUserAcountDao()
        {
            getDao();
            if (_userAcountDAO == null)
                _userAcountDAO = _facDAO.GetUserAccountDAO();

        }

        /// <summary>
        /// Void: getEmployeeDao()
        /// Explicación: Se llama a la fabrica dao de Employee para instanciarla.
        /// </summary>
        /// 
        private void getEmployeeDao()
        {
            getDao();
            if (_employeeDAO == null)
                _employeeDAO = _facDAO.GetEmployeeDAO();

        }

        /// <summary>
        /// Void: FinishTest()
        /// Explicación: Se llama a las funciones getEmployeeDao y getAccountDao y luego se eliminan
        /// todas las pruebas realizadas durante el proceso y se verifica que se eliminaron
        /// </summary>

        [Test]
        public void hFinishTest()
        {
            getEmployeeDao();
            getUserAcountDao();
            _employeeDAO.Delete(_employee);
            Assert.AreEqual(_userAcount.Email, "fondauser2@gmail.com");
            _userAcountDAO.Delete(_userAcount);
            //_employee = null;
            //Assert.AreEqual( _employee , null );
            _employee = null;
            _userAcount = null;
            Assert.AreEqual(_employee, null);
            Assert.AreEqual(_userAcount, null);
        }

    }
}
