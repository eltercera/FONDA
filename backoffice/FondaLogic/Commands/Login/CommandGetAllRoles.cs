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
    public class CommandGetAllRoles : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandGetAllRoles(Object receiver) : base(receiver)
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para buscar todos los roles del sistema
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IRoleDAO _RoleDAO = _facDAO.GetRoleDAO();


                Receiver = _RoleDAO.GetAll();
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
