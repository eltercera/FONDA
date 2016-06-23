using com.ds201625.fonda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic
{
    /// <summary>
    /// Comando Base para el patron comando
    /// </summary>
    public abstract class Command : ICommand
    {

        #region Receiver
        private Object receiver;

        public Object Receiver
        {
            get { return receiver; }
            protected set { receiver = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase comando
        /// </summary>
        /// <param name="receiver">recibe un objeto</param>
        public Command(Object receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Constructor vacio de la clase comando
        /// </summary>
        public Command() {}
        #endregion

        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        public abstract void Execute();

    }
}
