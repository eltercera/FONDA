using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficePresenter.FondaMVPException.OrderAccount
{
    public class MVPExceptionPrintInvoice : MVPException
    {
        #region Constructors

        public MVPExceptionPrintInvoice(string message, Exception ex) : base(message, ex)
        {
        }
        public MVPExceptionPrintInvoice(string message) : base(message)
        {
        }
        public MVPExceptionPrintInvoice(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
