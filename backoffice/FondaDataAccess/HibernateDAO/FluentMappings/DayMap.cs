using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class DayMap : ClassMap<com.ds201625.fonda.Domain.Day>
    {
        public DayMap()
        {
            Table("DAY");

            Id(x => x.Id)
              .Column("day_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("day_name")
              .Unique()
              .Not.Nullable();

        }
    }
}
