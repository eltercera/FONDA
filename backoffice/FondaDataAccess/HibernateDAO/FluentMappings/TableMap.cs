using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class TableMap: ClassMap<com.ds201625.fonda.Domain.Table>
    {
        public TableMap()
        {
            Table("CTABLE");

            CompositeId()
            .KeyReference(x => x.Restaurant,"tab_res")
            .KeyProperty(x => x.Id, "tab_id");

            Map(x => x.Capacity)
              .Column("tab_capacity")
              .Not.Nullable();

            References(x => x.Status)
                .Column("fk_tab_status")
                .Not.Nullable()
                .Cascade.Persist();

        }
    }
}
