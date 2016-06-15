using BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Domain;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter
{
    public class DefaultPresenter : BackOfficePresenter.Presenter
    {
        //Enlace entre el Modelo y la Vista
        private IOrdersModel _view;


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public DefaultPresenter(IOrdersModel viewDefault)
            : base(viewDefault) 
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewDefault;

        }

        /// <summary>
        /// Metodo encargad de llenar la tabla de Ordenes
        /// </summary>
        public void GetOrders(string restaurantId)
        {
            int result;
            //Define objeto a recibir
            IList<Account> listAccount;
            //Invoca a comando del tipo deseado
            Command commandGetOrders;
            Restaurant _restaurant = null;
            

            try
            {

                //Obtener el parametro
                if (!int.TryParse(restaurantId, out result))
                {
                    _restaurant = new Restaurant();
                    _restaurant.Id = result;
                }

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetOrders = CommandFactory.GetCommandGetOrders(_restaurant);

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
            catch (Exception)
            {
                //TODO: Arrojar excepciones personalizadas
                //TODO: Escribir en el Log la excepcion
                throw;
            }
       
    }
     


        /// <summary>
        /// Construye la tabla de Ordenes
        /// </summary>
        /// <param name="data">una lista de ordenes</param>
        private void FillTable(IList<Account> data)
        {


            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta



            int totalRows = data.Count; //tamano de la lista 
            int totalColumns = 2; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //con un if aqui, o con la funcion en el accountDAO..
                if (data[i].Status.StatusId == 11)
                {
                    //Crea una nueva fila de la tabla
                    TableRow tRow = new TableRow();
                    //Le asigna el Id a cada fila de la tabla
                    tRow.Attributes["data-id"] = data[i].Id.ToString();
                    //Agrega la fila a la tabla existente
                    _view.OrdersTable.Rows.Add(tRow);
                    for (int j = 0; j <= totalColumns; j++)
                    {
                        //Crea una nueva celda de la tabla
                        TableCell tCell = new TableCell();
                        //Agrega el nombre de la categoria
                        if (j.Equals(0))
                            tCell.Text = data[i].Number.ToString();
                        //Agrega las acciones de la tabla
                        else if (j.Equals(1))
                        {
                            tCell.Text = data[i].Commensal.Email.ToString();
                        }
                        else if (j.Equals(2))
                        {
                            LinkButton action1 = new LinkButton();
                            LinkButton action2 = new LinkButton();
                            LinkButton action3 = new LinkButton();

                            action1.Text += OrderAccountResources.VerDetalleOrden;
                            action1.Text += data[i].Id;
                            action1.Text += OrderAccountResources.Cerrar;
                            action1.Text += OrderAccountResources.VerDetalleOrden2;
                            action1.Text += OrderAccountResources.Cerrar2;
                            //Guardamos el recurso de Session del ID de la orden
                            int idAccount = data[i].Id;
                            _view.Session= idAccount.ToString();
                            tCell.Controls.Add(action1);


                            action2.Text += OrderAccountResources.VerFactura;
                            action2.Text += data[i].Id;
                            action2.Text += OrderAccountResources.Cerrar;
                            action2.Text += OrderAccountResources.VerFactura2;
                            action2.Text += OrderAccountResources.Cerrar2;
                            tCell.Controls.Add(action2);


                            action2.Text += OrderAccountResources.ModificarFactura;
                            action2.Text += data[i].Id;
                            action2.Text += OrderAccountResources.Cerrar;
                            action2.Text += OrderAccountResources.ModificarFactura2;
                            action2.Text += OrderAccountResources.Cerrar2;
                            tCell.Controls.Add(action3);
                        }
                        //Agrega la celda a la fila
                        tRow.Cells.Add(tCell);

                    }
                }
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

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "# Orden";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Nombre";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Accion";

            h3.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla
        /// </summary>
        private void CleanTable()
        {
            _view.OrdersTable.Rows.Clear();

        }

    }
}
