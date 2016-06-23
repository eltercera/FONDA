using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FondaBeckEndLogic;

namespace com.ds201625.fonda.BackEndLogic.ProfileManagement
{
    /// <summary>
    /// Comando para actualizar un perfil de un Commensal
    /// </summary>
    public class UpdateProfileCommand : BaseCommand
    {
        public UpdateProfileCommand() : base() { }

        /// <summary>
        /// Metodo para inicializar los parametros
        /// </summary>
        /// <returns>Un arreglo con los parametros Commensal, Profile Original y Profile a Modificar</returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 3 Parametros
            Parameter[] paramters = new Parameter[3];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            // [1] El profile Original
            paramters[1] = new Parameter(typeof(Profile), true);

            // [2] El profile a Modificar
            paramters[2] = new Parameter(typeof(Profile), true);

            return paramters;
        }
        /// <summary>
        /// Metodo Invoke para la ejecucion del 
        /// buscar un perfil especifico
        /// </summary>
        protected override void Invoke()
        {
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                // Se obtienen los parametros Commensal, Profile Original y Profile a Modificar
                Commensal commensal = (Commensal)GetParameter(0);
                Profile oldProfile = (Profile)GetParameter(1);
                Profile profile = (Profile)GetParameter(2);

                // Obtiene el dao CommensalDAO
                ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

                if (profile.ProfileName == null || profile.Person == null || profile.Person.Name == null
                        || profile.Person.LastName == null || profile.Person.Ssn == null)
                    throw new UpdateProfileCommandException(ResourceMessages.InvalidInformationProfile);
            try
            {
                //Set nombre del perfil
                oldProfile.ProfileName = profile.ProfileName;
                //Set nombre de la persona
                oldProfile.Person.Name = profile.Person.Name;
                //Set apellido de la persona
                oldProfile.Person.LastName = profile.Person.LastName;
                //Set numero de telefono de la persona
                oldProfile.Person.PhoneNumber = profile.Person.PhoneNumber;
                //Set direccion de la persona
                oldProfile.Person.Address = profile.Person.Address;
                // Set ssn de la persona
                oldProfile.Person.Ssn = profile.Person.Ssn;

                //Se guardan los cambios del perfil del comensal
                commensalDAO.Save(commensal);

                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ResourceMessages.ProfileUpdated + commensal.Id + ResourceMessages.Slash + profile.ProfileName,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new UpdateProfileCommandException(ResourceMessages.UpdateProfileException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new UpdateProfileCommandException(ResourceMessages.UpdateProfileException, e);
            }
            // Guardar el resultado.
            Result = profile;

            //Logger al Culminar el metodo
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, Result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
