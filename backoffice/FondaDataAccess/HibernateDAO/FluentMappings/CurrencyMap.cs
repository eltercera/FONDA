using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class CurrencyMap : ClassMap<com.ds201625.fonda.Domain.Currency>
    {
        public CurrencyMap()
        {
            Table("CURRENCY");

            Id(x => x.Id)
              .Column("cu_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("cur_name")
              .Not.Nullable();

            Map(x => x.Symbol)
                .Column("cur_symbol")
                .Not.Nullable();
        }

    }
}
