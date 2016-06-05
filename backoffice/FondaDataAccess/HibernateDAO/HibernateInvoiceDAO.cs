using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    class HibernateInvoiceDAO: HibernateBaseEntityDAO<Invoice>, IInvoiceDao
    {
    }
}
