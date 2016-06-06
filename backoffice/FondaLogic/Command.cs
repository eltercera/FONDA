using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic
{
    /// <summary>
    /// Comando Base para el patron comando
    /// </summary>
    public abstract class Command<Input, Output>
    {
        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <param name="param">E</param>
        /// <returns></returns>
        public abstract Output Execute(Input param);
    }
}
