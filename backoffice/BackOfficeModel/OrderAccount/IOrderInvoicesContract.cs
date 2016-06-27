using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.OrderAccount
{
    public interface IOrderInvoicesContract : IContract
    {
        Table OrderInvoicesTable { get; set; }

        string SessionAccountId { get; set; }

        Label NumberAccount { get; set; }
    }
}
