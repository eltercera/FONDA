using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOfficeModel.OrderAccount
{
    public interface IOrderInvoicesModel : IModel
    {
        Table OrderInvoicesTable { get; set; }

        string SessionAccountId { get; set; }

        Label NumberAccount { get; set; }
    }
}
