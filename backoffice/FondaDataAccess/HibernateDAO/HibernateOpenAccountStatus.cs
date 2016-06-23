using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateOpenAccountStatus :
        HibernateStatusDAO<OpenAccountStatus>, IOpenAccountStatusDAO
    {
        public HibernateOpenAccountStatus() { }

        public OpenAccountStatus getOpenAccountStatus()
        {
            OpenAccountStatus status = FindById(11);
            if (status == null)
            {
                status = OpenAccountStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}
