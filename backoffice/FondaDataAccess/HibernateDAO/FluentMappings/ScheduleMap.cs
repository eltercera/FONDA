using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ScheduleMap : ClassMap<com.ds201625.fonda.Domain.Schedule>
    {
        public ScheduleMap()
        {
            Table("SCHEDULE");

            Id(x => x.Id)
              .Column("sch_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.OpeningTime)
              .Column("sch_openingTime")
              .Not.Nullable();

            Map(x => x.ClosingTime)
              .Column("sch_closingTime")
              .Not.Nullable();

            HasManyToMany(x => x.Day)
                
                .Cascade.All();

        }
    }
}
