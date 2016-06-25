using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    /// <summary>
    /// Excepcion de tipo ParameterIndexOutRangeException
    /// </summary>
    class ParameterIndexOutRangeException : FondaCommandLogicException
    {

        private ParameterIndexOutRangeException(string message) : base(message)
		{ }

        public static ParameterIndexOutRangeException Generate(Command cmd, int index)
        {
            string msj = "Indice " + index + "fuera de rango " + cmd.ToString();
            return new ParameterIndexOutRangeException(msj);
        }
    }
}
