
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
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private com.ds201625.fonda.Domain.UserAccount _userAcount;
        private MockRepository _MockRepository;
        private Mock<IUserListModel> _mock;
        private IUserListModel contract;
        private UserListPresenter _userListPresenter;
        private com.ds201625.fonda.Domain.Employee _employee;
        private DateTime _employeeBirthDate = Convert.ToDateTime("03/09/1992");

        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IUserListModel>();

        }
        [Test(Description = "Caso de error, cuando la tabla de usuarios no tiene un Id de Restaurante y rol restaurant")]
        public void LoadTableUserListRolRestaurantTest()
        {
            Table userListTable = new Table();
            _mock.Setup(x => x.tableUserList).Returns(userListTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);



            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _userListPresenter = new UserListPresenter(contract);

            _userListPresenter.LoadTable("Restaurante");

            Assert.AreEqual(0, contract.tableUserList.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);

        }

        [Test(Description = "Caso de error, cuando la tabla de usuarios no tiene un Id de Restaurante y rol sistema")]
        public void LoadTableUserListRolSistemTest()
        {
            Table userListTable = new Table();
            _mock.Setup(x => x.tableUserList).Returns(userListTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _userListPresenter = new UserListPresenter(contract);

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

        public void generateUserAccount()
        {
            _userAcount = new com.ds201625.fonda.Domain.UserAccount();
            _userAcount.Email = "fondasis@gmail.com";
            _userAcount.Password = "123456";
            _userAcount.Status = com.ds201625.fonda.Domain.ActiveSimpleStatus.Instance;

        }

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

        [Test(Description = "prueba unitaria de cuando se agrega un empleado")]
        public void ValidateEmailTest()
        {
            generateUserAccount();
            generateEmployee();
            IUserAccountDAO _userAcountDAO = _facDAO.GetUserAccountDAO();
            IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
            _userAcountDAO.Save(_userAcount);
            _employeeDAO.Save(_employee);
            TextBox textBoxEmail = new TextBox();
            textBoxEmail.Text = "fondasis@gmail.com";
            _mock.Setup(x => x.textBoxEmail).Returns(textBoxEmail);
            contract = _mock.Object;
            _userListPresenter = new UserListPresenter(contract);
            bool existeemail = _userListPresenter.ValidationEmail();
            Assert.AreEqual(true, existeemail);


        }
        [Test(Description = "prueba unitaria de cuando se agrega un empleado")]
        public void ValidateSsnTest()
        {

            DropDownList dropDownListNss1 = new DropDownList();
            dropDownListNss1.Text = "V";
            _mock.Setup(x => x.dropDownListNss1).Returns(dropDownListNss1);

            TextBox textBoxNss2 = new TextBox();
            textBoxNss2.Text = "242871509";
            _mock.Setup(x => x.textBoxNss2).Returns(textBoxNss2);
            contract = _mock.Object;
            _userListPresenter = new UserListPresenter(contract);
            bool existessn = _userListPresenter.ValidationSsn();
            Assert.AreEqual(true, existessn);


        }

        [Test(Description = "prueba unitaria de cuando se agrega un empleado")]
        public void ValidateUsernameTest()
        {
            TextBox textBoxUserNameU = new TextBox();
            textBoxUserNameU.Text = "rejimenez.12";
            _mock.Setup(x => x.textBoxUserNameU).Returns(textBoxUserNameU);
            contract = _mock.Object;
            _userListPresenter = new UserListPresenter(contract);
            bool existeusername = _userListPresenter.ValidationSsn();
            Assert.AreEqual(true, existeusername);


        }

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
