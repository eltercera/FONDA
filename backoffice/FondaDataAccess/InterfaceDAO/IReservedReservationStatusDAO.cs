using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IReservedReservationStatusDAO : IStatusDAO<ReservedReservationStatus>
    {
        ReservedReservationStatus getReservedReservationStatus();

    }
}