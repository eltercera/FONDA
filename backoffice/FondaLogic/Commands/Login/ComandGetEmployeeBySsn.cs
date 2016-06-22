using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using FondaLogic.FondaCommandException.Login;
using com.ds201625.fonda.DataAccess.Exceptions;
using FondaLogic.FondaCommandException.login;

namespace FondaLogic.Commands.Login
{
    class ComandGetEmployeeBySsn : Command 
    {
        // fabrica de dao para ejecutar el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        // ssn del empleado a buscar
        string Ssn;
        /// <summary>
        /// constructor del comando
        /// </summary>
        /// <param name="receiver">Ssn del empleado que se quiere buscar</param>
        public ComandGetEmployeeBySsn(Object receiver) : base(receiver)
        {
            try
            {
                Ssn = (string)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }
        /// <summary>
        /// Metodo que ejecuta el comando para buscar un empleado de la bd
        /// por ssn
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();

                //obtengo resultado del comando
                Receiver = _employeeDAO.FindBySsn(Ssn);
            }
            // obtengo excepciones que pueden ser generedas en la capa de acceso a datos
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameGetExployeeSsn, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameGetExployeeSsn, e);
            }
            // Guarda el resultado.
            Object Result = Receiver;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

    }
}
