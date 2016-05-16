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
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_2 = int.Parse(Request.QueryString["id"]);
            id = id_2;
            MenuCategory menu = Obj_Menu(id_2);
            TextBox1.Text = menu.Name;
        }

        public MenuCategory Obj_Menu(int id)
        {

            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            MenuCategory obj = _mencatDAO.FindById(id);
            return obj;
        }

        //public void Guardar_Cambios(MenuCategory obj) {

        //    FactoryDAO factoryDAO = FactoryDAO.Intance;
        //    IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
        //    _mencatDAO.Save(obj);


        //}

        protected void BotonModificarCategoria_Click(object sender, EventArgs e)
        {
            //AQUI HAY UNPEO CON AGARRAR EL NOMBRE Y VALOR DEL TEXTBOX
            //AlertSuccess_ModificarCategoria.Visible = true;
            MenuCategory menu = Obj_Menu(id);
            string nombre = TextBox1.Text;
            menu.Name = nombre;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            _mencatDAO.Save(menu);
        }
    }
}