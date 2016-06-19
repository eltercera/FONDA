using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOfficeModel.OrderAccount
{
    public interface IClosedOrdersModel: IModel
    {
        Table ClosedOrdersTable { get; set; }

        string Session { get; set; }

    }
}
