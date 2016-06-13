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
    public class CommandGetRestaurantById : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        Restaurant _restaurant;
        public CommandGetRestaurantById(Object receiver) : base(receiver)
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
                //Metodos para acceder a la BD
                FactoryDAO _facDAO = FactoryDAO.Intance;
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();


                Receiver = _restaurantDAO.FindById(_restaurant.Id);
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
