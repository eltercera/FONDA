using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Reservations;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.Resources.FondaResources.Reservations;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations
{
    public class CommandCancelReservation : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private List<int> _list;
        private Reservation _reservation;
        CanceledReservationStatus _canceledReservationStatus;
        Command commandSaveReservation;

        public CommandCancelReservation(Object receiver) : base(receiver){ }

        public override void Execute()
        {
            try
            {
                //Defino el DAO
                _reservation = (Reservation)Receiver;
                _canceledReservationStatus = _facDAO.GetCanceledReservationStatus();
                  
                if(_reservation.Status.Equals(_canceledReservationStatus))
                {
                    throw new CommandExceptionCancelReservation(ReservationErrors.MessageCommandExceptionCancelReservationCanceledStatus);
                }
                _reservation.Status = _canceledReservationStatus;
               commandSaveReservation = CommandFactory.GetCommandSaveReservation(_reservation);

                commandSaveReservation.Execute();
                Receiver = (Reservation)_reservation;
            }

            catch (NullReferenceException ex)
            {
                CommandExceptionCancelReservation exception = new CommandExceptionCancelReservation(
                    ReservationErrors.CommandExceptionCancelReservationCode,
                    ReservationResources.ClassNameCancelReservation,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ReservationErrors.MessageCommandExceptionCancelReservation,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                _reservation = EntityFactory.GetReservation();
                Receiver = _reservation;
            }
            catch(Exception ex)
            {
                CommandExceptionCancelReservation exception = new CommandExceptionCancelReservation(
                    ReservationErrors.CommandExceptionCancelReservationCode,
                    ReservationResources.ClassNameCancelReservation,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ReservationErrors.MessageCommandExceptionCancelReservation,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                _reservation = EntityFactory.GetReservation();
                Receiver = _reservation;
            }

            Logger.WriteSuccessLog(ReservationResources.ClassNameCancelReservation
                , ReservationResources.SuccessMessageCommandCancelReservation
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
