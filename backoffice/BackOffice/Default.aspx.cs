using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BackOffice.Content;
using BackOffice.Seccion.Restaurant;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace BackOffice
{
    public partial class Prueba : System.Web.UI.Page
    {
        FactoryDAO factoryDAO = FactoryDAO.Intance;
        //IList<Dish> Sugerencia = new List<Dish>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataTable();
            //LoadTable_MenuSugestion();
    }

        /// <summary>
        /// Construye una tabla de mesas
        /// Utilizando el control de asp: Table
        /// </summary>
        protected void LoadDataTable()
        {
            CleanTable();
            //ID del restaurante donde nos encontramos
            int _idRestaurant = 0;
            if (Session["RestaurantID"] != null)
            {
                string idRestaurant = Session[RestaurantResource.SessionRestaurant].ToString();
                _idRestaurant = int.Parse(idRestaurant);
            }
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            IList<com.ds201625.fonda.Domain.Table> listTable = _tableDAO.GetTables(_idRestaurant);


            int totalRows = listTable.Count; //tamano de la lista 
            int totalColumns = 4; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listTable[i].Id.ToString();
                //Agrega la fila a la tabla existente
                table.Rows.Add(tRow);
                // CABLEADO DE RESERVA
                string statusTable = string.Empty;
                string user = string.Empty;
                string status = listTable[i].Status.ToString();
                string statusActive = FreeTableStatus.Instance.ToString();
                string statusInactive = BusyTableStatus.Instance.ToString();
                int quantity = 0;
                if (status == statusActive)
                {
                    status = RestaurantResource.Active;
                    user = "N/A";
                    quantity = 0;
                }
                else if (status == statusInactive)
                {
                    status = RestaurantResource.Inactive;
                    user = "Usuario" + listTable[i].Id;
                    quantity = listTable[i].Capacity - 1;

                }
                // TERMINA EL CABLEADO DE RESERVA
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el ID de la mesa
                    if (j.Equals(0))
                        tCell.Text = listTable[i].Number.ToString();
                    //Agrega la capacidad de la mesa
                    else if (j.Equals(1))
                        tCell.Text = listTable[i].Capacity.ToString();
                    //Agrega el numero de comensales
                    else if (j.Equals(2))
                        tCell.Text = quantity.ToString();
                    //Agrega el usuario que realizo la reserva
                    else if (j.Equals(3))
                        tCell.Text = user;
                    //Agrega el status
                    else if (j.Equals(4))
                    {
                        tCell.Text = status;
                        tCell.CssClass = "text-center";
                    }
                    //Agrega la celda
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            table.Rows.AddAt(0, header);
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
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();
            TableHeaderCell h5 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "ID";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Capacidad";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Comensales";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Usuario que realizo la reserva";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Estado";
            h5.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla mostrada en pantalla
        /// </summary>
        public void CleanTable()
        {
            table.Rows.Clear();
            //TableDayMenuDashboard.Rows.Clear();
        }

        //procedimiento que carga latabla de sugerencia del dia en el default importante cargen el test de dish 2 veces
        //y despues el de menu category para que aparezca informacion
        //protected void LoadTable_MenuSugestion()
        //{

        //    CleanTable();
        //    //Genero los objetos para la consulta
        //    //Genero la lista de la consulta
        //    FactoryDAO factoryDAO = FactoryDAO.Intance;
        //    IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
        //    IList<MenuCategory> listMenuC = _mencatDAO.GetAll();


        //    int lenghtListMenuC = listMenuC.Count;
        //    for (int i = 0; i <= lenghtListMenuC - 1; i++)
        //    {
        //        MenuCategory categoria = listMenuC[i];
        //        if (categoria.ListDish != null)
        //        {
        //            IList<Dish> listDish = categoria.ListDish;
        //            int lenghtlistDish = listDish.Count;

        //            for (int j = 0; j <= lenghtlistDish - 1; j++)
        //            {


        //                if (listDish[j].Suggestion == true)
        //                {
        //                    Sugerencia.Add(listDish[j]);

        //                }

        //            }
        //        }

        //    }



        //    int totalRows = Sugerencia.Count; //tamano de la lista 
        //    int totalColumns = 1; //numero de columnas de la tabla

        //    //Recorremos la lista
        //    for (int i = 0; i <= totalRows - 1; i++)
        //    {
        //        //Crea una nueva fila de la tabla
        //        TableRow tRow = new TableRow();
        //        //Le asigna el Id a cada fila de la tabla
        //        tRow.Attributes["data-id"] = Sugerencia[i].Id.ToString();
        //        String ver_id = Sugerencia[i].Id.ToString();
        //        //Agrega la fila a la tabla existente
        //        TableDayMenuDashboard.Rows.Add(tRow);
        //        for (int j = 0; j <= totalColumns; j++)
        //        {

        //            //Crea una nueva celda de la tabla
        //            TableCell tCell = new TableCell();
        //            //Agrega el nombre de la categoria
        //            if (j.Equals(0))
        //                tCell.Text = Sugerencia[i].Name;
        //            if (j.Equals(1))
        //                tCell.Text = Sugerencia[i].Cost.ToString();

        //            //Agrega las acciones de la tabla
        //            //else if (j.Equals(2))
        //            //{
        //            //    tCell.CssClass = "text-center";
        //            //    //Crea hipervinculo para las acciones
        //            //    LinkButton action = new LinkButton();
        //            //    action.Attributes["data-toggle"] = "modal";
        //            //    action.Attributes["data-target"] = "#ver_plato";
        //            //    action.Text = RecursosMenu1.Accion_Sugerencia;
        //            //    tCell.Controls.Add(action);
        //            //}
        //            //Agrega la 
        //            tRow.Cells.Add(tCell);

        //        }


        //    }
        //    //Agrega el encabezado a la Tabla
        //    TableHeaderRow header = GenerateTableHeaderCategory();
        //    TableDayMenuDashboard.Rows.AddAt(0, header);
        //}

        ///// <summary>
        ///// Genera el encabezado de la tabla Categoria
        ///// </summary>
        ///// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        //private TableHeaderRow GenerateTableHeaderCategory()
        //{
        //    //Se crea la fila en donde se insertara el header
        //    TableHeaderRow header = new TableHeaderRow();

        //    //Se crean las columnas del header
        //    TableHeaderCell h1 = new TableHeaderCell();
        //    TableHeaderCell h2 = new TableHeaderCell();
        //    //TableHeaderCell h3 = new TableHeaderCell();

        //    //Se indica que se trabajara en el header y se asignan los valores a las columnas
        //    header.TableSection = TableRowSection.TableHeader;
        //    h1.Text = "Nombre";
        //    h1.Scope = TableHeaderScope.Column;
        //    h2.Text = "Precio";
        //    h2.Scope = TableHeaderScope.Column;
        //    //h3.Text = "Acciones";
        //    //h3.Scope = TableHeaderScope.Column;

        //    //Se asignan las columnas a la fila
        //    header.Cells.Add(h1);
        //    header.Cells.Add(h2);
        //    //header.Cells.Add(h3);

        //    return header;
        //}


    }
}