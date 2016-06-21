using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;


namespace FondaLogic.Commands.OrderAccount
{
    public class CommandClosedOrders : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId;
        IList<Account> listClosedOrders;

        public CommandClosedOrders(Object receiver) : base(receiver)
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




        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        public override void Execute()
        {
            try
            {
                //Defino el DAO
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                //Obtengo el objeto con la informacion enviada
                IList<Account> listClosedOrders = _restaurantDAO.ClosedOrdersByRestaurantId(_restaurantId);
                Receiver = listClosedOrders;

        }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetClosedOrders exception = new CommandExceptionGetClosedOrders(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameGetCloseOrders,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                listClosedOrders = new List<Account>();
                Receiver = listClosedOrders;
                //throw exceptionGetOrders;
            }
        }

    }
}
