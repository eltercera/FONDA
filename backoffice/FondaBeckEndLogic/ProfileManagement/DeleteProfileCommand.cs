using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackEndLogic.ProfileManagement
{
    public class DeleteProfileCommand : BaseCommand
    {
        /// <summary>
        /// Comando para eliminar un perfil de un Commensal
        /// </summary>
        public DeleteProfileCommand() : base() { }

        protected override Parameter[] InitParameters()
        {
            // Requiere 2 Parametros
            Parameter[] paramters = new Parameter[2];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            // [1] El profile a Eliminar
            paramters[1] = new Parameter(typeof(Profile), true);

            return paramters;
        }

        /// <summary>
        /// Metodo Invoke para la ejecucion del
        /// eliminar un profile de un commensal
        /// </summary>
        protected override void Invoke()
        {
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                      ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Se obtienen los parametros Commensal y Profile
                Commensal commensal = (Commensal)GetParameter(0);
                Profile profile = (Profile)GetParameter(1);
                // Obtiene el dao CommensalDAO
                ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
            try
            {
                //Se remueve el perfil de la lista de perfiles del commensal
                commensal.Profiles.Remove(profile);
                //Set Status del perfil como deshabilitado
                profile.Status = FacDao.GetDisabledSimpleStatus();

                //Se Guarda el commensal con los cambios realizados
                commensalDAO.Save(commensal);

                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ResourceMessages.ProfileDeleted + commensal.Id + ResourceMessages.Slash + profile.ProfileName,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteProfileCommandException(ResourceMessages.DeleteProfileException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteProfileCommandException(ResourceMessages.DeleteProfileException, e);
            }

            // Guardar el resultado.
            Result = commensal;

            //Logger al Culminar el metodo
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, Result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
