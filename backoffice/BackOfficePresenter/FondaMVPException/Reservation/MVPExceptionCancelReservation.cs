using System;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException.Reservations
{
    public class MVPExceptionCancelReservation : MVPException
    {
        #region Constructors

        public MVPExceptionCancelReservation(string message, Exception ex) : base(message, ex)
        {
        }
        public MVPExceptionCancelReservation(string message) : base(message)
        {
        }
        public MVPExceptionCancelReservation(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
