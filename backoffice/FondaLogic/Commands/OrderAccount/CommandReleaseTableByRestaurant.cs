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
    public class CommandReleaseTableByRestaurant : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        private IList<object> _list;
        private IRestaurantDAO _restaurantDAO;
        public CommandReleaseTableByRestaurant(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _list = (IList<object>)Receiver;
                Restaurant _restaurant = new Restaurant();
                int _tableId =0;
                _restaurant = (Restaurant) _list[0];
                _tableId = (int)_list[1];
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                _restaurantDAO.ReleaseTable(_restaurant, _tableId);


            }
            catch (Exception ex)
            {
                CommandExceptionReleaseTableByRestaurant exception = new CommandExceptionReleaseTableByRestaurant(
                    OrderAccountResources.CommandExceptionReleaseTableByRestaurantCode,
                    OrderAccountResources.ClassNameReleaseTableByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionReleaseTableByRestaurant,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;

            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameReleaseTableByRestaurant
                , OrderAccountResources.SuccessMessageCommandReleaseTableByRestaurant
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
