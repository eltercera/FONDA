
using BackOfficeModel.Login;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.FondaCommandException.login;
using FondaLogic.FondaCommandException.Login;
using FondaLogic.Log;
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


        /// <summary>
        /// Procedimiento que muestra mensaje dependiendo del error ocurrido
        /// </summary>
        /// <param name="visible">booleano indicando si se muestra mensaje o no</param>
        /// <param name="message">String a mostrar en el mensaje</param>
        /// <param name="type">Tipo de mensaje a mostrar</param>
        public void mensajeLogin(Boolean visible, string message, string type)
        {
            System.Diagnostics.Debug.WriteLine("entre en mensaje");
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
                    
                    _view.alertinfoLog.Visible = visible;
                    _view.alertloginError.Visible = !visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertinfoLog.InnerText = message; break;
                case "Success":
                    System.Diagnostics.Debug.WriteLine("entre en mensaje");
                    _view.alertsuccessLog.Visible = visible;
                    _view.alertloginError.Visible = !visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.InnerText = message; break;
                case "State":

                    _view.alertloginError.Visible = visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertloginError.InnerText = message; break;
                case "userInvalid":

                    _view.alertloginError.Visible = visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertloginError.InnerText = message; break;

                case "passwodInvalid":

                    _view.alertloginError.Visible = visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertloginError.InnerText = message; break;
                case "emailInvalid":

                    _view.alertloginError.Visible = visible;
                    _view.alertwarningLog.Visible = !visible;
                    _view.alertinfoLog.Visible = !visible;
                    _view.alertsuccessLog.Visible = !visible;
                    _view.alertloginError.InnerText = message; break;
            }

        }
        /// <summary>
        /// metodo que valida los campos de entrada de la vista
        /// </summary>
        /// <returns></returns>
        public bool validateCapsEnter()
        {
            //variable de resultado
            bool result = true;
            //valor del campo de texto
            string user = _view.UserIni.Value;
            //resultado de validacion
            bool formatValideUsername = true;
            //resultado de validacion
            bool formatValidePassword = true;
            //validacion de user
            formatValideUsername = validaString("^[A-Z0-9a-z]*$", user);
            //validacion de formato de password
            formatValidePassword = validaString("^[A-Z0-9a-z]*$", _view.UserPassword.Value);
            if (formatValideUsername == false)
            {
                //retorno de falso 
                result = false;
                //mensaje de error
                mensajeLogin(true, mensajes.loguserInvalid, mensajes.tipoUserInvalid);
            }
            if (formatValidePassword == false)
            {
                //retorno de false
                result = false;
                //mensaje de error
                mensajeLogin(true, mensajes.logpassInvalid, mensajes.tipoPasswordInvalid);
            }

            return result;
        }

        /// <summary>
        /// metodo que valida el ingreso del usuario
        /// </summary>
        /// 
        public void ValidateUser()
        {

            string user = _view.UserIni.Value;
            bool validateCamps = validateCapsEnter();
            if (validateCamps)
            {
                // usuario intentando ingresar
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
                        //Validacion de que no se encontro usuario
                        if (_employeeResult != null)
                        {
                            if (_employeeResult.Status.StatusId.ToString() == "1")
                            {
                                System.Diagnostics.Debug.WriteLine("estado activo!");
                                System.Diagnostics.Debug.WriteLine("Consegui la cuenta!");
                                System.Diagnostics.Debug.WriteLine(_employeeResult.Name);
                                if (_employeeResult.UserAccount != null)
                                {
                                    _userPassword = _employeeResult.UserAccount.Password;
                                    System.Diagnostics.Debug.WriteLine("Es el password de la cuenta", _userPassword);
                                    //Validacion de que la cuenta que intenta ingresar al sistema tiene
                                    //clave correcta
                                    if ((_userPassword == _view.UserPassword.Value))
                                    {
                                        System.Diagnostics.Debug.WriteLine("Aprobe el login");
                                        //Se le da valores a las variables de session 
                                        HttpContext.Current.Session[ResourceLogin.sessionRol] = (string)_employeeResult.Role.Name;
                                        HttpContext.Current.Session[ResourceLogin.sessionName] = _employeeResult.Name;
                                        HttpContext.Current.Session[ResourceLogin.sessionLastname] = _employeeResult.LastName;
                                        HttpContext.Current.Session[ResourceLogin.sessionUserID] = _employeeResult.Id;
                                        System.Diagnostics.Debug.WriteLine(_employeeResult.Restaurant.Id, "ID del restaurant");
                                        if (_employeeResult.Restaurant != null)
                                        {
                                            string RestaurantID = _employeeResult.Restaurant.Id.ToString();
                                            int idRestaurant = int.Parse(RestaurantID);
                                            _restaurant = (Restaurant)EntityFactory.GetRestaurant();
                                            _restaurant.Id = idRestaurant;
                                            //se busca el restaurante del empleado para dar valores a las 
                                            //variables de session
                                            CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_restaurant);
                                            CommandGetRestaurantById.Execute();
                                            _restaurantResult = (Restaurant)CommandGetRestaurantById.Receiver;
                                            HttpContext.Current.Session[ResourceLogin.sessionRestaurantID] = _employeeResult.Restaurant.Id.ToString();
                                            HttpContext.Current.Session[RestaurantResource.SessionRestaurant] = _restaurantResult.Id.ToString();
                                            HttpContext.Current.Session[RestaurantResource.SessionNameRest] = _restaurantResult.Name;
                                            /* Asignacion de variable de session */
                                            _view.SessionRestaurant = _employeeResult.Restaurant.Id.ToString();
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
                                        //error claves distintas, se llama a mostrar mensaje de error
                                        System.Diagnostics.Debug.WriteLine("clave mala");
                                        //_info[7] = "Error";
                                        mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
                                    }
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("Estado inactivo");
                                mensajeLogin(true, mensajes.logState, mensajes.tipoState);
                            }
                        }
                        else
                        {
                            //error buscando empleado ,  se llama a mostrar mensaje de error
                            System.Diagnostics.Debug.WriteLine("No se encontro usuario");
                            //_info[8] = "Error";
                            mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
                        }

                    }
                    catch (InvalidTypeOfParameterException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameInvalidParameter, e);
                    }
                    catch (ParameterIndexOutOfRangeException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameIndexParameter, e);
                    }
                    catch (RequieredParameterNotFoundException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameParameterNotFound, e);
                    }
                    catch (Exception e)
                    {
                        
                    }
                    // Guarda el resultado.
                    Object Result = _employeeResult;
                    //logger
                    Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
                else
                {
                    //_info[9] = "Error";  se llama a mostrar mensaje de error
                    mensajeLogin(true, mensajes.logErrcamp, mensajes.tipoInfo);
                }

            }
        }





        /// <summary>
        /// metodo que recupera la clave del usuario
        /// </summary>
        public void Recoverpassword()
        {
            bool validateCamps = validateCapsRecover();
            if (validateCamps)
            {
                //Fabrica de Dao
                FactoryDAO factoryDAO = FactoryDAO.Intance;
                //Valores de la vista
                //email del usuario
                String email = _view.RecoverEmail.Value;
                //password1 de la nueva clave
                String passwordnew1 = _view.Password1.Value;
                //password de la nueva clave
                String passwordnew2 = _view.Password2.Value;
                //username intentando entrar 
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
                    //se obtiene empleado buscado
                    _employeeResult = (Employee)CommandGetEmployeeByUser.Receiver;
                    //validacion de campos vacios
                    if ((email != null) && (passwordnew1 != null) && (passwordnew2 != null) && (username != null))
                    {
                        //validacion de haber encontrado
                        if (_employeeResult != null)
                        {
                            if (_employeeResult.UserAccount != null)
                            {
                                //validacion correo intentando entrar igual al de la bd
                                if (email.Equals(_employeeResult.UserAccount.Email))
                                {
                                    //validacion de claves de verifacion iguales
                                    if (passwordnew1.Equals(passwordnew2))
                                    {
                                        System.Diagnostics.Debug.WriteLine("Entre a modificar contrase;a");
                                        mensajeLogin(true, mensajes.logSuccess, mensajes.tipoSucess);
                                        _employeeResult.UserAccount.Password = passwordnew1;
                                        CommandSaveEmployee = CommandFactory.GetCommandSaveEmployee(_employeeResult);
                                        CommandSaveEmployee.Execute();

                                        //mensajeLogin(true, mensajes.logSuccess, mensajes.tipoSucess);
                                    }
                                    else
                                    {
                                        // se muestra error 
                                        mensajeLogin(true, mensajes.logErrpasword, mensajes.tipoInfo);
                                    }
                                }
                                else
                                {
                                    // se muestra error
                                    mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                                }
                            }
                            else
                            {
                                // se muestra error
                                mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                            }
                        }
                        else
                        {
                            // se muestra error
                            mensajeLogin(true, mensajes.logWarningcamp, mensajes.tipoWarning);
                        }
                    }
                    else
                    {
                        // se muestra error
                        mensajeLogin(true, mensajes.logErrcampvac, mensajes.tipoInfo);
                    }
                    System.Diagnostics.Debug.WriteLine(_employeeResult.Id);
                }
                catch (SaveEntityFondaDAOException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameSaveEmployee, e);

                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameInvalidParameter, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameIndexParameter, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameParameterNotFound, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameSaveEmployee, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameSaveEmployee, e);
                }
                // Guarda el resultado.
                Employee Result = _employee;
                //logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);



            }
        }
        /// <summary>
        /// metodo que valida los campos de entrada de la vista
        /// </summary>
        /// <returns></returns>
        public bool validateCapsRecover()
        {
            //variable de resultado
            bool result = true;
            //valor del campo de texto
            string user = _view.UserRecover.Value;
            //resultado de validacion
            bool formatValideUsername = true;
            //resultado de validacion
            bool formatValidePassword1 = true;
            bool formatValidePassword2 = true;
            //resultado de validacion
            bool formatValideEmail = true;
            //validacion de user
            formatValideUsername = validaString("^[A-Z0-9a-z]*$", user);
            //validacion de formato de password
            formatValidePassword1 = validaString("^[A-Z0-9a-z]*$", _view.Password1.Value);
            formatValidePassword2 = validaString("^[A-Z0-9a-z]*$", _view.Password2.Value);
            formatValideEmail = validaString(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",_view.RecoverEmail.Value);
            if (formatValideUsername == false)
            {
                //retorno de falso 
                result = false;
                //mensaje de error
                mensajeLogin(true, mensajes.loguserInvalid, mensajes.tipoUserInvalid);
            }
            if (formatValidePassword1 == false)
            {
                //retorno de false
                result = false;
                //mensaje de error
                mensajeLogin(true, mensajes.logpassInvalid, mensajes.tipoPasswordInvalid);
            }
            if (formatValidePassword2 == false)
            {
                //retorno de false
                result = false;
                //mensaje de error
                mensajeLogin(true, mensajes.logpassInvalid, mensajes.tipoPasswordInvalid);
            }
            if (formatValideEmail == false)
            {
                //retorno de false
                result = false;
                //mensaje de error
                mensajeLogin(true, mensajes.logemailInvalid, mensajes.tipoEmailInvalidad);
            }
            return result;
        }



    }
}
