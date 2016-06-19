using BackOfficeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackOfficePresenter
{
    public class Presenter
    {
        private IModel _view;

        public Presenter(IModel page)
        {
            _view = page;
        }

        public void SuccessLabel(string message)
        {
            _view.SuccessLabel.Visible = true;
            _view.SuccessLabelMessage.Text = message;
        }

        public void ErrorLabel(string message)
        {
            _view.ErrorLabel.Visible = true;
            _view.ErrorLabelMessage.Text = message;
        }
        public bool validaString(string expresionRegular,string evalua)
        {
            if ((!Regex.IsMatch(evalua, expresionRegular)))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Limpia las filas de la tabla
        /// </summary>
        public void CleanTable(System.Web.UI.WebControls.Table table)
        {
            table.Rows.Clear();

        }

        public void HideMessageLabel()
        {
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;
        }
    }
}
