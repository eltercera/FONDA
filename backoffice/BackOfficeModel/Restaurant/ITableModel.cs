using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.Restaurante
{
    public interface ITableModel : IContract
    {
        //alertar de agregar mesa
        HtmlGenericControl alertSuccess_AddTable { get; set; }
        //alerta de modifcar mesa
        HtmlGenericControl alertSuccess_ModifyTable { get; set; }
        //modal de agregar mesa
        DropDownList dddlCapacityA { get; set; }
        Button buttonCancelA { get; set; }
        Button buttonAdd { get; set; }
        //modal de modificar mesa
        DropDownList dddlCapacityM { get; set; }
        Button buttonModify { get; set; }
        Button buttonCancelM { get; set; }
        //página
        HiddenField tableModifyId { get; set; }
        Table tablePage { get; set; }
    }
}
