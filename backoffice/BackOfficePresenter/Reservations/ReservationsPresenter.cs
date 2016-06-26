using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Resources.FondaResources.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using com.ds201625.fonda.Logic.FondaLogic.Log;

namespace com.ds201625.fonda.View.BackOfficePresenter.Reservations
{
    public class ReservationsPresenter : Presenter
    {
        //Enlace entre el Modelo y la Vista
        private IReservationsContract _view;
        private int totalColumns = 6;


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public ReservationsPresenter(IReservationsContract viewDefault)
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
            IList<Reservation> _listReservations = new List<Reservation>();
            Command commandGetReservations;

            try
            {

                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Obtiene la instancia del comando enviado el restaurante como parametro
                if (result != 0)
                    commandGetReservations = CommandFactory.GetCommandFindReservationsByRestaurant(result);
                else
                    commandGetReservations = CommandFactory.GetCommandGetAllReservations();

                //TODO (Reservations): Revisar si esto funciona bien
                //ejecuta el comando deseado
                commandGetReservations.Execute();

                //asigno el resultado a la lista de reservaciones
                _listReservations = (List<Reservation>)commandGetReservations.Receiver;

                //reviso si la lista de reservaciones no esta vacia
                if (_listReservations != null)
                {
                    FillReservationsTable(_listReservations);
                }

            }
            catch (MVPExceptionOrdersTable ex)
            {
                MVPExceptionOrdersTable e = new MVPExceptionOrdersTable
                    (
                        ReservationErrors.MVPExceptionReservationsTableCode,
                        ReservationResources.ClassNameReservationsPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        ReservationErrors.MessageMVPExceptionReservationsTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
            catch (Exception ex)
            {
                MVPExceptionOrdersTable e = new MVPExceptionOrdersTable
                    (
                        ReservationErrors.MVPExceptionReservationsTableCode,
                        ReservationResources.ClassNameReservationsPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        ReservationErrors.MessageMVPExceptionReservationsTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }

            Logger.WriteSuccessLog(ReservationResources.ClassNameReservationsPresenter
                , ReservationResources.MessageGetReservations
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        }




        //TODO (RESERVATIONS):
        /// <summary>
        /// Metodo encargado de cancelar la reservacion
        /// </summary>
        public void CancelReservation()
        {

        }


        /// <summary>
        /// Construye la tabla de Reservaciones
        /// </summary>
        /// <param name="listReservations">Lista de restaurantes</param>
        private void FillReservationsTable(IList<Reservation> listReservations)
        {
            //Escondo los labels y limpio la tabla
            HideMessageLabel();
            CleanTable(_view.ReservationsTable);

            //Genero los objetos para la consulta
            //Tamaño de la lista de reservaciones
            int totalRowsReservations = listReservations.Count;
            StringBuilder dataId = new StringBuilder();
            StringBuilder status = new StringBuilder();

            //Recorremos la lista
            for (int i = 0; i <= totalRowsReservations - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                dataId.Append(listReservations[i].Id.ToString());
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes[ReservationResources.dataId] = dataId.ToString();
                //Agrega la fila a la tabla existente
                _view.ReservationsTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns - 1; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();

                    //Agrega el numero de la reservacion. Esto hay que implementarlo
                    if (j.Equals(0))
                        tCell.Text = listReservations[i].Number.ToString();

                    //TODO (Reservations): Agregar la columna del email del comensal
                    //Agrega el email del comensal. Esto hay que implementarlo en comensal
                    // else if (j.Equals(1))
                    //     tCell.Text = data[i].Commensal.Email.ToString();

                    //TODO (Reservations): Agregar la columna de restaurant
                    //Agrega el restaurante
                    //else if (j.Equals(2))
                    //    tCell.Text = restaurant.Name.ToString();
                    //TODO (Reservations): Posemos hacerlo con un CommandFindRestaurantByTable

                    //TODO (Reservationes): Agregar la columna de numero de mesas
                    //Agrega el numero de mesa
                    //else if (j.Equals(3))
                    //    tCell.Text = listTables[k].Number.ToString();

                    //Agrega la fecha de creacion de la reservacion
                    else if (j.Equals(1))
                        tCell.Text = listReservations[i].CreationDate.ToString();
                    //Agrega la fecha de reservacion de la mesa
                    else if (j.Equals(2))
                        tCell.Text = listReservations[i].ReservationDate.ToString();
                    //Agrega el numero de comensales de la reservacion
                    else if (j.Equals(3))
                        tCell.Text = listReservations[i].CommensalNumber.ToString();
                 
                    //TODO (Reservacion): Arreglar el estado
                    //Agrega el estado de la reservacion
                    else if (j.Equals(4))
                    {
                        //Revisa el estado actual para convertirlo a string
                        if (listReservations[i].Status.Equals(ReservedReservationStatus.Instance))
                            status.Append(ReservationResources.CanceledReservationStatus);
                        else if (listReservations[i].Status.Equals(CanceledReservationStatus.Instance))
                            status.Append(ReservationResources.ReservedReservationStatus);
  
                        tCell.Text = status.ToString();
                        status.Clear();
                    }
                    //Agrega las acciones de la tabla
                    else if (j.Equals(5))
                    {
                        tCell.CssClass = ReservationResources.CssClassActions;

                        //boton de detalle de la reservacion
                        LinkButton LBReservationInfo = new LinkButton();
                        LBReservationInfo.Text += ReservationResources.ReservationInfo;
                        LBReservationInfo.Attributes[ReservationResources.href] =
                            ReservationResources.reservationURL + dataId.ToString();
                        tCell.Controls.Add(LBReservationInfo);

                        //boton de cancelar reservacion
                        LinkButton LBCancelReservation = new LinkButton();
                        LBCancelReservation.Text += ReservationResources.CancelReservation;
                        LBCancelReservation.Attributes[ReservationResources.href] =
                            ReservationResources.RefreshURL + dataId.ToString();
                        tCell.Controls.Add(LBCancelReservation);
                    }
                    //    Agrega la celda a la fila
                    tRow.Cells.Add(tCell);
                }
                //Limpia el objeto StringBuilder
                dataId.Clear();

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.ReservationsTable.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Reservaciones
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
           // TableHeaderCell h7 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            //TODO (Reservacion): Mejorar esto
            h1.Text = ReservationResources.ReservationNumberColumn;
            h1.Scope = TableHeaderScope.Column;
          //  h2.Text = ReservationResources.ReservationUserColumn;
          //  h2.Scope = TableHeaderScope.Column;
          //  h3.Text = ReservationResources.ReservationTableColumn;
          //  h3.Scope = TableHeaderScope.Column;
            h2.Text = ReservationResources.ReservationCreationDateColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = ReservationResources.ReservationDateColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = ReservationResources.ReservationCommensalNumberColumn;
            h4.Scope = TableHeaderScope.Column;
            h5.Text = ReservationResources.StatusColumn;
            h5.Scope = TableHeaderScope.Column;
            h6.Text = ReservationResources.ActionColumn;
            h6.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);
            header.Cells.Add(h6);
         //   header.Cells.Add(h7);

            return header;
        }

        public override void HideMessageLabel()
        {
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;
            _view.WarningLabel.Visible = false;
        }

    }
}
