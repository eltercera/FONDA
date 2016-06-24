using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaBeckEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Get Commensal Email Command
    /// </summary>
    class GetCommensalEmailCommand : BaseCommand
    {
        private  UserAccount answer;
        private ICommensalDAO commensalDAO;
        private UserAccount userAccount;

        /// <summary>
        /// constructor obtener comensal
        /// </summary>
        public GetCommensalEmailCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El UserAccount
            paramters[0] = new Parameter(typeof(UserAccount), true);

            return paramters;
		}

        /// <summary>
        /// metodo invoke que ejecuta el buscar comensal por email 
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            // Obtencion de parametros
            userAccount = (UserAccount)GetParameter(0);
            // Obtiene el dao que se requiere
            commensalDAO = FacDao.GetCommensalDAO();
            // Ejecucion del Buscar.	

            if (userAccount.Email == null)
                throw new Exception(ResourceMessages.InvalidInformation);

            try
            {
                answer = (UserAccount)commensalDAO.FindByEmail(userAccount.Email);
                 Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  ResourceMessages.CommensalEmail + answer.Id + ResourceMessages.Slash + answer.Email,
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalEmailCommandException(ResourceMessages.ParametersGetComensEmailException,
                           e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalEmailCommandException(ResourceMessages.ParametersGetComensEmailException,
                           e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalEmailCommandException(ResourceMessages.ParametersGetComensEmailException,
                           e);
            }
            catch (FindByEmailUserAccountFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalEmailCommandException(ResourceMessages.GetCommensalEmailException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalEmailCommandException(ResourceMessages.GetCommensalEmailException, e);
            }
            // Guardar el resultado.
            Result = answer;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(),System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}