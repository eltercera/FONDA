using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOfficeModel.OrderAccount
{
    public interface IInvoiceDetailModel : IModel
    {
        Table DetailInvoiceTable { get; set; }

        string Session { get; set; }

        string SessionNumberAccount { get; set; }

        string SessionIdInvoice { get; set; }

        string SessionNumberInvoice { get; set; }

        Label UserName { get; set; }

        Label UserLastName { get; set; }

        Label UserId { get; set; }

        Label IvaInvoice { get; set; }

        Label TotalInvoice { get; set; }

        Label DateInvoice { get; set; }
        
        LinkButton PrintInvoice { get; set; }
    }
}