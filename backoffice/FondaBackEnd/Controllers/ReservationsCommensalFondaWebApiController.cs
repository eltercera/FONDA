using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.FondaBackEnd.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]

    /// <summary>
    /// favorites restaurants fonda web API controller.
    /// </summary>
    public class ReservationsCommensalFondaWebApiController : FondaWebApi
    {
        private Commensal commensal;
        private Reservation reservation;
        private ICommand command;

        /// <summary>
        /// constructor de restaurant favoritos fonda web API controller.
        /// </summary>
        public ReservationsCommensalFondaWebApiController() : base() { }

    

        /// <summary>
        /// metodo que lista las reservaciones de un commensal
        /// </summary>
        /// <param name="idCommensal"></param>
        /// <returns>result.Reservations</returns>

        [Route("findCommensalReservations")]
        [HttpGet]
        [FondaAuthToken]
        public IHttpActionResult findCommensalReservations()
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            IList<Reservation> result;
            try
            {
                Commensal commensal = GetCommensal(Request.Headers);
                //Creación del commensal con id
       //         commensal = EntityFactory.GetCommensal();
             //   commensal.Id = idCommensal;

                // Obtención del commando
                command = FacCommand.GetCommensalReservationsCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (IList<Reservation>)command.Result;
                 
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 GeneralRes.CommensalReservation + commensal.Email,
                System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalReservationsFondaCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindCommensalReservationsFondaWebApiControllerException(GeneralRes.GetCommensalReservationsException,
                    e);

            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindCommensalReservationsFondaWebApiControllerException(GeneralRes.GetCommensalReservationsException,
                    e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                /*throw new FindCommensalReservationsFondaWebApiControllerException(GeneralRes.GetFavoriteRestaurantException, 
                    e);*/
                FindCommensalReservationsFondaWebApiControllerException error = new FindCommensalReservationsFondaWebApiControllerException("prueba");
                return InternalServerError(error);

            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }

        /// <summary>
        /// metodo que busca la existencia de un commensal
        /// </summary>
        /// <param name="email"></param>
        /// <returns>result</returns>

        [Route("findCommensalEmail/{email}")]
        [HttpGet]
        public IHttpActionResult findCommensalEmail(string email)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            UserAccount result;
            try
            {
                UserAccount commensal = EntityFactory.GetUserAccount();
                commensal.Email = email;
                // Obtención del commando
                command = FacCommand.GetCommensalEmailCommand();
                // Agregacion de parametros
                command.SetParameter(0, commensal);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (UserAccount)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.CommensalEmail + commensal.Email, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalEmailCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException,
                    e);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException,
                    e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException,
                    e);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }

        /// <summary>
        /// metodo que agrega un restaurant favorito de un comensal
        /// </summary>
        /// <param name=reservation></param>
        /// <param name="reservation"></param>
        /// <returns>result</returns>

        [Route("reservation")]
        [HttpPost]
        [FondaAuthToken]
        ///[FondaAuthToken]
        public IHttpActionResult addreservation(Reservation reservation)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Commensal result;
            try
            {

                //Obtenemos al commensal
                Commensal commensal = GetCommensal(Request.Headers);
                if (commensal == null)
                    return BadRequest();

                //Obetenmos el commando
                ICommand command = FacCommand.GetCreateCommensalReservationCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);
                command.SetParameter(1, reservation);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (Commensal)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.RestAddedToFav + commensal.Id + GeneralRes.Slash + reservation.Id,
                  System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (CreateCommensalReservationCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                CreateCommensalReservationCommandException error = new
                    CreateCommensalReservationCommandException(GeneralRes.AddFavRestException, e);
                return InternalServerError(error);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                CreateCommensalReservationCommandException error = new
                    CreateCommensalReservationCommandException(GeneralRes.AddFavRestException, e);
                return InternalServerError(error);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

                CreateCommensalReservationCommandException error = new
                    CreateCommensalReservationCommandException(GeneralRes.AddFavRestException, e);
                return InternalServerError(error);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Created("", result);
        }

    }
}