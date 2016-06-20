using BackOfficeModel.OrderAccount;
using BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class OrdersPresenter : BackOfficePresenter.Presenter
    {
        //Enlace entre el Modelo y la Vista
        private IOrdersModel _view;
        private int totalColumns = 3;


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public OrdersPresenter(IOrdersModel viewDefault)
            : base(viewDefault) 
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewDefault;
            
        }

        ///<summary>
        ///Metodo para cerrar la caja
        /// </summary>
        public void Close()
        {
            int result = 0;
            string totalOrder;
            IList<Account> _openOrders = new List<Account>();
            Command commandCloseCashRegister;
            Command commandGetOrders;
            try
            {
                
                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetOrders = CommandFactory.GetCommandGetOrders(result);
                commandCloseCashRegister = CommandFactory.GetCommandCloseCashRegister(result);

                //Ejecuta el comando deseado
                commandGetOrders.Execute();

                _openOrders = (List<Account>)commandGetOrders.Receiver;

                if (_openOrders.Count == 0)
                {
                    commandCloseCashRegister.Execute();
                    totalOrder = (string)commandCloseCashRegister.Receiver;
                    SuccessLabel("Ha cerrado la caja exitosamente, el balance del dia fue: " + totalOrder);

                }
                else if (_openOrders.Count != 0)
                    throw new MVPExceptionCloseButton("No se puede realizar el cierre de caja");

            }
            catch (MVPExceptionCloseButton ex)
            {
                MVPExceptionCloseButton e = new MVPExceptionCloseButton
                    (
                        Errors.MVPExceptionCloseButtonCode,
                        Errors.ClassNameOrdersPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        Errors.MessageMVPExceptionCloseButton,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
        }
     

        /// <summary>
        /// Metodo encargado de llenar la tabla de Ordenes
        /// </summary>
        public void GetOrders()
        {
            int result = 0;
            //Define objeto a recibir
            IList<Account> listAccount;
            //Invoca a comando del tipo deseado
            Command commandGetOrders;            

            try
            {

                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetOrders = CommandFactory.GetCommandGetOrders(result);

                //Ejecuta el comando deseado
                commandGetOrders.Execute();

                //Se obtiene el resultado de la operacion
                listAccount = (IList<Account>) commandGetOrders.Receiver;


                //Revisa si la lista no esta vacia
                if (listAccount != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(listAccount);
                }

            }
            catch (MVPExceptionOrdersTable ex)
            {
                //Revisar
                MVPExceptionOrdersTable e = new MVPExceptionOrdersTable
                    (
                        Errors.MVPExceptionOrdersTableCode,
                        Errors.ClassNameOrdersPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        Errors.MessageMVPExceptionOrdersTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                throw e;
                ErrorLabel(e.MessageException);
            }
       
    }
     


        /// <summary>
        /// Construye la tabla de Ordenes
        /// </summary>
        /// <param name="data">una lista de ordenes</param>
        private void FillTable(IList<Account> data)
        {

            HideMessageLabel();
            CleanTable(_view.OrdersTable);
            //Genero los objetos para la consulta
            //Genero la lista de la consulta

            int totalRows = data.Count; //tamano de la lista 
            StringBuilder dataId = new StringBuilder();

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {

                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                dataId.Append(data[i].Id.ToString());
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes[OrderAccountResources.dataId] = dataId.ToString();
                //Agrega la fila a la tabla existente
                _view.OrdersTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();

                    //Agrega el numero de orden
                    if (j.Equals(0))
                        tCell.Text = data[i].Number.ToString();
                        
                    //Agrega el correo del comensal
                    else if (j.Equals(1))
                        tCell.Text = data[i].Commensal.Email.ToString();

                    //Agrega el numero de mesa
                    else if(j.Equals(2))
                        tCell.Text = data[i].Table.Number.ToString();

                    //Agrega las acciones de la tabla
                    else if (j.Equals(3))
                    {
                        LinkButton actionInfo = new LinkButton();

                        actionInfo.Text += OrderAccountResources.ActionInfo;
                        actionInfo.Attributes[OrderAccountResources.href] = 
                            OrderAccountResources.detailURL + dataId.ToString();
                        tCell.Controls.Add(actionInfo);

                    }
                    //Agrega la celda a la fila
                    tRow.Cells.Add(tCell);

                }

                //Limpia el objeto StringBuilder
                dataId.Clear();

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.OrdersTable.Rows.AddAt(0, header);
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


            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            //Esto tambien debo mejorarlo
            h1.Text = OrderAccountResources.OrderNumberColumn;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = OrderAccountResources.OrderUserColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = OrderAccountResources.OrderTableColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = OrderAccountResources.ActionColumn;
            h4.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);

            return header;
        }



    }
}
