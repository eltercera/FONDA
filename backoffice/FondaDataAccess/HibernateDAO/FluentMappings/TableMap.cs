using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class TableMap: ClassMap<com.ds201625.fonda.Domain.Table>
    {
        public TableMap()
        {
            Table("CTABLE");

            Id(x => x.Id)
            .Column("tab_id")
            .Not.Nullable()
            .GeneratedBy.Increment();

            Map(x => x.Capacity)
              .Column("tab_capacity")
              .Not.Nullable();

            Map(x => x.Number)
              .Column("tab_number")
              .Not.Nullable();

            References(x => x.Status)
                .Column("fk_tab_status")
                .Not.Nullable()
                .Cascade.Persist();


            #region Reservation

            HasManyToMany(x => x.Reservations)
               .Cascade.All()
               .ExtraLazyLoad()
               .Table("RESERVATION_TABLE");

            #endregion

        }
    }
}
