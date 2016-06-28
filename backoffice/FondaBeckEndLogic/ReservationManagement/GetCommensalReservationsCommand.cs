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


namespace com.ds201625.fonda.BackEndLogic.ReservationManagement
{
    /// <summary>
    /// Get Commensal Reservations Command.
    /// </summary>
    class GetCommensalReservationsCommand : BaseCommand
    {
        private IList<Reservation> listReservation;
        private ICommensalDAO CommensalDAO;
        private Commensal commensal;
        private IList<Reservation> reservations;
      

        /// <summary>
        /// constructor obtener Reservations command
        /// </summary>
        public GetCommensalReservationsCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 1 Parametros
            Parameter[] paramters = new Parameter[1];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            return paramters;
		}

        /// <summary>
        /// metodo invoke que ejecuta el buscar reservaciones de un comensal
        /// </summary>
		protected override void Invoke()
		{
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

             
            // Obtencion de parametros
            commensal = (Commensal)GetParameter(0);
            // Obtiene el dao que se requiere
            CommensalDAO = FacDao.GetCommensalDAO();

              if (commensal.Id <= 0)
                throw new Exception(ResourceMessages.InvalidInformation);

            try
            {
               commensal = (Commensal)CommensalDAO.FindById(commensal.Id);
               reservations = commensal.Reservations;
            
                            
                    Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                      ResourceMessages.Commensal + commensal.Id + ResourceMessages.Slash +
                      commensal.Email, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.ParametersGetFavRestException, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.ParametersGetFavRestException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.ParametersGetFavRestException, e);
            }
            catch (FindByIdFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurantException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurantException, e);
            }
            // Guardar el resultado.
               Result = reservations;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
		}
	}
}