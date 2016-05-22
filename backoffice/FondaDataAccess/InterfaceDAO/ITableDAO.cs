using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using System;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface ITableDAO : IBaseEntityDAO<Table>
    {
        IList<Table> GetAll();
        IList<Table> GetTables(int restaurant);
        IList<Table> TablesAvailableByDate(IList<Reservation> listReservation, DateTime date);
        IList<Table> TablesAvailableByCapacity(IList<Table> listTable, int commensalNumber);
    }
}
