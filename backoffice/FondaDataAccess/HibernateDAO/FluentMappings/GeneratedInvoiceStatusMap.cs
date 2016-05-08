using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class GeneratedInvoiceStatusMap: SubclassMap<com.ds201625.fonda.Domain.GeneratedInvoiceStatus>
    {
        public GeneratedInvoiceStatusMap()
        {
            DiscriminatorValue(@"GeneratedInvoiceStatus");
        }
    }
}
