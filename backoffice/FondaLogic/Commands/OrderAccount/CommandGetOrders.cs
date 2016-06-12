﻿using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;


namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetOrders : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        int restaurantId;

        public CommandGetOrders(Object receiver) : base(receiver)
        {
            try
            {
                restaurantId = (int) receiver;
            }
            catch (NullReferenceException ex)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }

        }



        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        public override void Execute()
        {
            try
            {
                //Defino el DAO
                IOrderAccountDao _orderDAO;
                //Obtengo la instancia del DAO a utilizar
                _orderDAO = _facDAO.GetOrderAccountDAO();

                IList<Account> listAccounts = _orderDAO.FindByRestaurant(restaurantId);
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetOrders exceptionGetOrders = new CommandExceptionGetOrders(
                    //Arreglar
                    FondaResources.General.Errors.NullReferenceExceptionMessage,
                    FondaResources.OrderAccount.Errors.ClassNameGetOrders,
                    FondaResources.OrderAccount.Errors.CommandMethod,
                    FondaResources.General.Errors.NullReferenceExceptionMessage, ex);

                Logger.WriteErrorLog(exceptionGetOrders);

                throw exceptionGetOrders;
            }



        }

    }
}
