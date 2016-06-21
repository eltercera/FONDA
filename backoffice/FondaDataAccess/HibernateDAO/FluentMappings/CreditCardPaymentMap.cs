using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class CreditCardPaymentMap : SubclassMap<com.ds201625.fonda.Domain.CreditCardPayment>
    {
        public CreditCardPaymentMap()
        {
            DiscriminatorValue(@"CreditCardPayment");

            Map(x => x.LastCardDigits)
                .Column("ccp_last_digits")
                .Nullable();

            Map(x => x.Tip)
            .Column("ccp_tip");

        }
    }
}
