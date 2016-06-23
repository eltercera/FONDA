using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException 
{
    public class MVPExceptionCloseButton : MVPException
    {
        #region Constructors

        public MVPExceptionCloseButton(string message, Exception ex) : base(message, ex)
        {
        }
        public MVPExceptionCloseButton(string message) : base(message)
        {
        }
        public MVPExceptionCloseButton(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
