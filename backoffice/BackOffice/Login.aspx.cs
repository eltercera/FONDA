using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BackOffice.Content;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using BackOffice.Seccion.Restaurant;
using com.ds201625.fonda.BackOffice.Presenter;
using BackOfficeModel.Login;
using BackOfficePresenter.Login;
using FondaResources.Login;

namespace BackOffice.Seccion.Configuracion
{
    public partial class WebForm1 : System.Web.UI.Page, ILoginModel
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            errorLogin.Visible = false;
            warningLog.Visible = false;

            if ((Request.QueryString[mensajes.tipoInfo] == "true"))
                mensajeLogin(true, mensajes.logInfo, mensajes.tipoInfo);
            else
                infoLog.Visible = false;

            if ((Request.QueryString[mensajes.tipoSucess] == "true"))
                mensajeLogin(true, mensajes.logSuccess,mensajes.tipoSucess);
            else
                successLog.Visible = false;
        }


        
        /// <summary>
        /// Metodo  que nos permite establecer un mensaje en el login
        /// </summary>
        /// <param name="visible">si deseamos que sea visible</param>
        /// <param name="message"> el mensaje que deseamos mostrar</param>
        /// <param name="type">tipo de mensaje Error;Warning;Info;Sucess</param>
        public void mensajeLogin(Boolean visible, string message, string type)
        {
            switch (type)
            {
                case "Error":
                    errorLogin.Visible = visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    errorLogin.InnerText = message; break;
                case "Warning":
                    warningLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    warningLog.InnerText = message; break;
                case "Info":
                    infoLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    successLog.Visible = !visible;
                    infoLog.InnerText = message; break;
                case "Success":
                    successLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.InnerText = message; break;
            }
        }
      

        // 2DA ENTREGA
        #region presenter 
        private LoginPresenter _presenter;
        #endregion

        #region Model
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
        // username de login
        public System.Web.UI.HtmlControls.HtmlInputText UserIni
        {
            get { return userIni; }
            set { userIni = value; }
        }
        // password del usuario
        public System.Web.UI.HtmlControls.HtmlInputPassword UserPassword
        {
            get { return passwordIni; }
            set { passwordIni = value; }
        }
        //button de ingresar
        public System.Web.UI.HtmlControls.HtmlButton Loggin
        {
            get { return buttonLogin; }
            set { buttonLogin = value; }
        }
        // usuario de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputText UserRecover
        {
            get { return user; }
            set { user = value; }
        }
        //correo de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputGenericControl RecoverEmail
        {
            get { return RestablecerCorreo; }
            set { RestablecerCorreo = value; }

        }
        //password1 de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputPassword Password1
        {
            get { return password1; }
            set { password1 = value; }
        }
        //password2 de recuperacion de clave
        public System.Web.UI.HtmlControls.HtmlInputPassword Password2
        {
            get { return password2; }
            set { password2 = value; }
        }

        //alerts

        public System.Web.UI.HtmlControls.HtmlGenericControl alertloginError
        {
            get { return errorLogin; }
            set { errorLogin = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertwarningLog
        {
            get { return warningLog; }
            set { warningLog = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertinfoLog
        {
            get { return infoLog; }
            set { infoLog = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertsuccessLog
        {
            get { return successLog; }
            set { successLog = value; }
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



        #endregion
        #region constructor
        public WebForm1()
        {
            _presenter = new LoginPresenter(this);
        }
        #endregion

        public void Uservalidate(object sender, EventArgs e)
        {
            Uservalidate();
        }
        public void Uservalidate()
        {   //exception de variale de session vacia
             _presenter.ValidateUser();
            try
            {
                if (Session[ResourceLogin.sessionRol].ToString() == "Sistema")
                {
                    Response.Redirect("~/Seccion/Restaurant/Restaurante.aspx");


                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception)
            {

            }
        }

        public void Recoverpassword(object sender, EventArgs e)
        {
            Recoverpassword();
        }
        public void Recoverpassword()
        {
            _presenter.Recoverpassword();
        }

    }
}