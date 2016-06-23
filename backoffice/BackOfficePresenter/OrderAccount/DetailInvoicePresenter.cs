using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException.OrderAccount;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security.AntiXss;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficePresenter.OrderAccount
{
    public class DetailInvoicePresenter : Presenter
    {
        private IDetailInvoiceContract _view;
        private int totalColumns = 3;
        private int accountId = 0;
        private int invoiceId = 0;
        private int restaurantId = 0;
        private float tip = 0.0F;
        private string _currency = null;
        private float subtotal = 0.0F;
        private Invoice _invoice;
        private CreditCardPayment _creditCardPayment;

        public DetailInvoicePresenter(IDetailInvoiceContract viewInvoiceDetail) : 
            base(viewInvoiceDetail)
        {
            _view = viewInvoiceDetail;
        }

        ///<summary>
        ///Metodo para imprimir la factura
        /// </summary>
        public void PrintInvoice()
        {

            List<int> parameters;
            Command commandPrintInvoice;

            try
            {
                accountId = int.Parse(_view.SessionIdAccount);
                restaurantId = int.Parse(_view.SessionRestaurant);

                //Recibe 2 enteros
                // 1  id de la factura
                // 2  id del restaurant               
                parameters = new List<int> { accountId, restaurantId };
                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandPrintInvoice = CommandFactory.GetCommandPrintInvoice(parameters);

                //Ejecuta el comando deseado
                commandPrintInvoice.Execute();

            }
            catch (MVPExceptionPrintInvoice ex)
            {
                MVPExceptionPrintInvoice e = new MVPExceptionPrintInvoice
                    (
                        OrderAccountResources.MVPExceptionPrintInvoiceCode,
                        OrderAccountResources.ClassNameInvoiceDetailPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionPrintInvoice,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
            catch (Exception ex)
            {
                MVPExceptionDetailOrderTable e = new MVPExceptionDetailOrderTable
                    (
                        OrderAccountResources.MVPExceptionPrintInvoiceCode,
                        OrderAccountResources.ClassNameInvoiceDetailPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionPrintInvoice,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameInvoiceDetailPresenter
                , OrderAccountResources.SuccessPrintInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
            SuccessLabel(OrderAccountResources.SuccessPrintInvoice);
        }

        ///<summary>
        ///Metodo para llenar la tabla de Detalle de la factura
        public void GetDetailInvoice()
        {
            
            //Define objeto a recibir
            IList<DishOrder> listDishOrder;

            List<int> parameters;
            List<Object> result;
            Command commandGetDetailInvoice;

            try
            {
                invoiceId = GetQueryParameter();
                accountId = int.Parse(_view.SessionIdAccount);

                //Recibe 2 enteros
                // 1  id de la factura
                // 2  id de la orden                
                parameters = new List<int> { invoiceId, accountId };
                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetDetailInvoice = CommandFactory.GetCommandGetDetailInvoice(parameters);

                //Ejecuta el comando deseado
                commandGetDetailInvoice.Execute();

                //Se obtiene el resultado de la operacion
                result = (List<Object>)commandGetDetailInvoice.Receiver;
                _invoice = (Invoice)result[0];
                _currency = (string)result[1];
                listDishOrder = (IList<DishOrder>)result[2];
                subtotal = (float) result[3];
                

                //Revisa si la lista no esta vacia
                if (_invoice != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(listDishOrder);
                    //Llama al metodo para el llenado de los Label
                    FillLabels();
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
            catch(Exception ex)
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
        }

        /// <summary>
        /// Llena los campos donde se muestra la
        /// informacion de la factura
        /// </summary>
        private void FillLabels()
        {
            ResetLabels();
            //Label de la factura
            _view.SessionNumberInvoice = _invoice.Number.ToString();
            _view.DateInvoice.Text = _invoice.Date.ToShortDateString();
            _view.UserName.Text = _invoice.Profile.Person.Name.ToString();
            _view.UserLastName.Text = _invoice.Profile.Person.LastName.ToString();
            _view.UserId.Text = _invoice.Profile.Person.Ssn.ToString();
            _view.SubTotalInvoice.Text = string.Format(OrderAccountResources.CurrencyTotal, _currency, subtotal.ToString());
            _view.IvaInvoice.Text = string.Format(OrderAccountResources.CurrencyTotal, _currency, _invoice.Tax.ToString());
            _view.TotalInvoice.Text = string.Format(OrderAccountResources.CurrencyTotal, _currency, _invoice.Total.ToString());
            if (_invoice.Payment.GetType().Name.Equals(OrderAccountResources.CreditCard))
            {
                _creditCardPayment = (CreditCardPayment)_invoice.Payment;
                tip = _creditCardPayment.Tip;
            }
            _view.TipInvoice.Text = string.Format(OrderAccountResources.CurrencyTotal, _currency, tip.ToString());
            if (_invoice.Status.Equals(GeneratedInvoiceStatus.Instance))
                _view.PrintInvoice.Visible = true;
            else if (_invoice.Status.Equals(CanceledInvoiceStatus.Instance))
                _view.PrintInvoice.Visible = false;
        }

        /// <summary>
        /// Limpia los labels donde se muestra el detalle
        /// de la factura
        /// </summary>
        private void ResetLabels()
        {
            string reset = string.Empty;
            //Label de la factura
            _view.SessionNumberInvoice = reset;
            _view.DateInvoice.Text = reset;
            _view.UserName.Text = reset;
            _view.UserLastName.Text = reset;
            _view.UserId.Text = reset;
            _view.IvaInvoice.Text = reset;
            _view.TotalInvoice.Text = reset;
        }

        private void FillTable(IList<DishOrder> data)
        {
            HideMessageLabel();
            CleanTable(_view.DetailInvoiceTable);

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
                _view.DetailInvoiceTable.Rows.Add(tRow);
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
            _view.DetailInvoiceTable.Rows.AddAt(0, header);                 

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

        /// <summary>
        /// Obtiene el parametro pasado en el URL
        /// </summary>
        /// <returns>Id</returns>
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
