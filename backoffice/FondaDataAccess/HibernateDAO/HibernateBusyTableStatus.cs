using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateBusyTableStatus :
           HibernateStatusDAO<BusyTableStatus>, IBusyTableStatusDAO

    {
        public HibernateBusyTableStatus() { }

        public BusyTableStatus getBusyTableStatus()
        {
            BusyTableStatus status = FindById(5);
            if (status == null)
            {
                status = BusyTableStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}
