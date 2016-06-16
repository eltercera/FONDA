using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Web.Services;
using System.Web.Script.Serialization;
using BackOfficeModel.OrderAccount;
using BackOffice.Seccion.Restaurant;
using System.Web.SessionState;
using FondaResources.OrderAccount;
using FondaResources.Login;
using BackOfficeModel;
using System.Web.UI.HtmlControls;

namespace BackOffice.Seccion.Caja
{
    public partial class Default : System.Web.UI.Page, IOrdersModel
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

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IOrdersModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
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

        public Default()
        {
                  _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.OrdersPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //Llama al presentador para llenar la tabla de ordenes
            _presenter.GetOrders();
        }

        
    }
}