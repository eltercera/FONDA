using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class ClosedAccountStatusMap
        : SubclassMap<com.ds201625.fonda.Domain.ClosedAccountStatus>
    {
        public ClosedAccountStatusMap()
        {
            DiscriminatorValue(@"ClosedAccountStatus");
        }
    }
}
