using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;

namespace FondaLogic.Commands.Login
{
    class ComandGetEmployeeBySsn : Command 
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        string Ssn;
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


                Receiver = _employeeDAO.FindBySsn(Ssn);
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetEmployee exceptionGetEmployee = new CommandExceptionGetEmployee(
                //Arrojar
                FondaResources.General.Errors.NullExceptionReferenceCode,
                FondaResources.Login.Errors.ClassNameGetExployeeSsn,
                FondaResources.Login.Errors.CommandMethod,
                FondaResources.General.Errors.NullExceptionReferenceMessage,
                ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetEmployee);

                throw exceptionGetEmployee;
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);

            }
        }

    }
}
