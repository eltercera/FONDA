using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateClosedAccountStatus :
        HibernateStatusDAO<ClosedAccountStatus>, IClosedAccountStatusDAO
    {
        public HibernateClosedAccountStatus() { }

        public ClosedAccountStatus getClosedAccountStatus()
        {
            ClosedAccountStatus status = FindById(12);
            if (status == null)
            {
                status = ClosedAccountStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}
