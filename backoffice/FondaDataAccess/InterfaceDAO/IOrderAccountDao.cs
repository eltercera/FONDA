﻿using System;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IOrderAccountDao : IBaseEntityDAO<Account>
    {
        Account FindByCommensal(Commensal commensal);
        IList<Account> FindByRestaurant(Restaurant restaurant);
        IList<Account> GetAll();
        IList<Account> ClosedOrdersByRestaurant(Restaurant restaurant);
    }
}
