using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.Login
{
    class InvalidTypeParameterException : FondaLogicException
    {

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
