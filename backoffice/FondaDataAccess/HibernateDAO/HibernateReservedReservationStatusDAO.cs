using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateReservedReservationStatus :
           HibernateStatusDAO<ReservedReservationStatus>, IReservedReservationStatusDAO

    {
        public HibernateReservedReservationStatus() { }

        public ReservedReservationStatus getReservedReservationStatus()
        {
            ReservedReservationStatus status = FindById(8);
            if (status == null)
            {
                status = ReservedReservationStatus.Instance;
                Save(status);
            }

            return status;
        }

    }
}