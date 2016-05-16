using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateInvoiceDAO : HibernateBaseEntityDAO<Invoice>, IInvoiceDao
    {
        public IList<Invoice> findAllInvoice(Profile profile)
        {
            return null;
        }
    }
}
