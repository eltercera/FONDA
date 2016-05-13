using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Seccion.Menu
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarPlato.Visible = false;
            AlertSuccess_ModificarPlato.Visible = false;
        }


        protected void BotonModificarPlato_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModificarPlato.Visible = true;
        }

        protected void BotonAgregarPlatillo_Click(object sender, EventArgs e)
        {
            AlertSuccess_AgregarPlato.Visible = true;
        }

        protected void ButtonCancelarAgregarPlatillo_Click(object sender, EventArgs e)
        {

        }
    }
}