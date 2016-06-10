using com.ds201625.fonda;
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
    public abstract class Command<Output> 
    {

        private Entity receiver;

        public Entity Receiver
        {
            get { return receiver; }
        }

        public Command(Entity receiver)
        {
            this.receiver = receiver;
        }


        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <param name="param">E</param>
        /// <returns></returns>
        public abstract Output Execute();

    }
}
