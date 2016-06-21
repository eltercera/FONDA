using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using FondaResources.OrderAccount;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficeModel;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleOrden : System.Web.UI.Page, IDetailOrderModel
    {
        #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.OrderAccount.DetailOrderPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Table DetailOrderTable
        {
            get { return orderDetail; }

            set { orderDetail = value; }
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

        public string SessionNumberAccount
        {
            get { return Session[OrderAccountResources.SessionNumberAccount].ToString(); }

            set { Session[OrderAccountResources.SessionNumberAccount] = value; }
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
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.DetailOrderPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AccountID"] != null)
            //{   //Llama al presentador para llenar la tabla de ordenes
            //Session[OrderAccountResources.SessionIdAccount] = System.Web.HttpContext.Current.Request.QueryString["Id"];
            _presenter.GetDetailOrder();
            //}
        }



    }

}