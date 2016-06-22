using BackOfficeModel.OrderAccount;
using BackOfficePresenter.FondaMVPException;
using BackOfficePresenter.FondaMVPException.OrderAccount;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security.AntiXss;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class DetailOrderPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IDetailOrderModel _view;
        int totalColumns = 3;
        string currency;


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

            //Define objeto a recibir
            IList<DishOrder> listDishOrder;
            Account order;

            int orderId, restaurantId;
            List<int> parameters;
            List<Object> result;
            Command commandGetDetailOrder;

            try
            {
                orderId = GetQueryParameter();
                restaurantId = int.Parse(_view.SessionRestaurant);



                //Recibe 2 enteros
                // 1  son el numero de la orden
                // 2 es el id del restaurant                
                parameters = new List<int> { orderId, restaurantId };
                commandGetDetailOrder = CommandFactory.GetCommandGetDetailOrder(parameters);

                //Ejecuta el comando
                commandGetDetailOrder.Execute();

                //Recibe el resultado de la operacion
                result = (List<Object>)commandGetDetailOrder.Receiver;

                listDishOrder = (IList<DishOrder>)result[0];
                order = (Account)result[1];
                currency = (string)result[2];

                //Variables de sesion, no deberian estar vacias
                //El metodo getqueryparam url tiene una falla, deberia ser transparente para el usuario el id de la orden
                //Deberia mostrarse es el number de la account y junto con el restaurante devolver la orden correspondiente
                //Igual pasa con factura
                //Esto implica cambiar el metodo que te devuelve la factura
                _view.SessionNumberAccount = order.Number.ToString();


                //Revisa si la lista no esta vacia
                if (listDishOrder != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(listDishOrder);
                }
            }
            catch (MVPExceptionDetailOrderTable ex)
            {
                MVPExceptionDetailOrderTable e = new MVPExceptionDetailOrderTable
                    (
                        OrderAccountResources.MVPExceptionDetailOrderTableCode,
                        OrderAccountResources.ClassNameDetailOrderPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionDetailOrderTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
            catch (FormatException ex)
            {
                MVPExceptionQuery e = new MVPExceptionQuery
                    (
                        OrderAccountResources.MVPExceptionQueryCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionQuery,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                HttpContext.Current.Server.ClearError();
                HttpContext.Current.Response.Redirect(OrderAccountResources.allOrdersURL);
            }
            catch (HttpRequestValidationException ex)
            {
                MVPExceptionDetailOrderTable e = new MVPExceptionDetailOrderTable
                    (
                        OrderAccountResources.MVPExceptionDetailOrderTableCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionOrderInvoicesTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                HttpContext.Current.Server.ClearError();
                HttpContext.Current.Response.Redirect(OrderAccountResources.allOrdersURL);
            }
            catch (Exception ex)
            {
                MVPExceptionDetailOrderTable e = new MVPExceptionDetailOrderTable
                    (
                        OrderAccountResources.MVPExceptionDetailOrderTableCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionOrderInvoicesTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                //Cambiar URL
                HttpContext.Current.Response.Redirect(OrderAccountResources.allOrdersURL);
                ErrorLabel(e.MessageException);
            }


            Logger.WriteSuccessLog(OrderAccountResources.MVPExceptionDetailOrderTableCode
                                    , OrderAccountResources.SuccessMessageDetailOrderPresenter
                                    , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                                    );
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
                        tCell.Text = (currency + " " + data[i].Dishcost.ToString());

                    //Agrega el total (precio*cantidad)
                    else if (j.Equals(3))
                    {
                        total = data[i].Count * data[i].Dishcost;
                        tCell.Text = (currency + " " + total.ToString());
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
                HttpContext.Current.Request.QueryString[OrderAccountResources.QueryParam];

            if (AntiXssEncoder.HtmlEncode(queryParameter, false) != null)
                return int.Parse(queryParameter);

            return result;
        }



    }
}

