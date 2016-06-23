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
    public class CommandGetAllZones : Command
    {
        //Fabrica que dara el metodo para el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;

        /// <summary>
        /// Constructor del metodo
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllZones(object receiver)
            : base(receiver)
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para obtener todas las zonas
        /// </summary>
        public override void Execute()
        {
            try
            {
                IZoneDAO _zoneDAO = _facDAO.GetZoneDAO();

                Receiver = _zoneDAO.allZone();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
