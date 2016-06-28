using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security.AntiXss;
using System.Web.UI.WebControls;
using com.ds201625.fonda.Resources.FondaResources.Reservations;

namespace com.ds201625.fonda.View.BackOfficePresenter.Reservations
{
    public class DetailReservationPresenter : Presenter
    {
        private IDetailReservationContract _view;
        private int reservationId = 0;
        private Reservation _reservation;
       // private Commensal _commensal;
        private Domain.Table _table;
        private Restaurant _restaurant;

        public DetailReservationPresenter(IDetailReservationContract viewReservationDetail) :
            base(viewReservationDetail)
        {
            _view = viewReservationDetail;
        }

       

        ///<summary>
        ///Metodo para buscar los campos del Detalle de la reservacion
        public void GetDetailReservation()
        {
            List<Object> result;
            Command commandGetDetailReservation;
            try
            {
                reservationId = GetQueryParameter();
                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetDetailReservation = CommandFactory.GetCommandGetDetailReservation(reservationId);

                //Ejecuta el comando deseado
                commandGetDetailReservation.Execute();

                //Se obtiene el resultado de la operacion
                result = (List<Object>)commandGetDetailReservation.Receiver;
                _reservation = (Reservation)result[0];
                _table = (Domain.Table)result[1];
               _restaurant = (Restaurant)result[2];

                //Revisa si la lista no esta vacia
                if (_reservation != null)
                {
                    //Llama al metodo para el llenado de los Label
                    FillLabels();
                }

            }
            catch (MVPExceptionDetailReservationTable ex)
            {
                MVPExceptionDetailReservationTable e = new MVPExceptionDetailReservationTable
                    (
                        ReservationErrors.MVPExceptionDetailReservationTableCode,
                        ReservationResources.ClassNameDetailReservationPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        ReservationErrors.MessageMVPExceptionDetailReservationTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
            catch (Exception ex)
            {
                MVPExceptionDetailOrderTable e = new MVPExceptionDetailOrderTable
                    (
                        ReservationErrors.MVPExceptionDetailReservationTableCode,
                        ReservationResources.ClassNameDetailReservationPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        ReservationErrors.MessageMVPExceptionDetailReservationTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
        }

        /// <summary>
        /// Llena los campos donde se muestra la
        /// informacion de la factura
        /// </summary>
        private void FillLabels()
        {
            HideMessageLabel();
            ResetLabels();
            //Label de la factura
            _view.SessionNumberReservation = _reservation.Number.ToString();
            _view.NumberReservation.Text = _reservation.Number.ToString();
            _view.NumberCommensal.Text = _reservation.CommensalNumber.ToString();
            _view.Restaurant.Text = _restaurant.Name;
            _view.RestaurantTable.Text = _table.Number.ToString();
            _view.CreationDate.Text = _reservation.CreationDate.ToString();
            _view.ReservationDate.Text = _reservation.ReservationDate.ToString();
        }

        /// <summary>
        /// Limpia los labels donde se muestra el detalle
        /// de la factura
        /// </summary>
        private void ResetLabels()
        {
            string reset = string.Empty;
            //Label de la reservacion
            _view.SessionNumberReservation = reset;
            _view.NumberReservation.Text = reset;
            _view.NumberCommensal.Text = reset;
            _view.Restaurant.Text = reset;
            _view.RestaurantTable.Text = reset;
            _view.CreationDate.Text = reset;
            _view.ReservationDate.Text = reset;
        }
        /// <summary>
        /// Obtiene el parametro pasado en el URL
        /// </summary>
        /// <returns>Id</returns>
        private int GetQueryParameter()
        {
            int result = 0;
            string queryParameter =
                HttpContext.Current.Request.QueryString[ReservationResources.QueryParam];

            if (AntiXssEncoder.HtmlEncode(queryParameter, false) != null)
                return int.Parse(queryParameter);

            return result;
        }
    }
}
