using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException.OrderAccount;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandValidateProfileByCommensal : Command
    {
        public CommandValidateProfileByCommensal(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            int profileId;
            bool result = false;
            Commensal commensal;
            Profile profile;
            List<Object> parameters;
            IList<Profile> profiles;

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
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionValidateProfileByCommensal exception = new CommandExceptionValidateProfileByCommensal(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameCloseCashRegister,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }
            catch(Exception ex)
            {
                CommandExceptionValidateProfileByCommensal exception = new CommandExceptionValidateProfileByCommensal(
    FondaResources.General.Errors.NullExceptionReferenceCode,
    FondaResources.OrderAccount.Errors.ClassNameCloseCashRegister,
    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    FondaResources.General.Errors.NullExceptionReferenceMessage,
    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }
        }
    }
}
