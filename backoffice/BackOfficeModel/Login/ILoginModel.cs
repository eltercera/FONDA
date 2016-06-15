using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace BackOfficeModel.Login
{
    public interface ILoginModel : IModel
    {
        // login del sistema
        HtmlInputText UserIni { get; set; }
        HtmlInputPassword UserPassword { get; set; }
        HtmlButton Loggin { get; set; }
        //recuperacion de clave
        HtmlInputPassword Password1 { get; set; }
        HtmlInputPassword Password2 { get; set; }
        HtmlInputText UserRecover { get; set; }
        HtmlInputGenericControl RecoverEmail { get; set; }
        // alerts
        HtmlGenericControl alertloginError { get; set; }
        HtmlGenericControl alertwarningLog { get; set; }
        HtmlGenericControl alertinfoLog { get; set; }
        HtmlGenericControl alertsuccessLog { get; set; }
    }
}
