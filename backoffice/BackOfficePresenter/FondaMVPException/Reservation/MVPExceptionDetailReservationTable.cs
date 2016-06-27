using System;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException
{
    public class MVPExceptionDetailReservationTable : MVPException
    {
        #region Constructors

        public MVPExceptionDetailReservationTable(string message, Exception ex) : base(message, ex)
        {
        }

        public MVPExceptionDetailReservationTable(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
