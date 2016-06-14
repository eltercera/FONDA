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
            System.Diagnostics.Debug.WriteLine( "Entre en clear data");
        }

        protected void ClearTable()
        {
            _view.tableUserList.Rows.Clear();
        }


        public void LoadTable(string _role)
        {
            
            try
            {
                System.Diagnostics.Debug.WriteLine(_role, "empezando loadtable");
                //_role = (string)(string)HttpContext.Current.Session[ResourceLogin.sessionRol];
                ClearTable();
                LoadDataTable(_role);
                System.Diagnostics.Debug.WriteLine(_role,"Entre en load table con rol");
            }
            catch (Exception e)
            {
                //Alerts("Exception");
            }
        }
        
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

            Command CommanGetAllEmployee;
            CommanGetAllEmployee = CommandFactory.GetCommandGetAllEmployee("null");
            CommanGetAllEmployee.Execute();
            _employeeList = (IList<Employee>)CommanGetAllEmployee.Receiver;
            System.Diagnostics.Debug.WriteLine("ejecute comando");
            string _idrest = (string)(HttpContext.Current.Session[ResourceLogin.sessionRestaurantID]);

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
                    //editStatusA.Click += new EventHandler(ModifyStatus_Click);
                    editStatusA.Attributes.Add("data-id", _employee.Id.ToString());
                    editStatusA.Text = G1RecursosInterfaz.editstatusA;

                    //boton Modificar status Inactivo
                    //editStatusI.Click += new EventHandler(ModifyStatus_Click);
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



        protected void Modify_Click(object sender, EventArgs e)
        {

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
            _view.textBoxNameUser.Text = "";
            _view.textBoxNameUser.Attributes["placeholder"] = "Apellido";
            _view.dropDownListNss1.Text = "";
            _view.textBoxNss2.Text = "";
            _view.textBoxNss2.Attributes["placeholder"] = "Ej. 19245998";
            _view.textBoxAddress.Text = "";
            _view.textBoxAddress.Attributes["placeholder"] = "Dirección";
            _view.textBoxAddress.Text = "";
            _view.textBoxAddress.Attributes["placeholder"] = "nickname@ejemplo.com";
            _view.textBoxEmail.Text = "";
            _view.textBoxEmail.Attributes["placeholder"] = "Ej. 04127890544";
            _view.textBoxBirtDate.Text = "";
            _view.textBoxBirtDate.Attributes["placeholder"] = "DD/MM/YYYY";
            _view.DropDownListRole.Items.Clear();
            _view.DropDownListRole.Items.Add("");
            _view.DropDownListGender.Text = "";
            _view.textBoxPaswword.Text = "";
            _view.textBoxPaswword.Attributes["placeholder"] = "Password";
            _view.textBoxRepitPaswword.Text = "";
            _view.textBoxRepitPaswword.Attributes["placeholder"] = "Repetir Password";
            _view.textBoxRepitPaswword.Text = "";
            _view.textBoxRepitPaswword.Attributes["placeholder"] = "Usuario";
            _view.textBoxPaswword.Enabled = true;
            _view.textBoxRepitPaswword.Enabled = true;
            _view.buttonButtonAddModify.Text = "Agregar";
        }

        protected void ChangeRole(string _role1)
        {
            _facDAO = FactoryDAO.Intance;
            Command CommandGetAllRoles;
            CommandGetAllRoles = CommandFactory.GetCommandGetAllRoles("null");
            CommandGetAllRoles.Execute();
            _roleList = (IList<Role>)CommandGetAllRoles.Receiver;
            //_roleList = _roleDAO.GetAll();
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

        protected void ChangeRestaurant()
        {
            /*_facDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            IList<com.ds201625.fonda.Domain.Restaurant> _restList = _restaurantDAO.GetAll();*/
            Command CommandGetAllRestaurants;
            CommandGetAllRestaurants = CommandFactory.GetCommandGetAllRestaurants("null");
            CommandGetAllRestaurants.Execute();
            IList<Restaurant> _restList = (IList<Restaurant>)CommandGetAllRestaurants.Receiver;
            if (_restList != null)
            {
                foreach (Restaurant _rest in _restList)
                {
                    _view.dropDownListRestaurant.Items.Add(new ListItem(_rest.Name, _rest.Id.ToString()));
                }
            }
        }

    }
}
