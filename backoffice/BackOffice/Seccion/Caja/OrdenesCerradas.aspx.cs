﻿using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using BackOffice.Seccion.Restaurant;
using BackOfficePresenter.OrderAccount;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficeModel;

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
            get { return _closedOrders; }

            set { _closedOrders = value; }
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
            get { return Session[ResourceLogin.sessionRestaurantID].ToString(); }

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

        public OrdenesCerradas()
        {
            _presenter = new ClosedOrdersPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RestaurantID"] != null)
            {   //Llama al presentador para llenar la tabla de ordenes
                _presenter.GetClosedOrders(Session[RestaurantResource.SessionRestaurant].ToString());
            }
        }


    }
}