using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetDishOrdersByAccountId : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _orderAccount = 0;

        public CommandGetDishOrdersByAccountId(Object receiver) : base(receiver) { }
        public override void Execute()
        {
            try
            {
                _orderAccount = (int)Receiver;
                //Defino el DAO
                IDishOrderDAO _dishOrderDAO;
                //Obtengo la instancia del DAO a utilizar
                _dishOrderDAO = _facDAO.GetDishOrderDAO();
                //Obtengo el objeto con la informacion enviada
                IList<DishOrder> listDetailOrder = _dishOrderDAO.GetDishesByAccount(_orderAccount);
                Receiver = listDetailOrder;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetDishOrdersByAccount exception = new CommandExceptionGetDishOrdersByAccount(
                    OrderAccountResources.CommandExceptionGetDishOrdersByAccountCode,
                    OrderAccountResources.ClassNameGetDishOrdersByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetDishOrdersByAccount,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                IList<DishOrder>  listDetailOrder = new List<DishOrder>();
                Receiver = listDetailOrder;

                throw exception;

            }
            catch (Exception ex)
            {
                CommandExceptionGetDishOrdersByAccount exception = new CommandExceptionGetDishOrdersByAccount(
                    OrderAccountResources.CommandExceptionGetDishOrdersByAccountCode,
                    OrderAccountResources.ClassNameGetDishOrdersByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetDishOrdersByAccount,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                IList<DishOrder> listDetailOrder = new List<DishOrder>();
                Receiver = listDetailOrder;

                throw exception;

            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetDishOrdersByAccount
                , OrderAccountResources.SuccessMessageCommandGetDishOrdersByAccount
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }

}
