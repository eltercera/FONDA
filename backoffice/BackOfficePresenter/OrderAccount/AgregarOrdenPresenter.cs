using BackOfficeModel.OrderAccount;
using BackOfficePresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackOffice.Presenter
{
    public class AgregarOrdenPresenter: BackOfficePresenter.Presenter
    {
        private IAgregarOrdenModel _view;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaAgregarOrden">Interfaz</param>
        public AgregarOrdenPresenter(IAgregarOrdenModel viewOrder)
            : base(viewOrder) 
        {

            _view = viewOrder;

        }
    }
}
