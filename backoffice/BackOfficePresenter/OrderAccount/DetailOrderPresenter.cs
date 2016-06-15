using BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Domain;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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

        ///<summary>
        ///Metodo para llenar la tabla de Ordenes Cerradas
        /// </summary>
        public void GetDetailOrder()
        {
            int result;
            //Define objeto a recibir
            IList<DishOrder> listDishOrder;
            //Invoca al comando
            Command commandDetailOrder;

            try
            {
                //Obtener el parametro
                if (!int.TryParse(_view.Session, out result))
                {
                    _view.Session = result.ToString();
                }

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandDetailOrder = CommandFactory.GetDetailOrder(result);

                //Ejecuta el comando deseado
                commandDetailOrder.Execute();

                //Se obtiene el resultado de la operacion
                listDishOrder = (IList<DishOrder>)commandDetailOrder.Receiver;


                //Revisa si la lista no esta vacia
                if (listDishOrder != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(listDishOrder);
                }
            }
            catch (Exception)
            {
                //TODO: Arrojar excepciones personalizadas
                //TODO: Escribir en el Log la excepcion
                throw;
            }
        }

        private void FillTable(IList<DishOrder> data)
        {


            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta



            int totalRows = data.Count; //tamano de la lista 
            int totalColumns = 2; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = data[i].Id.ToString();
                //Agrega la fila a la tabla existente
                _view.DetailOrderTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega la cantidad del pedido del plato
                    if (j.Equals(0))
                        tCell.Text = data[i].Count.ToString();
                    //Agrega el plato
                    else if (j.Equals(1))
                    {
                        tCell.Text = data[i].Dish.Name.ToString();
                    }
                    //Agrega el costo del plato
                    else if (j.Equals(2))
                    {
                        tCell.Text = data[i].Dishcost.ToString();
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
        /// Genera el encabezado de la tabla Ordenes Cerradas
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
            h1.Text = "Cantidad";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Plato";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Precio por plato";
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
            _view.DetailOrderTable.Rows.Clear();

        }


    }
}
