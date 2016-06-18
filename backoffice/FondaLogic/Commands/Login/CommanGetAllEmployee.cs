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

namespace FondaLogic.Commands.Login
{
    public class CommanGetAllEmployee : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;

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

                IList<Employee> listEmployee = _EmployeeDAO.GetAll();
                Receiver = listEmployee;
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetEmployee exceptionGetEmployee = new CommandExceptionGetEmployee(
                //Arrojar
                FondaResources.General.Errors.NullExceptionReferenceCode,
                FondaResources.Login.Errors.ClassNameGetEmployee,
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
