using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;


namespace FondaLogic.Commands.Reservations
{
    public class CommandGetTables : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId;

        public CommandGetTables(Object receiver) : base(receiver)
        {
            try
            {
                _restaurantId = (int)receiver;
            }
            catch (NullReferenceException ex)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }

        }

        /// <summary>
        /// Metodo que ejecuta el comando que consulta las mesas de un Restaurante
        /// </summary>
        public override void Execute()
        {
            IList<Table> listTables;

            try
            {
                //Defino el DAO
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _restaurantDAO = _facDAO.GetRestaurantDAO();

                listTables = _restaurantDAO.TablesByRestaurantId(_restaurantId);

                Receiver = listTables;
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetTables exceptionGetTables = new CommandExceptionGetTables(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.Restaurant.RestaurantErrors.ClassNameGetReservations,
                    FondaResources.Restaurant.RestaurantErrors.CommandMethod,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetTables);

                listTables = new List<Table>();
                Receiver = listTables;
                //throw exceptionGetOrders;
            }



        }

    }
}
