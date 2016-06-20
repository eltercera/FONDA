using System;

namespace FondaLogic.Commands.OrderAccount
{
    /// <summary>
    /// Comando para pagar una orden abierta
    /// </summary>
    public class CommandPayOrder : Command
    {
        public CommandPayOrder(Object receiver) : base() { }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
