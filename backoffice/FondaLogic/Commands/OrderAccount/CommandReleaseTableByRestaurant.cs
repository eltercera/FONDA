using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandReleaseTableByRestaurant : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        private IList<object> _list;
        private IRestaurantDAO _restaurantDAO;
        public CommandReleaseTableByRestaurant(Object receiver) : base(receiver) {
            try
            {
                _list = (IList<object>)receiver;
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
                Restaurant _restaurant = new Restaurant();
                int _tableId =0;
                _restaurant = (Restaurant) _list[0];
                _tableId = (int)_list[1];
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                _restaurantDAO.ReleaseTable(_restaurant, _tableId);


            }
            catch (Exception ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionReleaseTableByRestaurant exception = new CommandExceptionReleaseTableByRestaurant(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameReleaseTableByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);


            }
        }
    }
}
