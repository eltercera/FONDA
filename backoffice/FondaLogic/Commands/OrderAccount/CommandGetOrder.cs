using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetOrder : Command
    {
        public CommandGetOrder(Object receiver) : base(receiver)
        {
        }

        /// <summary>
        /// Metodo que ejecuta el comando para consultar una orden
        /// </summary>
        /// <param name="param">Id de la Orden</param>
        /// <returns>La orden</returns>
        public override void Execute()
        {
            try
            {
                //Metodos para acceder a la BD
                FactoryDAO _facDAO = FactoryDAO.Intance;
                IOrderAccountDao _orderDAO = _facDAO.GetOrderAccountDAO();


                 Receiver = _orderDAO.FindById(1);
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
