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


        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = false;
            AlertSuccess_ModificarCategoria.Visible = false;
            CargarTabla();
        }

        /// <summary>
        /// Construye una tabla de categorias
        /// Utilizando el control de asp: Table
        /// </summary>
        protected void CargarTabla() {

            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            IList<RestaurantCategory> listRest = _restcatDAO.GetAll();


            int totalRows = listRest.Count; //tamano de la lista 
            int totalColumns = 1; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Agrega la fila a la tabla existente
                CategoriaRest.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria
                    if (j.Equals(0))
                        tCell.Text = listRest[i].Name;
                    //Agrega las acciones de la tabla
                    else if(j.Equals(1))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        HyperLink action = new HyperLink();
                        action.Attributes["data-toggle"] = "modal";
                        action.Attributes["data-target"] = "#modificar";
                        action.Text = ResourceRestaurant.ActionCategory;
                        tCell.Controls.Add(action);
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            CategoriaRest.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            
            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Acciones";
            h2.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);

            return header;
        }
     

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            RestaurantCategory _restcat = new RestaurantCategory();
            String nombreA = NombreCatA.Text;
            _restcat.Name = nombreA;
            _restcatDAO.Save(_restcat);
            CargarTabla();
        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModificarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            IList<RestaurantCategory> listRest = _restcatDAO.GetAll();
            int longitud = listRest.Count;
            string nameM;
            int idCat = 0;

            for (int i = 0; i <= longitud - 1; i++)
            {
                nameM = listRest[i].Name;
                idCat = listRest[i].Id;
            }

            RestaurantCategory _restaurant = _restcatDAO.FindById(idCat);
            nameM = NombreCatM.Text;
            _restaurant.Name = nameM;
            _restcatDAO.Save(_restaurant);
            CargarTabla();
        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            
        }
    }
}