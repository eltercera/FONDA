using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations
{
    public class CommandGetReservationById : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _reservationId = 0;

        public CommandGetReservationById(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _reservationId = (int)Receiver;
                //Defino el DAO
                IReservationDAO _reservationDAO;
                //Obtengo la instancia del DAO a utilizar
                _reservationDAO = _facDAO.GetReservationDAO();
                //Obtengo el objeto con la informacion enviada
                Reservation _reservation = _reservationDAO.FindById(_reservationId);
                Receiver = _reservation;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetReservationById exception = new CommandExceptionGetReservationById(
                    ReservationErrors.CommandExceptionGetReservationByIdCode,
                    ReservationResources.ClassNameGetReservationById,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ReservationErrors.MessageCommandExceptionGetReservationById,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                Reservation _reservation = EntityFactory.GetReservation();
                Receiver = _reservation;

                
            }
            catch (Exception ex)
            {
                CommandExceptionGetInvoice exception = new CommandExceptionGetInvoice(
                    ReservationErrors.CommandExceptionGetReservationByIdCode,
                    ReservationResources.ClassNameGetReservationById,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ReservationErrors.MessageCommandExceptionGetReservationById,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                Invoice _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;

            }

            Logger.WriteSuccessLog(ReservationResources.ClassNameGetReservationById
                , ReservationResources.SuccessMessageCommandGetReservationById
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }
    }
}
