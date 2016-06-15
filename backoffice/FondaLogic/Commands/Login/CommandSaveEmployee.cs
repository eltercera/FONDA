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
            catch (SaveEntityFondaDAOException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionCreateEmployee exceptionCreateEmployee = new CommandExceptionCreateEmployee(
                //Arrojar
                FondaResources.General.Errors.SaveExceptionReferenceCode,
                FondaResources.Login.Errors.ClassNameSaveEmployee,
                FondaResources.Login.Errors.CommandMethod,
                FondaResources.General.Errors.SaveExceptionReferenceMessage,
                ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionCreateEmployee);

                throw exceptionCreateEmployee;

            }
            catch (NullReferenceException ex)
            {

                //TODO: Arrojar Excepcion personalizada
                CommandExceptionCreateEmployee exceptionCreateEmployee = new CommandExceptionCreateEmployee(
                //Arrojar
                FondaResources.General.Errors.NullExceptionReferenceCode,
                FondaResources.Login.Errors.ClassNameSaveEmployee,
                FondaResources.Login.Errors.CommandMethod,
                FondaResources.General.Errors.NullExceptionReferenceMessage,
                ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionCreateEmployee);

                throw exceptionCreateEmployee;

            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);

            }

        }

    }
}
