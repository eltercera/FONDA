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

namespace BackOffice.Seccion.Configuracion
{
    public partial class ListarUsuario : System.Web.UI.Page
    {
        private FactoryDAO _facDAO;
        private IEmployeeDAO _employeeDAO;
        private IList<Employee> _employeeList;
        private IRoleDAO _roleDAO;
        private IUserAccountDAO _userAccountDAO;
        private IList<Role> _roleList;
        private Employee _employee;   
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearAlert();
                LoadTable();
        }

        protected void ClearAlert ()
        {
            this.alert.Attributes.Clear();
            this.alert.InnerHtml = "";
        }

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
            string _role = (string)(Session[RecursoMaster.sessionRol]);
            ClearTable();
            LoadDataTable(_role);
        }
        
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

        protected void ModalInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            ClearModalAddModify();
            string _role = (string)(Session[RecursoMaster.sessionRol]);
            ChangeRole(_role);
            if (_role == "Sistema")
                ChangeRestaurant();
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
        }

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
            this.birtDate.Text = _employee.BirthDate.ToString();
            this.userNameU.Text = _employee.Username;
            this.role.Text = _employee.Role.Id.ToString();
            this.email.Text = _employee.UserAccount.Email;
            this.password.Enabled = false;
            this.repitPassword.Enabled = false;
            this.ButtonAddModify.Text = "Modificar";
            this.ButtonAddModify.Attributes.Add("data-id", _idEmployee.ToString());
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Alerts("Cancel");
        }

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
            this.birtDate.Attributes["placeholder"] = "DD/MM/AA";
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

        protected void SetEmployee(Employee _employee)
        {
            string _roleUser = (string)(Session[RecursoMaster.sessionRol]);
            Role _role;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant;
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
        }

        protected void ModalAddModify_Click(object sender, EventArgs e)
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

                SetEmployee(_employee);
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
            }
        }

        protected bool ValidationEmail()
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

        protected bool ValidationUsername()
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

        protected bool ValidationSsn()
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
    }
}