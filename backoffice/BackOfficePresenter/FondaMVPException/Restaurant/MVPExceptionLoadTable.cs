using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException.Restaurant
{
    public class MVPExceptionLoadTable : MVPException
    {
        #region Constructors

        public MVPExceptionLoadTable(string message, Exception ex) : base(message, ex)
        {
        }

        public MVPExceptionLoadTable(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
