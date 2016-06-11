using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BackOffice.Content;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using BackOffice.Seccion.Restaurant;
using BackOfficeModel.Login;


namespace BackOffice.Seccion.Configuracion
{
    public partial class WebForm1 : System.Web.UI.Page, ILoginModel
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            errorLogin.Visible = false;
            warningLog.Visible = false;

            if ((Request.QueryString[mensajes.tipoInfo] == "true"))
                mensajeLogin(true, mensajes.logInfo, mensajes.tipoInfo);
            else
                infoLog.Visible = false;

            if ((Request.QueryString[mensajes.tipoSucess] == "true"))
                mensajeLogin(true, mensajes.logSuccess, mensajes.tipoSucess);
            else
                successLog.Visible = false;
        }

        /*

        /// <summary>
        /// metodos que se encarga de activar la validacion del usuario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Uservalidate(object sender, EventArgs e)
        {
            Uservalidate();
        }
        /// <summary>
        /// Metodo que se encarga de activar la recuperacion de contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Recoverpassword(object sender, EventArgs e)
        {
            Recoverpassword();
        }
        */
        /// <summary>
        /// Metodo  que nos permite establecer un mensaje en el login
        /// </summary>
        /// <param name="visible">si deseamos que sea visible</param>
        /// <param name="message"> el mensaje que deseamos mostrar</param>
        /// <param name="type">tipo de mensaje Error;Warning;Info;Sucess</param>
        public void mensajeLogin(Boolean visible, string message, string type)
        {
            switch (type)
            {
                case "Error": errorLogin.Visible = visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    errorLogin.InnerText = message; break;
                case "Warning": warningLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    warningLog.InnerText = message; break;
                case "Info": infoLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    successLog.Visible = !visible;
                    infoLog.InnerText = message; break;
                case "Success": successLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.InnerText = message; break;
            }
        }
        /*
    /// <summary>
    /// Metodo que valida el intento de ingreso al sistema
    /// </summary>
         public void Uservalidate()
         {
             FactoryDAO factoryDAO = FactoryDAO.Intance;
             IEmployeeDAO _EmploDAO = factoryDAO.GetEmployeeDAO();
             Employee _employee;
             _employee = new Employee();
             string user = userIni.Value;
             string _userPassword="";
             string password = passwordIni.Value;
             Console.WriteLine("imprimiendo valor :");
             Console.WriteLine(user);
             //Restaurante
             IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();

             if (user == "" | password == "")
             {
                 mensajeLogin(true, mensajes.logErrcamp, mensajes.tipoInfo);
             }
             else
             {
                 _employee = _EmploDAO.FindByusername(userIni.Value);
                 if (_employee != null)
                 {
                       if (_employee.UserAccount != null)
                        _userPassword = _employee.UserAccount.Password;
                    if (_employee != null & _employee.UserAccount != null & _userPassword == password)
                     {

                         Session[RecursoMaster.sessionRol] = _employee.Role.Name;
                         Session[RecursoMaster.sessionName] = _employee.Name;
                         Session[RecursoMaster.sessionLastname] = _employee.LastName;
                         Session[RecursoMaster.sessionUserID] = _employee.Id;

                         if (_employee.Restaurant != null)
                         {
                             Session[RecursoMaster.sessionRestaurantID] = _employee.Restaurant.Id;
                             //Manejo de Restaurante
                             string RestaurantID = _employee.Restaurant.Id.ToString();
                             int idRestaurant = int.Parse(RestaurantID);
                             com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);
                             Session[RestaurantResource.SessionRestaurant] = _restaurant.Id.ToString();
                             Session[RestaurantResource.SessionNameRest] = _restaurant.Name.ToString();

                         }
                         else
                             Session[RecursoMaster.sessionRestaurantID] = "0";
                         mensajeLogin(false, mensajes.logErr, mensajes.tipoErr);
                         if (_employee.Role.Name == "Sistema")
                             Response.Redirect("~/Seccion/Restaurant/Restaurante.aspx");
                         else

                             Response.Redirect("Default.aspx");
                     }
                     else
                      {
                         mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
                      }
                 }
                  else
                     {

                     mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
                     }
             }

         }

        /// <summary>
         /// Metodo encargado de validar los campos de resstablecer contraseña 
        /// </summary>
        /// <param name="_employee">el usuario que se desa verificar</param>
        /// <returns></returns>
         public bool ValidateRecoverpassword( Employee _employee)
         {
             String email = RestablecerCorreo.Value;
             String passwordnew1 = password1.Value;
             String passwordnew2 = password2.Value;
             String username = user.Value;

             if (email != "" & passwordnew1 != "" & passwordnew2 != "" & username != "")
             {
                 if (_employee != null)
                 {
                     if (_employee.UserAccount != null)
                     {
                         if (email.Equals(_employee.UserAccount.Email))
                         {
                             if (passwordnew1.Equals(passwordnew2))
                             {
                                 return true;
                             }
                             else
                                 mensajeLogin(true, mensajes.logErrpasword, mensajes.tipoInfo);
                         }
                         else
                             mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                     }
                     else
                         mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                 }
                 else
                     mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
             }
             else
                 mensajeLogin(true, mensajes.logErrcampvac, mensajes.tipoInfo);
             return false;
         }

         /// <summary>
         /// Metodo encargado de restablecer la contraseña 
         /// </summary>
         public void Recoverpassword()
         {
             FactoryDAO factoryDAO = FactoryDAO.Intance;
             IEmployeeDAO _EmployeDAO = factoryDAO.GetEmployeeDAO();
             Employee _employee;
             _employee = new Employee();
             String email = RestablecerCorreo.Value;
             String passwordnew1 = password1.Value;
             String passwordnew2 = password2.Value;
             String username = user.Value;
                _employee = _EmployeDAO.FindByusername(username);      
             if(ValidateRecoverpassword(_employee))
             {   SetEmployee(_employee);
                 _EmployeDAO.Save(_employee);
                  string opcion = "true";
                  Response.Redirect("Login.aspx?" + mensajes.tipoSucess + "=" + opcion);
              }

          } 

         /// <summary>
         /// Metodo encargado de setear la nueva contraseña al usuario
         /// </summary>
         /// <param name="_employee"></param>
         protected void SetEmployee(Employee _employee)
          {


              if (this.password1.Value != "")
              _employee.UserAccount.Password = this.password1.Value;

         }      

         */


        // 2DA ENTREGA
        #region presenter 
        private com.ds201625.fonda.BackOffice.Presenter.LoginPresenter _presenter;
        #endregion

        #region Model
        public Label ErrorLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        // username de login
        public System.Web.UI.HtmlControls.HtmlInputText UserIni
        {
            get { return userIni; }
            set { userIni = value; }
        }
        // password del usuario
        public System.Web.UI.HtmlControls.HtmlInputPassword UserPassword
        {
            get { return passwordIni; }
            set { passwordIni = value; }
        }
        //button de ingresar
        public System.Web.UI.HtmlControls.HtmlButton Loggin
        {
            get { return buttonLogin; }
            set { buttonLogin = value; }
        }
        // usuario de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputText UserRecover
        {
            get { return user; }
            set { user = value; }
        }
        //correo de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputGenericControl RecoverEmail
        {
            get { return RestablecerCorreo; }
            set { RestablecerCorreo = value; }

        }
        //password1 de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputPassword Password1
        {
            get { return password1; }
            set { password1 = value; }
        }
        //password2 de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputPassword Password2
        {
            get { return password2; }
            set { password2 = value; }
        }
        public Label SuccessLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
        #region constructor
        public WebForm1()
        {
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.LoginPresenter(this);
        }
        #endregion

        public void Uservalidate (object sender, EventArgs e)
        {
            Uservalidate();
        }
        public void Uservalidate()
        {
            System.Diagnostics.Debug.WriteLine("Entre en funcion Uservalidate");
             string[] _info;
            _info =_presenter.ValidateUser();
            //_presenter.ValidateUser(Session);
            if ((_info[7] == "Error") || (_info[8]=="Error"))
            {
                mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
            }
            else
            {
                if (_info[4] != "0")
                {
                    Session[RecursoMaster.sessionRol] = _info[0];
                    Session[RecursoMaster.sessionName] = _info[1];
                    Session[RecursoMaster.sessionLastname] = _info[2];
                    Session[RecursoMaster.sessionUserID] = _info[3];
                    Session[RecursoMaster.sessionRestaurantID] = _info[4];
                    Session[RestaurantResource.SessionRestaurant] = _info[5];
                    Session[RestaurantResource.SessionNameRest] = _info[6];
                }
                else
                {

                    Session[RecursoMaster.sessionRol] = _info[0];
                    Session[RecursoMaster.sessionName] = _info[1];
                    Session[RecursoMaster.sessionLastname] = _info[2];
                    Session[RecursoMaster.sessionUserID] = _info[3];
                    System.Diagnostics.Debug.WriteLine("soy admin");
                    
                }
                if (Session[RecursoMaster.sessionRol].ToString() == "Sistema")
                {
                    Response.Redirect("~/Seccion/Restaurant/Restaurante.aspx");
                    
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            /*System.Diagnostics.Debug.WriteLine(Session[RecursoMaster.sessionRol]);
            System.Diagnostics.Debug.WriteLine(Session[RecursoMaster.sessionName]);
            System.Diagnostics.Debug.WriteLine(Session[RecursoMaster.sessionLastname]);
            System.Diagnostics.Debug.WriteLine(Session[RecursoMaster.sessionRestaurantID]);
            System.Diagnostics.Debug.WriteLine(Session[RestaurantResource.SessionRestaurant]);
            System.Diagnostics.Debug.WriteLine(Session[RestaurantResource.SessionNameRest]);*/

                }

        public void Recoverpassword(object sender, EventArgs e)
        {
            Recoverpassword();
        }
        public void Recoverpassword()
        {
            
        }

    }
}