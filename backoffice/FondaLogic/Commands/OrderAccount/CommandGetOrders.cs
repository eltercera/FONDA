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
    public class CommandGetOrders : Command<IList<Account>>
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandGetOrders(Entity receiver) : base(receiver)
        {
        }

        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        /// <param name="param">Id del Restaurante</param>
        /// <returns>Lista de Ordenes</returns>
        public override IList<Account> Execute()
        {
            try
            {
                //Defino el DAO
                IOrderAccountDao _orderDAO;
                //Obtengo la instancia del DAO a utilizar
                _orderDAO = _facDAO.GetOrderAccountDAO();
                //Obtengo el objeto con la informacion enviada

                Restaurant res = (Restaurant)Receiver ;

                return  _orderDAO.FindByRestaurant(res);
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
