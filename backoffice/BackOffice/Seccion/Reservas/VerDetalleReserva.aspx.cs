using System;
using System.Web.UI.WebControls;
using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.Resources.FondaResources.Reservation;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficeModel;
using BackOffice.Content;
using com.ds201625.fonda.View.BackOfficePresenter.Reservations;
using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.View.BackOfficePresenter.Reservations;

namespace BackOffice.Seccion.Reservas
{
    public partial class VerDetalleReserva : System.Web.UI.Page, IDetailReservationContract
    {
        #region Presenter

        private DetailReservationPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Table DetailReservationTable
        {
            get { return ReservationDetail; }

            set { ReservationDetail = value; }
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
            //if (Session[ResourceLogin.sessionUserID] != null &&
            //    Session[ResourceLogin.sessionRestaurantID] != null)
            // //   _presenter.GetDetailReservation();
            //else
            //    Response.Redirect(RecursoMaster.addressLogin);
        }



    }

}