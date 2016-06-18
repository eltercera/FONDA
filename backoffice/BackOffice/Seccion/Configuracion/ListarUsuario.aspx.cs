using BackOffice.Content;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using com.ds201625.fonda.DataAccess.Exceptions;
using BackOfficeModel.Login;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficePresenter.Login;

namespace BackOffice.Seccion.Configuracion
{
    public partial class ListarUsuario : System.Web.UI.Page, IUserListModel
    {
        /*private FactoryDAO _facDAO;
        private IEmployeeDAO _employeeDAO;
        private IList<Employee> _employeeList;
        private IRoleDAO _roleDAO;
        private IUserAccountDAO _userAccountDAO;
        private IList<Role> _roleList;
        private Employee _employee;   */

        /*
        protected void LoadDataTable (string _role)
        {
            #region Attributes DAO
            _facDAO = FactoryDAO.Intance;
            _roleDAO = _facDAO.GetRoleDAO();
            _roleList = _roleDAO.GetAll();
            _employeeDAO = _facDAO.GetEmployeeDAO();
            #endregion

            _employeeList = _employeeDAO.GetAll();

            string _idrest = (string)(Session[RecursoMaster.sessionRestaurantID]);

            #region Llenar Tabla Employee
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
                                this.TablaEmployee.Rows.Add(tRow);
                    }
                    else
                    {
                        this.TablaEmployee.Rows.Add(tRow);
                    }
 
                }
                //Agrega el encabezado a la Tabla
                TableHeaderRow header = HeaderTabletEmployee();
                this.TablaEmployee.Rows.AddAt(0, header);
            }
            #endregion

        }
        
        protected void LoadTable()
        {
            try
            {
                string _role = (string)(Session[RecursoMaster.sessionRol]);
                ClearTable();
                LoadDataTable(_role);
            }
            catch (Exception e)
            {
                Alerts("Exception");
            }
        }
        /*
        protected void ClearTable()
        {
            this.TablaEmployee.Rows.Clear();
        }

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
        */

        

        /*
        protected void Modify_Click(object sender, EventArgs e)
        {
            
            ClearModalAddModify();
            string _role = (string)(Session[RecursoMaster.sessionRol]);
            ChangeRole(_role);
            if (_role == "Sistema")
                ChangeRestaurant();

            LinkButton clickedLink = (LinkButton)sender;
            int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);

            _facDAO = FactoryDAO.Intance;
            _employeeDAO = _facDAO.GetEmployeeDAO();
            _employee = _employeeDAO.FindById(_idEmployee);

            this.nameUser.Text = _employee.Name;
            this.lastNameUser.Text = _employee.LastName;
            this.address.Text = _employee.Address;
            this.phoneNumber.Text = _employee.PhoneNumber;
            this.nss1.Text = _employee.Ssn.Substring(0, 1);
            int _length = (_employee.Ssn.Length) - 2;
            this.nss2.Text = _employee.Ssn.Substring(2, _length);
            this.gender.Text = _employee.Gender.ToString();
            this.birtDate.Text = _employee.BirthDate.ToString("dd/MM/yyyy");
            this.userNameU.Text = _employee.Username;
            this.role.Text = _employee.Role.Id.ToString();
            this.email.Text = _employee.UserAccount.Email;
            this.password.Enabled = false;
            this.repitPassword.Enabled = false;
            this.ButtonAddModify.Text = "Modificar";
            this.ButtonAddModify.Attributes.Add("data-id", _idEmployee.ToString());
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);

        }
        */

        /*
        protected void ClearModalAddModify()
        {
            this.nameUser.Text = "";
            this.nameUser.Attributes["placeholder"] = "Nombre";
            this.lastNameUser.Text = "";
            this.lastNameUser.Attributes["placeholder"] = "Apellido";
            this.nss1.Text = "";
            this.nss2.Text = "";
            this.nss2.Attributes["placeholder"] = "Ej. 19245998";
            this.address.Text = "";
            this.address.Attributes["placeholder"] = "Dirección";
            this.email.Text = "";
            this.email.Attributes["placeholder"] = "nickname@ejemplo.com";
            this.phoneNumber.Text = "";
            this.phoneNumber.Attributes["placeholder"] = "Ej. 04127890544";
            this.birtDate.Text = "";
            this.birtDate.Attributes["placeholder"] = "DD/MM/YYYY";
            this.role.Items.Clear();
            this.role.Items.Add("");
            this.gender.Text = "";
            this.password.Text = "";
            this.password.Attributes["placeholder"] = "Password";
            this.repitPassword.Text = "";
            this.repitPassword.Attributes["placeholder"] = "Repetir Password";
            this.userNameU.Text = "";
            this.userNameU.Attributes["placeholder"] = "Usuario";
            this.password.Enabled = true;
            this.repitPassword.Enabled = true;
            this.ButtonAddModify.Text = "Agregar";     
        }

        protected void ChangeRole(string _role1)
        {
            _facDAO = FactoryDAO.Intance;
            _roleDAO = _facDAO.GetRoleDAO();
            _roleList = _roleDAO.GetAll();
            if (_roleList != null)
            {
                foreach (Role _role in _roleList)
                {
                    if ((_role1 != "Restaurante") && (_role.Id.ToString() == "3"))
                        this.role.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                    if (_role.Id.ToString() != "3")
                        this.role.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                }
            }
        }

        protected void ChangeRestaurant()
        {
            _facDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            IList<com.ds201625.fonda.Domain.Restaurant> _restList = _restaurantDAO.GetAll();
            if (_restList != null)
            {
                foreach (com.ds201625.fonda.Domain.Restaurant _rest in _restList)
                {
                        this.restaurant.Items.Add(new ListItem(_rest.Name, _rest.Id.ToString()));
                }
            }
        }

        protected Employee SetEmployee(Employee _employee)
        {
            string _roleUser = (string)(Session[RecursoMaster.sessionRol]);
            Role _role;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant;
            //_employee = new Employee();
            if (this.nameUser.Text != "")
                _employee.Name = this.nameUser.Text;
            if (this.lastNameUser.Text != "")
                _employee.LastName = this.lastNameUser.Text;
            if (this.address.Text != "")
                _employee.Address = this.address.Text;
            if (this.phoneNumber.Text != "")
                _employee.PhoneNumber = this.phoneNumber.Text;
            if (this.nss1.Text != "" && this.nss2.Text != "")
            {
                string _ssn = this.nss1.Text + "-" + this.nss2.Text;
                _employee.Ssn = _ssn;
            }
            if (this.gender.Text != "")
                _employee.Gender = char.Parse(this.gender.SelectedValue);
            if (this.birtDate.Text != "")
                _employee.BirthDate = DateTime.Parse(this.birtDate.Text);
            if (this.userNameU.Text != "")
                _employee.Username = this.userNameU.Text;
            if (this.role.Text != "")
            {
                _role = _roleDAO.FindById(int.Parse(this.role.SelectedValue));
                _employee.Role = _role;
            }
            if (this.ButtonAddModify.Text == "Agregar")
            {
                if (this.email.Text != "" && this.password.Text != "")
                {
                    UserAccount _userAccount = new UserAccount();
                    _userAccount.Email = this.email.Text;
                    _userAccount.Password = this.password.Text;
                    _employee.UserAccount = _userAccount;
                }

            }
            else
            {
                if (this.ButtonAddModify.Text == "Modificar")
                {
                    if (this.email.Text != "")
                        _employee.UserAccount.Email = this.email.Text;

                }
            }

            if (_roleUser == "Sistema")
            {
                if (_employee.Role.Name != "Sistema")
                {
                    if (this.restaurant.Text != "")
                    {
                        _restaurant = _restaurantDAO.FindById(int.Parse(this.restaurant.SelectedValue));
                        _employee.Restaurant = _restaurant;
                    }
                }
                else
                    _employee.Restaurant = null;

            }
            else
            {
                    string _idrest = (string)(Session[RecursoMaster.sessionRestaurantID]);
                    _restaurant = _restaurantDAO.FindById(int.Parse(_idrest));
                    _employee.Restaurant = _restaurant;
            }

            return _employee;
        }
        */

        /*
        protected void Alerts(string _success)
        {
            switch (_success)
            {
                case "Add":     this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                                this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Empleado ha sido" + G1RecursosInterfaz.strongAdd;
                                break;

                case "Modify":  this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                                this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Empleado ha sido" + G1RecursosInterfaz.strongModify;
                                break;

                case "Status":  this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                                this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Status del Empleado ha sido" + G1RecursosInterfaz.strongModify;
                                break;

                case "DangerAdd":    this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                                     this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                     this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al agregar el Empleado";
                                     break;

                case "DangerModify":  this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                                      this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                      this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al modificar el Empleado";
                                      break;

                case "DangerStatus":  this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                                      this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                      this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al modificar Status del Empleado";
                                      break;

                case "Exception":
                    break;

                case "Cancel":  this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                                this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                                this.alert.InnerHtml = G1RecursosInterfaz.buttonAlert + "La acción ha sido" + G1RecursosInterfaz.strogCancel;
                                break;

                case "DangerEmail": this.menssageEmail.InnerHtml = G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongNot + "Disponible!";
                                    break;

                case "DangerUsername":  this.menssageUsername.InnerHtml = G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongNot + "Disponible!";
                                        break;

                case "DangerSsn": this.menssageSsn.InnerHtml = G1RecursosInterfaz.iconDanger + " Ya Existe!";
                                        break;

                case "InvalidFormatName": this.messageNameUser.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo letras y espacios";
                                        break;

                case "InvalidFormatLastName": this.messageLastName.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo letras y espacios";
                                        break;

                case "InvalidFormatDni": this.messageDni.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo números";
                                        break;

                case "InvalidFormatPhone": this.messagePhone.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo";
                                        break;

                case "InvalidFormatAddress": this.messageAddress.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico con espacios";
                                        break;

                case "InvalidFormatUser": this.messageUser.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                                        break;

                case "InvalidFormatEmail": this.messageEmail.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato de Correo Inválido!";
                                        break;

                case "InvalidFormatPassword1": this.messagePassword1.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                                        break;

                case "InvalidFormatPassword2": this.messagePassword2.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                                        break;

                case "InvalidFormatPasswordEqual": this.messagePasswordEqual.InnerHtml = G1RecursosInterfaz.iconDanger + " Las contraseñas no coinciden";
                                        break;

                case "InvalidFormatBirthdate": this.messageBirthdate.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato de fecha inválido (DD/MM/YYYY)";
                                        break;

                case "Empty": this.messageEmpty.InnerHtml = G1RecursosInterfaz.iconExclamation + " Uno o mas Campos Obligatorios Vacíos";
                                        break;

            }
        }
        
        protected bool ValidationEmail()
        {
            try
            {
                _userAccountDAO = _facDAO.GetUserAccountDAO();
                UserAccount _userAccount = new UserAccount();
                _userAccount = _userAccountDAO.FindByEmail(this.email.Text);
                if (_userAccount != null)
                {
                    Alerts("DangerEmail");
                    return false;
                }
                return true;
            }
            catch (FindByEmailUserAccountFondaDAOException e)
            {
                throw new ValidationEmailEmployeeFondaBackOfficeException(
                    "Excepción al validar Email del Empleado",
                    e);
            }
            catch (NullReferenceException e)
            {
                throw new ValidationEmailEmployeeFondaBackOfficeException(
                    "Excepción apuntador nulo ",
                    e);
            }
            catch (Exception e)
            {
                throw new ValidationEmailEmployeeFondaBackOfficeException(
                    "Excepción al validar Email del Empleado",
                    e);
            }
        }

        protected bool ValidationUsername()
        {
            try
            {
                _employee = new Employee();
                _employee = _employeeDAO.FindByusername(this.userNameU.Text);
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

        protected bool ValidationSsn()
        {
            try
            {
                _employee = new Employee();
                string _ssn = this.nss1.Text + "-" + this.nss2.Text;
                _employee = _employeeDAO.FindBySsn(_ssn);
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

        protected void ModifyStatus_Click(object sender, EventArgs e)
        {
            _facDAO = FactoryDAO.Intance;
            _employeeDAO = _facDAO.GetEmployeeDAO();
            _employee = new Employee();

            LinkButton clickedLink = (LinkButton)sender;
            int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);
            _employee = _employeeDAO.FindById(_idEmployee);
            
            if(clickedLink.Text == G1RecursosInterfaz.editstatusA) 
                _employee.Status = _facDAO.GetActiveSimpleStatus();
            if (clickedLink.Text == G1RecursosInterfaz.editstatusI)
                _employee.Status = _facDAO.GetDisabledSimpleStatus();
            _employeeDAO.Save(_employee);
            Alerts("Status");
        }
        */
        /*
        protected bool ValidarCampo(String accion)
        {
            int good = 0;
            int bad = 0;
            string _role = (string)(Session[RecursoMaster.sessionRol]);
            string patronNumero = "^[0-9]*$";
            string patronTexto = "^[A-Z a-z]*$";
            string patronAlphaNumerico1 = "^[A-Z0-9(.) a-z]*$";
            string patronAlphaNumerico2 = "^[A-Z0-9a-z]*$";
            string patronFecha = @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d";
            string patronEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            string Name = nameUser.Text;
            string LastName = lastNameUser.Text;
            //char Nationality = Convert.ToChar(nss1.Text);
            string Identity = nss1.Text;
            string Dni = nss2.Text;
            string Birthdate = birtDate.Text;
            string Phone = phoneNumber.Text;
            //char Gender = Convert.ToChar(gender.Text);
            string Address = address.Text;
            string Role = role.Text;
            string UserName = userNameU.Text;
            string Email = email.Text;
            string Password1 = password.Text;
            string Password2 = repitPassword.Text;
            string Restaurant = restaurant.Text;

            if (accion == "Agregar")
            {
                if (Name == "" | LastName == "" | Identity == "" | Phone == "" | Role == ""
                    | UserName == "" | Email == "" | Password1 == "" | Password2 == "" | (_role != "Sistema" && Restaurant==""))
                {
                    Alerts("Empty");
                    bad = ++bad;
                    return false;
                }
                else
                {
                    this.messageEmpty.Attributes.Clear();
                    this.messageEmpty.InnerHtml = "";
                }
            }

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
                    this.messageEmpty.Attributes.Clear();
                    this.messageEmpty.InnerHtml = "";
                }
                
            }

            if ((!Regex.IsMatch(Name, patronTexto)))
            {
                Alerts("InvalidFormatName");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messageNameUser.Attributes.Clear();
                this.messageNameUser.InnerHtml = "";
            }

            if ((!Regex.IsMatch(LastName, patronTexto)))
            {
                Alerts("InvalidFormatLastName");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messageLastName.Attributes.Clear();
                this.messageLastName.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Dni, patronNumero)))
            {
                Alerts("InvalidFormatDni");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messageDni.Attributes.Clear();
                this.messageDni.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Birthdate, patronFecha)))
            {
                  Alerts("InvalidFormatBirthdate");
                  bad = ++bad;
            }
            else
            {
            good = ++good;
            this.messageBirthdate.Attributes.Clear();
            this.messageBirthdate.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Phone, patronNumero)))
            {
                Alerts("InvalidFormatPhone");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messagePhone.Attributes.Clear();
                this.messagePhone.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Address, patronAlphaNumerico1)))
            {
                Alerts("InvalidFormatAddress");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messageAddress.Attributes.Clear();
                this.messageAddress.InnerHtml = "";
            }



            if ((!Regex.IsMatch(UserName, patronAlphaNumerico2)))
            {
                Alerts("InvalidFormatUser");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messageUser.Attributes.Clear();
                this.messageUser.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Email, patronEmail)))
            {
                Alerts("InvalidFormatEmail");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.menssageEmail.Attributes.Clear();
                this.menssageEmail.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Password1, patronAlphaNumerico2)))
            {
                Alerts("InvalidFormatPassword1");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messagePassword1.Attributes.Clear();
                this.messagePassword1.InnerHtml = "";
            }

            if ((!Regex.IsMatch(Password2, patronAlphaNumerico2)))
            {
                Alerts("InvalidFormatPassword2");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messagePassword2.Attributes.Clear();
                this.messagePassword2.InnerHtml = "";
            }

            if (!(Password1 == Password2))
            {
                Alerts("InvalidFormatPasswordEqual");
                bad = ++bad;
            }
            else
            {
                good = ++good;
                this.messagePasswordEqual.Attributes.Clear();
                this.messagePasswordEqual.InnerHtml = "";
            }


            if (bad == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        #region Presenter
        private UserListPresenter userListPresenter;
        #endregion

        #region model
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
        //Alertas de la pagina
        public System.Web.UI.HtmlControls.HtmlGenericControl userListAlert
        {
            get { return alert; }
            set { alert = value; }
        }
        //tabla de usuarios
        public System.Web.UI.WebControls.Table tableUserList
        {
            get { return TablaEmployee; }
            set { TablaEmployee = value; }
        }
        //textbox de nameuser agregar
        public TextBox textBoxNameUser
        {
            get { return nameUser; }
            set { nameUser = value; }
        }
        //textbox apellido agregar
        public TextBox textBoxlastNameUser
        {
            get { return lastNameUser; }
            set { lastNameUser = value; }
        }
        //nacionalidad
        public DropDownList dropDownListNss1
        {
            get { return nss1; }
            set { nss1 = value; }
        }
        //cedula del empleado agregar
        public TextBox textBoxNss2
        {
            get { return nss2; }
            set { nss2 = value; }
        }
        //direccion de empleado agregar
        public TextBox textBoxAddress
        {
            get { return address; }
            set { address = value; }
        }
        //correo del usuario a agregar
        public TextBox textBoxEmail
        {
            get { return email; }
            set { email = value; }
        }
        //numero de telefono del usuario de agregar
        public TextBox textBoxPhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        //fecha nacimiento del empleado a agregar
        public TextBox textBoxBirtDate
        {
            get { return birtDate; }
            set { birtDate = value; }
        }
        //Rol del empelado agregar
        public DropDownList DropDownListRole
        {
            get { return role; }
            set { role = value; }
        }
        //Sexo del empleado agregar
        public DropDownList DropDownListGender
        {
            get { return gender; }
            set { gender = value; }
        }
        //confirmacion de la cuenta del empleado
        public TextBox textBoxPaswword
        {
            get { return password; }
            set { password = value; }
        }
        //confirmacion de la clave del empleado
        public TextBox textBoxRepitPaswword
        {
            get { return repitPassword; }
            set { repitPassword = value; }
        }
        //nombre de usario del empleado
        public TextBox textBoxUserNameU
        {
            get { return userNameU; }
            set { userNameU = value; }
        }
        //boton de agregar o modificar
        public Button buttonButtonAddModify
        {
            get { return ButtonAddModify; }
            set { ButtonAddModify = value; }
        }
        //restaurante del empleado agregar
        public DropDownList dropDownListRestaurant
        {
            get { return restaurant; }
            set { restaurant = value; }
        }

        //ALERTS
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlAlert
        {
            get { return alert; }
            set { alert = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlmessageNameUser
        {
            get { return messageNameUser; }
            set { messageNameUser = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageLastName
        {
            get { return messageLastName; }
            set { messageLastName = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageDni
        {
            get { return messageDni; }
            set { messageDni = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageBirthdate
        {
            get { return messageBirthdate; }
            set { messageBirthdate = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePhone
        {
            get { return messagePhone; }
            set { messagePhone = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageAddress
        {
            get { return messageAddress; }
            set { messageAddress = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemenssageUsername
        {
            get { return menssageUsername; }
            set { menssageUsername = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageEmail
        {
            get { return messageEmail; }
            set { messageEmail = value; }
        }

        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePassword1
        {
            get { return messagePassword1; }
            set { messagePassword1 = value; }
        }

        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePassword2
        {
            get { return messagePassword2; }
            set { messagePassword2 = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePasswordEqual
        {
            get { return messagePasswordEqual; }
            set { messagePasswordEqual = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemenssageSsn
        {
            get { return menssageSsn; }
            set { menssageSsn = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageUser
        {
            get { return messageUser; }
            set { messageUser = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageEmpty
        {
            get { return messageEmpty; }
            set { messageEmpty = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemenssageEmail
        {
            get { return menssageEmail; }
            set { menssageEmail = value; }
        }

        public string SessionRestaurant
        {
            get { return Session[ResourceLogin.sessionRestaurantID].ToString(); }

            set { Session[ResourceLogin.sessionRestaurantID] = value; }
        }

        public HtmlGenericControl SuccessLabel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HtmlGenericControl ErrorLabel
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        #endregion

        #region constructor
        public ListarUsuario()
        {
            //presentador de la vista
            userListPresenter = new UserListPresenter(this);
        }
        #endregion
        /// <summary>
        /// metodo que llama a presentador para agregar empleado al sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Click(object sender, EventArgs e)
        {
            //script para bajar el modal de agregar empleado
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            userListPresenter.Add_Click();
        }
        /// <summary>
        /// metodo que llama al presentador para modificar usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ModalAddModify_Click(object sender, EventArgs e)
        {
            /*
            if (ValidarCampo(ButtonAddModify.Text))
            {
                _facDAO = FactoryDAO.Intance;
                _employeeDAO = _facDAO.GetEmployeeDAO();
                _roleDAO = _facDAO.GetRoleDAO();
                _userAccountDAO = _facDAO.GetUserAccountDAO();
                _employee = new Employee();
                bool _emailValid, _ssnValid, _userNameValid;

                _emailValid = ValidationEmail();
                _ssnValid = ValidationSsn();
                _userNameValid = ValidationUsername();

                if (ButtonAddModify.Text == "Agregar")
                {
                    if (_emailValid)
                    {
                        this.menssageEmail.Attributes.Clear();
                        this.menssageEmail.InnerHtml = "";
                    }
                    if (_ssnValid)
                    {
                        this.menssageSsn.Attributes.Clear();
                        this.menssageSsn.InnerHtml = "";
                    }
                    if (_userNameValid)
                    {
                        this.menssageUsername.Attributes.Clear();
                        this.menssageUsername.InnerHtml = "";
                    }
                }
                if (ButtonAddModify.Text == "Modificar")
                {
                    Button clickedLink = (Button)sender;
                    int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);
                    _employee = _employeeDAO.FindById(_idEmployee);
                    string _ssn = this.nss1.Text + "-" + this.nss2.Text;

                    if (this.email.Text == _employee.UserAccount.Email)
                    {
                        _emailValid = true;
                        this.menssageEmail.Attributes.Clear();
                        this.menssageEmail.InnerHtml = "";
                    }
                    if (_ssn == _employee.Ssn)
                    {
                        _ssnValid = true;
                        this.menssageSsn.Attributes.Clear();
                        this.menssageSsn.InnerHtml = "";
                    }
                    if (this.userNameU.Text == _employee.Username)
                    {
                        _userNameValid = true;
                        this.menssageUsername.Attributes.Clear();
                        this.menssageUsername.InnerHtml = "";
                    }
                }

                if (_emailValid && _ssnValid && _userNameValid)
                {

                    _employee = SetEmployee(_employee);
                    if (ButtonAddModify.Text == "Agregar")
                    {
                        if (_emailValid && _ssnValid && _userNameValid)
                        {
                            _employee.Status = _facDAO.GetActiveSimpleStatus();
                        }
                    }

                    if (_employee.UserAccount.Id.ToString() == "0")
                    {
                        _userAccountDAO.Save(_employee.UserAccount);
                    }
                    _employeeDAO.Save(_employee);
                    if (ButtonAddModify.Text == "Agregar")
                    {
                        Alerts("Add");
                    }
                    if (ButtonAddModify.Text == "Modificar")
                    {
                        Alerts("Modify");
                    }
                    ClearModalAddModify();

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            }
            */
            //ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            bool error = false;
            error = userListPresenter.ModalAddModify_Click(sender);
            if (error)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            }
        }
        /// <summary>
        /// metodo que carga la pagina, se carga la tabla de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
           
            userListPresenter.ClearAlert();
            userListPresenter.LoadTable(Session[ResourceLogin.sessionRol].ToString());
            
        }
        /// <summary>
        /// metodo que redirige a info del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ModalInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }
        protected void Modify_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("entre modify code behind");
           // userListPresenter.Modify_Click(sender,e);
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
        }
        /// <summary>
        /// metodo de cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            userListPresenter.Alerts("Cancel");
        }
        protected void ModifyStatus_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("entre en code behind");
            userListPresenter.ModifyStatus_Click(sender,e);
        }


    }
    }