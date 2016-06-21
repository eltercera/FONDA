using BackOfficeModel.OrderAccount;
using System;
using System.Web.UI.WebControls;
using BackOfficeModel;
using System.Web.UI.HtmlControls;
using FondaResources.Login;
using FondaResources.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class ListarFacturas : System.Web.UI.Page, IOrderInvoicesModel
    {
        #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrderInvoicesPresenter _presenter;

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

        public System.Web.UI.WebControls.Table OrdersTable
        {
            get { return orderInvoices; }

            set { orderInvoices = value; }
        }

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IOrderInvoicesModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }
        string IOrderInvoicesModel.SessionIdInvoice
        {
            get { return Session[OrderAccountResources.SessionIdInvoice].ToString(); }

            set { Session[OrderAccountResources.SessionIdInvoice] = value; }
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

        public Table OrderInvoicesTable
        {
            get { return orderInvoices; }

            set { orderInvoices = value; }
        }

        #endregion

        #region Constructor
        public ListarFacturas()
        {
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrderInvoicesPresenter(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.GetInvoices();
        }
    }
}