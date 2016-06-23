using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.Restaurant
{
    public interface IRestaurantModel : IModel
    {
        Table restaurantTable { get; set; }
        HiddenField RestaurantModifyById { get; set; }

        //Modal-Elementos consultar
        TextBox nameConsult { get; set; }
        TextBox categoryConsult { get; set; }
        TextBox nationalityConsult { get; set; }
        TextBox rifConsult { get; set; }
        TextBox currencyConsult { get; set; }
        TextBox addressConsult { get; set; }
        TextBox zoneConsult { get; set; }
        TextBox openingTimeConsult { get; set; }
        TextBox closingTimeConsult { get; set; }

        CheckBox day1Consult { get; set; }
        CheckBox day2Consult { get; set; }
        CheckBox day3Consult { get; set; }
        CheckBox day4Consult { get; set; }
        CheckBox day5Consult { get; set; }
        CheckBox day6Consult { get; set; }
        CheckBox day7Consult { get; set; }

        HtmlImage imageConsult { get; set; }

        Button closeConsult { get; set; }

        //Modal-Elementos modificar
        TextBox nameModify { get; set; }
        TextBox rifModify { get; set; }
        TextBox addressModify { get; set; }
        TextBox longModify { get; set; }
        TextBox latModify { get; set; }
        TextBox showOpeningTimeModify { get; set; }
        TextBox openingTimeModify { get; set; }
        TextBox showClosingTimeModify { get; set; }
        TextBox closingTimeModify { get; set; }

        DropDownList categoryModify { get; set; }
        DropDownList nationalityModify { get; set; }
        DropDownList currencyModify { get; set; }
        DropDownList zoneModify { get; set; }

        CheckBox day1Modify { get; set; }
        CheckBox day2Modify { get; set; }
        CheckBox day3Modify { get; set; }
        CheckBox day4Modify { get; set; }
        CheckBox day5Modify { get; set; }
        CheckBox day6Modify { get; set; }
        CheckBox day7Modify { get; set; }

        HtmlInputFile imageModify { get; set; }

        Button buttonModify { get; set; }
        Button buttonCancelModify { get; set; }


        //Modal-Elementos agregar
        TextBox nameAdd { get; set; }
        TextBox rifAdd { get; set; }
        TextBox addressAdd { get; set; }
        TextBox longAdd { get; set; }
        TextBox latAdd { get; set; }
        TextBox openingTimeAdd { get; set; }
        TextBox closingTimeAdd { get; set; }

        DropDownList categoryAdd { get; set; }
        DropDownList nationalityAdd { get; set; }
        DropDownList currencyAdd { get; set; }
        DropDownList zoneAdd { get; set; }

        CheckBox day1Add { get; set; }
        CheckBox day2Add { get; set; }
        CheckBox day3Add { get; set; }
        CheckBox day4Add { get; set; }
        CheckBox day5Add { get; set; }
        CheckBox day6Add { get; set; }
        CheckBox day7Add { get; set; }

        HtmlInputFile imageAdd { get; set; }

        Button buttonAdd { get; set; }
        Button buttonCancelAdd { get; set; }

        //Alertas
        HtmlGenericControl alertErrorModify { get; set; }
        HtmlGenericControl alertErrorAdd { get; set; }
        HtmlGenericControl alertSuccessAdd { get; set; }
        HtmlGenericControl alertSuccessModify { get; set; }

    }
}
