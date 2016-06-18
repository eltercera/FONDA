﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOfficeModel;
using BackOfficeModel.OrderAccount;
using FondaLogic;
using FondaLogic.Factory;
using com.ds201625.fonda.Domain;
using BackOfficePresenter.FondaMVPException;
using System.Web.UI.WebControls;
using FondaResources.OrderAccount;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class OrderInvoicesPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IOrderInvoicesModel _view;
        private int totalColumns = 4;

        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewOrderInvoices">Interfaz</param>
        public OrderInvoicesPresenter(IOrderInvoicesModel viewOrderInvoices) 
            : base(viewOrderInvoices)
        {
            //Enlace Modelo - Vista
            _view = viewOrderInvoices;
        }

        /// <summary>
        /// Metodo encargado de llenar la tabla de Facturas
        /// </summary>
        public void GetInvoices()
        {
            int result = 0;
            //Define objeto a recibir
            IList<Invoice> listInvoice;
            //Invoca a comando del tipo deseado
            Command commandGetInvoicesByAccount;

            try
            {

                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Obtiene la instancia del comando enviado el restaurante como parametro
                //commandGetInvoicesByAccount = CommandFactory.GetCommandFindInvoicesByRestaurant(result);

                //Ejecuta el comando deseado
                //commandGetInvoicesByAccount.Execute();

                //Se obtiene el resultado de la operacion
                //listInvoice = (IList<Invoice>)commandGetInvoicesByAccount.Receiver;


                //Revisa si la lista no esta vacia
                //if (listInvoice != null)
                //{
                    //Llama al metodo para el llenado de la tabla
                   // FillTable(listInvoice);
                //}
            }
            catch (MVPExceptionOrdersTable ex)
            {
                Console.WriteLine("No falla");
            }

        }



        /// <summary>
        /// Construye la tabla de Ordenes
        /// </summary>
        /// <param name="data">una lista de ordenes</param>
        private void FillTable(IList<Invoice> data)
        {

            //Esto puede mejorarse
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta

            int totalRows = data.Count; //tamano de la lista 
            StringBuilder status = new StringBuilder();

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {

                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes[OrderAccountResources.dataId] =
                    data[i].Id.ToString();
                //Agrega la fila a la tabla existente
                _view.OrderInvoicesTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();

                    //Agrega el numero de factura
                    if (j.Equals(0))
                        tCell.Text = data[i].Number.ToString();

                    //Agrega la fecha de la factura
                    else if (j.Equals(1))
                        tCell.Text = data[i].Date.ToShortDateString();

                    //Agrega el total de la factura
                    else if (j.Equals(2))
                        tCell.Text = data[i].Total.ToString();

                    //Agrega el status de la factura
                    else if (j.Equals(3))
                    {
                        if (data[i].Status.Equals(CanceledInvoiceStatus.Instance))
                            status.Append(OrderAccountResources.CanceledStatus);
                        else if(data[i].Status.Equals(GeneratedInvoiceStatus.Instance))
                            status.Append(OrderAccountResources.GeneratedStatus);

                        tCell.Text = status.ToString();
                        status.Clear();
                    }

                    //Agrega las acciones de la tabla
                    else if (j.Equals(4))
                    {
                        LinkButton actionInfo = new LinkButton();

                        actionInfo.Text += OrderAccountResources.ActionInfo;
                        actionInfo.Attributes[OrderAccountResources.href] =
                            OrderAccountResources.detailURL;
                        tCell.Controls.Add(actionInfo);

                        //Guardamos el recurso de Session del ID de la orden
                        int idAccount = data[i].Id;
                        _view.Session = idAccount.ToString();

                    }
                    //Agrega la celda a la fila
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.OrderInvoicesTable.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Ordenes
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
            TableHeaderCell h5 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            //Esto tambien debo mejorarlo
            h1.Text = OrderAccountResources.OrderNumberColumn;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = OrderAccountResources.DateColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = OrderAccountResources.TotalColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = OrderAccountResources.StatusColumn;
            h4.Scope = TableHeaderScope.Column;
            h5.Text = OrderAccountResources.ActionColumn;
            h5.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla
        /// </summary>
        private void CleanTable()
        {
            _view.OrderInvoicesTable.Rows.Clear();

        }
    }
}
