using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class InvoiceMap: ClassMap<com.ds201625.fonda.Domain.Invoice>
    {
        public InvoiceMap() {
            Table("INVOICE");

            Id(x => x.Id)
                .Column("i_id")
                .Not.Nullable()
                .GeneratedBy.Increment();

            Map(x => x.Tip)
                .Column("i_tip")
                .Not.Nullable();

            Map(x => x.Date)
               .Column("i_date")
               .Not.Nullable();

            Map(x => x.Total)
               .Column("i_total")
               .Not.Nullable();

            Map(x => x.Tax)
               .Column("i_tax")
               .Not.Nullable();

            References(x => x.Status)
               .Column("fk_status_id")
               .Not.Nullable()
               .Cascade.Persist();

           /* References(x => x.RecordStatus)
                .Column("fk_inv_status_id")
                .Not.Nullable()
                .Cascade.Persist();*/

            /* References(x => x.Currency)
                 .Column("fk_currency_id")
                 .Not.Nullable(); */

             References(x => x.Account)
                .Column("fk_account_id")
                .Not.LazyLoad()
                .Not.Nullable(); 

             References(x => x.Payment)
                .Column("fk_payment_id")
                .Not.Nullable();

            References(x => x.Profile)
                .Column("fk_profile_id")
                .Not.Nullable();

            References(x => x.Restaurant)
                .Column("fk_restaurant_id")
                .Not.LazyLoad()
                .Not.Nullable(); 
                

            

            
        }
    }
}
