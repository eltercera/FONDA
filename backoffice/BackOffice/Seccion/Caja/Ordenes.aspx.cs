using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.Login;
using BackOfficeModel;
using System.Web.UI.HtmlControls;
using BackOffice.Content;

namespace BackOffice.Seccion.Caja
{
    public partial class Ordenes : System.Web.UI.Page, IOrdersModel
    {
        #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrdersPresenter _presenter;

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
            get { return orderList; }

            set { orderList = value; }
        }

        public Button CloseButton
        {
            get { return closeCR; }
            
            set { closeCR = value; }
        }

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IOrdersModel.Session
        {
            get
            {
                return Session[OrderAccountResources.SessionIdAccount].ToString();
            }

            set
            {
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

        HtmlGenericControl IModel.SuccessLabel
        {
            get { return this.SuccessLabel; }
        }

        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        #endregion

        #region Constructor

        public Ordenes()
        {
                  _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrdersPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //Llama al presentador para llenar la tabla de ordenes
            if (Session[ResourceLogin.sessionUserID] != null &&
                Session[ResourceLogin.sessionRestaurantID] != null)
                _presenter.GetOrders();
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }

        protected void CloseCashRegister_Click(object sender, EventArgs e)
        {
            _presenter.Close();
        }
    }
}