using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using FondaResources.OrderAccount;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficeModel;
using BackOffice.Content;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleFactura : System.Web.UI.Page, IInvoiceDetailModel
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

        public System.Web.UI.WebControls.Label UserName
        {
            get { return name; }

            set { name = value; }
        }

        public System.Web.UI.WebControls.Label UserLastName
        {
            get { return lastname; }

            set { lastname = value; }
        }

        public System.Web.UI.WebControls.Label UserId
        {
            get { return ssn; }

            set { ssn = value; }
        }

        public System.Web.UI.WebControls.Label IvaInvoice
        {
            get { return iva; }

            set { iva = value; }
        }

        public System.Web.UI.WebControls.Label TotalInvoice
        {
            get { return total; }

            set { total = value; }
        }

        public System.Web.UI.WebControls.Label DateInvoice
        {
            get { return date; }

            set { date = value; }
        }

        public System.Web.UI.WebControls.LinkButton PrintInvoice
        {
            get { return print; }

            set { print = value; }
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
        string IInvoiceDetailModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdInvoice].ToString(); }

            set { Session[OrderAccountResources.SessionIdInvoice] = value; }
        }
        string IInvoiceDetailModel.SessionIdAccount
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
            if (Session[ResourceLogin.sessionUserID] != null)
            {

                _presenter.GetDetailOrder();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }
    }
}