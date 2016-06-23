using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using System;
using System.Web.UI.WebControls;
using com.ds201625.fonda.View.BackOfficeModel;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.Resources.FondaResources.Login;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using BackOffice.Content;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class ListarFacturas : System.Web.UI.Page, IOrderInvoicesContract
    {
        #region Presenter

        private OrderInvoicesPresenter _presenter;
       
        #endregion

        #region Model

        /// <summary>
        /// Label de exito
        /// </summary>
        HtmlGenericControl IContract.SuccessLabel
        {
            get { return this.SuccessLabel; }
        }

        /// <summary>
        /// Label de error
        /// </summary>
        HtmlGenericControl IContract.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        /// <summary>
        /// Mensaje de exito
        /// </summary>
        Label IContract.SuccessLabelMessage
        {
            get { return this.SuccessLabelMessage; }

            set { this.SuccessLabelMessage = value; }
        }

        /// <summary>
        /// Mensaje de error
        /// </summary>
        Label IContract.ErrorLabelMessage
        {
            get { return this.ErrorLabelMessage; }

            set { this.ErrorLabelMessage = value; }

        }

        /// <summary>
        /// Tabla de Facturas
        /// </summary>
        public Table OrderInvoicesTable
        {
            get { return orderInvoices; }

            set { orderInvoices = value; }
        }

        public System.Web.UI.WebControls.Label NumberAccount
        {
            get { return ordernumber; }
            
            set { ordernumber = value; }
        }

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IOrderInvoicesContract.SessionAccountId
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }

        /// <summary>
        /// Variable de sesion del Restaurante
        /// </summary>
        public string SessionRestaurant
        {
            get
            {
                if (Session[OrderAccountResources.SessionRestaurantId] != null)
                    return Session[OrderAccountResources.SessionRestaurantId].ToString();
                else
                    return OrderAccountResources.Empty;
        }

            set { Session[OrderAccountResources.SessionRestaurantId] = value; }
        }

        #endregion

        #region Constructor
        public ListarFacturas()
        {
            _presenter = new OrderInvoicesPresenter(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null &&
                Session[ResourceLogin.sessionRestaurantID] != null)
            _presenter.GetInvoices();
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }
    }
}