using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.View.BackOfficePresenter.Reservations;
using com.ds201625.fonda.Resources.FondaResources.Reservation;
using com.ds201625.fonda.View.BackOfficeModel;
using com.ds201625.fonda.Resources.FondaResources.Login;
using BackOffice.Content;

namespace BackOffice.Seccion.Reservas
{
    public partial class Default : System.Web.UI.Page, IReservationsModel
    {
        #region Presenter
        private ReservationsPresenter _presenter;
        #endregion

        #region Model
        Label IContract.ErrorLabelMessage
        {
            get { return this.ErrorLabelMessage; }

            set { this.ErrorLabelMessage = value; }

        }

        Label IContract.SuccessLabelMessage
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

        HtmlGenericControl IContract.SuccessLabel
        {
            get { return this.SuccessLabel; }
        }

        HtmlGenericControl IContract.ErrorLabel
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