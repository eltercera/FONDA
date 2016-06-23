using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    public class CommandAddCategory : Command
    {
        //Fabrica DAO para el metodo que ejecutara el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        //Objeto -nombre de la catgeoria- que recibe el comando
        string name;

        public CommandAddCategory(object receiver)
            : base(receiver)
        {
            name = (string)receiver;
        }
        public override void Execute()
        {
            try
            {
                IRestaurantCategoryDAO _restcatDAO = _facDAO.GetRestaurantCategoryDAO();

                Receiver = _restcatDAO.GetRestaurantCategory(name);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}