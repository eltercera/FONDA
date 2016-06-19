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
    public class CommandGetReservations : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _restaurantId;

        public CommandGetReservations(Object receiver) : base(receiver)
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
        /// Metodo que ejecuta el comando que consulta las reservaciones segun un Restaurante
        /// </summary>
        public override void Execute()
        {
            IList<Reservation> listReservations;

            try
            {
                //Defino el DAO
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _restaurantDAO = _facDAO.GetRestaurantDAO();

                listReservations = _restaurantDAO.ReservationsByRestaurantId(_restaurantId);

                Receiver = listReservations;
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetReservations exceptionGetReservations = new CommandExceptionGetReservations(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.Reservation.ReservationErrors.ClassNameGetReservations,
                    FondaResources.Reservation.ReservationErrors.CommandMethod,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetReservations);

                listReservations = new List<Reservation>();
                Receiver = listReservations;
                //throw exceptionGetOrders;
            }



        }

    }
}
