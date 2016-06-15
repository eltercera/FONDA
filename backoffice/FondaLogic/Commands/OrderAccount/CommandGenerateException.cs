using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    class CommandGenerateException : Command
    {
        public CommandGenerateException(object receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            int a = 1;
            int b = 0;
            int result;

            try
            {
                result = a / b;
            }
            catch (DivideByZeroException ex)
            {

                throw ex;
            }


        }
    }
}
