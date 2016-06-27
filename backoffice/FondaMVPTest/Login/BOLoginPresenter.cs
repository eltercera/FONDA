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
        // variables a utilizarse en el transcurso de las pruebas unitarias
        private static Employee _employee;
        private MockRepository _MockRepository;
        private Mock<ILoginModel> _mock;
        private ILoginModel contract;
        private LoginPresenter _Login;
        private static UserAccount _userAcount;
        private DateTime _employeeBirthDate = Convert.ToDateTime("03/09/1992");
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        /// <summary>
        /// metodo que inicializa mock a utilizarse en el transcurso de las pruebas unitarias
        /// este mock representa el contrato entre la vista y el modelo
        /// </summary>
        [SetUp]
        public void Init()
        {
        
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<ILoginModel>();

        }
        [Test(Description = "Prueba unitaria que verifica que un usuario existente en la bd se loguee correctamente")]
        public void ValidateTest()
        {
            //valor en el mock de textbox de usuario loguenadose
            HtmlInputText UserIni = new HtmlInputText();
            UserIni.Value = "fondapizzares";
            _mock.Setup(x => x.UserIni).Returns(UserIni);
            //valor en el mock de textbox de password 
            HtmlInputPassword UserPassword = new HtmlInputPassword();
            UserIni.Value = "fondas12345";
            _mock.Setup(x => x.UserPassword).Returns(UserPassword);
            //valor en el mock alert correspondiente
            HtmlGenericControl alerterror = new HtmlGenericControl();
            _mock.Setup(x => x.alertloginError).Returns(alerterror);
            //valor en el mock alert correspondiente
            HtmlGenericControl alertwarningL = new HtmlGenericControl();
            _mock.Setup(x => x.alertwarningLog).Returns(alertwarningL);
            //valor en el mock alert correspondiente
            HtmlGenericControl alertinfoL = new HtmlGenericControl();
            _mock.Setup(x => x.alertinfoLog).Returns(alertinfoL);
            //valor en el mock alert correspondiente
            HtmlGenericControl alertsuccessL = new HtmlGenericControl();
            _mock.Setup(x => x.alertsuccessLog).Returns(alertsuccessL);
            //valor en el mock alert correspondiente
            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);
            //valor en el mock alert correspondiente
            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);
            // se le da al contracto valor del mock
            contract = _mock.Object;
           //se instacia presentador
            _Login = new LoginPresenter(contract);
            //se llama metodo del presentador que permite el loggin
            _Login.ValidateUser();

            // alert de error en el logueo no es activado
            Assert.AreEqual(false, contract.alertwarningLog.Visible);

        }
        /// <summary>
        /// metodo que le da valor a la variable de userAccount a utilizarse 
        /// en la prueba unitaria
        /// </summar
        public void generateUserAccount()
        {
            _userAcount = new UserAccount();
            _userAcount.Email = "fondasis@gmail.com";
            _userAcount.Password = "123456";
            _userAcount.Status = ActiveSimpleStatus.Instance;

        }

        /// <summary>
        /// Prueba unitaria en donde primero se le da valor a los elementos necesarios de la vista para el logueo
        /// se le da el valor al contracto con el mock, el formato del username que intenta entrar no es valido
        /// se llama al metodo del presentador que valida este formato
        /// se verifica que el alert de formato invalido se haya activado
        /// </summary>
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de user no sea correcto")]
        public void ValidateformatUserTest()
        {
            //Elementos de la vista a utilizarse en la vista
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
            //se le da valor al contrato
            contract = _mock.Object;
            //se instacia el presentador
            _Login = new LoginPresenter(contract);
            //se llama  metodo del presentador que valida este formato
            _Login.validateCapsEnter();


            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        /// <summary>
        /// Prueba unitaria en donde primero se le da valor a los elementos necesarios de la vista para el logueo
        /// se le da el valor al contracto con el mock, el formato de la contrase;a que intenta entrar no es valido
        /// se llama al metodo del presentador que valida este formato
        /// se verifica que el alert de formato invalido se haya activado
        /// </summary>
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password no sea correcto")]
        public void ValidateformatPasswordTest()
        {
            //Elementos de la vista a utilizarse en el presentador
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
            // se le da valor al contrato 
            contract = _mock.Object;
            // se instacia al presentador
            _Login = new LoginPresenter(contract);
            // se llama a funcion del presentador encargada de validar el formato
            _Login.validateCapsEnter();

            // se verifica que alert de error este visible
            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        /// <summary>
        /// Prueba unitaria en donde primero se le da valor a los elementos necesarios de la vista para
        /// la recuperacion de contrase;a de un usuario en el sistema
        /// se le da el valor al contracto con el mock, el formato de la username que intenta
        /// recuperar contrease;a que intenta entrar no es valido
        /// se llama al metodo del presentador que valida este formato
        /// se verifica que el alert de formato invalido se haya activado
        /// </summary>
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de user de recuperar clave no sea correcto")]
        public void ValidateformatUserRecoverPasswordTest()
        {
            //elementos de la vista a utilizarse en el presentador
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
            // se le da valor al contrato
            contract = _mock.Object;
            // se instacia al presentador
            _Login = new LoginPresenter(contract);
            //se llama metodo del presentador encargador de hacer las validaciones
            _Login.validateCapsRecover();

            // se verifica que sea visible el alert de error al hacer la recuperacion de contrase;a
            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        /// <summary>
        /// Prueba unitaria en donde primero se le da valor a los elementos necesarios de la vista para
        /// la recuperacion de contrase;a de un usuario en el sistema
        /// se le da el valor al contracto con el mock, el formato de la username que intenta
        /// recuperar contrease;a que intenta entrar no es valido
        /// se llama al metodo del presentador que valida este formato
        /// se verifica que el alert de formato invalido se haya activado
        /// </summary>
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de email no sea correcto, de recuperar clave")]
        public void ValidateformatEmailRecoverPasswordTest()
        {
            //elementos de la vista a utilizarse
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
            // se le da valor al contrato
            contract = _mock.Object;
            // se instancia al presentador
            _Login = new LoginPresenter(contract);
            // se llama metodo del presentador encargado de validar formatos
            _Login.validateCapsRecover();
            // se verifica que el alert de error al intentar cambiar contrase;a tuvo error

            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        /// <summary>
        /// Prueba unitaria en donde primero se le da valor a los elementos necesarios de la vista para
        /// la recuperacion de contrase;a de un usuario en el sistema
        /// se le da el valor al contracto con el mock, el formato de la password nueva que intenta
        /// recuperar contrease;a que intenta entrar no es valido
        /// se llama al metodo del presentador que valida este formato
        /// se verifica que el alert de formato invalido se haya activado
        /// </summary>
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password1 no sea correcto,de recuperar clave")]
        public void ValidateformatPassword1RecoverPasswordTest()
        {
            //elementos de la vista a utilizarse en el presentador
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
            // se le da valor al contrato
            contract = _mock.Object;
            // se instacia al presentador
            _Login = new LoginPresenter(contract);
            // se llama metodo del presentador que valida formato
            _Login.validateCapsRecover();
            // alert de error en la recuperacion de contrase;a debe ser visible

            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        /// <summary>
        /// Prueba unitaria en donde primero se le da valor a los elementos necesarios de la vista para
        /// la recuperacion de contrase;a de un usuario en el sistema
        /// se le da el valor al contracto con el mock, el formato de la password de confirmacion que intenta
        /// recuperar contrease;a que intenta entrar no es valido
        /// se llama al metodo del presentador que valida este formato
        /// se verifica que el alert de formato invalido se haya activado
        /// </summary>
        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password2 no sea correcto, de recuperar clave")]
        public void ValidateformatPassword2RecoverPasswordTest()
        {
            //elementos de la vista a utilizarse en el presentador
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
            // se le da valor al contrato
            contract = _mock.Object;
            //se instacia al presentador
            _Login = new LoginPresenter(contract);
            //se llama metodo del presentador que valida formato
            _Login.validateCapsRecover();
            //alert de error en recuperacion de contrase;a debe ser visible

            Assert.AreEqual(true, contract.alertloginError.Visible);

        }
        /// <summary>
        /// metodo que le da valor a la variable de empleado a utilizarse 
        /// en la prueba unitaria
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
        /// metodo que verifica que se le cambie el password a un usuario del sistema
        /// </summary>

        [Test(Description = "Prueba unitaria que prueba que el alert de warnig sea activado cuando el formato de password no sea correcto")]
        public void RecoverPasswordTest()
        {
            //Se generan objetos con valor de empleado y userAccount
            IUserAccountDAO _userAcountDAO = _facDAO.GetUserAccountDAO();
            IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
            generateUserAccount();
            generateEmployee();
            //se guardan
            _userAcountDAO.Save(_userAcount);
            _employeeDAO.Save(_employee);
            //Elementos de la vista a utilizar en el presentador
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
            //se le da valor al contrato
            contract = _mock.Object;
            // se instancia presentador
            _Login = new LoginPresenter(contract);
            // se llama metodo del presentador
            _Login.Recoverpassword();
            _userAcountDAO = _facDAO.GetUserAccountDAO();
            UserAccount _userTest = (UserAccount)_userAcountDAO.FindByEmail("fondasis@gmail.com");
            Assert.AreEqual(_userTest.Password, "123456");



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
            _employee = null;
            _userAcount = null;
            Assert.AreEqual(_employee, null);
            Assert.AreEqual(_userAcount, null);
        }

    }
}
