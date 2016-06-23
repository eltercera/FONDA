using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
   public class RoleMap : ClassMap<com.ds201625.fonda.Domain.Role>
    {

        public  RoleMap()
        {
        
             Table("ROLE");

             Id(x => x.Id)
                 .Column("rol_id")
                 .Not.Nullable()
                 .GeneratedBy.Increment();

             Map(x => x.Name)
                 .Column("rol_name")
                 .Not.Nullable();

             Map(x => x.Descripcion)
                 .Column("rol_descripcion")
                 .Not.Nullable();


    }
}
}