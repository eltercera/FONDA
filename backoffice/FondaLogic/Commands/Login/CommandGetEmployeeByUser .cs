using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.login;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Login
{
    public class CommandGetEmployeeByUser : Command
    {
        // fabrica que me dara el dao que contiene el metodo a encapsular en este comando
        FactoryDAO _facDAO = FactoryDAO.Intance;
        // nombre de usuario del a buscar 
        string _username;
        /// <summary>
        /// metodo constructor del comando
        /// </summary>
        /// <param name="receiver">recibe username del usuario a buscar</param>
        public CommandGetEmployeeByUser(Object receiver) : base(receiver)
        {
            try
            {
                _username = (string)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }
        /// <summary>
        /// Metodo que ejecuta el comando para buscar un empleado de la bd
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
                // se ejecuta comando que busca empleado por username

                Receiver = _employeeDAO.FindByusername(_username);
            }
            //se capturan excepciones que pueden ser generadas en la capa de acceso de datos
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Resources.FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Resources.FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Resources.FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Resources.FondaResources.Login.Errors.ClassNameGetEmployeeUser, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Resources.FondaResources.Login.Errors.ClassNameGetEmployeeUser, e);
            }
            // Guarda el resultado.
            Object Result = Receiver;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resources.FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


        }
    }
    }
