using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations
{
    public class CommandGetAllReservations : Command
    {
        //fabrica de dao que me dara el metodo que se ejecuatara en el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        /// <summary>
        /// constructor de comando, no recibe nada
        /// </summary>
        public CommandGetAllReservations() : base()
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para buscar todas las reservaciones del sistema
        /// </summary>
        /// <returns>List Reservaciones</returns>
        public override void Execute()
        {
            try
            {
                //Metodos para acceder a la BD

                IReservationDAO _reservationDAO = _facDAO.GetReservationDAO();

                // se ejecuta metodo que me devuelve todos los restaurantes
                Receiver = _reservationDAO.GetAll();
            }
            // se capturan excepciones que pueden ser generadas en la capa de acceso a datos
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllReservations(Resources.FondaResources.Reservations.ReservationErrors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllReservations(Resources.FondaResources.Reservations.ReservationErrors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllReservations(Resources.FondaResources.Reservations.ReservationErrors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllReservations(Resources.FondaResources.Reservations.ReservationErrors.ClassNameGetAllReservations, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllReservations(Resources.FondaResources.Reservations.ReservationErrors.ClassNameGetAllReservations, e);
            }
            // Guarda el resultado.
            Object Result = Receiver;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resources.FondaResources.Reservations.ReservationErrors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
