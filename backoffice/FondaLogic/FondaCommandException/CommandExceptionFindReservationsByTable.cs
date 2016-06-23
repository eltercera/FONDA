using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle la busqueda de las facturas de una cuenta
    /// </summary>
    public class CommandExceptionFindReservationsByTable : CommandException
    {


        #region Constructors

        public CommandExceptionFindReservationsByTable(string message) : base(message)
        {
        }
        public CommandExceptionFindReservationsByTable(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionFindReservationsByTable(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion

    }
}
