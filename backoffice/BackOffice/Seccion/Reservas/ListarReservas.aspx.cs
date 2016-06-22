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
using BackOffice.Content;

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
            get { return this.ErrorLabelMessage; }

            set { this.ErrorLabelMessage = value; }

        }

        Label IModel.SuccessLabelMessage
        {
            get { return this.SuccessLabelMessage; }

            set { this.SuccessLabelMessage = value; }
        }

        Label IReservationsModel.WarningLabelMessage
        {
            get { return this.WarningLabelMessage; }

            set { this.WarningLabelMessage = value; }
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
            get { return Session[ReservationResources.SessionIdReservation].ToString(); }

            set { Session[ReservationResources.SessionIdReservation] = value; }
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
            get { return this.SuccessLabel; }
        }

        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        HtmlGenericControl IReservationsModel.WarningLabel
        {
            get { return this.WarningLabel; }
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
            if (Session[ResourceLogin.sessionUserID] != null)
            {

                //Llama al presentador para llenar la tabla reservas
                _presenter.GetReservations();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);

        }

        protected void ButtonCancelReservation_Click(object sender, EventArgs e)
        {
            _presenter.CancelReservation();
        }
    }
}