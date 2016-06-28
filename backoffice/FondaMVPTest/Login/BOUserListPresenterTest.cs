
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.View.BackOfficeModel.Login;
using com.ds201625.fonda.View.BackOfficePresenter.Login;
using Moq;
using NUnit.Framework;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace FondaMVPTest.Login
{
    [TestFixture]
    class BOUserListPresenterTest
    {

        //variables a utillizar en el transcurso de las pruebas unitarias
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private com.ds201625.fonda.Domain.UserAccount _userAcount;
        private MockRepository _MockRepository;
        private Mock<IUserListModel> _mock;
        private IUserListModel contract;
        private UserListPresenter _userListPresenter;
        private com.ds201625.fonda.Domain.Employee _employee;
        private DateTime _employeeBirthDate = Convert.ToDateTime("03/09/1992");
        /// <summary>
        /// metodo setUp de las pruebas unitarias
        /// se le da valor al mock a utilizarse
        /// </summary>
        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IUserListModel>();

        }
        /// <summary>
        /// verifica que si no se tiene un id de restaurante y de rol logueado como 
        /// restaurante y no se cargara la tabla
        /// </summary>
        [Test(Description = "Caso de error, cuando la tabla de usuarios no tiene un Id de Restaurante y rol restaurant")]
        public void LoadTableUserListRolRestaurantTest()
        {
            //elementos de la vista a utilizarse en el presentador
            Table userListTable = new Table();
            _mock.Setup(x => x.tableUserList).Returns(userListTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);



            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);
            // se le da valor al contrato
            contract = _mock.Object;
            //se instancia al presentador
            _userListPresenter = new UserListPresenter(contract);
            // se llama metodo del presentador que carga la tabla
            _userListPresenter.LoadTable("Restaurante");
            //no hay filas en la tabla
            Assert.AreEqual(0, contract.tableUserList.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);

        }
        /// <summary>
        /// verifica que si no se tiene un id de restaurante y de rol logueado como 
        /// Sistema y no se cargara la tabla
        /// </summary>
        [Test(Description = "Caso de error, cuando la tabla de usuarios no tiene un Id de Restaurante y rol sistema")]
        public void LoadTableUserListRolSistemTest()
        {
            //Elementos de la vista a utilizarse en el presentador
            Table userListTable = new Table();
            _mock.Setup(x => x.tableUserList).Returns(userListTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);
            //se le da valor al contrato
            contract = _mock.Object;
            // se instancia presentador
            _userListPresenter = new UserListPresenter(contract);
            // se llama a metodo del presentador que carga la tabla
            _userListPresenter.LoadTable("Sistema");

            Assert.AreEqual(0, contract.tableUserList.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);

        }

        /*[Test(Description = "prueba unitaria de cuando se agrega un empleado")]
        public void AddUserTest()
        {

            TextBox textBoxNameUser = new TextBox();
            textBoxNameUser.Text = "Gabriela";
            _mock.Setup(x => x.textBoxNameUser).Returns(textBoxNameUser);

            TextBox textBoxlastNameUser = new TextBox();
            textBoxlastNameUser.Text = "Gonzalez";
            _mock.Setup(x => x.textBoxlastNameUser).Returns(textBoxlastNameUser);

            TextBox textBoxAddress = new TextBox();
            textBoxAddress.Text = "Edo miranda";
            _mock.Setup(x => x.textBoxAddress).Returns(textBoxAddress);

            TextBox textBoxPhoneNumber = new TextBox();
            textBoxPhoneNumber.Text = "04149311244";
            _mock.Setup(x => x.textBoxPhoneNumber).Returns(textBoxPhoneNumber);

            DropDownList dropDownListNss1  = new DropDownList();
            dropDownListNss1.Text = "V";
            _mock.Setup(x => x.dropDownListNss1).Returns(dropDownListNss1);

            TextBox textBoxNss2 = new TextBox();
            textBoxNss2.Text = "6969696969";
            _mock.Setup(x => x.textBoxNss2).Returns(textBoxNss2);

            DropDownList DropDownListGender = new DropDownList();
            DropDownListGender.Text = "F";
            _mock.Setup(x => x.DropDownListGender).Returns(DropDownListGender);

            HtmlInputGenericControl textBoxBirtDate = new HtmlInputGenericControl();
            textBoxBirtDate.Value = "14/04/1994";
            _mock.Setup(x => x.textBoxBirtDate).Returns(textBoxBirtDate);

            TextBox textBoxUserNameU = new TextBox();
            textBoxUserNameU.Text = "gabriela12333";
            _mock.Setup(x => x.textBoxUserNameU).Returns(textBoxUserNameU);

            DropDownList DropDownListRole = new DropDownList();
            DropDownListRole.Text = "Restaurante";
            _mock.Setup(x => x.DropDownListRole).Returns(DropDownListRole);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            Button buttonButtonAddModify = new Button();
            buttonButtonAddModify.Text = "Agregar";
            _mock.Setup(x => x.buttonButtonAddModify).Returns(buttonButtonAddModify);

            contract = _mock.Object;

            _userListPresenter = new UserListPresenter(contract);
          //falta
            

        }*/
        /// <summary>
        /// metodo que le da valor a la variable de userAccount a utilizarse 
        /// en la prueba unitaria
        /// </summar
        public void generateUserAccount()
        {
            _userAcount = new com.ds201625.fonda.Domain.UserAccount();
            _userAcount.Email = "fondasis@gmail.com";
            _userAcount.Password = "123456";
            _userAcount.Status = com.ds201625.fonda.Domain.ActiveSimpleStatus.Instance;

        }
        /// <summary>
        /// metodo que le da valor a la variable de empleado a utilizarse 
        /// en la prueba unitaria
        /// </summary>
        public void generateEmployee()
        {
            _employee = new com.ds201625.fonda.Domain.Employee();

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
            _employee.Status = com.ds201625.fonda.Domain.ActiveSimpleStatus.Instance;

        }
        /// <summary>
        /// prueba unitaria que verifica que presentador valide q correo ya existe en la bd
        /// </summary>
        [Test(Description = "prueba unitaria que verifica que presentador valide q correo ya existe en la bd")]
        public void ValidateEmailTest()
        {
            //se generara empleado y userAccount
            generateUserAccount();
            generateEmployee();
            IUserAccountDAO _userAcountDAO = _facDAO.GetUserAccountDAO();
            IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
            // se guardan
            _userAcountDAO.Save(_userAcount);
            _employeeDAO.Save(_employee);
            // elemento de la vista a utilizar en el presentador 
            TextBox textBoxEmail = new TextBox();
            textBoxEmail.Text = "fondasis@gmail.com";
            _mock.Setup(x => x.textBoxEmail).Returns(textBoxEmail);
            // se le da valor al contrato
            contract = _mock.Object;
            // se instancia presentador
            _userListPresenter = new UserListPresenter(contract);
            //se llama metodo presentador que valida que email exista en la bd
            bool existeemail = _userListPresenter.ValidationEmail();
            Assert.AreEqual(true, existeemail);


        }
        /// <summary>
        /// prueba unitaria que verifica que el presentador valide que ya existe un empleado con un Ssn
        /// </summary>
        [Test(Description = "prueba unitaria que verifica que el presentador valide que ya existe un empleado con un Ssn")]
        public void ValidateSsnTest()
        {
            // elementos de la vista a utilizarse en el presentador
            DropDownList dropDownListNss1 = new DropDownList();
            dropDownListNss1.Text = "V";
            _mock.Setup(x => x.dropDownListNss1).Returns(dropDownListNss1);

            TextBox textBoxNss2 = new TextBox();
            textBoxNss2.Text = "242871509";
            _mock.Setup(x => x.textBoxNss2).Returns(textBoxNss2);
            // se le da valor al contrato
            contract = _mock.Object;
            // se instacia presentador
            _userListPresenter = new UserListPresenter(contract);
           // se llama metodo del presentador que valida que ssn exista en la Bd
            bool existessn = _userListPresenter.ValidationSsn();
            Assert.AreEqual(true, existessn);


        }
        /// <summary>
        /// prueba unitaria que verifica que el presentador valide que ya existe un empleado con un username
        /// </summary>
        [Test(Description = "prueba unitaria que verifica que el presentador valide que ya existe un empleado con un username")]
        public void ValidateUsernameTest()
        {
            //elemento de la vista a utilizarse en el presentador
            TextBox textBoxUserNameU = new TextBox();
            textBoxUserNameU.Text = "rejimenez.12";
            _mock.Setup(x => x.textBoxUserNameU).Returns(textBoxUserNameU);
            // se le da valor al contrato
            contract = _mock.Object;
            // se instacia presentador
            _userListPresenter = new UserListPresenter(contract);
            //se llama metodo del presentador que valida que username ya existe en la bd
            bool existeusername = _userListPresenter.ValidationUsername();
            Assert.AreEqual(true, existeusername);


        }
        /// <summary>
        /// prueba unitaria final que elimina datos insertads en la bd
        /// durante las pruebas unitarias
        /// </summary>
        [Test]
        public void zFinishTest()
        {
            IUserAccountDAO _userAcountDAO = _facDAO.GetUserAccountDAO();
            IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
            _employeeDAO.Delete(_employee);
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
