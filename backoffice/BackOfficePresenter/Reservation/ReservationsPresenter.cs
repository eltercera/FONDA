using BackOfficeModel.Reservations;
using BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.Reservations
{
    public class ReservationsPresenter : BackOfficePresenter.Presenter
    {
        //Enlace entre el Modelo y la Vista
        private IReservationsModel _view;
        private int totalColumns = 8;


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public ReservationsPresenter(IReservationsModel viewDefault)
            : base(viewDefault)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewDefault;

        }


        /// <summary>
        /// Metodo encargado de llenar la tabla de Reservas
        /// </summary>
        public void GetReservations()
        {
            int result = 0;
         

            try
            {

                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Llama al metodo para el llenado de la tabla
                FillReservationsTable(result);




            }
            catch (MVPExceptionOrdersTable ex)
            {
                Console.WriteLine("No falla");
            }

        }



        /// <summary>
        /// Metodo encargado de cambiar el estado de la reservacion a cancelado
        /// </summary>
        public void CancelReservation()
        {

        }


        /// <summary>
        /// Construye la tabla de Reservaciones
        /// </summary>
        /// <param name="restaurantId">El id del Restaurant</param>
        private void FillReservationsTable(int restaurantId)
        {
            //Escondo los labels
            HideMessageLabel();

            CleanTable();
            //Genero los objetos para la consulta

            //Define objeto a recibir
            IList<Domain.Table> listTables;
            Restaurant restaurant;
            //Invoca a comando del tipo deseado
            Command commandFindReservationsByTable;
            Command commandGetTables;
            Command commandFindRestaurantById;



            //Genero la lista de la consulta
            //Obtiene la instancia del comando enviado el restaurante como parametro       
            commandGetTables = CommandFactory.GetCommandGetTables(restaurantId);
            commandFindRestaurantById = CommandFactory.GetCommandFindRestaurantById(restaurantId);
            //Ejecuta el comando deseado

            commandGetTables.Execute();
            commandFindRestaurantById.Execute();
            //Se obtiene el resultado de la operacion
            listTables = (IList<Domain.Table>)commandGetTables.Receiver;
            restaurant = (Restaurant)commandFindRestaurantById.Receiver;

            //if (listTables != null)
            //{
            //    ////Llama al metodo para el llenado de la tabla
            //    //FillReservationsTable(result);
            //}


            //Tamaño de la lista de mesas
            int totalRowsTables = listTables.Count;
            // int totalRows = listTables.Count; //tamano de la lista 

            //Recorremos la lista
            for (int k = 0; k <= totalRowsTables - 1; k++)
            {
                //Obtiene la instancia del comando enviado la mesa como parametro  
                commandFindReservationsByTable = CommandFactory.GetCommandFindReservationsByTable(listTables[k].Id);
                commandFindReservationsByTable.Execute();

                if (listTables != null)
                {
                    IList<Reservation> listReservations = new List<Reservation>();
                    //Se obtiene el resultado de la operacion
                    listReservations = (IList<Reservation>)commandFindReservationsByTable.Receiver;

                    if (listReservations != null)
                    {
                        //tamaño de la lista de reservaciones de la mesa
                        int totalRowsReservations = listReservations.Count;
                        StringBuilder dataId = new StringBuilder();
                        //Recorremos la lista de reservaciones de la mesa

                        for (int i = 0; i <= totalRowsReservations - 1; i++)
                        {
                            //Crea una nueva fila de la tabla
                            TableRow tRow = new TableRow();
                            dataId.Append(listReservations[i].Id.ToString());
                            //Le asigna el Id a cada fila de la tabla
                            tRow.Attributes[ReservationResources.dataId] =
                                listReservations[i].Id.ToString();
                            //Agrega la fila a la tabla existente
                            _view.ReservationsTable.Rows.Add(tRow);
                            for (int j = 0; j <= totalColumns-1; j++)
                            {
                                //Crea una nueva celda de la tabla
                                TableCell tCell = new TableCell();

                                //Agrega el numero de la reservacion. Esto hay que implementarlo
                                if (j.Equals(0))
                                    tCell.Text = listReservations[i].Number.ToString();

                                //Agrega el email del comensal. Esto hay que implementarlo en comensal
                                // else if (j.Equals(1))
                                //     tCell.Text = data[i].Commensal.Email.ToString();

                                //Agrega el restaurante
                                else if (j.Equals(2))
                                    tCell.Text = restaurant.Name.ToString();

                                //Agrega el numero de mesa
                                else if (j.Equals(3))
                                    tCell.Text = listTables[k].Number.ToString();

                                //Agrega la fecha de creacion de la reservacion
                                else if (j.Equals(4))
                                    tCell.Text = listReservations[i].CreationDate.ToString();

                                //Agrega la fecha de reservacion de la mesa
                                else if (j.Equals(5))
                                    tCell.Text = listReservations[i].ReservationDate.ToString();

                                //Agrega el estado de la reservacion
                                else if (j.Equals(6))
                                    tCell.Text = listReservations[i].Status.ToString();


                                //Agrega las acciones de la tabla
                                else if (j.Equals(7))
                                {
                                    LinkButton cancelReservation = new LinkButton();

                                    cancelReservation.Text += ReservationResources.CancelReservation;
                                    cancelReservation.Attributes[ReservationResources.href] =
                                    ReservationResources.RefreshURL + dataId.ToString();
                                    tCell.Controls.Add(cancelReservation);

                                    //Guardamos el recurso de Session del ID de la reservacion
                                    int idReservation = listReservations[i].Id;
                                    _view.Session = idReservation.ToString();

                                }
                            //    Agrega la celda a la fila
                                tRow.Cells.Add(tCell);

                            }

                        }
                    }
                }

            }




            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.ReservationsTable.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Ordenes
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
            TableHeaderCell h6 = new TableHeaderCell();
            TableHeaderCell h7 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
           // Esto tambien debo mejorarlo
            h1.Text = ReservationResources.ReservationNumberColumn;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = ReservationResources.ReservationUserColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = ReservationResources.ReservationTableColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = ReservationResources.ReservationCreationDateColumn;
            h4.Scope = TableHeaderScope.Column;
            h5.Text = ReservationResources.ReservationDateColumn;
            h5.Scope = TableHeaderScope.Column;
            h6.Text = ReservationResources.StatusColumn;
            h6.Scope = TableHeaderScope.Column;
            h7.Text = ReservationResources.ActionColumn;
            h7.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);
            header.Cells.Add(h6);
            header.Cells.Add(h7);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla
        /// </summary>
        private void CleanTable()
        {
            _view.ReservationsTable.Rows.Clear();

        }

        public override void HideMessageLabel()
        {
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;
            _view.WarningLabel.Visible = false;
        }

    }
}
