using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ReservationMap : ClassMap<com.ds201625.fonda.Domain.Reservation>
    {
        public ReservationMap()
        {
            Table("RESERVATION");

            Id(x => x.Id)
              .Column("res_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Number)
              .Column("res_date")
              .Not.Nullable();

            Map(x => x.ReservationDate)
              .Column("res_date")
              .Not.Nullable();

            Map(x => x.CreationDate)
              .Column("res_createDate")
              .Not.Nullable();

            Map(x => x.CommensalNumber)
              .Column("res_commensalNumber")
              .Not.Nullable();

            References(x => x.Status)
                .Column("fk_res_status")
                .Not.Nullable()
                .Cascade.Persist();

        }
    }
}
