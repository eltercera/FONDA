using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException.OrderAccount;
using FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandValidateProfileByCommensal : Command
    {
        private int profileId;
        private bool result = false;
        private Commensal commensal;
        private List<Object> parameters;
        private IList<Profile> profiles;

        public CommandValidateProfileByCommensal(Object receiver) : base(receiver) { }

        public override void Execute()
        {

            try
            {
                parameters = (List<Object>)Receiver;
                profileId = (int)parameters[0];
                commensal = (Commensal)parameters[1];

                profiles = (IList<Profile>)commensal.Profiles;

                foreach (Profile p in profiles)
                {
                    if (p.Id.Equals(profileId))
                        result = true;
                }

                Receiver = result;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionValidateProfileByCommensal exception = new CommandExceptionValidateProfileByCommensal(
                    OrderAccountResources.CommandExceptionValidateProfileByCommensalCode,
                    OrderAccountResources.ClassNameValidateProfileByCommensal,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionValidateProfileByCommensal,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }
            catch(Exception ex)
            {
                CommandExceptionValidateProfileByCommensal exception = new CommandExceptionValidateProfileByCommensal(
                    OrderAccountResources.CommandExceptionValidateProfileByCommensalCode,
                    OrderAccountResources.ClassNameValidateProfileByCommensal,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionValidateProfileByCommensal,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameValidateProfileByCommensal
                , OrderAccountResources.SuccessMessageCommandExceptionValidateProfileByCommensal
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
