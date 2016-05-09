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
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            MenuCategory _mencat = new MenuCategory();
            String nombre = Value1.Text;
            _mencat.Name = nombre;
            _mencat.ListDish = null;
            _mencat.Status = ActiveSimpleStatus.Instance;
            _mencatDAO.Save(_mencat);
        }

        protected void BotonModificarCategoria_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModificarCategoria.Visible = true;
        }
    }
}