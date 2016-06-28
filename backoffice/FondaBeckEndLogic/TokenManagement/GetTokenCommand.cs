
﻿using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.BackEndLogic.Exceptions;

using System;
using FondaBeckEndLogic;
using com.ds201625.fonda.DataAccess.Log;

namespace com.ds201625.fonda.BackEndLogic.TokenManagement
{
    /// <summary>
    /// Comando para la Buscar Token
    /// </summary>
    public class GetTokenCommand : BaseCommand
    {
        /// <summary>
        /// constructor GetTokenCommand
        /// </summary>
        public GetTokenCommand() : base() { }
        /// <summary>
        /// Metodo para inicializar los parametros
        /// </summary>
        /// <returns>Un arreglo con el parametro Commensal/returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            return paramters;
        }
        /// <summary>
        /// Metodo Invoke para la ejecucion del 
        /// buscar un Token especifico
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Obtencion de parametros
                Commensal commensal = (Commensal)GetParameter(0);

                // Obtiene el dao CommensalDAO
                ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

                Token token = (Token)EntityFactory.GetToken();
            try
            {
                // Se agrega el Token al commensal
                commensal.AddToken(token);

                //Se guardan los cambios
                commensalDAO.Save(commensal);

                //Logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 ResourceMessages.Token + commensal.Id , System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetTokenCommandException(ResourceMessages.GetTokenException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetTokenCommandException(ResourceMessages.GetTokenException, e);
            }


            //Se guardan los resultados
            Result = token;

            //Logger al Culminar el metodo
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
    }
}
