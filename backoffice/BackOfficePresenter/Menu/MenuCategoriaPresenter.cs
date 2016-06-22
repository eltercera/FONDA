using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.View.BackOfficeModel.Menu;

namespace com.ds201625.fonda.View.BackOfficePresenter.Menu
{
    public class MenuCategoriaPresenter : Presenter
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
