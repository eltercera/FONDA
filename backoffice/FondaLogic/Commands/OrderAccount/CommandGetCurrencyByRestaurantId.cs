using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    /// <summary>
    /// Comando que devuelve un objeto Currency dado el id
    /// de un restaurante
    /// </summary>
    public class CommandGetCurrencyByRestaurantId : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId = 0;
        private string _symbol = null;

        public CommandGetCurrencyByRestaurantId(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _restaurantId = (int)Receiver;

                //Defino el DAO
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                //Obtengo el objeto con la informacion enviada
                Restaurant _restaurant = _restaurantDAO.FindById(_restaurantId);
                _symbol = _restaurant.Currency.Symbol;

                Receiver = _symbol;
            }
            catch (Exception ex)
            {
                CommandExceptionGetCurrencyByRestaurant exceptionGetOrders = new CommandExceptionGetCurrencyByRestaurant(
                    OrderAccountResources.CommandExceptionGetCurrencyByRestaurantCode,
                    OrderAccountResources.ClassNameGetCurrencyByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetCurrencyByRestaurant,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrders);

                Receiver = string.Empty;

                throw exceptionGetOrders;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetCurrencyByRestaurant
                , OrderAccountResources.SuccessMessageCommandGetCurrencyByRestaurant
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
