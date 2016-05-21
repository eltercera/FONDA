using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateDisableSimpleStatus :
        HibernateStatusDAO<DisableSimpleStatus>, IDisableSimpleStatusDAO
    {
        public HibernateDisableSimpleStatus() { }

        public DisableSimpleStatus getDisableSimpleStatus()
        {
            DisableSimpleStatus status = FindById(2);
            if (status == null)
            {
                status = DisableSimpleStatus.Instance;
                Save(status);
            }

            return status;
        }

    }
}
