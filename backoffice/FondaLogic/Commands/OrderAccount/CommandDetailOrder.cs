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
        Account _orderAccount = new Account();

        public CommandDetailOrder(Object receiver) : base(receiver)
        {
            try
            {
                _orderAccount = (Account)receiver;
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
                ////Defino el DAO
                //IOrderAccountDao _orderDAO;
                ////Obtengo la instancia del DAO a utilizar
                //_orderDAO = _facDAO.GetOrderAccountDAO();
                ////Obtengo el objeto con la informacion enviada
                //IList<Dish> listDetailOrder = _orderDAO.GetDishesByAccount(_orderAccount);
                //Receiver = listDetailOrder;

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
