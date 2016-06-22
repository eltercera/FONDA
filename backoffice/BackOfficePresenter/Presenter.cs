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
        /// <summary>
        /// metodo que valida un string con respecto a una expresion regular
        /// </summary>
        /// <param name="expresionRegular">expresion regular a comparar</param>
        /// <param name="evalua">string a evaluar</param>
        /// <returns></returns>
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

        public virtual void HideMessageLabel()
        {
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;
        }
    }
}
