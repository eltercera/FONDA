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
using System.Web.Services;

namespace BackOffice.Seccion.Menu
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarPlato.Visible = false;
            AlertSuccess_ModificarPlato.Visible = false;
            AlertDanger_AgregarPlato.Visible = false;
            AlertDanger_ModificarPlato.Visible = false;
            LoadTable();
        }

        protected void LoadTable()
        {

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta

            //FactoryDAO factoryDAO = FactoryDAO.Intance;
            //IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            //IList<MenuCategory> listMenuC = _mencatDAO.GetAll();

            FactoryDAO _factoryDAO = FactoryDAO.Intance;
            IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
            IList<Dish> _listDish = _dishDAO.GetAll();


            int totalRows = _listDish.Count; //tamano de la lista 
            int totalColumns = 4; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = _listDish[i].Id.ToString();
                //Agrega la fila a la tabla existente
                TableDish.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria
                    if (j.Equals(0))
                        tCell.Text = _listDish[i].Name;
                    if (j.Equals(1))
                        tCell.Text = _listDish[i].Cost.ToString();

                    //Agrega el checkbox de sugerencia de la tabla
                    else if (j.Equals(2))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones

                        //LinkButton action = new LinkButton();
                        //action.Attributes["data-toggle"] = "modal";
                        //action.Attributes["data-target"] = "#modificar";
                        //action.Text = RecursosMenu1.Acciones;

                        CheckBox CheckBoxSuggestion = new CheckBox();
                        CheckBoxSuggestion.ToolTip = "Marcar Sugerencia";
                        tCell.Controls.Add(CheckBoxSuggestion);
                    }
                    if (j.Equals(3))
                        tCell.Text = _listDish[i].Status.ToString();
 
                    //Agrega las acciones de la tabla
                    else if (j.Equals(4))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton action = new LinkButton();
                        action.Attributes["data-toggle"] = "modal";
                        action.Attributes["data-target"] = "#modify_dish";
                        action.Text = RecursosMenu1.Acciones;
                        tCell.Controls.Add(action);
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }
            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            TableDish.Rows.AddAt(0, header);
        }

        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();
            TableHeaderCell h5 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Plato";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Precio";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Sugerencia del dia";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Estado";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Acciones";
            h5.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);

            return header;
        }


        public void CleanTable()
        {
           TableDish.Rows.Clear();

        }

        protected void ButtonModifyDish_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModificarPlato.Visible = true;
        }

        protected void ButtonAddDish_Click(object sender, EventArgs e)
        {
            AlertSuccess_AgregarPlato.Visible = true;
        }

        protected void ButtonCancelAddDish_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo plato
        /// </summary>
        /// <param name="Id">Id del plato a mostrar</param>
        /// <returns>Informacion de objeto plato</returns>
        [WebMethod]
        public static Dish GetData(string Id)
        {
            int _dishID = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IDishDAO _dishDAO = factoryDAO.GetDishDAO();
            Dish _dish = _dishDAO.FindById(_dishID);

            return _dish;
        }
    }
}