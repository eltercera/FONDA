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
        private Entity _entity;

        /// <summary>
        /// Objeto base mediante se envia informacion a los comandos
        /// </summary>
        public Entity Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <param name="param">E</param>
        /// <returns></returns>
        public abstract Output Execute();
    }
}
