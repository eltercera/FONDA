using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using com.ds201625.fonda.DataAccess.Exceptions;
using FondaLogic.FondaCommandException.Login;

namespace FondaLogic.Commands.Login
{
    class ComandoGetUserAcountByEmail : Command
    {
        // fabarica que me dara el dao para ejecutar un metodo en el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        // email del empleado a buscar
        string Email;
        /// <summary>
        /// constructor del comando
        /// </summary>
        /// <param name="receiver">recibe email del empleado a buscar</param>
        public ComandoGetUserAcountByEmail(Object receiver) : base(receiver)
        {
            try
            {
                Email = (string)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }
        /// <summary>
        /// Metodo que ejecuta el comando para buscar un empleado de la bd por el email
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD
                // dao que me dara metodo a ejecuta
                IUserAccountDAO _userAccountDAO = _facDAO.GetUserAccountDAO();

                // se ejecuta metodo del dao
                Receiver = _userAccountDAO.FindByEmail(Email);
            }
            // se capturan excepciones que pueden generarse en la capa de acceso a datos
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetUserAccount(FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetUserAccount(FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetUserAccount(FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetUserAccount(FondaResources.Login.Errors.ClassNameGetUserAccountEmail, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetUserAccount(FondaResources.Login.Errors.ClassNameGetUserAccountEmail, e);
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
