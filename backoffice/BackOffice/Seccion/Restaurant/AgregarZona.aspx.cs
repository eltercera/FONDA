using BackOffice.Content;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Seccion.Restaurant
{
    public partial class AgregarZona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }
    }
}