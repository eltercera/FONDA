using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaBeckEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic.ReservationManager
{ 
    /// <summary>
    /// Create Favorite Restaurant Command.
    /// </summary>
    class CreateCommensalReservationCommand : BaseCommand 
    {

        private Commensal commensal;
        private Reservation reservation;
        private ICommensalDAO commensalDAO;
        private IReservationDAO reservationDAO;
  

        /// <summary>
        /// constructor create Commensal Reservation command
        /// </summary>
         public CreateCommensalReservationCommand() : base() { }
         
         /// <summary>
         /// metodo que inicializa los parametros
         /// </summary>
         /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 2 Parametros
            Parameter[] paramters = new Parameter[2];

            // [0] el Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            // [1] La Reservacion
            paramters[1] = new Parameter(typeof(Reservation), true);
            return paramters;
        }

        /// <summary>
        /// metodo invoke que ejecuta el agregar reservacion
        /// </summary>
		protected override void Invoke()
		{
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            // Obtencion de parametros
            Commensal  idCommensal = (Commensal)GetParameter(0);
            Reservation idReservation = (Reservation)GetParameter(1);
       
            // Obtiene el DAO que se requiere
            commensalDAO = FacDao.GetCommensalDAO();
            reservationDAO = FacDao.GetReservationDAO();
      

            if ((idCommensal.Id <= 0) || (idReservation.Id <= 0))
                throw new Exception(ResourceMessages.InvalidInformation);
           
            // Ejecucion del agregar.		
			try
			{
                commensal  = (Commensal)commensalDAO.FindById(idCommensal.Id);
                reservation = (Reservation)reservationDAO.FindById(idReservation.Id);
                commensal.Reservations.Remove(reservation);
                commensal.Reservations.Add(reservation); ;
                commensalDAO.Save(commensal);
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                    ResourceMessages.ReservationAdded + commensal.Id + ResourceMessages.Slash + reservation.Number,
                   System.Reflection.MethodBase.GetCurrentMethod().Name);
               
            }
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateCommensalReservationCommandException(ResourceMessages.ParametersCreateCommensalReservationException, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateCommensalReservationCommandException(ResourceMessages.ParametersCreateCommensalReservationException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateCommensalReservationCommandException(ResourceMessages.ParametersCreateCommensalReservationException, e);
            }
			catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateCommensalReservationCommandException(ResourceMessages.CreateCommensalReservationException, e);
               
			}
			catch (Exception e)
			{
               Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw new CreateCommensalReservationCommandException(ResourceMessages.CreateCommensalReservationException, e);
			}
            // Guarda el resultado.
            Result = commensal;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                Result.ToString(),System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceMessages.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
		}
	}
}
  