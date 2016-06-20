using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using FondaResources.OrderAccount;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficeModel;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleFactura : System.Web.UI.Page, IInvoiceDetailContract
    { 
       #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.OrderAccount.InvoiceDetailPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Table DetailInvoiceTable
        {
            get { return invoiceDetail; }

            set { invoiceDetail = value; }
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
        string IInvoiceDetailContract.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }
        string IInvoiceDetailContract.SessionIdInvoice
        {
            get { return Session[OrderAccountResources.SessionIdInvoice].ToString(); }

            set { Session[OrderAccountResources.SessionIdInvoice] = value; }
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

        public string SessionNumberInvoice
        {
            get { return Session[OrderAccountResources.SessionNumberInvoice].ToString(); }

            set { Session[OrderAccountResources.SessionNumberInvoice] = value; }
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

        public VerDetalleFactura()
        {
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.InvoiceDetailPresenter(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.GetDetailOrder();
        }
    }
}