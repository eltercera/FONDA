using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Seccion.Configuracion
{
    public partial class AgregarModificarPrivilegio : System.Web.UI.Page
    {
        private string success;
        protected void Page_Load(object sender, EventArgs e)
        {
            exitoFormulario.Style["display"] = "none";
            alertaFormulario.Style["display"] = "none";

            this.success = Request.QueryString["success"];
            if (success != null)
            {
                if (success.CompareTo("modificar") == 0)
                {
                    this.nombrePrivilegio.Text = "Gestionar Usuario";
                    this.descripcionPrivilegio.Text = "Registro de Usuario y su permisología";
                    this.Button1.Text = "Modificar";

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            exitoFormulario.Style["display"] = "inline";
            alertaFormulario.Style["display"] = "none";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            alertaFormulario.Style["display"] = "inline";
            exitoFormulario.Style["display"] = "none";
        }
    }
}