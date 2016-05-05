using System;
using FluentNHibernate.Mapping;


namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class AccountStatusMap : SubclassMap<com.ds201625.fonda.Domain.AccountStatus>
    {
        public AccountStatusMap()
        {
            DiscriminatorValue(@"AccountStatus");
        }
    }
}
