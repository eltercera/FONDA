using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOfficeModel.Login;
using System.Web.UI.HtmlControls;
using FondaResources.Login;
using BackOfficePresenter.Login;

namespace BackOffice.Seccion.Configuracion
{
    public partial class DetalleModificar : System.Web.UI.Page, IDetailModifyModel
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        #region model
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

        public void Modify_Click1(object sender, EventArgs e)
        {
            detailModifyPresenter.cargarUser();
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);

        }
        public void Modify_Click2(object sender, EventArgs e)
        {
            bool result = detailModifyPresenter.Modify_Click();
            if (result)
            {

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#modalAddModify').modal('show');", true);
            }
        }

    }
}