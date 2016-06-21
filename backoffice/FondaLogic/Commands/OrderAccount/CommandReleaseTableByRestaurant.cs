using com.ds201625.fonda.DataAccess.FactoryDAO;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
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
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionReleaseTableByRestaurant exception = new CommandExceptionReleaseTableByRestaurant(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameReleaseTableByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);


            }
        }
    }
}
