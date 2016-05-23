using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IDayDAO : INounBaseEntityDAO<Day>
    {
        IList<Day> GetDay(bool[] days);

    }
}
