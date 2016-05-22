using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateActiveReservationStatus :
           HibernateStatusDAO<ActiveReservationStatus>, IActiveReservationStatusDAO

    {
        public HibernateActiveReservationStatus() { }

        public ActiveReservationStatus getActiveReservationStatus()
        {
            ActiveReservationStatus status = FindById(7);
            if (status == null)
            {
                status = ActiveReservationStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}