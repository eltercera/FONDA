using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.Session
{
    public class HibernateCanceledInvoiceStatus :
            HibernateStatusDAO<CanceledInvoiceStatus>, ICanceledInvoiceStatusDAO
    {

        public HibernateCanceledInvoiceStatus() { }

        public CanceledInvoiceStatus getCanceledInvoiceStatus()
        {
            CanceledInvoiceStatus status = FindById(14);
            if (status == null)
            {
                status = CanceledInvoiceStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}
