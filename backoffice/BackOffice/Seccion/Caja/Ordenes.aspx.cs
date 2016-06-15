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

namespace BackOffice.Seccion.Caja
{
    public partial class Default : System.Web.UI.Page, IOrdersModel
    {
        #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.DefaultPresenter _presenter;

        #endregion

        #region Model

        public Label ErrorLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Web.UI.WebControls.Table OrdersTable
        {
            get { return _orderList; }

            set { _orderList = value; }
        }

        public Label SuccessLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IOrdersModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }

        #endregion

        #region Constructor

        public Default()
        {
                  _presenter = new com.ds201625.fonda.BackOffice.Presenter.DefaultPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //Llama al presentador para llenar la tabla de ordenes
            _presenter.GetOrders(Session[RestaurantResource.SessionRestaurant].ToString());
        }


    }
}