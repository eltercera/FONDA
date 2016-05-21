using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateFreeTableStatus :
                HibernateStatusDAO<FreeTableStatus>, IFreeTableStatusDAO
    {
        public HibernateFreeTableStatus() { }

        public FreeTableStatus getFreeTableStatus()
        {
            FreeTableStatus status = FindById(6);
            if (status == null)
            {
                status = FreeTableStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}
