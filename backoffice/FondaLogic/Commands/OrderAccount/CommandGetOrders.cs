using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetOrders : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        int restaurantId;

        public CommandGetOrders(Object receiver) : base(receiver)
        {
            try
            {
                restaurantId = (int) receiver;
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
                IOrderAccountDao _orderDAO;
                //Obtengo la instancia del DAO a utilizar
                _orderDAO = _facDAO.GetOrderAccountDAO();

                IList<Account> listAccounts = _orderDAO.FindByRestaurant(restaurantId);

                Receiver = listAccounts;
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
