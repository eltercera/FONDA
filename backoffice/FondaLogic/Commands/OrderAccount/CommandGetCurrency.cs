using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetCurrency : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _restaurantId = 0;
        string _symbol = null;

        public CommandGetCurrency(Object receiver) : base(receiver)
        {
            try
            {
                _restaurantId = (int)receiver;
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
                //Defino el DAO
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                //Obtengo el objeto con la informacion enviada
                Restaurant _restaurant = _restaurantDAO.FindById(_restaurantId);
                Currency curr = new Currency();
                curr = _restaurant.Currency;
                _symbol = curr.Symbol;

                Receiver = _symbol;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
