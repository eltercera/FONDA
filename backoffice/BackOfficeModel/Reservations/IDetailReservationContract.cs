using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.Reservations
{
    public interface IDetailReservationContract : IContract
    {
        Table DetailReservationTable { get; set; }

        string Session { get; set; }

        string SessionNumberReservation { get; set; }
    }
}
