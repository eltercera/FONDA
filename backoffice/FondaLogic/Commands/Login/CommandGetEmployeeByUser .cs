using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using com.ds201625.fonda.Domain;

namespace FondaLogic.Commands.Login
{
    public class CommandGetEmployeeByUser : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        string _username;

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


                Receiver = _employeeDAO.FindByusername(_username);
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
