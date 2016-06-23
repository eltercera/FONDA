using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateGeneratedInvoiceStatus :
        HibernateStatusDAO<GeneratedInvoiceStatus>, IGeneratedInvoiceStatusDAO
    {

        public HibernateGeneratedInvoiceStatus () {}

        public GeneratedInvoiceStatus getGeneatedInvoiceStatus()
        {
            GeneratedInvoiceStatus status = FindById(13);
            if (status == null)
            {
                status = GeneratedInvoiceStatus.Instance;
                Save(status);
            }

            return status;
        }
    }
}
