using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using FondaLogic.Log;
using FondaLogic.FondaCommandException;
using FondaLogic.FondaCommandException.Login;

namespace FondaLogic.Commands.Login
{
    class CommandSaveEmployee : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        Employee _employee;

        public CommandSaveEmployee(Object receiver) : base(receiver)
        {
            try
            {
                _employee = (Employee)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD
                
                IEmployeeDAO _employeeDAO = _facDAO.GetEmployeeDAO();
                

                 _employeeDAO.Save(_employee);
                
            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameSaveEmployee, e);

            }
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameSaveEmployee, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(FondaResources.Login.Errors.ClassNameSaveEmployee, e);
            }
            // Guarda el resultado.
            Employee Result = _employee;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

    }
}
