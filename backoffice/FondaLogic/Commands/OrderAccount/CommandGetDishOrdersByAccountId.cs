using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.Log;
using System;
using System.Collections.Generic;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetDishOrdersByAccountId : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _orderAccount = 0;

        public CommandGetDishOrdersByAccountId(Object receiver) : base(receiver)
        {
            try
            {
                _orderAccount = (int)receiver;
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
                IDishOrderDAO _dishOrderDAO;
                //Obtengo la instancia del DAO a utilizar
                _dishOrderDAO = _facDAO.GetDishOrderDAO();
                //Obtengo el objeto con la informacion enviada
                IList<DishOrder> listDetailOrder = _dishOrderDAO.GetDishesByAccount(_orderAccount);
                Receiver = listDetailOrder;

            }
            catch (NullReferenceException ex)
            {

            }
        }
    }

}
