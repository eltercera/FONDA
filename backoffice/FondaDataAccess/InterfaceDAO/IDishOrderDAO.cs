using System;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IDishOrderDAO : IBaseEntityDAO<DishOrder>
    {
        IList<DishOrder> GetAll();
        IList<DishOrder> GetDishesByAccount(int _accountId);
    }
}
