using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class CashPaymentMap: SubclassMap<com.ds201625.fonda.Domain.CashPayment>
    {
        public CashPaymentMap()
        {
            DiscriminatorValue(@"CashPayment");


        }
    }
}
