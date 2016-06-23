using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateCanceledReservationStatus :
           HibernateStatusDAO<CanceledReservationStatus>, ICanceledReservationStatusDAO

    {
        public HibernateCanceledReservationStatus() { }

        public CanceledReservationStatus getCanceledReservationStatus()
        {
            CanceledReservationStatus status = FindById(8);
            if (status == null)
            {
                status = CanceledReservationStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}