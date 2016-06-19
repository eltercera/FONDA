using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BackOfficeModel.Reservations
{
    public interface IReservationsModel : IModel
    {
        Table ReservationsTable { get; set; }

        HtmlGenericControl WarningLabel { get; }

        Label WarningLabelMessage { get; set; }

        string Session { get; set; }
    }
}
