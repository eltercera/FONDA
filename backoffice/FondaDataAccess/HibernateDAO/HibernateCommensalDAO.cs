using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.DataAccess.Log;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateCommensalDAO : HibernateUserAccountDAO,ICommensalDAO
	{

        #region Reservation

        /// <summary>
        /// Clase que tiene el manejo de los metodos de la base de datos de Commensal
        /// </summary>
        private FactoryDAO.FactoryDAO _facDAO;

        public HibernateCommensalDAO()
        {
            this._facDAO = FactoryDAO.FactoryDAO.Intance;
        }
        


        /// <summary>
        /// Busca un commensal por una reservacion
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>Commensal</returns>
        public Commensal GetCommensalByReservation(int reservationId)
        {
            IList<object> _listCommensal = new List<object>();
            IList<Reservation> _listReservation = new List<Reservation>();
            Commensal _commensal = EntityFactory.GetCommensal();
            ICommensalDAO _commensalDAO = _facDAO.GetCommensalDAO();
            //  Restaurant _restaurant;
            // _restaurantDAO = _facDAO.GetRestaurantDAO();
            try
            {
                _listCommensal = _commensalDAO.GetAll();

                foreach (Commensal commensal in _listCommensal)
                {
                    _listReservation = commensal.Reservations;
                    foreach (Reservation _reservation in _listReservation)
                    {
                        if (reservationId.Equals(_reservation.Id))
                        {
                           _commensal = commensal;
                        }
                    }
                }
               

               }
            //Todo Reservation: Personalizar
            catch (Exception ex)
            {
                GetOrderAccountFondaDAOException exception = new GetOrderAccountFondaDAOException(
                    OrderAccountResources.MessageCanceledInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageGetOrderAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _commensal;
        }

        #endregion


    }
}

