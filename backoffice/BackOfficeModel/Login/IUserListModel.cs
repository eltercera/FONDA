using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BackOfficeModel.Login
{
    public interface IUserListModel : IModel
    {
         HtmlGenericControl userListAlert { get; set; }
         Table tableUserList { get; set; }
        TextBox textBoxNameUser { get; set; }
        TextBox textBoxlastNameUser { get; set; }
        DropDownList dropDownListNss1 { get; set; }
        TextBox textBoxNss2 { get; set; }
        TextBox textBoxAddress { get; set; }
        TextBox textBoxEmail { get; set; }
        TextBox textBoxPhoneNumber { get; set; }
        TextBox textBoxBirtDate { get; set; }
        DropDownList DropDownListRole { get; set; }
        DropDownList DropDownListGender { get; set; }
        TextBox textBoxPaswword { get; set; }
        TextBox textBoxRepitPaswword { get; set; }
        TextBox textBoxUserNameU { get; set; }
        Button buttonButtonAddModify { get; set; }

        DropDownList dropDownListRestaurant { get; set; }
    }
}
