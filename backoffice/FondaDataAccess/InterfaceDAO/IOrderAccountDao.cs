using System;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IOrderAccountDao : IBaseEntityDAO<Account>
    {
      //  Account FindByCommensal(Commensal commensal);
      //  IList<Account> FindByRestaurant(Restaurant restaurant);
        IList<Account> GetAll();
        int GenerateNumberAccount(Restaurant _restaurant);
        IList<Account> FindAccountByRestaurant(int _idRestaurant);
        float CloseCashRegister(int restaurantId);
        Invoice SaveInvoice(Invoice _invoice, int _accountId, int _restaurantId);
        void ChangeStatusAccount(Account _account);
        Invoice CancelInvoice(Invoice _invoice, int _accountId);
    }
}
