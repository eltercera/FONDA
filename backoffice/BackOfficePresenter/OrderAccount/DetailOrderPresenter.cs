using BackOfficeModel.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficePresenter.OrderAccount
{
    public class DetailOrderPresenter : Presenter
    {
        //Enlace Modelo - Vista
        private IDetailOrderModel _view;


        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewDetailOrder">Interfaz</param>

        public DetailOrderPresenter(IDetailOrderModel viewDetailOrder)
            : base(viewDetailOrder)
        {
            //Enlace Modelo - Vista
            _view = viewDetailOrder;
        }
    }
}
