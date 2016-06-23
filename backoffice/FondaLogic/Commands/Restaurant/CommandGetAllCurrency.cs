using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.Restaurante
{
    public class CommandGetAllCurrency : Command
    {
        //Fabrica que da el metodo para ejecutar el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;


        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllCurrency(object receiver)
            : base(receiver)
        {

        }

        /// <summary>
        /// Metodo para ejecutar el comando para obtener todas las currencies
        /// </summary>
        public override void Execute()
        {
            try
            {
                ICurrencyDAO _currencyDAO = _facDAO.GetCurrencyDAO();

                Receiver = _currencyDAO.GetAll();
            }
            catch
            {
                throw new NotImplementedException();

            }

        }
    }
}
