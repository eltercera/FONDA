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
using FondaLogic.FondaCommandException.login;

namespace FondaLogic.Commands.Login
{
    // comando que busca todos los empleado de la bd
    public class CommanGetAllEmployee : Command
    {
        // fabrica que me dara dao que contiene metodo a encapsular en este comando
        FactoryDAO _facDAO = FactoryDAO.Intance;
        /// <summary>
        /// conttructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommanGetAllEmployee(Object receiver) : base(receiver)
        {

        }
        /// <summary>
        /// Metodo que ejecuta el comando para buscar todos los empleados del sistema
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IEmployeeDAO _EmployeeDAO = _facDAO.GetEmployeeDAO();
                //se obtiene resultado del metodo del dao
                IList<Employee> listEmployee = _EmployeeDAO.GetAll();
                Receiver = listEmployee;
            }
            // se capturan excepciones que se pueden generadas en la capa de acceso a datos
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
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameGetEmployee, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(FondaResources.Login.Errors.ClassNameGetEmployee, e);
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
