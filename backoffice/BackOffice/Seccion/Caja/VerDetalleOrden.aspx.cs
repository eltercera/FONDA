using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using FondaResources.OrderAccount;
using BackOfficePresenter.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleOrden : System.Web.UI.Page, IDetailOrderModel
    {
        #region Presenter

        private DetailOrderPresenter _presenter;

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

        public System.Web.UI.WebControls.Table DetailOrderTable
        {
            get { return Pago; }

            set { Pago = value; }
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
        /// Recurso de Session con el que inicia el Page_Load
        /// </summary>
        string IDetailOrderModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }

        #endregion

        #region Constructor

        public VerDetalleOrden()
        {
            _presenter = new DetailOrderPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountID"] != null)
            {   //Llama al presentador para llenar la tabla de ordenes
                _presenter.GetDetailOrder();
            }
        }



    }

}