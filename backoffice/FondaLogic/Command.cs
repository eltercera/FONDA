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
    public abstract class Command : ICommand
    {

        private Object receiver;

        public Object Receiver
        {
            get { return receiver; }
            protected set { receiver = value; }
        }

        public Command(Object receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        public abstract void Execute();

    }
}
