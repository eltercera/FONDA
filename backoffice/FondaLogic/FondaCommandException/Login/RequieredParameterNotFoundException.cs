using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.Login
{
    class RequieredParameterNotFoundException : FondaLogicException
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
