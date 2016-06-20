using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandCloseCashRegister : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _restaurantId = 0;
        string _symbol = null;
        float _totalOrders = 0;

        public CommandCloseCashRegister(Object receiver) : base(receiver)
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
                IOrderAccountDao _orderDAO;
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _orderDAO = _facDAO.GetOrderAccountDAO();
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                //Obtengo el objeto con la informacion enviada
                IList<Account> _openOrdersDay = _restaurantDAO.OpenOrdersByRestaurantId(_restaurantId);
                    _totalOrders = _orderDAO.CloseCashRegister(_restaurantId);
                    Restaurant _restaurant = _restaurantDAO.FindById(_restaurantId);
                    Currency curr = new Currency();
                    curr = _restaurant.Currency;
                    _symbol = curr.Symbol;

                    Receiver = (_symbol + " " + _totalOrders);               
            }
            catch (CommandExceptionCloseCashRegister ex)
            {


            }
        }
    }
}

