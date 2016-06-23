using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.OrderAccount
{
    public interface IDetailInvoiceContract : IContract
    {
        Table DetailInvoiceTable { get; set; }

        string Session { get; set; }

        string SessionIdAccount { get; set; }

        string SessionNumberInvoice { get; set; }

        Label UserName { get; set; }

        Label UserLastName { get; set; }

        Label UserId { get; set; }

        Label NumberAccount { get; set; }

        Label IvaInvoice { get; set; }

        Label TotalInvoice { get; set; }

        Label DateInvoice { get; set; }
        
        Label SubTotalInvoice { get; set; }
        Label TipInvoice { get; set; }

        Button PrintInvoice { get; set; }

    }
}