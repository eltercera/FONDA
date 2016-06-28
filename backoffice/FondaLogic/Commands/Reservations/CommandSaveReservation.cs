using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations
{
    // comando que guarda una reservacion en la bd
    class CommandSaveReservation : Command
    {
        // fabrica que me dara dao que contiene metodo a encapsular en este comando
        FactoryDAO _facDAO = FactoryDAO.Intance;
        // reservacion a guardar en la bd
        Reservation _reservation;

        /// <summary>
        /// metodo constructor del comando
        /// </summary>
        /// <param name="receiver">reservacion que se quiere guardar en la bd</param>
        public CommandSaveReservation(Object receiver) : base(receiver)
        {
            try
            {
                _reservation = (Reservation)receiver;
            }
            catch (Exception)
            {
                //TODO Reservation: Enviar excepcion personalizada
                throw;
            }
        }

       
        /// <summary>
        /// metodo que se ejecuta para guardar el la reservacion
        /// </summary>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IReservationDAO _reservationDAO = _facDAO.GetReservationDAO();

                // se ejecuta metodo del dao para guardar useraccount
                _reservationDAO.Save(_reservation);

            }
            //TODO Reservation: Personalizar estas excepciones
            // se capturan excecpciones que pueden ser generadas en la capa de acceso a datos
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(Resources.FondaResources.Login.Errors.ClassNameSaveEmployee, e);

            }
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(Resources.FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(Resources.FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(Resources.FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(Resources.FondaResources.Login.Errors.ClassNameSaveEmployee, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveUserAccount(Resources.FondaResources.Login.Errors.ClassNameSaveEmployee, e);
            }
            // Guarda el resultado.
            Reservation Result = _reservation;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resources.FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }


    }
}
