using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class PaymentMap: ClassMap<com.ds201625.fonda.Domain.Payment>
    {
        public PaymentMap() {
            Table("PAYMENT");

            Id(x => x.Id)
                .Column("p_id")
                .Not.Nullable()
                .GeneratedBy.Increment();

            DiscriminateSubClassesOnColumn("p_type")
                .Not.Nullable();

            Map(x => x.Amount)
                .Column("p_amount")
                .Not.Nullable();

        }

    }
}
