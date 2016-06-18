using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOfficeModel.Menu;

namespace com.ds201625.fonda.BackOffice.Presenter.Menu
{
    public class MenuCategoriaPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IMenuCategory _view;
        int totalColumns = 3;

        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewMenuCategory">Interfaz</param>
        public MenuCategoriaPresenter(IMenuCategory page) : base(page)
        {
            _view = page;
        }
    }
}
