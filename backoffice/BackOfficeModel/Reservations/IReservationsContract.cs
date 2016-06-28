using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.Reservations
{
    public interface IReservationsContract : IContract
    {
        Table ReservationsTable { get; set; }

        HtmlGenericControl WarningLabel { get; }

        Label WarningLabelMessage { get; set; }

        string Session { get; set; }
    }
}
