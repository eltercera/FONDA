using FluentNHibernate.Mapping;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class TableStatusMap : SubclassMap<com.ds201625.fonda.Domain.TableStatus>
    {
        public TableStatusMap()
        {
            DiscriminatorValue(@"TableStatus");
        }
    }
}
