using BackOfficeModel.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class InvoiceDetailPresenter : BackOfficePresenter.Presenter
    {
        private IInvoiceDetailContract _view;

        public InvoiceDetailPresenter(IInvoiceDetailContract viewInvoiceDetail) : 
            base(viewInvoiceDetail)
        {
            _view = viewInvoiceDetail;
        }
    }
}
