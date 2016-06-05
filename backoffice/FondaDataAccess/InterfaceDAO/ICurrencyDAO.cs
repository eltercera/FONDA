using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface ICurrencyDAO : INounBaseEntityDAO<Currency>
    {
        IList<Currency> GetAll();
    }
}
