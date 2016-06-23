using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.BackEnd.Exceptions;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.FondaBackEnd.Exceptions;

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
        public IHttpActionResult GetTotalAccount(int restaurantId, int orderId)
        {
            float totalAccount = 0.0F;
            IList<int> _list = new List<int>();
            try
            {
                Command _command;
                _list.Add(restaurantId); //1
                _list.Add(orderId); //3
                _command = CommandFactory.GetCommandTotalOrder(_list);
                _command.Execute();
                totalAccount = (float)_command.Receiver;


            }
            catch (CommandExceptionTotalOrder e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetTotalAccountException ex = new GetTotalAccountException(OrderAccountResources.MessageGetTotalAccountException, e);

                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(ex.Message, ex);
                return InternalServerError(ex);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetTotalAccountException ex = new GetTotalAccountException(OrderAccountResources.MessageGetTotalAccountException, e);

                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(ex.Message, ex);
                return InternalServerError(ex);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, totalAccount.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

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
        [Route("restaurant/{restaurantId}/order/{orderId}/profile/{profileId}")]
        [FondaAuthToken]
        public IHttpActionResult PayAccount(int restaurantId, int orderId, int profileId, Payment payment)
        {
            Invoice invoice = EntityFactory.GetInvoice();
            List<Object> parameters = new List<object>();
            Command pay;


            try
            {
                Commensal commensal = GetCommensal(Request.Headers);
                parameters.Add(restaurantId);
                parameters.Add(orderId);
                parameters.Add(profileId);
                parameters.Add(payment);
                parameters.Add(commensal);

                pay = CommandFactory.GetCommandPayOrder(parameters);
                pay.Execute();
                invoice = (Invoice) pay.Receiver;
               
            }
            catch (PayAccountException ex)
            {
                PayAccountException e = new PayAccountException(OrderAccountResources.MessagePayAccountException);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }
            catch (Exception ex)
            {
                PayAccountException e = new PayAccountException(OrderAccountResources.MessagePayAccountException);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, invoice.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Created("",invoice);
        }

        /// <summary>
        /// Servicio web que devuelve una lista de facturas de un perfil
        /// </summary>
        /// <returns>Lista de Invoice</returns>
        [HttpPost]
        [Route("profile/{profileId}/invoices")]
        [FondaAuthToken]
        public IHttpActionResult GetPaymentHistory(int profileId)
        {
            IList<Invoice> paymentHistory = new List<Invoice>();
            List<Object> parameters = new List<object>();
            Command command;

            try
            {
                Commensal commensal = GetCommensal(Request.Headers);
                parameters.Add(profileId);
                parameters.Add(commensal);

                command = CommandFactory.GetCommandGetPaymentHistoryByProfile(parameters);

                paymentHistory = (IList<Invoice>)command.Receiver;
            }
            catch (CommandExceptionGetPaymentHistoryByProfile ex)
            {
                GetPaymentHistoryByProfileException e = new GetPaymentHistoryByProfileException(OrderAccountResources.MessageGetPaymentHistory);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }
            catch (Exception ex) {
                GetPaymentHistoryByProfileException e = new GetPaymentHistoryByProfileException(OrderAccountResources.MessageGetPaymentHistory);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, paymentHistory.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

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
                Command _command;
                _command = CommandFactory.GetCommandGetDishOrdersByAccountId(orderId);
                _command.Execute();
                orderDetail = (List<DishOrder>)_command.Receiver;


            }
            catch (GetOrderDetailException ex)
            {
                GetOrderDetailException e = new GetOrderDetailException(OrderAccountResources.MessageGetOrderDetailException);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }
            catch (Exception ex)
            {
                GetOrderDetailException e = new GetOrderDetailException(OrderAccountResources.MessageGetOrderDetailException);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, orderDetail.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(orderDetail);
        }

        [HttpGet]
        [Route("restaurant/{restaurantId}/order/{orderId}/invoice/{invoiceId}")]
        [FondaAuthToken]
        public IHttpActionResult CanceledInvoice(int restaurantId, int orderId, int invoiceId)
        {
            List<int> _list = new List<int>();
            Command _command;
            Invoice _invoice = EntityFactory.GetInvoice();

            try
            {
                //Comando para anular factura 
                _list.Add(invoiceId);//1
                _list.Add(orderId);// 2
                _command = CommandFactory.GetCommandCancelInvoiced(_list);
                _command.Execute();
                _invoice = (Invoice)_command.Receiver;
            }
            catch (CanceledInvoiceException ex)
            {
                CanceledInvoiceException e = new CanceledInvoiceException(OrderAccountResources.MessageGetOrderDetailException);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }
            catch (Exception ex)
            {
                CanceledInvoiceException e = new CanceledInvoiceException(OrderAccountResources.MessageGetOrderDetailException);
                com.ds201625.fonda.Logic.FondaLogic.Log.Logger.WriteErrorLog(e.Message, e);
                return InternalServerError(ex);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, _invoice.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(_invoice);
        }


    }
}