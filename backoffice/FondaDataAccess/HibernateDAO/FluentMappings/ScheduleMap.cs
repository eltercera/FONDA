﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class ScheduleMap : ClassMap<com.ds201625.fonda.Domain.Schedule>
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

            HasMany(x => x.Day.Id)
                .KeyColumn("fk_day")
                .Inverse()
                .Cascade.Persist();

        }
    }
}