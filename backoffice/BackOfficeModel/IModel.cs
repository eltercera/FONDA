using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOfficeModel
{
    public interface IModel
    {
        string SessionRestaurant { get; set; }

        Label SuccessLabelMessage { get; set; }

        Label ErrorLabelMessage { get; set; }


    }
}
