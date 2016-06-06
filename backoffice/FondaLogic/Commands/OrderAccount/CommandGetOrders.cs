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
    public class CommandGetOrders : Command<int, IList<Entity>>
    {
        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        /// <param name="param">Id del Restaurante</param>
        /// <returns>Lista de Ordenes</returns>
        public override IList<Entity> Execute(int restaurantId)
        {
            try
            {
                //Metodos para acceder a la BD
                FactoryDAO _facDAO = FactoryDAO.Intance;
                IOrderAccountDao _orderDAO = _facDAO.GetOrderAccountDAO();


                return (IList<Entity>) _orderDAO.GetAll();
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
