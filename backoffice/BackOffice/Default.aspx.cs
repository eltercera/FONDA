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

namespace BackOffice
{
    public partial class Prueba : System.Web.UI.Page
    {
        IList<Dish> Sugerencia = new List<Dish>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable_MenuSugestion();
        }
        //procedimiento que carga latabla de sugerencia del dia en el default importante cargen el test de dish 2 veces
        //y despues el de menu category para que aparezca informacion
        protected void LoadTable_MenuSugestion()
        {

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            IList<MenuCategory> listMenuC = _mencatDAO.GetAll();


            int lenghtListMenuC = listMenuC.Count;
            for (int i = 0; i <= lenghtListMenuC - 1; i++)
            {
                MenuCategory categoria = listMenuC[i];
                if (categoria.ListDish != null)
                {
                    IList<Dish> listDish = categoria.ListDish;
                    int lenghtlistDish = listDish.Count;

                    for (int j = 0; j <= lenghtlistDish - 1; j++)
                    {


                        if (listDish[j].Suggestion == true)
                        {
                            Sugerencia.Add(listDish[j]);

                        }

                    }
                }

            }



            int totalRows = Sugerencia.Count; //tamano de la lista 
            int totalColumns = 1; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = Sugerencia[i].Id.ToString();
                String ver_id = Sugerencia[i].Id.ToString();
                //Agrega la fila a la tabla existente
                TableDayMenuDashboard.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {

                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria
                    if (j.Equals(0))
                        tCell.Text = Sugerencia[i].Name;
                    if (j.Equals(1))
                        tCell.Text = Sugerencia[i].Cost.ToString();

                    //Agrega las acciones de la tabla
                    //else if (j.Equals(2))
                    //{
                    //    tCell.CssClass = "text-center";
                    //    //Crea hipervinculo para las acciones
                    //    LinkButton action = new LinkButton();
                    //    action.Attributes["data-toggle"] = "modal";
                    //    action.Attributes["data-target"] = "#ver_plato";
                    //    action.Text = RecursosMenu1.Accion_Sugerencia;
                    //    tCell.Controls.Add(action);
                    //}
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }


            }
            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            TableDayMenuDashboard.Rows.AddAt(0, header);
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
            //TableHeaderCell h3 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Precio";
            h2.Scope = TableHeaderScope.Column;
            //h3.Text = "Acciones";
            //h3.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            //header.Cells.Add(h3);

            return header;
        }

        public void CleanTable()
        {
            TableDayMenuDashboard.Rows.Clear();

        }
    }
}