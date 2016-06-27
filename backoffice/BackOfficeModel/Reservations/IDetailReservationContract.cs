using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.Reservations
{
    public interface IDetailReservationContract : IContract
    {
      //  Table DetailReservationTable { get; set; }

        string Session { get; set; }

        string SessionNumberReservation { get; set; }

        Label UserAccount { get; set; }

        Label NumberCommensal { get; set; }

        Label Restaurant { get; set; }

        Label RestaurantTable { get; set; }

        Label CreationDate { get; set; }

        Label ReservationDate { get; set; }

        //Button PrintInvoice { get; set; }

    }
}
