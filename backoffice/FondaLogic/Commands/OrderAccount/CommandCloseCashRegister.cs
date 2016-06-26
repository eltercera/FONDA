using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandCloseCashRegister : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId = 0;
        private string _symbol = null;
        private float _totalOrders = 0;

        public CommandCloseCashRegister(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _restaurantId = (int)Receiver;
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

                Receiver = string.Format(OrderAccountResources.CurrencyTotal, _symbol, _totalOrders);         
            }
            catch (NullReferenceException ex)
            {
                CommandExceptionCloseCashRegister exception = new CommandExceptionCloseCashRegister(
                    OrderAccountResources.CommandExceptionCloseCashRegisterCode,
                    OrderAccountResources.ClassNameCloseCashRegister,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandCloseCashRegister,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                Receiver = string.Empty;
                throw exception;
            }
            catch(Exception ex)
            {
                CommandExceptionCloseCashRegister exception = new CommandExceptionCloseCashRegister(
                    OrderAccountResources.CommandExceptionCloseCashRegisterCode,
                    OrderAccountResources.ClassNameCloseCashRegister,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandCloseCashRegister,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                Receiver = string.Empty;
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameCloseCashRegister
                        , OrderAccountResources.SuccessMessageCommandCloseCashRegister
                        , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                        );
        }
    }
}

