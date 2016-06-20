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
            _view.SuccessLabelMessage.Text = message;
        }

        public void ErrorLabel(string message)
        {
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
    }
}
