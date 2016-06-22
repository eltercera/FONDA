using BackOfficeModel.OrderAccount;
using System;
using System.Web.UI.WebControls;
using BackOfficeModel;
using System.Web.UI.HtmlControls;
using FondaResources.Login;
using FondaResources.OrderAccount;
using BackOffice.Content;

namespace BackOffice.Seccion.Caja
{
    public partial class ListarFacturas : System.Web.UI.Page, IOrderInvoicesModel
    {
        #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrderInvoicesPresenter _presenter;

        #endregion

        #region Model

        /// <summary>
        /// Label de exito
        /// </summary>
        HtmlGenericControl IModel.SuccessLabel
        {
            get { return this.SuccessLabel; }
        }

        /// <summary>
        /// Label de error
        /// </summary>
        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        /// <summary>
        /// Mensaje de exito
        /// </summary>
        Label IModel.SuccessLabelMessage
        {
            get { return this.SuccessLabelMessage; }

            set { this.SuccessLabelMessage = value; }
        }

        /// <summary>
        /// Mensaje de error
        /// </summary>
        Label IModel.ErrorLabelMessage
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

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IOrderInvoicesModel.SessionAccountId
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
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrderInvoicesPresenter(this);
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