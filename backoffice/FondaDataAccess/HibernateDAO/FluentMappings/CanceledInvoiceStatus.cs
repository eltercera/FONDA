using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class CanceledInvoiceStatus: SubclassMap<com.ds201625.fonda.Domain.CanceledInvoiceStatus>
    {
        public CanceledInvoiceStatus()
        {
            DiscriminatorValue(@"CanceledInvoiceStatus");
        }
    }
}
