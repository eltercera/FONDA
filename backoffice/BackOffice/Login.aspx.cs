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


namespace BackOffice.Seccion.Configuracion
{
    public partial class WebForm1 : System.Web.UI.Page
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
        public void Uservalidate(object sender, EventArgs e)
        {

            Uservalidate();
        }
        public void Recoverpassword(object sender, EventArgs e)
        {

            Recoverpassword();
        }

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
                            Session[RecursoMaster.sessionRestaurantID] = _employee.Restaurant.Id;
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
        /// Metodo encargado de restablecer la nueva contraseña del usuario
        /// </summary>
        /// <param name="_employee"></param>
        protected void SetEmployee(Employee _employee)
         {


             if (this.password1.Value != "")
             _employee.UserAccount.Password = this.password1.Value;
            
        }

                
    }
}