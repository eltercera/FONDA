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
    class CommandSaveRestaurant : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        Restaurant _restaurant;

        public CommandSaveRestaurant(Object receiver) : base(receiver)
        {
            try
            {
                _restaurant = (Restaurant)receiver;
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

                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

                //ejecuto el metodo del dao
                _restaurantDAO.Save(_restaurant);

            }
            catch (NullReferenceException ex)
            {
                // se guarda el resultado en el objeto 
                throw;
            }

            System.Diagnostics.Debug.WriteLine("entro al execute de save restaurant");
            Restaurant Result = _restaurant;

        }
    }
}

