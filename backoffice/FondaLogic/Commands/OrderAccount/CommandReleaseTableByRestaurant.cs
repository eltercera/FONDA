using com.ds201625.fonda.DataAccess.FactoryDAO;
using System;
using System.Collections.Generic;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandReleaseTableByRestaurant : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandReleaseTableByRestaurant(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("No se puede hacer cierre de caja con ordenes abiertas");

            }
        }
    }
}
