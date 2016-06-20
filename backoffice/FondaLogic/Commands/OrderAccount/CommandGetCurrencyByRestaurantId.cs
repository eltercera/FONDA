using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.Log;
using System;

namespace FondaLogic.Commands.OrderAccount
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

        public CommandGetCurrencyByRestaurantId(Object receiver) : base(receiver)
        {
            try
            {
                _restaurantId = (int)receiver;
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
                //Por personalizar
                Logger.WriteErrorLog("", ex);
            }
        }
    }
}
