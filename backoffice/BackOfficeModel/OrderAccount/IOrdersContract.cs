using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.OrderAccount
{
    public interface IOrdersContract : IContract
    {
        Table OrdersTable { get; set; }

        string Session { get; set; }

        Button CloseButton { get; set; }

    }
}
