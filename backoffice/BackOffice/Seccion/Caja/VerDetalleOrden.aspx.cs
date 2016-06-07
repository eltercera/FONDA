using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace BackOffice.Seccion.Caja
{
    public partial class VerDetalleOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        protected void LoadTable()
        {
            int id = int.Parse(Request.QueryString["id"]);
            CleanTable();


            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IOrderAccountDao _OrderAccountDAO = factoryDAO.GetOrderAccountDAO();
            IList<DishOrder> listDishOrder = (_OrderAccountDAO.FindById(id)).ListDish;

            int totalRows = listDishOrder.Count;
            int totalColumns = 4; //numero de columnas de la tabla





            //Seteo los label de la cabecera , falta restaurante y su direccion con la fecha.
            Label1.Text = id.ToString();
            Label2.Text = _OrderAccountDAO.FindById(id).Commensal.Email;


            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {


                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listDishOrder[i].Id.ToString();
                //Agrega la fila a la tabla existente
                Pago.Rows.Add(tRow);


                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria

                    if (j.Equals(0))
                        tCell.Text = listDishOrder[i].Dish.Name;
                    //Agrega las acciones de la tabla
                    else if (j.Equals(1))
                    {
                        tCell.Text = listDishOrder[i].Count.ToString();
                    }
                    else if (j.Equals(2))
                    {
                        tCell.Text = (listDishOrder[i].Dish.Cost - (listDishOrder[i].Dish.Cost * 0.1)).ToString();
                    }
                    else if (j.Equals(3))
                    {
                        tCell.Text = "10%";
                    }
                    else if (j.Equals(4))
                    {
                        tCell.Text = listDishOrder[i].Dish.Cost.ToString();
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }

            }
            // Si la orden no esta vacia entonces a;ado un label para ense;ar el monto total. El if eliminarlo luego 
            // de comprobar que nunca este vacia la orden para existir.
            if (_OrderAccountDAO.FindById(id).ListDish.Any())
            {
                LabelMontoTotal.Text = "MONTO TOTAL: " + _OrderAccountDAO.FindById(id).getMonto().ToString();
            }


            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            Pago.Rows.AddAt(0, header);

        }


        /// <summary>
        /// Genera el encabezado de la tabla Categoria
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
            h1.Text = "Plato";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Cantidad";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Precio";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "IVA";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Total";
            h5.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);

            return header;
        }

        public void CleanTable()
        {
            Pago.Rows.Clear();

        }

    }

}