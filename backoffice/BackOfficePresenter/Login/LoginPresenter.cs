
using BackOfficeModel.Login;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;



namespace BackOfficePresenter.Login
{
    public class LoginPresenter : BackOfficePresenter.Presenter
    {
        //enlace entre el modelo y la vista
        private ILoginModel _view;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public LoginPresenter(ILoginModel viewLogin)
            : base(viewLogin)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewLogin;

        }



        public void mensajeLogin(Boolean visible, string message, string type)
        {

            switch (type)
            {
                case "Error":
                    _view.alertloginError.Visible = visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertloginError.InnerText = message; break;
                case "Warning":

                    _view.alertwarningLog.Visible = visible;
                    _view.alertloginError.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertwarningLog.InnerText = message; break;
                case "Info":
                    System.Diagnostics.Debug.WriteLine("llame a mensaje loggin2");
                    _view.alertinfoLog.Visible = visible;
                    _view.alertloginError.Visible = !visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertinfoLog.InnerText = message; break;
                case "Success":
                    _view.alertsuccessLog.Visible = visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.InnerText = message; break;
            }
        }


        /// <summary>
        /// metodo que valida el ingreso del usuario
        /// </summary>
        /// <param name="user">usuario intentando entrar</param>
        public void ValidateUser()
        {
            // usuario intentando ingresar
            string user = _view.UserIni.Value;
            System.Diagnostics.Debug.WriteLine("Entre a LoginPresenter");
            System.Diagnostics.Debug.WriteLine("valor de userIni : ", user);
            //Defino objeto a recibir
            Employee _employee;
            //Objeto a enviar como parametro
            Employee _employeeResult = null;
            //Invoca comando del tipo deseado 
            Command CommandGetEmployeeByUser;
            //Comando que me trae restaurante del usuario
            Command CommandGetRestaurantById;
            //variable que contendra password del usuario en la bd
            string _userPassword = "";
            //informacion de la session a devolver
            string[] _info = new string[10];
            //restaurante a pasar como parametro en el comando de traer restaurante
            Restaurant _restaurant;
            //restaurante a obtener como resultado al buscarlo por el id
            Restaurant _restaurantResult;

            if ((_view.UserIni.Value != "") && (_view.UserPassword.Value != ""))
            {
                try
                {
                    //obtenemos parametro del comando 
                    _employee = (Employee)EntityFactory.GetEmployee();
                    _employee.Username = user;
                    //Obtenemos intancia del comando 
                    CommandGetEmployeeByUser = CommandFactory.GetCommandGetEmployeeByUser(_employee.Username);
                    //Se ejecuta comando deseado
                    CommandGetEmployeeByUser.Execute();
                    //obtenemos resultado
                    _employeeResult = (Employee)CommandGetEmployeeByUser.Receiver;
                    System.Diagnostics.Debug.WriteLine(_employeeResult.Name);
                    if (_employeeResult != null)
                    {
                        System.Diagnostics.Debug.WriteLine("Consegui la cuenta!");
                        System.Diagnostics.Debug.WriteLine(_employeeResult.Name);
                        if (_employeeResult.UserAccount != null)
                        {
                            _userPassword = _employeeResult.UserAccount.Password;
                            System.Diagnostics.Debug.WriteLine("Es el password de la cuenta", _userPassword);
                            if ((_userPassword == _view.UserPassword.Value))
                            {
                                System.Diagnostics.Debug.WriteLine("Aprobe el login");

                                HttpContext.Current.Session[ResourceLogin.sessionRol] = _employeeResult.Role.Name;
                                HttpContext.Current.Session[ResourceLogin.sessionName] = _employeeResult.Name;
                                HttpContext.Current.Session[ResourceLogin.sessionLastname] = _employeeResult.LastName;
                                HttpContext.Current.Session[ResourceLogin.sessionUserID] = _employeeResult.Id;
                                /*_info[0] = _employeeResult.Role.Name;
                                _info[1] = _employeeResult.Name;
                                _info[2] = _employeeResult.LastName;
                                _info[3] = _employeeResult.Id.ToString();*/
                                System.Diagnostics.Debug.WriteLine(_employeeResult.Restaurant.Id, "ID del restaurant");
                                if (_employeeResult.Restaurant != null)
                                {
                                    string RestaurantID = _employeeResult.Restaurant.Id.ToString();
                                    int idRestaurant = int.Parse(RestaurantID);
                                    _restaurant = (Restaurant)EntityFactory.GetRestaurant();
                                    _restaurant.Id = idRestaurant;
                                    
                                    CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_restaurant);
                                    CommandGetRestaurantById.Execute();
                                    _restaurantResult = (Restaurant)CommandGetRestaurantById.Receiver;
                                    HttpContext.Current.Session[ResourceLogin.sessionRestaurantID] = _employeeResult.Restaurant.Id.ToString();
                                    HttpContext.Current.Session[RestaurantResource.SessionRestaurant] = _restaurantResult.Id.ToString();
                                    HttpContext.Current.Session[RestaurantResource.SessionNameRest] = _restaurantResult.Name;

                                    System.Diagnostics.Debug.WriteLine(_restaurantResult.Id.ToString(), "ID del restaurant");
                                    System.Diagnostics.Debug.WriteLine(_restaurantResult.Name.ToString(), "nombre del restaurant");
                                }
                                else
                                {
                                    _info[4] = "0";
                                }


                            }
                            else
                            {
                                //error claves distintas
                                System.Diagnostics.Debug.WriteLine("clave mala");
                                //_info[7] = "Error";
                                mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
                            }
                        }
                    }
                    else
                    {
                        //error buscando empleado 
                        System.Diagnostics.Debug.WriteLine("No se encontro usuario");
                        //_info[8] = "Error";
                        mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
                    }

                }
                catch (Exception)
                {
                }

            }
            else
            {
                //_info[9] = "Error";
                mensajeLogin(true, mensajes.logErrcamp, mensajes.tipoInfo);
            }
            
        }





        /// <summary>
        /// metodo que recupera la clave del usuario
        /// </summary>
        public void Recoverpassword()
        {
            string[] _info = new string[10];
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            //Valores de la vista
            String email = _view.RecoverEmail.Value;
            String passwordnew1 = _view.Password1.Value;
            String passwordnew2 = _view.Password2.Value;
            String username = _view.UserRecover.Value;
            //Defino objeto a enviar como parametro al comando
            Employee _employee;
            //Objeto a recibir como resultado del comando 
            Employee _employeeResult = null;
            // comando del tipo deseado 
            Command CommandGetEmployeeByUser;
            //comando que guarda el usuario con el password cambiado
            Command CommandSaveEmployee;
            try
            {
                //obtenemos parametro del comando 
                _employee = (Employee)EntityFactory.GetEmployee();
                _employee.Username = username;
                //Obtenemos intancia del comando 
                CommandGetEmployeeByUser = CommandFactory.GetCommandGetEmployeeByUser(_employee.Username);
                //Se ejecuta comando deseado
                CommandGetEmployeeByUser.Execute();

                _employeeResult = (Employee)CommandGetEmployeeByUser.Receiver;
                if ((email != null) && (passwordnew1 != null) && (passwordnew2 != null) && (username != null))
                {
                    if (_employeeResult != null)
                    {
                        if (_employeeResult.UserAccount != null)
                        {
                            if (email.Equals(_employeeResult.UserAccount.Email))
                            {
                                if (passwordnew1.Equals(passwordnew2))
                                {
                                    System.Diagnostics.Debug.WriteLine("Entre a modificar contrase;a");
                                    _employeeResult.UserAccount.Password = passwordnew1;
                                    CommandSaveEmployee = CommandFactory.GetCommandSaveEmployee(_employeeResult);
                                    CommandSaveEmployee.Execute();
                                }
                                else
                                {
                                    mensajeLogin(true, mensajes.logErrpasword, mensajes.tipoInfo);
                                }
                            }
                            else
                            {
                                mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                            }
                        }
                        else
                        {
                            mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                        }
                    }
                    else
                    {
                        mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                    }
                }
                else
                {
                    mensajeLogin(true, mensajes.logErrcampvac, mensajes.tipoInfo);
                }
                System.Diagnostics.Debug.WriteLine(_employeeResult.Id);
            }
            catch (Exception)
            {
            }


        }



    }
}
