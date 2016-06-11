using BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BackOfficePresenter.OrderAccount
{
    public class ClosedOrdersPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IClosedOrdersModel _view;


        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewClosedOrders">Interfaz</param>

        public ClosedOrdersPresenter(IClosedOrdersModel viewClosedOrders)
            : base(viewClosedOrders)
        {
            //Enlace Modelo - Vista
            _view = viewClosedOrders;
        }

        ///<summary>
        ///Metodo para llenar la tabla de Ordenes Cerradas
        /// </summary>
        public void GetOrders(string restaurantId)
        {
            int result;
            //Define objeto a recibir
            IList<Account> listAccount;
            //Objeto a enviar como parametro
            Restaurant res = null;
            //Invoca al comando
            Command commandCloseOrder;

            try
            {
                //Obtener el parametro
                if (int.TryParse(restaurantId, out result))
                {
                    res = (Restaurant)EntityFactory.GetRestaurant();
                    res.Id = result;
                }
            }
            catch
            { }
                //Instancia del comando
                //commandCloseOrder = CommandFactory.GetCommandCloseOrder;
            
                
        }
    }


}
