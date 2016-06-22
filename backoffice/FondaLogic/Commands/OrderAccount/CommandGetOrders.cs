using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;


namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetOrders : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId;

        public CommandGetOrders(Object receiver) : base(receiver) { }

        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        public override void Execute()
        {
            IList<Account> listAccounts;

            try
            {
                _restaurantId = (int)Receiver;
                //Defino el DAO
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _restaurantDAO = _facDAO.GetRestaurantDAO();

                listAccounts = _restaurantDAO.OpenOrdersByRestaurantId(_restaurantId);

                Receiver = listAccounts;
            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetOrders exceptionGetOrders = new CommandExceptionGetOrders(
                    OrderAccountResources.CommandExceptionGetOrdersCode,
                    OrderAccountResources.ClassNameGetOrders,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetOrders,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,exceptionGetOrders);

                listAccounts = new List<Account>();
                Receiver = listAccounts;
                throw exceptionGetOrders;
            }
            catch (Exception ex)
            {
                CommandExceptionGetOrders exceptionGetOrders = new CommandExceptionGetOrders(
                    OrderAccountResources.CommandExceptionGetOrdersCode,
                    OrderAccountResources.ClassNameGetOrders,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetOrders,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrders);

                listAccounts = new List<Account>();
                Receiver = listAccounts;
                throw exceptionGetOrders;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetOrders
                , OrderAccountResources.SuccessMessageCommandGetOrders
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }

    }
}
