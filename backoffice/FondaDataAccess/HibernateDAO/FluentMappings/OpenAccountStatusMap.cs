using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class OpenAccountStatusMap
        : SubclassMap<com.ds201625.fonda.Domain.OpenAccountStatus>
    {
        public OpenAccountStatusMap()
        {
            DiscriminatorValue(@"OpenAccountStatus");
        }
    }
}
