using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Resources.FondaResources.Login;
using com.ds201625.fonda.View.BackOfficeModel.Restaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficePresenter.Restaurante
{
    public class TablePresenter : Presenter
    {
        FactoryDAO factoryDAO = FactoryDAO.Intance;
        int _idRestaurant = 1;
        com.ds201625.fonda.Domain.Restaurant _restaurant = new com.ds201625.fonda.Domain.Restaurant();
        
        //enlace entre el modelo y la vista
        private ITableModel _view;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public TablePresenter(ITableModel viewTable)
            : base(viewTable)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewTable;

        }

        //del .cs
        /// <summary>
        /// Construye una tabla de mesas
        /// Utilizando el control de asp: Table
        /// </summary>
        public void LoadDataTable()
        {
            CleanTable();
            Command commandGetTables;
            Command commandFindReservationByRestaurant;
            //ID del restaurante donde nos encontramos
            //Validamos que la Session de Gerente este iniciada
            int _idRestaurant = 1;
           /* if (Session["RestaurantID"] != null)
            {
                try
                {
                    string idRestaurant = Session[RestaurantResource.SessionRestaurant].ToString();
                    _idRestaurant = int.Parse(idRestaurant);
                }
                catch (Exception e)
                {
                    throw new CastException("Error al transformar un tipo de dato string a int", e);
                }
            }*/

            //Genero los objetos para la consulta
            //Genero la lista de mesas por restaurant
            //ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            //IList<com.ds201625.fonda.Domain.Table> listTable = _tableDAO.GetTables(_idRestaurant);

            //llena tabla con lista de mesas de un restaurante
            IList<com.ds201625.fonda.Domain.Table> listTable;
            commandGetTables = CommandFactory.GetCommandGetTables(_idRestaurant);
            commandGetTables.Execute();
            listTable = (IList<com.ds201625.fonda.Domain.Table>)commandGetTables.Receiver;
            System.Diagnostics.Debug.WriteLine("lista de mesas por restaurante");
            System.Diagnostics.Debug.WriteLine(listTable);

            //Genero la lista de reservas por restaurant
            IList<Reservation> listReservation;
            commandFindReservationByRestaurant = CommandFactory.GetCommandFindReservationsByRestaurant(_idRestaurant);
            commandFindReservationByRestaurant.Execute();
            listReservation = (IList<Reservation>)commandFindReservationByRestaurant.Receiver;
            System.Diagnostics.Debug.WriteLine("lista de reservas por restaurante");

            //IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            //  IList<Reserve> listReservation = _restaurantDAO.ReservationsByRestaurantId(_idRestaurant);
            //IList<Reserve> listReservation = null;
            //Fecha del sistema
            DateTime today = DateTime.Now;
            DateTime now = new DateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, 0);



            int totalRows = listTable.Count; //tamano de la lista 
            int totalColumns = 5; //numero de columnas de la tabla
            int totalRowsReservation = listReservation.Count; //tamano de la lista de reserva
            System.Diagnostics.Debug.WriteLine("reservas:" + totalRowsReservation);
            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listTable[i].Id.ToString();
                //Agrega la fila a la tabla existente
                _view.tablePage.Rows.Add(tRow);

                #region RESERVA
                string user = string.Empty;
                string status = listTable[i].Status.ToString();
                int quantity = 0;

                //Verificamos que existan reservas
                if (totalRowsReservation != 0)
                {
                    //Cantidad de reservas para ese restaurant
                    for (int r = 0; r <= totalRowsReservation - 1; r++)
                    {
                        //Fecha de reserva
                        DateTime reservationDate = listReservation[r].ReservationDate;
                        // DateTime reservationDate = listReservation[r].ReserveDate;

                        //Chequear si hay una reserva en curso o no y asigna los datos de reserva 
                        if ((now == reservationDate))
                        // if ((now == reservationDate) && (listTable[i].Id == listReservation[r].ReserveTable.Id))
                        {
                            status = RestaurantResource.Inactive;
                            user = "Usuario" + listTable[i].Id;
                            quantity = listReservation[r].CommensalNumber;
                        }
                        else
                        //else if ((now != reservationDate) || (listTable[i].Id != listReservation[r].ReserveTable.Id))
                        {
                            status = RestaurantResource.Active;
                            user = "N/A";
                            quantity = 0;

                        }
                    }
                }
                else if (totalRowsReservation == 0)
                {
                    status = RestaurantResource.Active;
                    user = "N/A";
                    quantity = 0;

                }
                #endregion



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
                    //Agrega las acciones
                    else if (j.Equals(5))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton actionModify = new LinkButton();
                        LinkButton actionActive = new LinkButton();
                        LinkButton actionInactive = new LinkButton();

                        actionModify.Attributes["data-toggle"] = "modal";
                        actionModify.Attributes["data-target"] = "#modificar";
                        actionModify.Text = RestaurantResource.ActionModify;
                        tCell.Controls.Add(actionModify);

                        actionActive.Attributes["data-status"] = "true";
                        actionActive.Text = RestaurantResource.ActionCheckStatus;
                        tCell.Controls.Add(actionActive);

                        actionInactive.Attributes["data-status"] = "false";
                        actionInactive.Text = RestaurantResource.ActionUnCheckStatus;
                        tCell.Controls.Add(actionInactive);

                    }
                    //Agrega la celda
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.tablePage.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        public TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();
            TableHeaderCell h5 = new TableHeaderCell();
            TableHeaderCell h6 = new TableHeaderCell();

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
            h6.Text = "Acciones";
            h6.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);
            header.Cells.Add(h6);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla mostrada en pantalla
        /// </summary>
        public void CleanTable()
        {
            _view.tablePage.Rows.Clear();
        }

        /// <summary>
        /// Agrega una nueva mesa
        /// </summary>
        public void ButtonAdd_Click()
        {
            //declaro comandos
            Command commandGetTables;
            Command commandGetRestaurantById;
            Command commandSaveTable;
            Restaurant _restaurant;
            _view.alertSuccess_AddTable.Visible = true;

            IList<com.ds201625.fonda.Domain.Table> listTable;
            commandGetTables = CommandFactory.GetCommandGetTables(_idRestaurant);
            commandGetTables.Execute();
            //asigno valores a la lista
            listTable = (IList<com.ds201625.fonda.Domain.Table>)commandGetTables.Receiver;

            //ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            //IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            //genero una nueva mesa
            com.ds201625.fonda.Domain.Table _table = new com.ds201625.fonda.Domain.Table();

            //busca las mesas del restaurante
            // IList<com.ds201625.fonda.Domain.Table> listTable = _tableDAO.GetTables(_idRestaurant);
            int capacity = int.Parse(_view.dddlCapacityA.SelectedValue);
            _table.Capacity = capacity;
            _table.Status = factoryDAO.GetFreeTableStatus();
            //le asigna un numero unico a la mesa para ese restaurante
            System.Diagnostics.Debug.WriteLine("numero de mesas" + listTable.Count);
            _table.Number = listTable.Count + 1;

            //commandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_idRestaurant);
           // commandGetRestaurantById.Execute();
            //_restaurant = (Restaurant)commandGetRestaurantById.Receiver;

            // _restaurant = _restaurantDAO.FindById(_idRestaurant);
           // _table. = _restaurant;
            //Guardo modificacion de mesa en la bd utilizando el comando SaveTable
            commandSaveTable = CommandFactory.GetCommandSaveTable(_table);
            //ejecuto el comando
            commandSaveTable.Execute();
            
            //  _table.Restaurant = _restaurant;
            //_tableDAO.Save(_table);
            LoadDataTable();
        }

        /// <summary>
        /// Modifica los datos de la mesa
        /// </summary>
        public void ButtonModify_Click()
        {
            //declaraciones de comandos
            Command commandSaveTable;
            Command commandFindTableById;
            Domain.Table _tableM;
            _view.alertSuccess_ModifyTable.Visible = true; 

            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            string TableID = _view.tableModifyId.Value;
            int idTable = int.Parse(TableID);
            //comando que busca una mesa dado su id
            commandFindTableById = CommandFactory.GetCommandFindTableById(idTable);
            //ejecuto el comando
            commandFindTableById.Execute();
            //Asigno el resultado del comando
            _tableM = (Domain.Table)commandFindTableById.Receiver;

            //com.ds201625.fonda.Domain.Table _tableM = _tableDAO.FindById(idTable);
            int capacity = int.Parse(_view.dddlCapacityM.SelectedValue);
            _tableM.Capacity = capacity;
            //Guardo modificacion de mesa en la bd utilizando el comando SaveTable
            commandSaveTable = CommandFactory.GetCommandSaveTable(_tableM);
            //ejecuto el comando
            commandSaveTable.Execute();
           // _tableDAO.Save(_tableM);
            LoadDataTable();

        }

        /// <summary>
        /// Cambia el Status de la mesa
        /// </summary>
        /// <param name="Id">Recibe el Id de la mesa</param>
        /// <param name="Status">Recibe el Status al que se va a cambiar</param>
        /// <returns>El Status a mostrar en la tabla</returns>
       
      


    }
}
