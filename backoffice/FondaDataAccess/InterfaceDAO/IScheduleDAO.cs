using com.ds201625.fonda.Domain;
using System;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IScheduleDAO : IBaseEntityDAO<Schedule>
    {
        Schedule GetSchedule(TimeSpan OpeningTime, TimeSpan ClosingTime, bool[] Days);
    }
}
