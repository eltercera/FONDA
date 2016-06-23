using com.ds201625.fonda;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    class CommandGenerateException : Command
    {
        public CommandGenerateException(object receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            string i = "word";
            int number;

            try
            {
                number = int.Parse(i);
            }
            catch (FormatException ex)
            {

                throw ex;
            }
            finally
            {
                Console.WriteLine("Operacion no permitida");
            }


        }
    }
}
