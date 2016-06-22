using System;
using System.Web.UI.WebControls;
using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficeModel;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using BackOffice.Content;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class OrdenesCerradas : System.Web.UI.Page, IClosedOrdersModel
    {
        #region Presenter

        private ClosedOrdersPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Table ClosedOrdersTable
        {
            get { return closedOrders; }

            set { closedOrders = value; }
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

        public string SessionRestaurant
        {
            get { return Session[OrderAccountResources.SessionRestaurantId].ToString(); }

            set { Session[OrderAccountResources.SessionRestaurantId] = value; }
        }

        public string SessionNumberAccount
        {
            get { return Session[OrderAccountResources.SessionNumberAccount].ToString(); }

            set { Session[OrderAccountResources.SessionNumberAccount] = value; }
        }

        HtmlGenericControl IModel.SuccessLabel
        {
            get { return this.SuccessLabel; }

        }

        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel; }

        }

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IClosedOrdersModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }

        #endregion

        #region Constructor

        public OrdenesCerradas()
        {
            _presenter = new ClosedOrdersPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //Llama al presentador para llenar la tabla de ordenes
            if (Session[ResourceLogin.sessionUserID] != null &&
                Session[OrderAccountResources.SessionRestaurantId] != null)
                _presenter.GetClosedOrders();
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }



    }
}