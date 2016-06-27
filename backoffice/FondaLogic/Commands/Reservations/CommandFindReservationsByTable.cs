using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations
{
    public class CommandFindReservationsByTable : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _tableId = 0;

        public CommandFindReservationsByTable(Object receiver) : base(receiver)
        {
            try
            {
                _tableId = (int)receiver;
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
                IReservationDAO _reservationDAO;
                //Obtengo la instancia del DAO a utilizar
                _reservationDAO = _facDAO.GetReservationDAO();
                //Obtengo el objeto con la informacion enviada
                IList<Reservation> listReservations = _reservationDAO.FindReservationsByTable(_tableId);
                Receiver = listReservations;

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
