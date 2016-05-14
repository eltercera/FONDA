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
       
        public string mencat{
            get { return this.Tabla.Text;}
            set { this.Tabla.Text = value;}
        }


        protected void Page_Load(object sender, EventArgs e)
        {   //Aqui atrapo el valor que me mandaria el restaurante en este caso el id
            //int nombreparametro= int.Parse(Request.QueryString["parametrouno"]);
            AlertSuccess_AgregarCategoria.Visible = false;
            AlertSuccess_ModificarCategoria.Visible = false;
             
            if (!this.IsPostBack)  
            {
                //Aqui se generan los objetos para hacer consulta y generar la lista de categorias
                FactoryDAO factoryDAO = FactoryDAO.Intance;
                IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
                MenuCategory _mencat = _mencatDAO.FindById(1);
                IList<MenuCategory> obj = _mencatDAO.GetAll();

        
                int longitud = obj.Count;
                
                //se recorre el objeto lista y se muestra en la tabla 
                for (int i=0; i<=longitud-1; i++)
                {
                   //aqui se carga y se arma la tabla html recursomenu es un archivo donde hay cadenas de string muy grandes
                    mencat += "<tr><td>" + obj[i].Name + "</td>";

                    if (obj[i].Status.ToString() == "Activo")
                    {
                        mencat += RecursosMenu1.Activo;
                    }
                    else
                    {
                        mencat += RecursosMenu1.Inactivo;
                    }

                    mencat += RecursosMenu1.Acciones;
                    mencat += RecursosMenu1.CerrarTR;

                }
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
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _menucatDAO = factoryDAO.GetMenuCategoryDAO();

            MenuCategory _menu = new MenuCategory();
            String nombre1 = TextBox1.Text;
            _menu.Name = nombre1;
            _menu.Status = ActiveSimpleStatus.Instance;
            _menucatDAO.Save(_menu);


           
           
        }

    
    }
}