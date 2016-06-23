using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    class CommandSaveCategory : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        RestaurantCategory _restCategory;

        public CommandSaveCategory(Object receiver) : base(receiver)
        {
            try
            {
                _restCategory = (RestaurantCategory)receiver;
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
                //defino los dao

                IRestaurantCategoryDAO _restCategoryDAO = _facDAO.GetRestaurantCategoryDAO();

                //ejecuto el metodo del dao
                _restCategoryDAO.Save(_restCategory);

            }
            catch (NullReferenceException ex)
            {
                // se guarda el resultado en el objeto 
                throw;
            }

            System.Diagnostics.Debug.WriteLine("entro al execute de save category");
            RestaurantCategory Result = _restCategory;
        }
    }
}
