using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using FondaResources.OrderAccount;
using BackOfficePresenter.OrderAccount;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficeModel;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleOrden : System.Web.UI.Page, IDetailOrderModel
    {
        #region Presenter

        private DetailOrderPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Table DetailOrderTable
        {
            get { return Pago; }

            set { Pago = value; }
        }

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

        /// <summary>
        /// Recurso de Session con el que inicia el Page_Load
        /// </summary>
        string IDetailOrderModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }

        public string SessionRestaurant
        {
            get { return Session[ResourceLogin.sessionRestaurantID].ToString(); }

            set { Session[ResourceLogin.sessionRestaurantID] = value; }
        }

        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        HtmlGenericControl IModel.SuccessLabel
        {
            get { return this.SuccessLabel; }

        }



        #endregion

        #region Constructor

        public VerDetalleOrden()
        {
            _presenter = new DetailOrderPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountID"] != null)
            {   //Llama al presentador para llenar la tabla de ordenes
                _presenter.GetDetailOrder();
            }
        }



    }

}