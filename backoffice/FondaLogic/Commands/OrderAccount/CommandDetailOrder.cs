using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.Log;
using System;
using System.Collections.Generic;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandDetailOrder : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _orderAccount = 0;

        public CommandDetailOrder(Object receiver) : base(receiver)
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
                //TODO: Arrojar Excepcion personalizada
                //TODO: Escribir en el Log la excepcion
                throw;
            }
        }
    }

}
