using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;


namespace FondaLogic.Commands.OrderAccount
{
    public class CommandClosedOrders : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId;
        private IList<Account> listClosedOrders;

        public CommandClosedOrders(Object receiver) : base(receiver) { }




        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
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
                IList<Account> listClosedOrders = _restaurantDAO.ClosedOrdersByRestaurantId(_restaurantId);
                Receiver = listClosedOrders;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetClosedOrders exception = new CommandExceptionGetClosedOrders(
                    OrderAccountResources.CommandExceptionGetClosedOrdersCode,
                    OrderAccountResources.ClassNameGetCloseOrders,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetClosedOrders,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                listClosedOrders = new List<Account>();
                Receiver = listClosedOrders;
                throw exception;
            }
            catch (Exception ex)
            {
                CommandExceptionGetClosedOrders exception = new CommandExceptionGetClosedOrders(
                    OrderAccountResources.CommandExceptionGetClosedOrdersCode,
                    OrderAccountResources.ClassNameGetCloseOrders,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetClosedOrders,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                listClosedOrders = new List<Account>();
                Receiver = listClosedOrders;
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameValidateProfileByCommensal
                , OrderAccountResources.SuccessMessageCommandGetClosedOrders
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }

    }
}
