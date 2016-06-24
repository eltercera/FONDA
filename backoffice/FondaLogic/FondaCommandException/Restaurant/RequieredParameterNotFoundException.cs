using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    /// <summary>
    /// excepcion de tipo RequieredParameterNotFoundException
    /// </summary>
    class RequieredParameterNotFoundException : FondaCommandLogicException
    {
        private RequieredParameterNotFoundException(string message) : base(message)
        { }

        public static RequieredParameterNotFoundException Generate(Command cmd, int index)
        {
            String msj = "Parametro " + index + " es requerido para " + cmd.ToString();
            return new RequieredParameterNotFoundException(msj);
        }
    }
}
