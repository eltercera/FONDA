using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.Login
{
    class InvalidTypeParameterException : FondaLogicException
    {
        /// <summary>
        /// excepcion que es lanzada en caso de que falle una consulta con un parametro incorrecto
        /// </summary>
        /// <param name="message"></param>
        public InvalidTypeParameterException(string message) : base(message) { }

        public static InvalidTypeParameterException Generate(Type spected, Type recive)
        {
            string msg = "Error de tipo de parametro se espera ("
                         + spected.ToString() +
                         ") y se recivio de tipo ("
                         + recive.ToString() +
                         ")";
            return new InvalidTypeParameterException(msg);
        }
    }
}
