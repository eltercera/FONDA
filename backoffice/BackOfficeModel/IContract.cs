using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel
{
    public interface IContract
    {
        string SessionRestaurant { get; set; }

        HtmlGenericControl SuccessLabel { get; }

        Label SuccessLabelMessage { get; set; }

        HtmlGenericControl ErrorLabel { get; }

        Label ErrorLabelMessage { get; set; }

      


    }
}
