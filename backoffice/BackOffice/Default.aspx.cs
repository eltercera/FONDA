using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            exitoFormulario.Style["display"] = "none";
            alertaFormulario.Style["display"] = "none";
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