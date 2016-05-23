using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface ITableDAO : IBaseEntityDAO<Table>
    {
        IList<Table> GetAll();
        IList<Table> GetTables(int restaurant);
        IList<Table> findByStatus(Status status, int restaurant);
    }
}
