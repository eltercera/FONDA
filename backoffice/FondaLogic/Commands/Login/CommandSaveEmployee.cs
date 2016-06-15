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
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                //TODO: Escribir en el Log la excepcion
                throw;
            }

        }

    }
}
