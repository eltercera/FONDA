using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateUsedReservationStatus :
           HibernateStatusDAO<UsedReservationStatus>, IUsedReservationStatusDAO

    {
        public HibernateUsedReservationStatus() { }

        public UsedReservationStatus getUsedReservationStatus()
        {
            UsedReservationStatus status = FindById(9);
            if (status == null)
            {
                status = UsedReservationStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}