using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Data;

namespace BackOffice.Seccion.Menu
{
    public partial class ListarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = false;
            AlertSuccess_ModificarCategoria.Visible = false;
             
            if (!this.IsPostBack)  
            {
                //Aqui se deneran los objetos para hacer consulta y generar la lista de categorias
                FactoryDAO factoryDAO = FactoryDAO.Intance;
                IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
                MenuCategory _mencat = _mencatDAO.FindById(1);
                IList<MenuCategory> obj = _mencatDAO.GetAll();

                DataTable dt = new DataTable();  
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)),  new DataColumn("Name", typeof(string))});
                int longitud = obj.Count;
                
                //se recorre el objeto lista y se muestra en la tabla 
                for (int i=0; i<=longitud-1; i++)
                {
                    dt.Rows.Add(obj[i].Id, obj[i].Name);  
                }
                
                GridView1.DataSource = dt;  
                GridView1.DataBind();  
            } 
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