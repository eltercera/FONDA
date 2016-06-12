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
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int orderId;

        public CommandGetOrder(Object receiver) : base(receiver)
        {
            try
            {
                orderId = (int)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        /// <summary>
        /// Metodo que ejecuta el comando para consultar una orden
        /// </summary>
        public override void Execute()
        {
            try
            {
                //Metodos para acceder a la BD
                IOrderAccountDao _orderDAO = _facDAO.GetOrderAccountDAO();


                 Receiver = _orderDAO.FindById(orderId);
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
