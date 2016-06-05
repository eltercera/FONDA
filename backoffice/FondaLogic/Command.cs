using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic
{
    public abstract class Command<Input, Output>
    {
        public abstract Output Execute(Input param);
    }
}
