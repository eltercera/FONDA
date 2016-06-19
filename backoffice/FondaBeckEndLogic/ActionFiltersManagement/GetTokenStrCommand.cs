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
using FondaBeckEndLogic;

namespace com.ds201625.fonda.BackEndLogic.ActionFiltersManagement
{
    /// <summary>
    /// Comando para la Buscar Token por StrToken
    /// </summary>
    public class GetTokenStrCommand : BaseCommand
    {
        /// <summary>
        /// constructor GetTokenStrCommand
        /// </summary>
        public GetTokenStrCommand() : base() { }
        /// <summary>
        /// Metodo para inicializar los parametros
        /// </summary>
        /// <returns>Un arreglo con el parametro string Token/returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El Token
            paramters[0] = new Parameter(typeof(String), true);

            return paramters;
        }
        /// <summary>
        /// Metodo Invoke para la ejecucion del 
        /// buscar un Token por Str especifico
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //propiedad
            string property = "StrToken";
            // Obtencion de parametros
            String token = (String)GetParameter(0);

            // Obtiene el dao TokenDAO
            ITokenDAO tokenDAO = FacDao.GetTokenDAO();

            Token tok;

            try
            {
                // Busca el Token
                tok = tokenDAO.FindByStrToken(property,token);

                //Logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 ResourceMessages.Token + token, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (FindByStrTokenFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetTokenStrCommandException(ResourceMessages.GetTokenException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetTokenStrCommandException(ResourceMessages.GetTokenException, e);
            }


            //Se guardan los resultados
            Result = tok;

            //Logger al Culminar el metodo
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, Result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
    }
}
