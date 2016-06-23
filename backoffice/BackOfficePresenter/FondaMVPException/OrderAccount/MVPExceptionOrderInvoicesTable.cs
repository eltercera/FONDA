using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException
{
    public class MVPExceptionOrderInvoicesTable : MVPException
    {
        #region Constructors

        public MVPExceptionOrderInvoicesTable(string message, Exception ex) : base(message, ex)
        {
        }

        public MVPExceptionOrderInvoicesTable(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
