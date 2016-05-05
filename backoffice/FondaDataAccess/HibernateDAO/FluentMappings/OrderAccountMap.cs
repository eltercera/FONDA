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
            
            /*References(x => x.Table)
                .Column("fk_table_id")
                .Not.Nullable();*/

            References(x => x.Status)
                .Column("fk_Account_status_id")
                .Not.Nullable()
                .Cascade.Persist();

            References(x => x.RecordStatus)
                .Column("fk_record_status_id")
                .Not.Nullable()
                .Cascade.Persist();
            
        }
    }
}
