using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOfficeModel;
using BackOfficeModel.OrderAccount;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class OrderInvoicesPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IOrderInvoicesModel _view;

        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewOrderInvoices">Interfaz</param>
        public OrderInvoicesPresenter(IOrderInvoicesModel viewOrderInvoices) 
            : base(viewOrderInvoices)
        {
            //Enlace Modelo - Vista
            _view = viewOrderInvoices;
        }
    }
}
