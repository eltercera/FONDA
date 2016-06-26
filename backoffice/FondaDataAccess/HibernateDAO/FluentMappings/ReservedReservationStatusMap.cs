using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class ReservedReservationStatusMap : SubclassMap<com.ds201625.fonda.Domain.ReservedReservationStatus>
    {
        public ReservedReservationStatusMap()
        {
            DiscriminatorValue(@"ReservedReservationStatus");
        }
    }
}
