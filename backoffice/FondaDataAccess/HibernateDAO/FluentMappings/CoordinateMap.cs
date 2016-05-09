using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class CoordinateMap : ClassMap<com.ds201625.fonda.Domain.Coordinate>
    {
        public CoordinateMap()
        {
            Table("COORDINATE");

            Id(x => x.Id)
              .Column("coo_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Latitude)
              .Column("coo_latitud")
              .Not.Nullable();

            Map(x => x.Longitude)
              .Column("coo_longitud")
              .Not.Nullable();
        }
    }
}
