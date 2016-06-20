using BackOfficeModel.OrderAccount;
using BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using FondaLogic;
using FondaLogic.Factory;
using FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class InvoiceDetailPresenter : BackOfficePresenter.Presenter
    {
        private IInvoiceDetailContract _view;
        int totalColumns = 3;
        int accountId = 0;
        int accountNumber = 0;
        Invoice _invoice;

        public InvoiceDetailPresenter(IInvoiceDetailContract viewInvoiceDetail) : 
            base(viewInvoiceDetail)
        {
            _view = viewInvoiceDetail;
        }
        ///<summary>
        ///Metodo para llenar la tabla de Detalle de la Orden
        /// </summary>
        public void GetDetailOrder()
        {


            int result;
            //Define objeto a recibir
            IList <DishOrder> _listDish;
            //Invoca al comando
            Command commandGetInvoice;
            Command commandGetDishOrder;

            try
            {
                result = GetQueryParameter();
                accountId = int.Parse(_view.Session);
                

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetInvoice = CommandFactory.GetCommandGetInvoice(result);
                commandGetDishOrder = CommandFactory.GetDetailOrder(accountId);

                //Ejecuta el comando deseado
                commandGetInvoice.Execute();
                commandGetDishOrder.Execute();

                //Se obtiene el resultado de la operacion
                _invoice = (Invoice)commandGetInvoice.Receiver;
                _listDish = (List<DishOrder>)commandGetDishOrder.Receiver;
                _view.SessionNumberInvoice = _invoice.Number.ToString();

                //Revisa si la lista no esta vacia
                if (_invoice != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(_listDish);
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
            CleanTable(_view.DetailInvoiceTable);

            int totalRows = data.Count; //tamano de la lista 
            float total = 0;
            string _currency = _invoice.Currency.ToString();

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
            TableFooterRow footer = GenerateTableFooter();
            _view.DetailInvoiceTable.Rows.AddAt(totalRows + 1, footer);
                   

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

        private TableFooterRow GenerateTableFooter()
        {
            //Se crea la fila en donde se insertara el header
            TableFooterRow footer = new TableFooterRow();

            //Se crean las columnas del header
            var h1 = new TableCell();
            var h2 = new TableCell();

            footer.TableSection = TableRowSection.TableFooter;
            h1.Text = OrderAccountResources.IVAColumn;
            h2.Text = OrderAccountResources.TotalColumn;


            //Se asignan las columnas a la fila
            footer.Cells.Add(h1);
            footer.Cells.Add(h2);

            return footer;
        }

        private int GetQueryParameter()
        {
            int result = 0;
            string queryParameter =
                HttpContext.Current.Request.QueryString["Id"];


            if (queryParameter != null && queryParameter != string.Empty)
            {
                return int.Parse(queryParameter);
            }

            return result;
        }
    }
}
