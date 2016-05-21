using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ReservationMap : ClassMap<com.ds201625.fonda.Domain.Reservation>
    {
        public ReservationMap()
        {
            Table("CRESERVATION");

            Id(x => x.Id)
              .Column("res_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.ReserveDate)
              .Column("res_date")
              .Not.Nullable();

            Map(x => x.CreateDate)
              .Column("res_createDate")
              .Not.Nullable();

            Map(x => x.CommensalNumber)
              .Column("res_commensalNumber")
              .Not.Nullable();

            References(x => x.ReserveRestaurant)
              .Column("fk_res_restaurant");
            //.Not.Nullable();

            References(x => x.ReserveTable)
              .Column("fk_res_table");
            //  .Not.Nullable();

            References(x => x.ReserveStatus)
                .Column("fk_res_status")
                .Not.Nullable()
                .Cascade.Persist();

        }
    }
}
