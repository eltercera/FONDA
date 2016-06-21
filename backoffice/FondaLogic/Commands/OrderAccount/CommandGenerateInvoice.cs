using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using com.ds201625.fonda.Factory;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGenerateInvoice : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        IList<object> _list;
        IList<DishOrder> _listDishOrder;
        Restaurant _restaurant;
        //DishOrder _dishOrder;
        Invoice _invoice;
        Account _account;
        //UserAccount _userAccount;
        //Person _person;

        public CommandGenerateInvoice(Object receiver) : base(receiver)
        {
            try
            {
                _list = (IList<object>)receiver;
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

                IUserAccountDAO _userAccountDao = _facDAO.GetUserAccountDAO();
                ICommensalDAO _genericPersonDao = _facDAO.GetCommensalDAO();
                IPersonDAO _personDao = _facDAO.GetPersonDao();
                IDishOrderDAO _dishOrderDao = _facDAO.GetDishOrderDAO();
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
                IRestaurantDAO _restaurantDao = _facDAO.GetRestaurantDAO(); 
                int _restaurantId, _accountId = 0;
                _invoice = (Invoice)_list[0];
                _restaurantId = (int)_list[1];
                _accountId = (int)_list[2];
                _restaurant = _restaurantDao.FindById(_restaurantId);
                _account = _accountDAO.FindById(_accountId);
                _listDishOrder = _dishOrderDao.GetDishesByAccount(_account.Id);

                InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
                _invoice =_accountDAO.SaveInvoice(_invoice, _account.Id, _restaurant.Id);

                Receiver = _invoice;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGenerateInvoice exception = new CommandExceptionGenerateInvoice(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice(); ;
                Receiver = _invoice;
            }

        }

    }
}
