using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOfficeModel.OrderAccount
{
   public interface IAgregarOrdenModel : IModel
    {
        //DropDownList 
        Table TableMenu { get; set; }
    }
}
