using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException.Restaurant
{
    public class MVPExceptionFillDropdown : MVPException
    {
        #region Constructors

        public MVPExceptionFillDropdown(string message, Exception ex) : base(message, ex)
        {
        }

        public MVPExceptionFillDropdown(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion

    }
}
