using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.Restaurante
{
    class CommandModifyRestaurant : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        Object[] _object;
        int _restaurantO;
        Restaurant _restaurantN;
         

        public CommandModifyRestaurant (object receiver)
            : base (receiver)
        {
            _object = (Object[])receiver;
            _restaurantN = (Restaurant)_object[0];
            _restaurantO = (int)_object[1];


            /*int restaurantO, Entity restaurantN
            _restaurantO = (int)restaurantO;
            _restaurantN = (Restaurant)restaurantN;*/
        }
        
        public override void Execute()
        {
            try
            {
                IRestaurantDAO _RestaurantDAO = _facDAO.GetRestaurantDAO();

                Receiver = _RestaurantDAO.ModifyRestaurant(_restaurantO, _restaurantN);

            }
            catch
            {
                throw new NotImplementedException();
            }
         }
    }
}
