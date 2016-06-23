using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class ReservationFondaWebApiController : FondaWebApi
    {
        public ReservationFondaWebApiController() : base() { }

        [Route("reservation")]
        [HttpGet]
        [FondaAuthToken]
        public IHttpActionResult getReservation()
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            return Ok(commensal.Reservations);
        }

        [Route("reservation")]
        [HttpPost]
        [FondaAuthToken]
        public IHttpActionResult postReservation(Reservation reservation)
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            ICommensalDAO commensalDAO = FactoryDAO.GetCommensalDAO();

            if (reservation.ReserveDate == null || reservation.CreateDate == null || reservation.CommensalNumber == null)
                return BadRequest();

            reservation.ReserveStatus = FactoryDAO.GetActiveReservationStatus();
            reservation.ReserveUser.Status = FactoryDAO.GetActiveSimpleStatus();
            reservation.ReserveTable.Status = FactoryDAO.GetFreeTableStatus();
            reservation.ReserveRestaurant.Status = FactoryDAO.GetActiveSimpleStatus();
            commensal.Reservations.Add(reservation);


            try
            {
                commensalDAO.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            return Created("", reservation);
        }


        [Route("reservation/{id}")]
        [HttpDelete]
        [FondaAuthToken]
        public IHttpActionResult deleteReservation(int id)
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            ICommensalDAO commensalDAO = FactoryDAO.GetCommensalDAO();

            Reservation reservation = GetReservationDao().FindById(id);
            if (!commensal.Reservations.Contains(reservation))
                return BadRequest();

           // commensal.Reservations.Remove(reservation);
            reservation.ReserveStatus = FactoryDAO.GetCanceledReservationStatus();
            try
            {
                commensalDAO.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            return Ok();
        }

        private IReservationDAO GetReservationDao()
        {
            return FactoryDAO.GetReservationDAO();
        }
    }
}