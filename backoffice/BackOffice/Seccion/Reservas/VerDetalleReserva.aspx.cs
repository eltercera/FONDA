using System;
using System.Web.UI.WebControls;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficeModel;
using BackOffice.Content;
using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.View.BackOfficePresenter.Reservations;
using com.ds201625.fonda.Resources.FondaResources.Reservations;

namespace BackOffice.Seccion.Reservas
{
    public partial class VerDetalleReserva : System.Web.UI.Page, IDetailReservationContract
    {
        #region Presenter

        private DetailReservationPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Label NumberReservation
        {
            get { return numberReservation; }

            set { numberReservation = value; }
        }

        public System.Web.UI.WebControls.Label NumberCommensal
        {
            get { return numberCommensal; }

            set { numberCommensal = value; }
        }

        public System.Web.UI.WebControls.Label Restaurant
        {
            get { return restaurant; }

            set { restaurant = value; }
        }

        public System.Web.UI.WebControls.Label RestaurantTable
        {
            get { return restaurantTable; }

            set { restaurantTable = value; }
        }


        public System.Web.UI.WebControls.Label CreationDate
        {
            get { return creationDate; }

            set { creationDate = value; }
        }


        public System.Web.UI.WebControls.Label ReservationDate
        {
            get { return reservationDate; }

            set { reservationDate = value; }
        }

     

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

        /// <summary>
        /// Recurso de Session con el que inicia el Page_Load
        /// </summary>
        string IDetailReservationContract.Session
        {
            get { return Session[ReservationResources.SessionIdReservation].ToString(); }

            set { Session[ReservationResources.SessionIdReservation] = value; }
        }

        public string SessionRestaurant
        {
            get { return Session[ResourceLogin.sessionRestaurantID].ToString(); }

            set { Session[ResourceLogin.sessionRestaurantID] = value; }
        }

        public string SessionNumberReservation
        {
            get { return Session[ReservationResources.SessionNumberReservation].ToString(); }

            set { Session[ReservationResources.SessionNumberReservation] = value; }
        }
        HtmlGenericControl IContract.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        HtmlGenericControl IContract.SuccessLabel
        {
            get { return this.SuccessLabel; }

        }


        #endregion

        #region Constructor

        public VerDetalleReserva()
        {
            _presenter = new DetailReservationPresenter(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           _presenter.GetDetailReservation();
        }
    }
}