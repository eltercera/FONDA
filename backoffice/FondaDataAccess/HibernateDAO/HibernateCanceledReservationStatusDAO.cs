using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateCanceledReservationStatus :
           HibernateStatusDAO<CanceledReservationStatus>, ICanceledReservationStatusDAO

    {
        public HibernateCanceledReservationStatus() { }

        public CanceledReservationStatus getCanceledReservationStatus()
        {
            CanceledReservationStatus status = FindById(7);
            if (status == null)
            {
                status = CanceledReservationStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}