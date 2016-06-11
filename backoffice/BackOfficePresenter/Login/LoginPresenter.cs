using BackOfficeModel.Login;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;



namespace com.ds201625.fonda.BackOffice.Presenter
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
        /// metodo que valida el ingreso del usuario
        /// </summary>
        /// <param name="user">usuario intentando entrar</param>
        public string[] ValidateUser()
        {
            // usuario intentando ingresar
            string user = _view.UserIni.Value;
            System.Diagnostics.Debug.WriteLine("Entre a LoginPresenter");
            System.Diagnostics.Debug.WriteLine("valor de userIni : " ,user);
            //Defino objeto a recibir
            Employee _employee;
            //Objeto a enviar como parametro
            Employee _employeeResult = null;
            //Invoca comando del tipo deseado 
            Command<Employee> CommandGetEmployeeByUser;
            //Comando que me trae restaurante del usuario
            Command<Restaurant> CommandGetRestaurantById;
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
                    CommandGetEmployeeByUser = CommandFactory.GetCommandGetEmployeeByUser();
                    //Se envia el atributo usado como parametro a traves de Entity
                    CommandGetEmployeeByUser.Entity = _employee;
                    //Se ejecuta comando deseado
                    _employeeResult = CommandGetEmployeeByUser.Execute();
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

                                //SessionRecursoMaster.sessionRol] = _employeeResult.Role.Name;
                                //Session[RecursoMaster.sessionName] = _employeeResult.Name;
                                //Session[RecursoMaster.sessionLastname] = _employeeResult.LastName;
                                //Session[RecursoMaster.sessionUserID] = _employeeResult.Id;
                                _info[0] = _employeeResult.Role.Name;
                                _info[1] = _employeeResult.Name;
                                _info[2] = _employeeResult.LastName;
                                _info[3] = _employeeResult.Id.ToString();
                                if (_employeeResult.Restaurant != null)
                                {
                                    /*
                                    Session[RecursoMaster.sessionRestaurantID] = _employee.Restaurant.Id;
                                    //Manejo de Restaurante
                                    string RestaurantID = _employee.Restaurant.Id.ToString();
                                    int idRestaurant = int.Parse(RestaurantID);
                                    com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);
                                    Session[RestaurantResource.SessionRestaurant] = _restaurant.Id.ToString();
                                    Session[RestaurantResource.SessionNameRest] = _restaurant.Name.ToString();*/
                                    string RestaurantID = _employeeResult.Restaurant.Id.ToString();
                                    int idRestaurant = int.Parse(RestaurantID);
                                    _restaurant = (Restaurant)EntityFactory.GetRestaurant();
                                    _restaurant.Id = idRestaurant;
                                    CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById();
                                    CommandGetRestaurantById.Entity = _restaurant;
                                    _restaurantResult = CommandGetRestaurantById.Execute();
                                    _info[4] = _employeeResult.Restaurant.Id.ToString();
                                    _info[5] = _restaurantResult.Id.ToString();
                                    _info[6] = _restaurantResult.Name;
                                    /*System.Diagnostics.Debug.WriteLine(_restaurantResult.Id.ToString(), "ID del restaurant");
                                    System.Diagnostics.Debug.WriteLine(_restaurantResult.Name.ToString(), "nombre del restaurant");*/
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
                                _info[7] = "Error";
                            }
                        }
                    }
                    else
                    {
                        //error buscando empleado 
                        System.Diagnostics.Debug.WriteLine("No se encontro usuario");
                        _info[8] = "Error";
                    }

                }
                catch (Exception)
                {
                }

            }
            else
            {
                _info[9] = "Error";
            }
            return _info;
        }
    }
}
