using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaLogic.Commands.Login
{
    public class CommandGetEmployeeById : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int idEmployee;
        public CommandGetEmployeeById(Object receiver) : base(receiver)
        {
            try
            {
                idEmployee = (int)receiver;
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


                Receiver = _employeeDAO.FindById(idEmployee);
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                //TODO: Escribir en el Log la excepcion
                throw;
            }
        }
    }
}
