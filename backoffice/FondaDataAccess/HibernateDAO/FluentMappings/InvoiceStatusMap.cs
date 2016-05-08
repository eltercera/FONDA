using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class InvoiceStatusMap: SubclassMap<com.ds201625.fonda.Domain.InvoiceStatus>
    {
        public InvoiceStatusMap()
        {
            DiscriminatorValue(@"InvoiceStatus");
        }
    }
}
