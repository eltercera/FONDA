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
using System.Web.UI.WebControls;
using System.Web;
using System.Text.RegularExpressions;
using com.ds201625.fonda.DataAccess.Exceptions;


namespace BackOfficePresenter.Login
{
    public class UserListPresenter : BackOfficePresenter.Presenter
    {

        private FactoryDAO _facDAO;
        private IEmployeeDAO _employeeDAO;
        private IRoleDAO _roleDAO;
        public IList<Employee> _employeeList;
        private IList<Role> _roleList;
        private Employee _employee;
        private IUserAccountDAO _userAccountDAO;
        //enlace entre el modelo y la vista
        private IUserListModel _view;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public UserListPresenter(IUserListModel viewUserList)
            : base(viewUserList)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewUserList;

        }

        public void ClearAlert()
        {
            _view.userListAlert.Attributes.Clear();
            _view.userListAlert.InnerHtml = "";
            System.Diagnostics.Debug.WriteLine("Entre en clear data");
        }

        public void ClearTable()
        {
            _view.tableUserList.Rows.Clear();
        }

        /// <summary>
        /// metodo que carga la tabla de usuarios
        /// </summary>
        /// <param name="_role"></param>
        public void LoadTable(string _role)
        {

            try
            {
                System.Diagnostics.Debug.WriteLine(_role, "empezando loadtable");
                //se limpia la tabla
                ClearTable();
                //se carga con los usuarios dependieno del rol
                LoadDataTable(_role);
                System.Diagnostics.Debug.WriteLine(_role, "Entre en load table con rol");
            }
            catch (Exception e)
            {
                //Alerts("Exception");
            }
        }
        /// <summary>
        /// metodo que llena la tabla con usuarios dependiendo de rol del usuario
        /// </summary>
        /// <param name="_role">rol del usuario entrando al sistema</param>
        protected void LoadDataTable(string _role)
        {
            System.Diagnostics.Debug.WriteLine(_role, "Entre en load Datatable con rol");
            #region Attributes DAO
            _facDAO = FactoryDAO.Intance;
            _roleDAO = _facDAO.GetRoleDAO();
            //_roleList = _roleDAO.GetAll();
            _employeeDAO = _facDAO.GetEmployeeDAO();
            #endregion

            //_employeeList = _employeeDAO.GetAll();
            //Comando de buscar todos los empleados en el sistema
            Command CommanGetAllEmployee;
            CommanGetAllEmployee = CommandFactory.GetCommandGetAllEmployee("null");
            try
            {
                CommanGetAllEmployee.Execute();
            }
            catch (Exception)
            // CommanGetAllEmployee REVISAR
            {
            }
            _employeeList = (IList<Employee>)CommanGetAllEmployee.Receiver;
            System.Diagnostics.Debug.WriteLine("ejecute comando");
            string _idrest = (string)(HttpContext.Current.Session[ResourceLogin.sessionRestaurantID]);

            #region Llenar Tabla Employee
            //Se valida si la lista de empleado esta vacia
            if (_employeeList != null)
            {
                foreach (Employee _employee in _employeeList)
                {
                    //creo una nueva fila
                    TableRow tRow = new TableRow();
                    //genero las celdas que estaran en la fina
                    TableCell tCellName = new TableCell();
                    TableCell tCellLastName = new TableCell();
                    TableCell tCellSsn = new TableCell();
                    TableCell tCellRole = new TableCell();
                    TableCell tCellStatus = new TableCell();
                    TableCell tCellAction = new TableCell();
                    Label status = new Label();

                    //botones de las acciones
                    LinkButton edit = new LinkButton();
                    LinkButton editStatusA = new LinkButton();
                    LinkButton editStatusI = new LinkButton();

                    //boton modificar
                    edit.Click += new EventHandler(Modify_Click);
                    edit.Attributes.Add("data-id", _employee.Id.ToString());
                    edit.Text = G1RecursosInterfaz.edit;

                    //boton Modificar status Activo
                    editStatusA.Click += new EventHandler(ModifyStatus_Click);
                    editStatusA.Attributes.Add("data-id", _employee.Id.ToString());
                    editStatusA.Text = G1RecursosInterfaz.editstatusA;

                    //boton Modificar status Inactivo
                    editStatusI.Click += new EventHandler(ModifyStatus_Click);
                    editStatusI.Attributes.Add("data-id", _employee.Id.ToString());
                    editStatusI.Text = G1RecursosInterfaz.editstatusI;

                    //nombre del empleado
                    tCellName.Text = _employee.Name;
                    tRow.Cells.Add(tCellName);

                    //apellido del empleado
                    tCellLastName.Text = _employee.LastName;
                    tRow.Cells.Add(tCellLastName);

                    //ssn del empleado
                    tCellSsn.Text = _employee.Ssn;
                    tRow.Cells.Add(tCellSsn);

                    //rol del empleado
                    tCellRole.Text = _employee.Role.Name;
                    tRow.Cells.Add(tCellRole);

                    //validacion de status
                    if (_employee.Status.ToString() == "Activo")
                        status.Text = G1RecursosInterfaz.statusA;
                    else
                        status.Text = G1RecursosInterfaz.statusI;

                    //status del empleado
                    tCellStatus.HorizontalAlign = HorizontalAlign.Center;
                    tCellStatus.Controls.Add(status);
                    tRow.Cells.Add(tCellStatus);

                    //botodes de las acciones
                    tCellAction.HorizontalAlign = HorizontalAlign.Center;
                    tCellAction.Controls.Add(edit);
                    tCellAction.Controls.Add(editStatusA);
                    tCellAction.Controls.Add(editStatusI);
                    tRow.Cells.Add(tCellAction);


                    if (_role == "Restaurante")
                    {
                        if (_employee.Restaurant != null)
                            if (_employee.Restaurant.Id.ToString() == _idrest)
                                _view.tableUserList.Rows.Add(tRow);
                    }
                    else
                    {
                        _view.tableUserList.Rows.Add(tRow);
                    }

                }
                //Agrega el encabezado a la Tabla
                TableHeaderRow header = HeaderTabletEmployee();
                _view.tableUserList.Rows.AddAt(0, header);
            }
            #endregion

        }

        /// <summary>
        /// metodo que agrega una fila de empleado en la tabla de lista de usuarios
        /// </summary>
        /// <returns></returns>
        protected TableHeaderRow HeaderTabletEmployee()
        {
            //creo una nueva fila
            TableHeaderRow tRow = new TableHeaderRow();

            //genero las celdas que estaran en la fina
            TableHeaderCell tHCellName = new TableHeaderCell();
            TableHeaderCell tHCellLastName = new TableHeaderCell();
            TableHeaderCell tHCellSsn = new TableHeaderCell();
            TableHeaderCell tHCellRole = new TableHeaderCell();
            TableHeaderCell tHCellStatus = new TableHeaderCell();
            TableHeaderCell tHCellAction = new TableHeaderCell();

            tRow.TableSection = TableRowSection.TableHeader;
            //nombre del empleado
            tHCellName.Text = "Nombre";
            tHCellName.Scope = TableHeaderScope.Column;
            tRow.Cells.Add(tHCellName);

            //apellido del empleado
            tHCellLastName.Text = "Apellido";
            tHCellLastName.Scope = TableHeaderScope.Column;
            tRow.Cells.Add(tHCellLastName);

            //ssn del empleado
            tHCellSsn.Text = "CI";
            tHCellSsn.Scope = TableHeaderScope.Column;
            tRow.Cells.Add(tHCellSsn);

            //rol del empleado
            tHCellRole.Text = "Rol";
            tHCellRole.Scope = TableHeaderScope.Column;
            tRow.Cells.Add(tHCellRole);

            //status del empleado
            tHCellStatus.Text = "Status";
            tHCellStatus.Scope = TableHeaderScope.Column;
            tRow.Cells.Add(tHCellStatus);

            //acciones
            tHCellAction.Text = "Acciones";
            tHCellAction.Scope = TableHeaderScope.Column;
            tRow.Cells.Add(tHCellAction);

            return tRow;
        }



        public void Modify_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("entre modify presentador ");
            ClearModalAddModify();
            string _role = (string)(HttpContext.Current.Session[ResourceLogin.sessionRol]);
            ChangeRole(_role);
            if (_role == "Sistema")
                ChangeRestaurant();

            LinkButton clickedLink = (LinkButton)sender;
            int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);

            /*_facDAO = FactoryDAO.Intance;
            _employeeDAO = _facDAO.GetEmployeeDAO();
            _employee = _employeeDAO.FindById(_idEmployee);*/

            Command CommandGetEmployeeById;
            CommandGetEmployeeById = CommandFactory.GetCommandGetEmployeeById(_idEmployee);
            CommandGetEmployeeById.Execute();
            _employee = (Employee)CommandGetEmployeeById.Receiver;
            _view.textBoxNameUser.Text = _employee.Name;
            _view.textBoxlastNameUser.Text = _employee.LastName;
            _view.textBoxAddress.Text = _employee.Address;
            _view.textBoxPhoneNumber.Text = _employee.PhoneNumber;
            _view.dropDownListNss1.Text = _employee.Ssn.Substring(0, 1);
            int _length = (_employee.Ssn.Length) - 2;
            _view.textBoxNss2.Text = _employee.Ssn.Substring(2, _length);
            _view.DropDownListGender.Text = _employee.Gender.ToString();
            _view.textBoxBirtDate.Text = _employee.BirthDate.ToString("dd/MM/yyyy");
            _view.textBoxUserNameU.Text = _employee.Username;
            _view.DropDownListRole.Text = _employee.Role.Id.ToString();
            _view.textBoxEmail.Text = _employee.UserAccount.Email;
            _view.textBoxPaswword.Enabled = false;
            _view.textBoxRepitPaswword.Enabled = false;
            _view.buttonButtonAddModify.Text = "Modificar";
            _view.buttonButtonAddModify.Attributes.Add("data-id", _idEmployee.ToString());
            //ScriptManager.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            
        }

        protected void ClearModalAddModify()
        {
            _view.textBoxNameUser.Text = "";
            _view.textBoxNameUser.Attributes["placeholder"] = "Nombre";
            _view.textBoxlastNameUser.Text = "";
            _view.textBoxlastNameUser.Attributes["placeholder"] = "Apellido";
            _view.dropDownListNss1.Text = "";
            _view.textBoxNss2.Text = "";
            _view.textBoxNss2.Attributes["placeholder"] = "Ej. 19245998";
            _view.textBoxAddress.Text = "";
            _view.textBoxAddress.Attributes["placeholder"] = "Dirección";
            _view.textBoxEmail.Text = "";
            _view.textBoxEmail.Attributes["placeholder"] = "nickname@ejemplo.com";
            _view.textBoxPhoneNumber.Text = "";
            _view.textBoxPhoneNumber.Attributes["placeholder"] = "Ej. 04127890544";
            _view.textBoxBirtDate.Text = "";
            _view.textBoxBirtDate.Attributes["placeholder"] = "DD/MM/YYYY";
            _view.DropDownListRole.Items.Clear();
            _view.DropDownListRole.Items.Add("");
            _view.DropDownListGender.Text = "";
            _view.textBoxPaswword.Text = "";
            _view.textBoxPaswword.Attributes["placeholder"] = "Password";
            _view.textBoxRepitPaswword.Text = "";
            _view.textBoxRepitPaswword.Attributes["placeholder"] = "Repetir Password";
            _view.textBoxUserNameU.Text = "";
            _view.textBoxUserNameU.Attributes["placeholder"] = "Usuario";
            _view.textBoxPaswword.Enabled = true;
            _view.textBoxRepitPaswword.Enabled = true;
            _view.buttonButtonAddModify.Text = "Agregar";
        }
        /// <summary>
        /// metodo que carga los roles en el DropDown
        /// </summary>
        /// <param name="_role1"></param>
        protected void ChangeRole(string _role1)
        {
            _facDAO = FactoryDAO.Intance;
            Command CommandGetAllRoles;
            CommandGetAllRoles = CommandFactory.GetCommandGetAllRoles("null");
            try
            {
                CommandGetAllRoles.Execute();
            }
            catch (Exception)
            // falta CommandGetAllRoles
            {
            }
                _roleList = (IList<Role>)CommandGetAllRoles.Receiver;
            
            if (_roleList != null)
            {
                foreach (Role _role in _roleList)
                {
                    if ((_role1 != "Restaurante") && (_role.Id.ToString() == "3"))
                        _view.DropDownListRole.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                    if (_role.Id.ToString() != "3")
                        _view.DropDownListRole.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                }
            }
        }
        /// <summary>
        /// metodo que carga restaurantes en el dropdown
        /// </summary>
        protected void ChangeRestaurant()
        {   // comando que se trae todos los restaurantes del sistema
            Command CommandGetAllRestaurants;
            CommandGetAllRestaurants = CommandFactory.GetCommandGetAllRestaurants("null");
            try
            {
                CommandGetAllRestaurants.Execute();
            }
            catch(Exception)
            {

            }
            IList<Restaurant> _restList = (IList<Restaurant>)CommandGetAllRestaurants.Receiver;
            if (_restList != null)
            {
                foreach (Restaurant _rest in _restList)
                {
                    _view.dropDownListRestaurant.Items.Add(new ListItem(_rest.Name, _rest.Id.ToString()));
                }
            }
        }
        /// <summary>
        /// metodo que que agrega un empleado al sistema
        /// </summary>
        public void Add_Click()
        {
            //se limplia modal
            ClearModalAddModify();
            string _role = (string)(HttpContext.Current.Session[ResourceLogin.sessionRol]);
            ChangeRole(_role);
            System.Diagnostics.Debug.WriteLine("if del sistema");
            if (_role == "Sistema")
                ChangeRestaurant();
            System.Diagnostics.Debug.WriteLine("Entre en addclick del presentador");


        }
        /// <summary>
        /// metodo que cuando se le da boton de guardar valida y guarda el usuario
        /// </summary>
        /// <param name="sender"></param>
        public bool ModalAddModify_Click(object sender)
        {
            
            if (ValidarCampo(_view.buttonButtonAddModify.Text))
            {
                System.Diagnostics.Debug.WriteLine("entre validarcampos");
                // se trae nuevo usuario de fabrica
                _facDAO = FactoryDAO.Intance;
                _employeeDAO = _facDAO.GetEmployeeDAO();
                _roleDAO = _facDAO.GetRoleDAO();
                _userAccountDAO = _facDAO.GetUserAccountDAO();
                _employee = new Employee();
                bool _emailValid, _ssnValid, _userNameValid;
                //validacion de campos
                _emailValid = ValidationEmail();
                _ssnValid = ValidationSsn();
                _userNameValid = ValidationUsername();
                // se valida si se esta agregando o modificando

                if (_view.buttonButtonAddModify.Text == "Agregar")
                {
                    // se borra campo
                    if (_emailValid)
                    {
                        _view.HtmlGenericControlemenssageEmail.Attributes.Clear();
                        _view.HtmlGenericControlemenssageEmail.InnerHtml = "";
                    }
                    // se borra campo
                    if (_ssnValid)
                    {
                        _view.HtmlGenericControlemenssageSsn.Attributes.Clear();
                        _view.HtmlGenericControlemenssageSsn.InnerHtml = "";
                    }
                    // se borra campo
                    if (_userNameValid)
                    {
                        _view.HtmlGenericControlemenssageUsername.Attributes.Clear();
                        _view.HtmlGenericControlemenssageUsername.InnerHtml = "";
                    }
                }
                if (_view.buttonButtonAddModify.Text == "Modificar")
                {
                    Button clickedLink = (Button)sender;
                    int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);
                    //_employee = _employeeDAO.FindById(_idEmployee);
                    string _ssn = _view.dropDownListNss1.Text + "-" + _view.textBoxNss2.Text;
                    Command CommandGetEmployeeById = CommandFactory.GetCommandGetEmployeeById(_idEmployee);
                    try
                    {
                        CommandGetEmployeeById.Execute();
                    }
                    catch(Exception)
                    {

                    }
                    //REVISAR FALTA EXCEPTION
                    _employee = (Employee)CommandGetEmployeeById.Receiver;
                    //carga campo email con valor del usario a modificar
                    if (_view.textBoxEmail.Text == _employee.UserAccount.Email)
                    {
                        _emailValid = true;
                        _view.HtmlGenericControlemenssageEmail.Attributes.Clear();
                        _view.HtmlGenericControlemenssageEmail.InnerHtml = "";
                    }
                    //carga campo ssn con valor del usario a modificar
                    if (_ssn == _employee.Ssn)
                    {
                        _ssnValid = true;
                        _view.HtmlGenericControlemenssageSsn.Attributes.Clear();
                        _view.HtmlGenericControlemenssageSsn.InnerHtml = "";
                    }
                    //carga username email con valor del usario a modificar
                    if (_view.textBoxUserNameU.Text == _employee.Username)
                    {
                        _userNameValid = true;
                        _view.HtmlGenericControlemenssageUsername.Attributes.Clear();
                        _view.HtmlGenericControlemenssageUsername.InnerHtml = "";
                    }
                }
                System.Diagnostics.Debug.WriteLine("antes de if de boleeanos");
                //pregunta sobre validacion sobre existencia de valores en la bd
                if (_emailValid && _ssnValid && _userNameValid)
                {
                    System.Diagnostics.Debug.WriteLine("despues de if de boleeanos");
                    // se le da los valores al empleado creado
                    _employee = SetEmployee(_employee);
                    // se le da valor de activo
                    if (_view.buttonButtonAddModify.Text == "Agregar")
                    {

                            _employee.Status = _facDAO.GetActiveSimpleStatus();

                    }
                    // Seguarda usuario
                    if (_employee.UserAccount.Id.ToString() == "0")
                    {
                        // Comando para guardar userAccount
                        Command CommandSaveUserAccount = CommandFactory.GetCommandSaveEntity(_employee.UserAccount);
                        try
                        {
                            CommandSaveUserAccount.Execute();
                        }
                        catch (Exception)
                        {
                        }    
                            
                        //_userAccountDAO.Save(_employee.UserAccount);
                    }
                    System.Diagnostics.Debug.WriteLine("Guarde en la bd");
                    Command CommandSaveEmployee = CommandFactory.GetCommandSaveEmployee(_employee);
                    try
                    {
                        CommandSaveEmployee.Execute();
                    }
                    catch (Exception)
                    {
                    }

                    //_employeeDAO.Save(_employee);
                    //alerta de exito de guardado
                    if (_view.buttonButtonAddModify.Text == "Agregar")
                    {
                        Alerts("Add");
                    }
                    //alerta de exito de guardado
                    if (_view.buttonButtonAddModify.Text == "Modificar")
                    {
                        Alerts("Modify");
                    }
                    ClearModalAddModify();

                }
                else
                {
                    return true;
                   // ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
                }
            }
            else
            {
                return true;
                //ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            }
            return false;
        }
        /// <summary>
        /// metodo que valida los campos del modal 
        /// </summary>
        /// <param name="accion">accion puede ser modificar o agregar</param>
        /// <returns></returns>
        public bool ValidarCampo(String accion)
        {
            int good = 0;
            int bad = 0;
            //rol
            string _role = (string)(HttpContext.Current.Session[ResourceLogin.sessionRol]);
            //patron de numero del 0 al 9
            string patronNumero = "^[0-9]*$";
            //patron de solo letras
            string patronTexto = "^[A-Z a-z]*$";
            //patrones alphanumericos
            string patronAlphaNumerico1 = "^[A-Z0-9(.) a-z]*$";
            string patronAlphaNumerico2 = "^[A-Z0-9a-z]*$";
            //patron de fechas
            string patronFecha = @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d";
            //patron de email
            string patronEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            //valor de los elementos en el modal
            string Name = _view.textBoxNameUser.Text;
            string LastName = _view.textBoxlastNameUser.Text;
            string Nacionalidad= Convert.ToString(_view.dropDownListNss1.Text);
            string Identity = _view.dropDownListNss1.Text;
            string Dni = _view.textBoxNss2.Text;
            string Birthdate = _view.textBoxBirtDate.Text;
            string Phone = _view.textBoxPhoneNumber.Text;
            string Gender = Convert.ToString(_view.DropDownListGender.Text);
            string Address = _view.textBoxAddress.Text;
            string Role = _view.DropDownListRole.Text;
            string UserName = _view.textBoxUserNameU.Text;
            string Email = _view.textBoxEmail.Text;
            string Password1 = _view.textBoxPaswword.Text;
            string Password2 = _view.textBoxRepitPaswword.Text;
            string Restaurant = _view.dropDownListRestaurant.Text;
            //validacion de accion si se quiere validar y campos vacios
            if (accion == "Agregar")
            {
                System.Diagnostics.Debug.WriteLine("entre accion agregar validando");
                if (Name == "" | LastName == "" | Identity == "" | Phone == "" | Role == ""
                    | UserName == "" | Email == "" | Password1 == "" | Password2 == "" | Gender == "" | Nacionalidad=="" 
                    | Dni == "" | Birthdate =="" | Address == "")
                {
                    System.Diagnostics.Debug.WriteLine("entre accion agregar validando2");
                    Alerts("Empty");
                    bad = ++bad;
                    return false;
                }
                else
                {
                    //se muestran mensajes
                    System.Diagnostics.Debug.WriteLine("entre accion agregar else");
                    _view.HtmlGenericControlemessageEmpty.Attributes.Clear();
                    _view.HtmlGenericControlemessageEmpty.InnerHtml = "";
                }
            }
            //validacion de campos vacios
            if (accion == "Modificar")
            {
                if (Name == "" | LastName == "" | Identity == "" | Phone == "" | Role == ""
                    | UserName == "" | Email == "" | (_role != "Sistema" && Restaurant == ""))
                {
                    Alerts("Empty");
                    bad = ++bad;
                    return false;
                }
                else
                {
                    //validacion de campos vacios
                    _view.HtmlGenericControlemessageEmpty.Attributes.Clear();
                    _view.HtmlGenericControlemessageEmpty.InnerHtml = "";
                }

            }
            //Validacion de patron con respecto a nombre
            if ((!Regex.IsMatch(Name, patronTexto)))
            {
                Alerts("InvalidFormatName");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlmessageNameUser.Attributes.Clear();
                _view.HtmlGenericControlmessageNameUser.InnerHtml = "";
            }
            //Validacion de patron con respecto a apellido
            if ((!Regex.IsMatch(LastName, patronTexto)))
            {
                Alerts("InvalidFormatLastName");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessageLastName.Attributes.Clear();
                _view.HtmlGenericControlemessageLastName.InnerHtml = "";
            }
            //Validacion de patron con respecto a dni
            if ((!Regex.IsMatch(Dni, patronNumero)))
            {
                Alerts("InvalidFormatDni");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessageDni.Attributes.Clear();
                _view.HtmlGenericControlemessageDni.InnerHtml = "";
            }
            //Validacion de patron con respecto a fecha de nacimiento
            if ((!Regex.IsMatch(Birthdate, patronFecha)))
            {
                Alerts("InvalidFormatBirthdate");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessageBirthdate.Attributes.Clear();
                _view.HtmlGenericControlemessageBirthdate.InnerHtml = "";
            }
            //Validacion de patron con respecto a numero telefonico
            if ((!Regex.IsMatch(Phone, patronNumero)))
            {
                Alerts("InvalidFormatPhone");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessagePhone.Attributes.Clear();
                _view.HtmlGenericControlemessagePhone.InnerHtml = "";
            }
            //Validacion de patron con respecto a nombre
            if ((!Regex.IsMatch(Address, patronAlphaNumerico1)))
            {
                Alerts("InvalidFormatAddress");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessageAddress.Attributes.Clear();
                _view.HtmlGenericControlemessageAddress.InnerHtml = "";
            }


            //Validacion de patron con respecto a nombre de usuario
            if ((!Regex.IsMatch(UserName, patronAlphaNumerico2)))
            {
                Alerts("InvalidFormatUser");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessageUser.Attributes.Clear();
                _view.HtmlGenericControlemessageUser.InnerHtml = "";
            }
            //Validacion de patron con respecto a correo
            if ((!Regex.IsMatch(Email, patronEmail)))
            {
                Alerts("InvalidFormatEmail");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemenssageEmail.Attributes.Clear();
                _view.HtmlGenericControlemenssageEmail.InnerHtml = "";
            }
            //Validacion de patron con respecto a contrase;a
            if ((!Regex.IsMatch(Password1, patronAlphaNumerico2)))
            {
                Alerts("InvalidFormatPassword1");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessagePassword1.Attributes.Clear();
                _view.HtmlGenericControlemessagePassword1.InnerHtml = "";
            }
            //Validacion de patron con respecto a validacion de contrase;a
            if ((!Regex.IsMatch(Password2, patronAlphaNumerico2)))
            {
                Alerts("InvalidFormatPassword2");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessagePassword2.Attributes.Clear();
                _view.HtmlGenericControlemessagePassword2.InnerHtml = "";
            }
            //Validacion de claves iguales
            if (!(Password1 == Password2))
            {
                Alerts("InvalidFormatPasswordEqual");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                _view.HtmlGenericControlemessagePasswordEqual.Attributes.Clear();
                _view.HtmlGenericControlemessagePasswordEqual.InnerHtml = "";
            }

            //si no hubo errores true , sino false
            if (bad == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Alerts(string _success)
        {
            switch (_success)
            {
                case "Add":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Empleado ha sido" + G1RecursosInterfaz.strongAdd;
                    break;

                case "Modify":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Empleado ha sido" + G1RecursosInterfaz.strongModify;
                    break;

                case "Status":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Status del Empleado ha sido" + G1RecursosInterfaz.strongModify;
                    break;

                case "DangerAdd":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al agregar el Empleado";
                    break;

                case "DangerModify":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al modificar el Empleado";
                    break;

                case "DangerStatus":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al modificar Status del Empleado";
                    break;

                case "Exception":
                    break;

                case "Cancel":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + "La acción ha sido" + G1RecursosInterfaz.strogCancel;
                    break;

                case "DangerEmail":
                    _view.HtmlGenericControlemenssageEmail.InnerHtml = G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongNot + "Disponible!";
                    break;

                case "DangerUsername":
                    _view.HtmlGenericControlemenssageUsername.InnerHtml = G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongNot + "Disponible!";
                    break;

                case "DangerSsn":
                    _view.HtmlGenericControlemenssageSsn.InnerHtml = G1RecursosInterfaz.iconDanger + " Ya Existe!";
                    break;

                case "InvalidFormatName":
                    _view.HtmlGenericControlmessageNameUser.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo letras y espacios";
                    break;

                case "InvalidFormatLastName":
                    _view.HtmlGenericControlemessageLastName.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo letras y espacios";
                    break;

                case "InvalidFormatDni":
                    _view.HtmlGenericControlemessageDni.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo números";
                    break;

                case "InvalidFormatPhone":
                    _view.HtmlGenericControlemessagePhone.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo";
                    break;

                case "InvalidFormatAddress":
                    _view.HtmlGenericControlemessageAddress.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico con espacios";
                    break;

                case "InvalidFormatUser":
                    _view.HtmlGenericControlemessageUser.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                    break;

                case "InvalidFormatEmail":
                    _view.HtmlGenericControlemessageEmail.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato de Correo Inválido!";
                    break;

                case "InvalidFormatPassword1":
                    _view.HtmlGenericControlemessagePassword1.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                    break;

                case "InvalidFormatPassword2":
                    _view.HtmlGenericControlemessagePassword2.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                    break;

                case "InvalidFormatPasswordEqual":
                    _view.HtmlGenericControlemessagePasswordEqual.InnerHtml = G1RecursosInterfaz.iconDanger + " Las contraseñas no coinciden";
                    break;

                case "InvalidFormatBirthdate":
                    _view.HtmlGenericControlemessageBirthdate.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato de fecha inválido (DD/MM/YYYY)";
                    break;

                case "Empty":
                    _view.HtmlGenericControlemessageEmpty.InnerHtml = G1RecursosInterfaz.iconExclamation + " Uno o mas Campos Obligatorios Vacíos";
                    break;

            }
        }

        /// <summary>
        /// metodo que valida ssn del usuario existe
        /// </summary>
        /// <returns></returns>
        protected bool ValidationSsn()
        {
            try
            {
                _employee = new Employee();
                string _ssn = _view.dropDownListNss1.Text + "-" + _view.textBoxNss2.Text;
                //_employee = _employeeDAO.FindBySsn(_ssn);
                Command CommandGetEmployeeBySsn;
                CommandGetEmployeeBySsn = CommandFactory.GetComandGetEmployeeBySsn(_ssn);
                CommandGetEmployeeBySsn.Execute();
                _employee = (Employee)CommandGetEmployeeBySsn.Receiver;
                if (_employee != null)
                {
                    Alerts("DangerSsn");
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ValidationSsnEmployeeFondaBackOfficeException(
                    "Excepción al validar Ssn del Empleado",
                    e);
            }
        }
        /// <summary>
        /// metodo que valida que correo del usuario exista
        /// </summary>
        /// <returns></returns>

        protected bool ValidationEmail()
        {
            try
            {
                /*_userAccountDAO = _facDAO.GetUserAccountDAO();
                UserAccount _userAccount = new UserAccount();
                _userAccount = _userAccountDAO.FindByEmail(_view.textBoxEmail.Text);*/
                UserAccount _userAccount = new UserAccount();
                Command ComandoGetUserAccountByEmail;
                ComandoGetUserAccountByEmail = CommandFactory.GetComandoGetUserAcountByEmail(_view.textBoxEmail.Text);
                ComandoGetUserAccountByEmail.Execute();
                _userAccount = (UserAccount)ComandoGetUserAccountByEmail.Receiver;
                if (_userAccount != null)
                {
                    Alerts("DangerEmail");
                    return false;
                }
                return true;
            }
            catch (FindByusernameEmployeFondaDAOException e)
            {
                throw new ValidationUsernameEmployeeFondaBackOfficeException(
                    "Excepción al validar Username del Empleado",
                    e);
            }
            catch (Exception e)
            {
                throw new GetAllEmployeFondaDAOException(
                    "Excepción al validar Username del Empleado",
                    e);
            }
        }
        /// <summary>
        /// valida que username no exista ya en la bd
        /// </summary>
        /// <returns></returns>
        protected bool ValidationUsername()
        {
            try
            {
                _employee = new Employee();
                //_employee = _employeeDAO.FindByusername(this.userNameU.Text);
                Command CommandGetEmployeeByUser = CommandFactory.GetCommandGetEmployeeByUser(_view.textBoxUserNameU.Text);
                CommandGetEmployeeByUser.Execute();
                _employee = (Employee)CommandGetEmployeeByUser.Receiver;
                if (_employee != null)
                {
                    Alerts("DangerUsername");
                    return false;
                }
                return true;
            }
            catch (FindByusernameEmployeFondaDAOException e)
            {
                throw new ValidationUsernameEmployeeFondaBackOfficeException(
                    "Excepción al validar Username del Empleado",
                    e);
            }
            catch (Exception e)
            {
                throw new GetAllEmployeFondaDAOException(
                    "Excepción al validar Username del Empleado",
                    e);
            }
        }
        /// <summary>
        /// metodo que le da valores del objeto employee a guardar en la bd
        /// </summary>
        /// <param name="_employee">employee a agregar</param>
        /// <returns></returns>
        protected Employee SetEmployee(Employee _employee)
        {
            string _roleUser = (string)HttpContext.Current.Session[ResourceLogin.sessionRol];
            Role _role;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            Restaurant _restaurant;
            // se le da todos los valores de los atributos del tipo empleado
            _employee = new Employee();
            if (_view.textBoxNameUser.Text != "")
                _employee.Name = _view.textBoxNameUser.Text;
            if (_view.textBoxlastNameUser.Text != "")
                _employee.LastName = _view.textBoxlastNameUser.Text;
            if (_view.textBoxAddress.Text != "")
                _employee.Address = _view.textBoxAddress.Text;
            if (_view.textBoxPhoneNumber.Text != "")
                _employee.PhoneNumber = _view.textBoxPhoneNumber.Text;
            if (_view.dropDownListNss1.Text != "" && _view.textBoxNss2.Text != "")
            {
                string _ssn = _view.dropDownListNss1.Text + "-" + _view.textBoxNss2.Text;
                _employee.Ssn = _ssn;
            }
            if (_view.DropDownListGender.Text != "")
                _employee.Gender = char.Parse(_view.DropDownListGender.SelectedValue);
            if (_view.textBoxBirtDate.Text != "")
                _employee.BirthDate = DateTime.Parse(_view.textBoxBirtDate.Text);
            if (_view.textBoxUserNameU.Text != "")
                _employee.Username = _view.textBoxUserNameU.Text;
            if (_view.DropDownListRole.Text != "")
            {
                _role = _roleDAO.FindById(int.Parse(_view.DropDownListRole.SelectedValue));
                _employee.Role = _role;
            }
            if (_view.buttonButtonAddModify.Text == "Agregar")
            {
                if (_view.textBoxEmail.Text != "" && _view.textBoxPaswword.Text != "")
                {
                    //se le agrega cuenta del sistema al empleado
                    UserAccount _userAccount = new UserAccount();
                    _userAccount.Email = _view.textBoxEmail.Text;
                    _userAccount.Password = _view.textBoxPaswword.Text;
                    _employee.UserAccount = _userAccount;
                }

            }
            else
            {
                if (_view.buttonButtonAddModify.Text == "Modificar")
                {//se le agrega cuenta del sistema al usuario
                    if (_view.textBoxEmail.Text != "")
                        _employee.UserAccount.Email = _view.textBoxEmail.Text;

                }
            }
            //solo empleado sistema puede agregar a sistema
            if (_roleUser == "Sistema")
            {
                if (_employee.Role.Name != "Sistema")
                {
                    // se le agrega restaurante al empleado
                    if (_view.dropDownListRestaurant.Text != "")
                    {
                        //_restaurant = _restaurantDAO.FindById(int.Parse(this.restaurant.SelectedValue));
                        Restaurant _restaurantParam = (Restaurant)EntityFactory.GetRestaurant();
                        _restaurantParam.Id = int.Parse(_view.dropDownListRestaurant.SelectedValue);
                        Command CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_restaurantParam);
                        try
                        {
                            CommandGetRestaurantById.Execute();
                        }
                        catch (Exception)
                        {
                        }
                        //REVISAR
                        _restaurant = (Restaurant)CommandGetRestaurantById.Receiver;
                        _employee.Restaurant = _restaurant;
                    }
                }
                else
                    _employee.Restaurant = null;

            }
            else
            {
                //solo rol restaurante puede agregar empleado de restaurant
                string _idrest = (string)(HttpContext.Current.Session[ResourceLogin.sessionRestaurantID]);
                //_restaurant = _restaurantDAO.FindById(int.Parse(_idrest));
                Restaurant _restaurantParam = (Restaurant)EntityFactory.GetRestaurant();
                _restaurantParam.Id = int.Parse(_idrest);
                Command CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_restaurantParam);
                try
                {
                    CommandGetRestaurantById.Execute();
                    _restaurant = (Restaurant)CommandGetRestaurantById.Receiver;
                    _employee.Restaurant = _restaurant;
                }
                catch(Exception)
                {
                }
            }

            return _employee;
        }
        /// <summary>
        /// metodo que se encarga de modificar el estado del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ModifyStatus_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("entre en presentador");
            _facDAO = FactoryDAO.Intance;
            //_employeeDAO = _facDAO.GetEmployeeDAO();
            _employee = new Employee();

            LinkButton clickedLink = (LinkButton)sender;
            int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);
            //_employee = _employeeDAO.FindById(_idEmployee);
            //comando que busca el usuario
            Command CommandGetEmployeeById = CommandFactory.GetCommandGetEmployeeById(_idEmployee);
            try
            {
                CommandGetEmployeeById.Execute();
                _employee = (Employee)CommandGetEmployeeById.Receiver;

            }
            catch(Exception)
            //REVISAR
            {

            }
            //validacion de en que estado se encuentra y se cambia
            if (clickedLink.Text == G1RecursosInterfaz.editstatusA)
                _employee.Status = _facDAO.GetActiveSimpleStatus();
            if (clickedLink.Text == G1RecursosInterfaz.editstatusI)
                _employee.Status = _facDAO.GetDisabledSimpleStatus();
            //_employeeDAO.Save(_employee);
            //comando que guarda el empleado
            Command CommandSaveEmployee = CommandFactory.GetCommandSaveEmployee(_employee);
            try
            {
                CommandSaveEmployee.Execute();
            }
            catch(Exception)
            {

            }
            Alerts("Status");
            System.Diagnostics.Debug.WriteLine("lo hice perro");
        }

    }
}
    

    
