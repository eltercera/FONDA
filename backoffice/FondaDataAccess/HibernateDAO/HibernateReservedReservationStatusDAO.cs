using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateReservedReservationStatus :
           HibernateStatusDAO<ReservedReservationStatus>, IReservedReservationStatusDAO

    {
        public HibernateReservedReservationStatus() { }

        public ReservedReservationStatus getReservedReservationStatus()
        {
            ReservedReservationStatus status = FindById(7);
            if (status == null)
            {
                status = ReservedReservationStatus.Instance;
                Save(status);
            }

            return status;
        }

    }
}