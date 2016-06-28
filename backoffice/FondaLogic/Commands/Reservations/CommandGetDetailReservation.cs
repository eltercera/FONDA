using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
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
    public class CommandGetDetailReservation : Command
    {
        private int _reservationId;
        private Table _table;
        private int _tableId;

        public CommandGetDetailReservation(Object receiver) : base(receiver) { }
       
        public override void Execute()
        {
            //Invoca al comando
            Command commandGetReservationById;
            //Command commandGetCommensalByReservation;
            Command commandGetTableByReservation;
            Command commandGetRestaurantByTable;

            try
            {
                _reservationId = (int)Receiver;

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetReservationById = CommandFactory.GetCommandGetReservationById(_reservationId);
                //commandGetCommensalByReservation = CommandFactory.GetCommandGetCommensalByReservation(_reservationId);
                commandGetTableByReservation = CommandFactory.GetCommandGetTableByReservation(_reservationId);
                //Ejecuta el comando deseado
                commandGetReservationById.Execute();
                commandGetTableByReservation.Execute();
                _table = (Table)commandGetTableByReservation.Receiver;
                _tableId = _table.Id;

                commandGetRestaurantByTable = CommandFactory.GetCommandGetRestaurantByTable(_tableId);
                commandGetRestaurantByTable.Execute();
                //commandGetCommensalByReservation.Execute();
                //Respuesta a devolver
                Receiver = new List<Object>
                    {
                        commandGetReservationById.Receiver,
                        //commandGetCommensalByReservation.Receiver,
                        commandGetTableByReservation.Receiver,
                        commandGetRestaurantByTable.Receiver
                    };

            }
            catch (Exception ex)
            {
                CommandExceptionGetDetailReservation exception = new CommandExceptionGetDetailReservation(
                    ReservationErrors.CommandExceptionGetDetailReservationCode,
                    ReservationResources.ClassNameGetDetailReservation,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ReservationErrors.MessageCommandExceptionGetDetailReservation,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }
        }
    }
}

  
