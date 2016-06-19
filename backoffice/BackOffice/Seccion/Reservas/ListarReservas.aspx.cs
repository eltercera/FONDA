using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BackOfficeModel;
using BackOfficeModel.Reservations;
using com.ds201625.fonda.BackOffice.Presenter.Reservations;
using FondaResources.Reservation;
using FondaResources.Login;

namespace BackOffice.Seccion.Reservas
{
    public partial class Default : System.Web.UI.Page, IReservationsModel
    {
        #region Presenter
        private ReservationsPresenter _presenter;
        #endregion

        #region Model
        Label IModel.ErrorLabelMessage
        {
            get { return this.ErrorLabelMessage_UsedStatus; }

            set { this.ErrorLabelMessage_UsedStatus = value; }

        }

        Label IModel.SuccessLabelMessage
        {
            get { return this.SuccessLabelMessage_UsedStatus; }

            set { this.SuccessLabelMessage_UsedStatus = value; }
        }

        Label IReservationsModel.WarningLabelMessage
        {
            get { return this.WarningLabelMessage_UsedStatus; }

            set { this.WarningLabelMessage_UsedStatus = value; }
        }



        public System.Web.UI.WebControls.Table ReservationsTable
        {
            get { return ReservationsList; }

            set { ReservationsList = value; }
        }


        /// <summary>
        /// Recurso de Session para el ID de la Reserva
        /// </summary>
        string IReservationsModel.Session
        {
            get { return Session[ReservationResources.SessionIdAccount].ToString(); }

            set { Session[ReservationResources.SessionIdAccount] = value; }
        }

        public string SessionRestaurant
        {
            get
            {
                if (Session[ResourceLogin.sessionRestaurantID] != null)
                    return Session[ResourceLogin.sessionRestaurantID].ToString();
                else
                    return "0";
            }

            set { Session[ResourceLogin.sessionRestaurantID] = value; }
        }

        HtmlGenericControl IModel.SuccessLabel
        {
            get { return this.SuccessLabel_UsedStatus; }
        }

        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel_UsedStatus; }
        }

        HtmlGenericControl IReservationsModel.WarningLabel
        {
            get { return this.WarningLabel_UsedStatus; }
        }


        #endregion

        #region Constructor
        public Default()
        {
            _presenter = new ReservationsPresenter(this);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            //Llama al presentador para llenar la tabla reservas
            _presenter.GetReservations();

        }
    }
}