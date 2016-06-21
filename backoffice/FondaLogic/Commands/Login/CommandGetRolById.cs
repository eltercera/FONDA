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
    class CommandGetRolById : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _id;

        public CommandGetRolById(Object receiver) : base(receiver)
        {
            try
            {
                _id = (int)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        /// <summary>
        /// Metodo que ejecuta el comando para buscar un rool de la bd
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IRoleDAO _rolDAO = _facDAO.GetRoleDAO();


                Receiver = _rolDAO.FindById(_id);
            }
            catch (NullReferenceException ex)
            {
               
            }
            catch (Exception ex)
            {
               

            }
        }
    }
}
