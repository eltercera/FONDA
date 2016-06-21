using BackOfficeModel.OrderAccount;
using BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using FondaLogic;
using FondaLogic.Factory;
using FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class DetailOrderPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IDetailOrderModel _view;
        int totalColumns = 3;
        string _currency = null;


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

        ///<summary>
        ///Metodo para llenar la tabla de Ordenes Cerradas
        /// </summary>
        public void GetDetailOrder()
        {


            int result;
            //Define objeto a recibir
            IList<DishOrder> listDishOrder;
            Account _order;
            //Invoca al comando
            Command commandDetailOrder;
            Command commandGetOrder;
            Command commandGetCurrency;

            try
            {
                result = GetQueryParameter();
                int restaurantId = int.Parse(_view.SessionRestaurant);

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandDetailOrder = CommandFactory.GetDetailOrder(result);
                commandGetOrder = CommandFactory.GetCommandGetOrder(result);
                commandGetCurrency = CommandFactory.GetCommandGetCurrency(restaurantId);

                //Ejecuta el comando deseado
                commandDetailOrder.Execute();
                commandGetOrder.Execute();
                commandGetCurrency.Execute();

                //Se obtiene el resultado de la operacion
                listDishOrder = (IList<DishOrder>)commandDetailOrder.Receiver;
                _order = (Account)commandGetOrder.Receiver;
                _currency = (string)commandGetCurrency.Receiver;
                _view.SessionNumberAccount = _order.Number.ToString();

                //Revisa si la lista no esta vacia
                if (listDishOrder != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(listDishOrder);
                }

            }
            catch (MVPExceptionDetailOrderTable ex)
            {
                //Revisar
                MVPExceptionDetailOrderTable e = new MVPExceptionDetailOrderTable
                    (
                        Errors.MVPExceptionDetailOrderTableCode,
                        Errors.ClassNameDetailOrderPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        Errors.MessageMVPExceptionDetailOrderTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                throw e;
                ErrorLabel(e.MessageException);
            }
        }

        private void FillTable(IList<DishOrder> data)
        {
            HideMessageLabel();
            CleanTable(_view.DetailOrderTable);

            int totalRows = data.Count; //tamano de la lista 
            float total = 0;

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes[OrderAccountResources.dataId] = 
                    data[i].Id.ToString();
                //Agrega la fila a la tabla existente
                _view.DetailOrderTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();

                    //Agrega el plato
                    if (j.Equals(0))
                        tCell.Text = data[i].Dish.Name.ToString();

                    //Agrega la cantidad del pedido del plato
                    else if (j.Equals(1))
                        tCell.Text = data[i].Count.ToString();

                    //Agrega el costo del plato
                    else if (j.Equals(2))
                        tCell.Text = (_currency + " " + data[i].Dishcost.ToString());

                    //Agrega el total (precio*cantidad)
                    else if (j.Equals(3))
                    {
                        total = data[i].Count * data[i].Dishcost;
                        tCell.Text = (_currency + " " + total.ToString());
                        total = 0;
                    }

                    //Agrega la celda a la fila
                    tRow.Cells.Add(tCell);
                }
            }

                //Agrega el encabezado a la Tabla
                TableHeaderRow header = GenerateTableHeader();
                _view.DetailOrderTable.Rows.AddAt(0, header);
            
        }

        /// <summary>
        /// Genera el encabezado de la tabla que contiene el detalle
        /// de una orden
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = OrderAccountResources.DishNameColum;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = OrderAccountResources.QuantityColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = OrderAccountResources.PriceColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = OrderAccountResources.TotalColumn;
            h4.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);

            return header;
        }

        private int GetQueryParameter()
        {
            int result = 0;
            string queryParameter = 
                HttpContext.Current.Request.QueryString["Id"];


            if(queryParameter != null && queryParameter != string.Empty)
            {
                return int.Parse(queryParameter);
            }

            return result;
        }


    }
}
