using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandTotalOrder :Command
    {
        int _accountId, _restaurantId;
        float total;
        Account _account;
        Restaurant _restaurant;
        IList<int> _list;
        IRestaurantDAO _restaurantDao;
        IOrderAccountDao _accountDao;
        FactoryDAO _facDAO = FactoryDAO.Intance;
        public CommandTotalOrder(Object receiver) : base(receiver)
        {
            try
            {
                _list = (IList<int>)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        public override void Execute()
        {
            try
            {
                _restaurantDao = _facDAO.GetRestaurantDAO();
                _restaurantId = _list[0];
                _accountId = _list[1];
                _restaurant = _restaurantDao.FindById(_restaurantId);

                foreach (Account a in _restaurant.Accounts)
                {
                    if (a.Id==_accountId)
                    {
                        _account = a;
                    }
                }
                total =_account.GetAmount();
                if (total == 0)
                    throw new NullReferenceException();
                Receiver = total;
            }
            catch (NullReferenceException ex)
            {
                CommandExceptionTotalOrder exception = new CommandExceptionTotalOrder(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameTotalOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                total = 0;
                Receiver = total;
            }

        }
    }
}
