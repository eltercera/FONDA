using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficeModel.Reservations;
using com.ds201625.fonda.View.BackOfficePresenter.Reservations;
using com.ds201625.fonda.Resources.FondaResources.Reservations;
using com.ds201625.fonda.View.BackOfficeModel;
using com.ds201625.fonda.Resources.FondaResources.Login;

namespace BackOffice.Seccion.Reservas
{
    public partial class ListarReservas : System.Web.UI.Page, IReservationsContract
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

        Label IReservationsContract.WarningLabelMessage
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
        string IReservationsContract.Session
        {
            get
            {
                return Session[ReservationResources.SessionIdReservation].ToString();
            }

            set
            {
                //Session[ReservationResources.SessionIdReservation] = value;

                throw new NotImplementedException();
            }
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

        HtmlGenericControl IReservationsContract.WarningLabel
        {
            get { return this.WarningLabel; }
        }


        #endregion

        #region Constructor
        public ListarReservas()
        {
            _presenter = new ReservationsPresenter(this);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO (Reservation): Esto se deberia controlar por el presentador
            //Llama al presentador para llenar la tabla reservas
                if (Session[ResourceLogin.sessionUserID] != null &&           
                     Session[ResourceLogin.sessionRestaurantID] != null)
                _presenter.GetReservations();
            else if (Session[ResourceLogin.sessionRestaurantID] == null)
            {
                Session[ReservationResources.SessionNameRest] = ReservationResources.SessionAllRestaurants;
                _presenter.GetReservations();
            }
        }

        //protected void ButtonCancelReservation_Click(object sender, EventArgs e)
        //{
        //    _presenter.CancelReservation(sender, e);
        //}
    }
}