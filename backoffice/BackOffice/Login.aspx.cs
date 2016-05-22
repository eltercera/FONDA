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
        public void mensajeLogin(Boolean visible, string mensaje, string tipo)
        {
            switch (tipo)
            {
                case "Error": errorLogin.Visible = visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    errorLogin.InnerText = mensaje; break;
                case "Warning": warningLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    warningLog.InnerText = mensaje; break;
                case "Info": infoLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    successLog.Visible = !visible;
                    infoLog.InnerText = mensaje; break;
                case "Success": successLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.InnerText = mensaje; break;
            }
        }
        public void ValidarUsuario(object sender, EventArgs e)
        {

            validarUsuario();
        }
        public void EnvioCorreo(object sender, EventArgs e)
        {

            EnviarCorreo();
        }
        public void validarUsuario()
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IEmployeeDAO _EmploDAO = factoryDAO.GetEmployeeDAO();
            Employee _employee;
            _employee = new Employee();
            string user = userIni.Value;
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
                string _userPassword = _employee.UserAccount.Password;
                if (_employee != null & _userPassword == password)
                {


                    Session[RecursoMaster.sessionRol] = _employee.Role.Name;
                    Session[RecursoMaster.sessionName] = _employee.Name;
                    Session[RecursoMaster.sessionLastname] = _employee.LastName;
                    Session[RecursoMaster.sessionUserID] = _employee.Id;

                    //Manejo de Restaurante
                    string RestaurantID = _employee.Restaurant.Id.ToString();
                    int idRestaurant = int.Parse(RestaurantID);
                    com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);
                    Session[RestaurantResource.SessionRestaurant] = _restaurant.Id.ToString();
                    Session[RestaurantResource.SessionNameRest] = _restaurant.Name.ToString();

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

        }

        public void EnviarCorreo()
        {

            String CorreoDestino = RestablecerCorreo.Value;
            if (CorreoDestino != "fonda@gmail.com")
            {

                mensajeLogin(true, mensajes.logWarning, mensajes.tipoWarning);
            }
            else
            {
                mensajeLogin(true, mensajes.logInfo, mensajes.tipoInfo);


                string opcion = "true";
                Response.Redirect("Login.aspx?" + mensajes.tipoInfo + "=" + opcion);
            }
            RestablecerCorreo.Value = "";


        }
    }
}