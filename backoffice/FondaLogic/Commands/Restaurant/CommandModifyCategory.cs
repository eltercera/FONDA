using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    public class CommandModifyCategory : Command
    {
        //Fabrica DAO para el metodo que ejecutara el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        //Lista de Objetos y contenido -nombre de la categoria, id- que recibe el comando
        Object[] _object;
        string name;
        int id;

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandModifyCategory(object receiver)
            : base(receiver)
        {
            _object = (Object[])receiver;
            id = (int)_object[0];
            name = (string)_object[1];
        }

        public override void Execute()
        {
            try
            {
                IRestaurantCategoryDAO _restcatDAO = _facDAO.GetRestaurantCategoryDAO();

                Receiver = _restcatDAO.ModifyCategory(id, name);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
