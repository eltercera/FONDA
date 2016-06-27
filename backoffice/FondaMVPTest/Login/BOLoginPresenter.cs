using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
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
    class BOLoginPresenter
    {
        private static Employee _employee;
        private MockRepository _MockRepository;
        private Mock<ILoginModel> _mock;
        private ILoginModel contract;
        private LoginPresenter _Login;
        private static UserAccount _userAcount;
        private DateTime _employeeBirthDate = Convert.ToDateTime("03/09/1992");
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        
        [SetUp]
        public void Init()
        {
        
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<ILoginModel>();

        }
        [Test(Description = "Prueba unitaria que verifica que un usuario existente en la bd se loguee correctamente")]
        public void ValidateTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondapizzares";
            _mock.Setup(x => x.UserIni).Returns(UserIni);

            HtmlInputPassword UserPassword = new HtmlInputPassword();
            UserIni.Value = "fondas12345";
            _mock.Setup(x => x.UserPassword).Returns(UserPassword);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL= new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.ValidateUser();

            
            Assert.AreEqual(false, contract.alertwarningLog.Visible);

        }


        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de user no sea correcto")]
        public void ValidateformatUserTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "-----";
            _mock.Setup(x => x.UserIni).Returns(UserIni);

            HtmlInputPassword UserPassword = new HtmlInputPassword();
            UserIni.Value = "12345";
            _mock.Setup(x => x.UserPassword).Returns(UserPassword);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.validateCapsEnter();


            Assert.AreEqual(true, contract.alertloginError.Visible);

        }

        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password no sea correcto")]
        public void ValidateformatPasswordTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondas";
            _mock.Setup(x => x.UserIni).Returns(UserIni);

            HtmlInputPassword UserPassword = new HtmlInputPassword();
            UserIni.Value = "//////";
            _mock.Setup(x => x.UserPassword).Returns(UserPassword);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.validateCapsEnter();


            Assert.AreEqual(true, contract.alertloginError.Visible);

        }

        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de user de recuperar clave no sea correcto")]
        public void ValidateformatUserRecoverPasswordTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "/////";
            _mock.Setup(x => x.UserRecover).Returns(UserIni);

            HtmlInputGenericControl RecoverEmail = new HtmlInputGenericControl();
            RecoverEmail.Value = "fonda@gmail.com";
            _mock.Setup(x => x.RecoverEmail).Returns(RecoverEmail);

            HtmlInputPassword UserPassword1 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password1).Returns(UserPassword1);

            HtmlInputPassword UserPassword2 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password2).Returns(UserPassword2);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.validateCapsRecover();


            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de email no sea correcto, de recuperar clave")]
        public void ValidateformatEmailRecoverPasswordTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondas";
            _mock.Setup(x => x.UserRecover).Returns(UserIni);

            HtmlInputGenericControl RecoverEmail = new HtmlInputGenericControl();
            RecoverEmail.Value = "fongmail.com";
            _mock.Setup(x => x.RecoverEmail).Returns(RecoverEmail);

            HtmlInputPassword UserPassword1 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password1).Returns(UserPassword1);

            HtmlInputPassword UserPassword2 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password2).Returns(UserPassword2);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.validateCapsRecover();


            Assert.AreEqual(true, contract.alertloginError.Visible);

        }

        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password1 no sea correcto,de recuperar clave")]
        public void ValidateformatPassword1RecoverPasswordTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondas";
            _mock.Setup(x => x.UserRecover).Returns(UserIni);

            HtmlInputGenericControl RecoverEmail = new HtmlInputGenericControl();
            RecoverEmail.Value = "fong@gmail.com";
            _mock.Setup(x => x.RecoverEmail).Returns(RecoverEmail);

            HtmlInputPassword UserPassword1 = new HtmlInputPassword();
            UserIni.Value = "///";
            _mock.Setup(x => x.Password1).Returns(UserPassword1);

            HtmlInputPassword UserPassword2 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password2).Returns(UserPassword2);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.validateCapsRecover();


            Assert.AreEqual(true, contract.alertloginError.Visible);

        }

        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password2 no sea correcto, de recuperar clave")]
        public void ValidateformatPassword2RecoverPasswordTest()
        {
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondas";
            _mock.Setup(x => x.UserRecover).Returns(UserIni);

            HtmlInputGenericControl RecoverEmail = new HtmlInputGenericControl();
            RecoverEmail.Value = "fong@gmail.com";
            _mock.Setup(x => x.RecoverEmail).Returns(RecoverEmail);

            HtmlInputPassword UserPassword1 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password1).Returns(UserPassword1);

            HtmlInputPassword UserPassword2 = new HtmlInputPassword();
            UserIni.Value = "////";
            _mock.Setup(x => x.Password2).Returns(UserPassword2);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.validateCapsRecover();


            Assert.AreEqual(true, contract.alertloginError.Visible);

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

        public void generateUserAccount()
        {
            _userAcount = new UserAccount();
            _userAcount.Email = "fondasis@gmail.com";
            _userAcount.Password = "123456";
            _userAcount.Status = ActiveSimpleStatus.Instance;

        }

        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password no sea correcto")]
        public void RecoverPasswordTest()
        {
            IUserAccountDAO _userAcountDAO = _facDAO.GetUserAccountDAO();
            IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
            generateUserAccount();
            generateEmployee();
            /*_userAcount = new UserAccount();
            _userAcount.Email = "fondasis@gmail.com";
            _userAcount.Password = "123";
            _userAcount.Status = ActiveSimpleStatus.Instance;
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
            _employee.Status = ActiveSimpleStatus.Instance;*/
            _userAcountDAO.Save(_userAcount);
            _employeeDAO.Save(_employee);
            
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondasis";
            _mock.Setup(x => x.UserRecover).Returns(UserIni);

            HtmlInputGenericControl RecoverEmail = new HtmlInputGenericControl();
            RecoverEmail.Value = "fondasis@gmail.com";
            _mock.Setup(x => x.RecoverEmail).Returns(RecoverEmail);

            HtmlInputPassword UserPassword1 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password1).Returns(UserPassword1);

            HtmlInputPassword UserPassword2 = new HtmlInputPassword();
            UserIni.Value = "123456";
            _mock.Setup(x => x.Password2).Returns(UserPassword2);

            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);

            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);

            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);

            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _Login = new LoginPresenter(contract);

            _Login.Recoverpassword();
            _userAcountDAO = _facDAO.GetUserAccountDAO();
            UserAccount _userTest = (UserAccount)_userAcountDAO.FindByEmail("fondasis@gmail.com");
            Assert.AreEqual(_userTest.Password, "123456");



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
