using System;
using System.Web.UI.WebControls;
using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficeModel;
using BackOffice.Content;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleFactura : System.Web.UI.Page, IDetailInvoiceContract
    { 
       #region Presenter

        private DetailInvoicePresenter _presenter;

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
        public System.Web.UI.WebControls.Label NumberAccount
        {
            get { return accountNumber; }

            set { accountNumber = value; }
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
        public System.Web.UI.WebControls.Label SubTotalInvoice
        {
            get { return subtotal; }

            set { subtotal = value; }
        }
        public System.Web.UI.WebControls.Label TipInvoice
        {
            get { return propina; }

            set { propina = value; }
        }

        public System.Web.UI.WebControls.Label DateInvoice
        {
            get { return date; }

            set { date = value; }
        }

        public System.Web.UI.WebControls.Button PrintInvoice
        {
            get { return invoicePrint; }

            set { invoicePrint = value; }
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
        string IDetailInvoiceContract.Session
        {
            get { return Session[OrderAccountResources.SessionIdInvoice].ToString(); }

            set { Session[OrderAccountResources.SessionIdInvoice] = value; }
        }
        string IDetailInvoiceContract.SessionIdAccount
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

        public VerDetalleFactura()
        {
            _presenter = new DetailInvoicePresenter(this);
        }
        #endregion
        protected void print_Click(object sender, EventArgs e)
        {
            _presenter.PrintInvoice();
            //_presenter.SendInvoice();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null &&
                Session[ResourceLogin.sessionRestaurantID] != null)
                _presenter.GetDetailInvoice();
            else
                Response.Redirect(RecursoMaster.addressLogin);


        }
    }
}