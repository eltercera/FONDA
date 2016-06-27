using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException
{
    public class MVPExceptionReservationsTable : MVPException
    {
        #region Constructors

        public MVPExceptionReservationsTable(string message, Exception ex) : base(message, ex)
        {
        }

        public MVPExceptionReservationsTable(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
