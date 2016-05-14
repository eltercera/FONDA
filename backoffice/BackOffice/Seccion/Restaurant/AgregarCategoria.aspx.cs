using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;


namespace BackOffice.Seccion.Restaurant
{
    public partial class AgregarCategoria : System.Web.UI.Page
    {

        public string restcat {
        get { return this.CategoryT.Text; }
        set { this.CategoryT.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {   //Aqui atrapo el valor que me mandaria el restaurante en este caso el id
            //int nombreparametro= int.Parse(Request.QueryString["parametrouno"]);
            //  AlertSuccess_AgregarCategoria.Visible = false;
            //  AlertSuccess_ModificarCategoria.Visible = false;

            if (!this.IsPostBack)
            {
                //Aqui se generan los objetos para hacer consulta y generar la lista de categorias
                FactoryDAO factoryDAO = FactoryDAO.Intance;
                IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
                IList<RestaurantCategory> listRest = _restcatDAO.GetAll();


                int longitud = listRest.Count;

                //se recorre el objeto lista y se muestra en la tabla 
                for (int i = 0; i <= longitud - 1; i++)
                {
                    //aqui se carga y se arma la tabla html recursomenu es un archivo donde hay cadenas de string muy grandes
                    restcat += "<tr><td>" + listRest[i].Name + "</td>";

                    restcat += ResourceRestaurant.ActionTable;
                    restcat += ResourceRestaurant.Close;

                }
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
           // AlertSuccess_AgregarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            RestaurantCategory _restcat = new RestaurantCategory();
            String nombreA = NombreCatA.Text;
            _restcat.Name = nombreA;
            _restcatDAO.Save(_restcat);
        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
          //  AlertSuccess_ModificarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();

            RestaurantCategory _restaurant = new RestaurantCategory();
            String nombreM = NombreCatM.Text;
            _restaurant.Name = nombreM;
            _restcatDAO.Save(_restaurant);

        }
    }
}