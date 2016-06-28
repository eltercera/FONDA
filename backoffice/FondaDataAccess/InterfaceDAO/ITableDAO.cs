using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using System;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface ITableDAO : IBaseEntityDAO<Table>
    {
        IList<Table> GetAll();
        IList<Table> GetTables(int restaurant);
        IList<Table> GetAvailableTables(IList<Table> listTables);
        //IList<Table> findByStatus(Status status, int restaurant);
        IList<Table> TablesAvailableByDate(int restaurantIdI, IList<Reserve> listReservation, DateTime date);
        IList<Table> TablesAvailableByCapacity(IList<Table> listTable, int commensalNumber);
        Table GetTableByReservation(int resrevationId);
    }
}
