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
    /// Comando para la Buscar un Profile
    /// </summary>
    public class GetProfileCommand: BaseCommand
    {
        /// <summary>
        /// constructor GetProfileCommand
        /// </summary>
        public GetProfileCommand() : base() { }
        /// <summary>
        /// Metodo para inicializar los parametros
        /// </summary>
        /// <returns>Un arreglo con el parametro Profile</returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El Profile
            paramters[0] = new Parameter(typeof(Profile), true);


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

                // Se obtiene el parametro Profile
                Profile profile = (Profile)GetParameter(0);

                // Obtiene el dao ProfileDAO
                IProfileDAO profileDAO = FacDao.GetProfileDAO();
               
            try
            {
                //Se busca el profile por su id
                profile = (Profile)profileDAO.FindById(profile.Id);
                //Logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 ResourceMessages.Profile + profile.ProfileName, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FindByIdFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetProfileCommandException(ResourceMessages.GetProfileException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetProfileCommandException(ResourceMessages.GetProfileException, e);
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
