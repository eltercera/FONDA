using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class OrderAccountMap : ClassMap <com.ds201625.fonda.Domain.Account>
    {
        public OrderAccountMap()
        {
            Table("ORDER_ACCOUNT");

            Id(x => x.Id)
                .Column("oa_id")
                .Not.Nullable()
                .GeneratedBy.Increment();

            Map(x => x.Number)
              .Column("oa_number")
              .Not.Nullable();

            Map(x => x.Date)
               .Column("oa_date")
               .Not.Nullable();

            References(x => x.Table)
                .Column("fk_table_id")
                .Not.Nullable();

            HasMany(x => x.ListDish)
                .KeyColumn("fk_order_account")
                .ExtraLazyLoad()
                .Cascade.All();

            HasMany(x => x.Invoices)
                .KeyColumn("fk_account_id")
                .ExtraLazyLoad()
                .Cascade.All();

            References(x => x.Commensal)
                .Column("fk_commensal_id")
                .Not.Nullable();

            References(x => x.Status)
                .Column("fk_Account_status_id")
                .Not.Nullable()
                .Cascade.Persist();


            
        }
    }
}
