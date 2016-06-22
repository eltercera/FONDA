using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BackOffice.Seccion.Restaurant;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using BackOfficePresenter.Login;
using FondaResources.Login;
using BackOffice.Content;

namespace BackOffice
{
    public partial class Prueba : System.Web.UI.Page
    {
        FactoryDAO factoryDAO = FactoryDAO.Intance;
        IList<Dish> Sugerencia = new List<Dish>();
        int commensal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                LoadDataTable();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }

        /// <summary>
        /// Construye una tabla de mesas
        /// Utilizando el control de asp: Table
        /// </summary>
        protected void LoadDataTable()
        {
            //CleanTable();
            ////Cargar Table de Mesas
            ////ID del restaurante donde nos encontramos
            //int _idRestaurant = 0;
            //if (Session[ResourceLogin.sessionRestaurantID] != null)
            //{
            //    try {
            //        string idRestaurant = Session[RestaurantResource.SessionRestaurant].ToString();
            //        _idRestaurant = int.Parse(idRestaurant);
            //        }
            //    catch (Exception e) {
            //        throw new CastException("Error al transformar un tipo de dato string a int", e);
            //    }
            //}
            ////Genero los objetos para la consulta
            ////Genero la lista de la consulta
            //ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            //IList<com.ds201625.fonda.Domain.Table> listTable = _tableDAO.GetTables(_idRestaurant);
            //IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            //IList<Reservation> listReservation = _restaurantDAO.ReservationsByRestaurantId(_idRestaurant);
            //DateTime today = DateTime.Now;
            //DateTime now = new DateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, 0);


            //int totalRows = listTable.Count; //tamano de la lista 
            //int totalColumns = 4; //numero de columnas de la tabla
            //int totalRowsReservation = listReservation.Count; //tamano de la lista de reserva

            ////Recorremos la lista
            //for (int i = 0; i <= totalRows - 1; i++)
            //{
            //    //Crea una nueva fila de la tabla
            //    TableRow tRow = new TableRow();
            //    //Le asigna el Id a cada fila de la tabla
            //    tRow.Attributes["data-id"] = listTable[i].Id.ToString();
            //    //Agrega la fila a la tabla existente
            //    tableDefault.Rows.Add(tRow);

            //    #region CABLEADO RESERVA
                //string user = string.Empty;
                //string status = listTable[i].Status.ToString();
                //int quantity = 0;

                ////Verificamos que existan reservas
                //if (totalRowsReservation != 0)
                //{
                //    //Cantidad de reservas para ese restaurant
                //    for (int r = 0; r <= totalRowsReservation - 1; r++)
                //    {
                //        //Fecha de reserva
                //        DateTime reservationDate = listReservation[r].ReservationDate;

                //        //Chequear si hay una reserva en curso o no y asigna los datos de reserva
                //        if ((now == reservationDate) && (listTable[i].Id == listReservation[r].ReserveTable.Id))
                //        {
                //            status = RestaurantResource.Inactive;
                //            user = "Usuario" + listTable[i].Id;
                //            quantity = listReservation[r].CommensalNumber;
                //        }
                //        else if ((now != reservationDate) || (listTable[i].Id != listReservation[r].ReserveTable.Id))
                //        {
                //            status = RestaurantResource.Active;
                //            user = "N/A";
                //            quantity = 0;

                //        }
                //    }
                //}
                //else if (totalRowsReservation == 0)
                //{
                //    status = RestaurantResource.Active;
                //    user = "N/A";
                //    quantity = 0;

                //}
                //#endregion

            ////    for (int j = 0; j <= totalColumns; j++)
            ////    {
            ////        //Crea una nueva celda de la tabla
            ////        TableCell tCell = new TableCell();
            ////        //Agrega el ID de la mesa
            ////        if (j.Equals(0))
            ////            tCell.Text = listTable[i].Number.ToString();
            ////        //Agrega la capacidad de la mesa
            ////        else if (j.Equals(1))
            ////            tCell.Text = listTable[i].Capacity.ToString();
            ////        //Agrega el numero de comensales
            ////        else if (j.Equals(2))
            ////        {
            ////            tCell.Text = quantity.ToString();
            ////            commensal = quantity + commensal;
            ////        }
            ////        //Agrega el usuario que realizo la reserva
            ////        else if (j.Equals(3))
            ////            tCell.Text = user;
            ////        //Agrega el status
            ////        else if (j.Equals(4))
            ////        {
            ////            tCell.Text = status;
            ////            tCell.CssClass = "text-center";
            ////        }
            ////        //Agrega la celda
            ////        tRow.Cells.Add(tCell);

            ////    }

            ////}
            
            //commensalLabel.Text = commensal.ToString();

            ////Agrega el encabezado a la Tabla de MEsas
            //TableHeaderRow header = GenerateTableHeader();
            //tableDefault.Rows.AddAt(0, header);

            ////Agregar Table de Menu
            //IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            //IList<MenuCategory> listMenuC = _mencatDAO.GetAll();


            //int lenghtListMenuC = listMenuC.Count;
            //for (int i = 0; i <= lenghtListMenuC - 1; i++)
            //{
            //    MenuCategory categoria = listMenuC[i];
            //    if (categoria.ListDish != null)
            //    {
            //        IList<Dish> listDish = categoria.ListDish;
            //        int lenghtlistDish = listDish.Count;

            //        for (int j = 0; j <= lenghtlistDish - 1; j++)
            //        {


            //            if (listDish[j].Suggestion == true)
            //            {
            //                Sugerencia.Add(listDish[j]);

            //            }

            //        }
            //    }

            //}


            //int totalMenuRows = Sugerencia.Count; //tamano de la lista 
            //int totalMenuColumns = 1; //numero de columnas de la tabla

            ////Recorremos la lista
            //for (int i = 0; i <= totalMenuRows - 1; i++)
            //{
            //    //Crea una nueva fila de la tabla
            //    TableRow tRow = new TableRow();
            //    //Le asigna el Id a cada fila de la tabla
            //    tRow.Attributes["data-id"] = Sugerencia[i].Id.ToString();
            //    String ver_id = Sugerencia[i].Id.ToString();
            //    //Agrega la fila a la tabla existente
            //    TableDayMenuDashboard.Rows.Add(tRow);
            //    for (int j = 0; j <= totalMenuColumns; j++)
            //    {

            //        //Crea una nueva celda de la tabla
            //        TableCell tCell = new TableCell();
            //        //Agrega el nombre de la categoria
            //        if (j.Equals(0))
            //            tCell.Text = Sugerencia[i].Name;
            //        if (j.Equals(1))
            //            tCell.Text = Sugerencia[i].Cost.ToString();
            //        //Agrega la 
            //        tRow.Cells.Add(tCell);

            //    }


            //}
            ////Agrega el encabezado a la Tabla
            //TableHeaderRow headerMenu = GenerateTableHeaderCategory();
            //TableDayMenuDashboard.Rows.AddAt(0, headerMenu);
        }


        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        //private TableHeaderRow GenerateTableHeader()
        //{
        //    //Se crea la fila en donde se insertara el header
        //    TableHeaderRow header = new TableHeaderRow();

        //    //Se crean las columnas del header
        //    TableHeaderCell h1 = new TableHeaderCell();
        //    TableHeaderCell h2 = new TableHeaderCell();
        //    TableHeaderCell h3 = new TableHeaderCell();
        //    TableHeaderCell h4 = new TableHeaderCell();
        //    TableHeaderCell h5 = new TableHeaderCell();

        //    //Se indica que se trabajara en el header y se asignan los valores a las columnas
        //    header.TableSection = TableRowSection.TableHeader;
        //    h1.Text = "ID";
        //    h1.Scope = TableHeaderScope.Column;
        //    h2.Text = "Capacidad";
        //    h2.Scope = TableHeaderScope.Column;
        //    h3.Text = "Comensales";
        //    h3.Scope = TableHeaderScope.Column;
        //    h4.Text = "Usuario que realizo la reserva";
        //    h4.Scope = TableHeaderScope.Column;
        //    h5.Text = "Estado";
        //    h5.Scope = TableHeaderScope.Column;

        //    //Se asignan las columnas a la fila
        //    header.Cells.Add(h1);
        //    header.Cells.Add(h2);
        //    header.Cells.Add(h3);
        //    header.Cells.Add(h4);
        //    header.Cells.Add(h5);

        //    return header;
        //}

        ///// <summary>
        ///// Limpia las filas de la tabla mostrada en pantalla
        ///// </summary>
        //public void CleanTable()
        //{
        //    tableDefault.Rows.Clear();
        //    TableDayMenuDashboard.Rows.Clear();
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