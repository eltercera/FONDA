using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;



namespace BackOffice.Seccion.Configuracion
{
    public partial class WebForm1 : System.Web.UI.Page
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
                mensajeLogin(true, mensajes.logSuccess, mensajes.tipoSucess);
            else
                successLog.Visible = false;
        }
        public void mensajeLogin(Boolean visible, string mensaje, string tipo)
        {
            switch (tipo)
            {
                case "Error": errorLogin.Visible = visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    errorLogin.InnerText = mensaje; break;
                case "Warning": warningLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.Visible = !visible;
                    warningLog.InnerText = mensaje; break;
                case "Info": infoLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    successLog.Visible = !visible;
                    infoLog.InnerText = mensaje; break;
                case "Success": successLog.Visible = visible;
                    errorLogin.Visible = !visible;
                    warningLog.Visible = !visible;
                    infoLog.Visible = !visible;
                    successLog.InnerText = mensaje; break;
            }
        }
        public void ValidarUsuario(object sender, EventArgs e)
        {

            validarUsuario();
        }
        public void EnvioCorreo(object sender, EventArgs e)
        {

            EnviarCorreo();
        }
        public void validarUsuario()
        {
            string usuario = userIni.Value;
            string clave = passwordIni.Value;
            Console.WriteLine("imprimiendo valor :");
            Console.WriteLine(usuario);

            if (usuario == "" | clave == "") 
            {
                mensajeLogin(true, mensajes.logErrcamp, mensajes.tipoInfo);
            }
            else{
                if (usuario == "fonda" & clave == "12345")
                { mensajeLogin(false, mensajes.logErr, mensajes.tipoErr);
                Response.Redirect("inicio.aspx");
                }
                else { 
                            
                mensajeLogin(true, mensajes.logErr, mensajes.tipoWarning);
            }
          }
           
        }

        public void EnviarCorreo()
        {
        
            String CorreoDestino = RestablecerCorreo.Value;
            if (CorreoDestino != "fonda@gmail.com")
            {

                mensajeLogin(true, mensajes.logWarning, mensajes.tipoWarning);
            }
            else
            {
                mensajeLogin(true, mensajes.logInfo, mensajes.tipoInfo);
           

                string opcion = "true";
                Response.Redirect("Login.aspx?" + mensajes.tipoInfo + "=" + opcion);
            }
            RestablecerCorreo.Value = "";


        }
    }
}