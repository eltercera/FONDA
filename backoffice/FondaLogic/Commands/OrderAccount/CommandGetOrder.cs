using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetOrder : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int orderId;

        public CommandGetOrder(Object receiver) : base(receiver) { }

        /// <summary>
        /// Metodo que ejecuta el comando para consultar una orden
        /// </summary>
        public override void Execute()
        {
            try
            {
                orderId = (int)Receiver;
                //Metodos para acceder a la BD
                //ESTO HAY QUE CAMBIARLO
                //DEBERIA BUSCAR UNA ORDEN POR SU NUMERO Y SU RESTAURANTE
                IOrderAccountDao _orderDAO = _facDAO.GetOrderAccountDAO();


                Receiver = _orderDAO.FindById(orderId);

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetOrder exceptionGetOrder = new CommandExceptionGetOrder(
                    OrderAccountResources.CommandExceptionGetOrderCode,
                    OrderAccountResources.ClassNameGetOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetOrder,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrder);

                throw exceptionGetOrder;
            }
            catch (Exception ex)
            {
                CommandExceptionGetOrder exceptionGetOrder = new CommandExceptionGetOrder(
                    OrderAccountResources.CommandExceptionGetOrderCode,
                    OrderAccountResources.ClassNameGetOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetOrder,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrder);

                throw exceptionGetOrder;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetOrder
                , OrderAccountResources.SuccessMessageCommandGetOrder
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }

    }
}
