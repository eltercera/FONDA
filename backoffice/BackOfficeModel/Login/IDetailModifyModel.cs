using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace com.ds201625.fonda.View.BackOfficeModel.Login
{
    public interface IDetailModifyModel : IModel
    {
        /// <summary>
        /// metodos get y set de los elementos de la vista DetalleModificar.aspx
        /// a utilizarse en el presentador
        /// </summary>
        Label labelrestauranteemp { get; set; }
        Label labeltelefonoemp { get; set; }
        Label labeldireccionemp { get; set; }
        Label labelemailemp { get; set; }
        Label labelrolemp { get; set; }
        Label labelusuarioemp { get; set; }
        Label labelgeneroemp { get;set;}
        Label labelfechanacemp { get; set; }
        Label labelcedulaemp { get; set; }
        Label labelapellido { get; set; }
        Label labelNombre { get;set;}
        HtmlGenericControl HtmlGenericControlAlert { get; set; }
        TextBox textBoxNameUser { get; set; }
        TextBox textBoxlastNameUser { get; set; }
        DropDownList dropDownListNss1 { get; set; }
        TextBox textBoxNss2 { get; set; }
        TextBox textBoxAddress { get; set; }
        TextBox textBoxEmail { get; set; }
        TextBox textBoxPhoneNumber { get; set; }
        HtmlInputGenericControl textBoxBirtDate { get; set; }
        DropDownList DropDownListRole { get; set; }
        DropDownList DropDownListGender { get; set; }
        TextBox textBoxPaswword { get; set; }
        TextBox textBoxRepitPaswword { get; set; }
        TextBox textBoxUserNameU { get; set; }
        Button buttonButtonAddModify { get; set; }
        DropDownList dropDownListRestaurant { get; set; }
        HtmlGenericControl HtmlGenericControlemessageEmail { get; set; }
        HtmlGenericControl HtmlGenericControlemenssageUsername { get; set; }
        HtmlGenericControl HtmlGenericControlemenssageSsn { get; set; }
        HtmlGenericControl HtmlGenericControlmessageNameUser { get; set; }
        HtmlGenericControl HtmlGenericControlemessageLastName { get; set; }
        HtmlGenericControl HtmlGenericControlemessageDni { get; set; }
        HtmlGenericControl HtmlGenericControlemessagePhone { get; set; }
        HtmlGenericControl HtmlGenericControlemessageAddress { get; set; }
        HtmlGenericControl HtmlGenericControlemessageUser { get; set; }
        HtmlGenericControl HtmlGenericControlemessagePassword1 { get; set; }
        HtmlGenericControl HtmlGenericControlemessagePassword2 { get; set; }
        HtmlGenericControl HtmlGenericControlemessagePasswordEqual { get; set; }
        HtmlGenericControl HtmlGenericControlemessageBirthdate { get; set; }
        HtmlGenericControl HtmlGenericControlemessageEmpty { get; set; }
        HtmlGenericControl HtmlGenericControlemenssageEmail { get; set; }
    }
}
