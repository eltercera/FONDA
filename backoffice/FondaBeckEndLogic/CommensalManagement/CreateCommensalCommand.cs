using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using System;
using FondaBeckEndLogic;

namespace com.ds201625.fonda.BackEndLogic.CommensalManagement
{
    /// <summary>
    /// Comando para la Crear un Commensal
    /// </summary>
    public class CreateCommensalCommand : BaseCommand
    {
        /// <summary>
        /// constructor CreateCommensalCommand
        /// </summary>
        public CreateCommensalCommand() : base() { }
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
        /// crear un Commensal 
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Commensal commensal;
            try
            {
                // Obtencion de parametros
                commensal = (Commensal)GetParameter(0);

                // Obtiene el dao CommensalDAO
                ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
                // Guardar el resultado.
                commensalDAO.Save(commensal);
                //Logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 ResourceMessages.Commensal + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateCommensalCommandException(ResourceMessages.CreateCommensalException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateCommensalCommandException(ResourceMessages.CreateCommensalException, e);
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
