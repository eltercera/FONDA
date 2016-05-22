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

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!(IsPostBack))
            //{ 

            _facDAO = FactoryDAO.Intance;
            _roleDAO = _facDAO.GetRoleDAO();
            _roleList = _roleDAO.GetAll();

            if (IsPostBack)
            {
                if (_roleList != null)
                {
                    foreach (Role _role in _roleList)
                    {
                        this.role.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                    }
                }
              }
            

            this.alert.Attributes.Clear();
            this.alert.InnerHtml = "";

            
            _employeeDAO = _facDAO.GetEmployeeDAO();
            _employeeList = _employeeDAO.GetAll();



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
                     edit.Click += new EventHandler(Modificar_Click);
                     edit.Attributes.Add("data-id",_employee.Id.ToString());
                     edit.Text = G1RecursosInterfaz.edit;

                     //boton Modificar status Activo
                     editStatusA.Click += new EventHandler(Modificar_Click);
                     editStatusA.Attributes.Add("data-id", _employee.Id.ToString());
                     editStatusA.Text = G1RecursosInterfaz.editstatusA;

                     //boton Modificar status Inactivo
                     editStatusI.Click += new EventHandler(Modificar_Click);
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

                     this.TablaEmployee.Rows.Add(tRow);
                 }
             }




           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }

        protected void ModalInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }
        protected void ModalAgregar_Click(object sender, EventArgs e)
        { 
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#formUser').modal('show');", true);
        }
        protected void ClearModalAgregar()
        {
            this.nameUser.Text = "";
            this.nameUser.Attributes["placeholder"] = "Nombre";
            this.lastNameUser.Text = "";
            this.lastNameUser.Attributes["placeholder"] = "Apellido";
            this.nss1.Text = "";
            this.nss2.Text = "";
            this.nss2.Attributes["placeholder"] = "ej. 965831535-1";
            this.address.Text = "";
            this.address.Attributes["placeholder"] = "Dirección";
            this.email.Text = "";
            this.email.Attributes["placeholder"] = "Email";
            this.phoneNumber.Text = "";
            this.phoneNumber.Attributes["placeholder"] = "Teléfono";
            this.birtDate.Text = "";
            this.birtDate.Attributes["placeholder"] = "";
            this.role.Items.Clear();
            this.role.Items.Add("");
            this.gender.Text = "";
            this.password.Text = "";
            this.password.Attributes["placeholder"] = "Password";
            this.repitPassword.Text = "";
            this.repitPassword.Attributes["placeholder"] = "Repetir Password";
            this.userNameU.Text = "";
            this.userNameU.Attributes["placeholder"] = "Usuario";
            this.statusI.Checked = true;
            this.ButtonAgrMod.Text = "Agregar";
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
            this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
            this.alert.InnerHtml = G1RecursosInterfaz.dangerModificacioninicio + "El Rol" + G1RecursosInterfaz.dangerModificacionFinal;
        }
        protected void ModalAgregarModificar_Click(object sender, EventArgs e)
        {
            _facDAO = FactoryDAO.Intance;
            _employeeDAO = _facDAO.GetEmployeeDAO();
            _roleDAO = _facDAO.GetRoleDAO();
            _userAccountDAO = _facDAO.GetUserAccountDAO();
            Employee _employee = new Employee();
           
            if (ButtonAgrMod.Text == "Agregar")
            {
                _employee = new Employee();
                SetEmployee(_employee);
            }
            if (ButtonAgrMod.Text == "Modificar")
            {
                Button clickedLink = (Button)sender;
                int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);
                _employee = _employeeDAO.FindById(_idEmployee);
                SetEmployee(_employee);
            }

            _userAccountDAO.Save(_employee.UserAccount);
           _employeeDAO.Save(_employee);
            //Alert Si modifico o no
            ClearModalAgregar();
        }

        protected void SetEmployee (Employee _employee)
        {
            Role _role;
            if (this.role.Text != "")
            {
                _role = _roleDAO.FindById(int.Parse(this.role.SelectedValue));
                _employee.Role = _role;
            }
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

            if (this.ButtonAgrMod.Text == "Agregar")
            {
                if (this.email.Text != "" && this.password.Text != "")
                {
                    UserAccount _userAccount = new UserAccount();
                    _userAccount.Email = this.email.Text;
                    _userAccount.Password = this.password.Text;
                    _employee.UserAccount = _userAccount;
                }
               // _employee.RecordStatus = InsertedStatus.Instance;

            }
            else
                if (this.ButtonAgrMod.Text == "Modificar")
                {
                    if (_employee.UserAccount.Email != this.email.Text)
                    {
                        _employee.UserAccount.Email = this.email.Text;
                    }
                }
            
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            LinkButton clickedLink = (LinkButton)sender;
            int _idEmployee = int.Parse(clickedLink.Attributes["data-id"]);

            _facDAO = FactoryDAO.Intance;
            _employeeDAO = _facDAO.GetEmployeeDAO();
           // _roleDAO = _facDAO.GetRoleDAO();

            Employee _employee = _employeeDAO.FindById(_idEmployee);
            
            this.nameUser.Text = _employee.Name;
            this.lastNameUser.Text = _employee.LastName;
            this.address.Text = _employee.Address;
            this.phoneNumber.Text = _employee.PhoneNumber;
            this.nss1.Text = _employee.Ssn.Substring(0,1);
            int _length = (_employee.Ssn.Length) - 2;
            this.nss2.Text = _employee.Ssn.Substring(2, _length);
            this.gender.Text = _employee.Gender.ToString();
            this.birtDate.Text = _employee.BirthDate.ToString();
            this.userNameU.Text = _employee.Username;
            //this.statusA.Checked = true;
            this.role.Text = _employee.Role.Id.ToString();
            this.email.Text = _employee.UserAccount.Email;
            this.password.Enabled = false;
            this.repitPassword.Enabled = false;
            this.ButtonAgrMod.Text = "Modificar";
            this.ButtonAgrMod.Attributes.Add("data-id", _idEmployee.ToString());
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#formUser').modal('show');", true);

        }
    }
}