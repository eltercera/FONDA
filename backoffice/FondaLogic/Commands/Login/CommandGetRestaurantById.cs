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
                //CommandExceptionGetRestaurant exceptionGetRestaurant = new CommandExceptionGetRestaurant(
                //Arrojar
                //FondaResources.General.Errors.NullExceptionReferenceCode,
                //FondaResources.Login.Errors.ClassNameGetRestaurant,
                //FondaResources.Login.Errors.CommandMethod,
                //FondaResources.General.Errors.NullExceptionReferenceMessage,
                //ex);

                 //Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetRestaurant);

                //throw exceptionGetRestaurant;
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);

            }

        }
    }
}
