using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.View.BackOfficeModel.Login;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.Resources.FondaResources.Login;
using com.ds201625.fonda.View.BackOfficePresenter.Login;
using com.ds201625.fonda.View.BackOfficeModel;
using BackOffice.Content;

namespace BackOffice.Seccion.Configuracion
{
    public partial class DetalleModificar : System.Web.UI.Page, IDetailModifyModel
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                //Llama al presentador para llenar datos del empleado
                detailModifyPresenter.cargarUserDetail();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }
        #region model
        //labelusuario
        public System.Web.UI.WebControls.Label labelrestauranteemp
        {
            get { return labelrestauante; }
            set { labelrestauante = value; }
        }
        //labelusuario
        public System.Web.UI.WebControls.Label labelemailemp
        {
            get { return labelemail; }
            set { labelemail = value; }
        }
        //labelusuario
        public System.Web.UI.WebControls.Label labelusuarioemp
        {
            get { return labelusuario; }
            set { labelusuario = value; }
        }
        //labelrol
        public System.Web.UI.WebControls.Label labelrolemp
        {
            get { return labelrol; }
            set { labelrol = value; }
        }
        //labeldireccion
        public System.Web.UI.WebControls.Label labeldireccionemp
        {
            get { return labeldireccion; }
            set { labeldireccion = value; }
        }
        //labelgenero
        public System.Web.UI.WebControls.Label labelgeneroemp
        {
            get { return labelgenero; }
            set { labelgenero = value; }
        }
        //labeltelefono
        public System.Web.UI.WebControls.Label labeltelefonoemp
        {
            get { return labeltelefono; }
            set { labeltelefono = value; }
        }
        //labelfechanac
        public System.Web.UI.WebControls.Label labelfechanacemp
        {
            get { return labelfechanac; }
            set { labelfechanac = value; }
        }
        //labelcedula
        public System.Web.UI.WebControls.Label labelcedulaemp
        {
            get { return labelcedula; }
            set { labelcedula = value; }
        }
        //labelapellido
        public System.Web.UI.WebControls.Label labelapellido
        {
            get { return labelapellido2; }
            set { labelapellido2 = value; }
        }
        //labelnombre
        public System.Web.UI.WebControls.Label labelNombre
        {
            get { return labelnombre; }
            set { labelnombre = value; }
        }
        //alert
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
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageLastName
        {
            get { return messageLastName; }
            set { messageLastName = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageDni
        {
            get { return messageDni; }
            set { messageDni = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageBirthdate
        {
            get { return messageBirthdate; }
            set { messageBirthdate = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePhone
        {
            get { return messagePhone; }
            set { messagePhone = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageAddress
        {
            get { return messageAddress; }
            set { messageAddress = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemenssageUsername
        {
            get { return menssageUsername; }
            set { menssageUsername = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageEmail
        {
            get { return messageEmail; }
            set { messageEmail = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePassword1
        {
            get { return messagePassword1; }
            set { messagePassword1 = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePassword2
        {
            get { return messagePassword2; }
            set { messagePassword2 = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessagePasswordEqual
        {
            get { return messagePasswordEqual; }
            set { messagePasswordEqual = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemenssageSsn
        {
            get { return menssageSsn; }
            set { menssageSsn = value; }
        }
        //alert
        public System.Web.UI.HtmlControls.HtmlGenericControl HtmlGenericControlemessageUser
        {
            get { return messageUser; }
            set { messageUser = value; }
        }
        //alert
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
        //vairable de session
        public string SessionRestaurant
        {
            get { return Session[ResourceLogin.sessionRestaurantID].ToString(); }

            set { Session[ResourceLogin.sessionRestaurantID] = value; }
        }

        //metodo de i model
        public HtmlGenericControl SuccessLabel
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        //metodo de i model
        public HtmlGenericControl ErrorLabel
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        //metodo de imodel
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
        //metod de Imodel
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
        #endregion
        #region Presenter
        private DetailModifyPresenter detailModifyPresenter;
        #endregion
        #region constructor
        public DetalleModificar()
        {
            //presentador de la vista
            detailModifyPresenter = new DetailModifyPresenter(this);
        }
        #endregion
        /// <summary>
        /// metodo que llama a void en el presentador para modificar usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Modify_Click1(object sender, EventArgs e)
        {
            //se cargan datos del usuario en el modal
            detailModifyPresenter.cargarUser();
            //NOTA PROFESOR MAGURNO : INTENTAMOS BAJAR EL MODAL DESDE EL PRESENTADOR
            // NO HAYAMOS LA MANERA DE BAJARLO, ESTA DIFICIL ESO
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", 
            "$('#modalAddModify').modal('show');", true);

        }
        /// <summary>
        /// metodo que valida y modifica al usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Modify_Click2(object sender, EventArgs e)
        { 
            // se valida los campos que se estan intentando ingresar en el sistema
            //si son validos se modifica , si no se baja modal con mensajes de errores
            bool result = detailModifyPresenter.Modify_Click();
            if (result)
            {
                detailModifyPresenter.cargarUserDetail();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarModal", 
                "$('#modalAddModify').modal('show');", true);
            }
        }

    }
}