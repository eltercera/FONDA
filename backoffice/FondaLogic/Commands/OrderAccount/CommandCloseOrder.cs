using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandCloseOrder : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandCloseOrder(Object receiver) : base(receiver)
        {
        }

        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        /// <param name="param">Id del Restaurante</param>
        /// <returns>Lista de Ordenes</returns>
        public override void Execute()
        {
            try
            {
                //Defino el DAO
                IOrderAccountDao _orderDAO;
                //Obtengo la instancia del DAO a utilizar
                _orderDAO = _facDAO.GetOrderAccountDAO();
                //Obtengo el objeto con la informacion enviada

                Restaurant res = (Restaurant)Receiver;

                IList<Account> listClosedOrders = _orderDAO.ClosedOrdersByRestaurant(res);
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                //TODO: Escribir en el Log la excepcion
                throw;
            }
        }

    }
}
