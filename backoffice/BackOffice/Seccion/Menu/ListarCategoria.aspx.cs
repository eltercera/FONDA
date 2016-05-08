using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;

namespace BackOffice.Seccion.Menu
{
    public partial class ListarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = false;
            AlertSuccess_ModificarCategoria.Visible = false;
        }

        protected void BotonAgregarCategoria_Click(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO menuCatDAO = factoryDAO.GetMenuCategoryDAO();
            MenuCategory mc = menuCatDAO.FindById(1);
            Value1.Text = mc.Name;

        }

        protected void BotonModificarCategoria_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModificarCategoria.Visible = true;
        }
    }
}