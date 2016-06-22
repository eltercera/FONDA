using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandTotalOrder :Command
    {
        private int _accountId, _restaurantId;
        private float total;
        private Account _account;
        private Restaurant _restaurant;
        private IList<int> _list;
        private IRestaurantDAO _restaurantDao;
        private IOrderAccountDao _accountDao;
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandTotalOrder(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _list = (IList<int>)Receiver;
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
                total = total + (total*0.12f);
                if (total == 0)
                    throw new NullReferenceException();
                Receiver = total;
            }
            catch (NullReferenceException ex)
            {
                CommandExceptionTotalOrder exception = new CommandExceptionTotalOrder(
                    OrderAccountResources.CommandExceptionTotalOrderCode,
                    OrderAccountResources.ClassNameTotalOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionTotalOrder,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                total = 0;
                Receiver = total;
                throw exception;
            }
            catch (Exception ex)
            {
                CommandExceptionTotalOrder exception = new CommandExceptionTotalOrder(
                    OrderAccountResources.CommandExceptionTotalOrderCode,
                    OrderAccountResources.ClassNameTotalOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionTotalOrder,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                total = 0;
                Receiver = total;
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameTotalOrder
                , OrderAccountResources.SuccessMessageCommandTotalOrder
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }
    }
}
