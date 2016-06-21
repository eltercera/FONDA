using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BackOfficeModel.Restaurant
{
    public interface ICategoryModel : IModel
    {
        //alertas de agregar categoria 
        HtmlGenericControl alertAddCategoryError { get; set; }
        HtmlGenericControl alertAddCategorySuccess { get; set; }
        //alertas de modificar categoria
        HtmlGenericControl alertModifyCategoryError { get; set; }
        HtmlGenericControl alertModifyCategorySuccess { get; set; }
        //modal modificar categoria
        TextBox nameCategoryM { get; set; }
        Button buttonModificar { get; set; }
        Button buttonCancelarM { get; set; }
        //modal de agregar categoria
        TextBox nameCategoryA { get; set; }
        Button buttonAgregar { get; set; }
        Button buttonCancelarA { get; set; }
        //pagina
        HiddenField categoryModifyId { get; set; }
        Table categoryRest { get; set; }


    }
}
