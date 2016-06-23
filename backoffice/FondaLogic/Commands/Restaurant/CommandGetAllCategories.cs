using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.Restaurante
{
    public class CommandGetAllCategories : Command
    {
        //Fabrica que me dara el metodo que utilizara el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllCategories(object receiver)
            : base(receiver)
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para obtener todas las categorias
        /// </summary>
        public override void Execute()
        {
            try
            {
                IRestaurantCategoryDAO _categoryDAO = _facDAO.GetRestaurantCategoryDAO();

                Receiver = _categoryDAO.GetAll();
            }
            catch
            {
                throw new NotImplementedException();
            }

        }
    }
}
