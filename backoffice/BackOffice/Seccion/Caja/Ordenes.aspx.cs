using System;
using System.Web.UI.WebControls;
using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.Login;
using com.ds201625.fonda.View.BackOfficeModel;
using System.Web.UI.HtmlControls;
using BackOffice.Content;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class Ordenes : System.Web.UI.Page, IOrdersContract
    {
        #region Presenter

        private OrdersPresenter _presenter;

        #endregion

        #region Model

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
        string IOrdersContract.Session
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

        HtmlGenericControl IContract.SuccessLabel
        {
            get { return this.SuccessLabel; }
        }

        HtmlGenericControl IContract.ErrorLabel
        {
            get { return this.ErrorLabel; }
        }

        #endregion

        #region Constructor

        public Ordenes()
        {
                  _presenter = new OrdersPresenter(this);
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