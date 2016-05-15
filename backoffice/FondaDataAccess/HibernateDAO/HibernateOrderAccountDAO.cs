using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateOrderAccountDAO : HibernateBaseEntityDAO<Account>, IOrderAccountDao
    {
        public Account FindByCommensal(Commensal commensal)
        {
            return FindBy("Commensal", commensal);
        }
    }
}
