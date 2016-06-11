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
{/*
    public partial class DefaultOrdenesCerradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        protected void LoadTable()
        {

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IOrderAccountDao _accountDAO = factoryDAO.GetOrderAccountDAO();
            IList<Account> listAccount = _accountDAO.GetAll();


            int totalRows = listAccount.Count; //tamano de la lista 
            int totalColumns = 4; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {

                //con un if aqui, o con la funcion en el accountDAO..
                if (listAccount[i].Status.StatusId == 8)
                {

                    //Crea una nueva fila de la tabla
                    TableRow tRow = new TableRow();
                    //Le asigna el Id a cada fila de la tabla
                    tRow.Attributes["data-id"] = listAccount[i].Id.ToString();
                    //Agrega la fila a la tabla existente
                    Detalle.Rows.Add(tRow);


                    for (int j = 0; j <= totalColumns; j++)
                    {
                        //Crea una nueva celda de la tabla
                        TableCell tCell = new TableCell();
                        //Agrega el nombre de la categoria
                        if (j.Equals(0))
                            tCell.Text = listAccount[i].Id.ToString();
                        //Agrega las acciones de la tabla
                        else if (j.Equals(1))
                        {
                            tCell.Text = "Pedro";
                        }
                        else if (j.Equals(2))
                        {
                            tCell.Text = listAccount[i].Date.ToString();
                        }
                        else if (j.Equals(3))
                        {
                            tCell.Text = listAccount[i].getMonto().ToString();
                        }
                        else if (j.Equals(4))
                        {
                            LinkButton action2 = new LinkButton();

                            action2.Text += ResourceCaja.VerDetalleFactura;
                            action2.Text += listAccount[i].Id;
                            action2.Text += ResourceCaja.Cerrar;
                            action2.Text += ResourceCaja.VerDetalleFactura2;
                            action2.Text += ResourceCaja.Cerrar2;


                            tCell.Controls.Add(action2);


                        }

                        //Agrega la 
                        tRow.Cells.Add(tCell);
                    }

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            Detalle.Rows.AddAt(0, header);

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
            h1.Text = "# Orden";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Nombre";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Fecha";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Monto";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Accion";
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
            Detalle.Rows.Clear();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }*/
}