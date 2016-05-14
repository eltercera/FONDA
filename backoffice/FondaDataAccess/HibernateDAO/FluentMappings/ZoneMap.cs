using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ZoneMap : ClassMap<com.ds201625.fonda.Domain.Zone>
    {
        public ZoneMap()
        {
            Table("ZONE");

            Id(x => x.Id)
              .Column("zon_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("zon_name")
              .Not.Nullable();

        }
    }
}
