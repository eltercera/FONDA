using com.ds201625.fonda.Domain;
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
            Restaurant res = null;

            try
            {
                string nameRes = res.Name;
            }
            catch (DivideByZeroException ex)
            {

                throw ex;
            }


        }
    }
}
