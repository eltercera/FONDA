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
using com.ds201625.fonda.View.BackOfficeModel.Login;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficePresenter.Login;

namespace BackOffice.Seccion.Configuracion
{
    public partial class ListarUsuario : System.Web.UI.Page, IUserListModel
    {
        
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
        public HtmlInputGenericControl textBoxBirtDate
        {
            get { return birtDate2; }
            set { birtDate2 = value; }
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
        /// <summary>
        /// constructor, se crea el presentador
        /// </summary>
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
            //NOTA PROFESOR MAGURNO : INTENTAMOS BAJAR EL MODAL DESDE EL PRESENTADOR
            // NO HAYAMOS LA MANERA DE BAJARLO
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", 
            "$('#modalAddModify').modal('show');", true);
            userListPresenter.Add_Click();
        }
        /// <summary>
        /// metodo que llama al presentador agregar y validar a agregar usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ModalAddModify_Click(object sender, EventArgs e)
        {
            bool error = false;
            error = userListPresenter.ModalAddModify_Click(sender);
            // si una validacion del usuario que se intenta insertar da,
            //se vuelve a bajar modal con mensajes de errores de los campos
            if (error)
            {
                // script para bajar el modal de agregar empleado
                //NOTA PROFESOR MAGURNO : INTENTAMOS BAJAR EL MODAL DESDE EL PRESENTADOR
                // NO HAYAMOS LA MANERA DE BAJARLO, ESTA DIFICIL ESO
                ClientScript.RegisterStartupScript(GetType(), "mostrarModal", 
                "$('#modalAddModify').modal('show');", true);
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
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                if ((Session[ResourceLogin.sessionRol].ToString() == "Sistema") || (Session[ResourceLogin.sessionRol].ToString() == "Restaurante"))
                {
                    userListPresenter.LoadTable(Session[ResourceLogin.sessionRol].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
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
            // script para bajar el modal de agregar empleado
            //NOTA PROFESOR MAGURNO : INTENTAMOS BAJAR EL MODAL DESDE EL PRESENTADOR
            // NO HAYAMOS LA MANERA DE BAJARLO, ESTA DIFICIL ESO
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", 
            "$('#modalAddModify').modal('show');", true);
        }
        /// <summary>
        /// metodo de cancelar en el presentador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            userListPresenter.Alerts("Cancel");
        }
        /// <summary>
        /// metodo que llama metodo del presentador a modificar status de un empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ModifyStatus_Click(object sender, EventArgs e)
        {
            userListPresenter.ModifyStatus_Click(sender,e);
        }


    }
    }