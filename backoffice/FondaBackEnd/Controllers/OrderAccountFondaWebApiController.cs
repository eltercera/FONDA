using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class OrderAccountFondaWebApiController : FondaWebApi
    {
        public OrderAccountFondaWebApiController() : base() { }
        
        /// <summary>
        /// Servicio web que devuelve el monto total de la orden abierta
        /// </summary>
        /// <param name="restaurantId">Id del Restaurante</param>
        /// <param name="orderId">Id de la orden</param>
        /// <returns>El monto total de la orden</returns>
        [HttpPost]
        [Route("restaurant/{restaurantId}/order/{orderId}")]
        [FondaAuthToken]
        public IHttpActionResult GetOrderAccount(int restaurantId, int orderId)
        {
            float totalAccount = 0.0F;

            try
            {
                //TODO
                //Invocar a metodos para enviar detalle de orden
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(totalAccount);
        }

        /// <summary>
        /// Servicio web que realiza el pago de una cuenta abierta
        /// </summary>
        /// <param name="restaurantId">Id del Restaurante</param>
        /// <param name="orderId">Id de la orden</param>
        /// <param name="payment">Pago del usuario</param>
        /// <returns>Invoice emitida por el Restaurante</returns>
        [HttpPost]
        [Route("restaurant/{restaurantId}/order/{orderId}")]
        [FondaAuthToken]
        public IHttpActionResult PayAccount(int restaurantId, int orderId, Payment payment)
        {
            Invoice invoice = EntityFactory.GetInvoice();

            try
            {
                //TODO
                //Invocar a metodos para pagar orden
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(invoice);
        }

        /// <summary>
        /// Servicio web que devuelve una lista de facturas de un perfil
        /// </summary>
        /// <returns>Lista de Invoice</returns>
        [HttpGet]
        [Route("profile/invoices")]
        [FondaAuthToken]
        public IHttpActionResult GetPaymentHistory()
        {
            List<Invoice> paymentHistory = new List<Invoice>();

            try
            {
                //TODO
                //Invocar a metodos para devolver historial de pagos
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(paymentHistory);
        }

        /// <summary>
        /// Servicio web que devuelve el detalle de una orden
        /// </summary>
        /// <param name="restaurantId">Id del Restaurante</param>
        /// <param name="orderId">Id de la Orden</param>
        /// <returns>Lista de DishOrder</returns>
        [HttpGet]
        [Route("restaurant/{restaurantId}/order/{orderId}")]
        [FondaAuthToken]
        public IHttpActionResult GetOrderDetail(int restaurantId, int orderId)
        {
            List<DishOrder> orderDetail = new List<DishOrder>();

            try
            {
                //TODO
                //Invocar a metodos para devolver el detalle de la orden
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(orderDetail);
        }




    }
}