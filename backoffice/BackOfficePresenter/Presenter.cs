using com.ds201625.fonda.View.BackOfficeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter
{
    public class Presenter
    {
        private IContract _view;

        public Presenter(IContract page)
        {
            _view = page;
        }

        public void SuccessLabel(string message)
        {
            _view.SuccessLabel.Visible = true;
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabelMessage.Text = message;
        }

        public void ErrorLabel(string message)
        {
            _view.ErrorLabel.Visible = true;
            _view.SuccessLabel.Visible = false;
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

        public bool validaFechaNac(DateTime fechaF)
        {
            DateTime FechAc = DateTime.Now.Date;
            if (fechaF >= FechAc) // Si la fecha indicada es menor o igual a la fecha actual
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }


    }
}
