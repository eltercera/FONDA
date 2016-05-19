using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace BackOffice.Seccion.Restaurant
{
    public partial class Mesas : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AddTable.Visible = false;
            AlertSuccess_ModifyTable.Visible = false;
            LoadDataTable();
        }

        /// <summary>
        /// Construye una tabla de mesas
        /// Utilizando el control de asp: Table
        /// </summary>
        protected void LoadDataTable()
        {
            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            IList<com.ds201625.fonda.Domain.Table> listTable = _tableDAO.GetAll();


            int totalRows = listTable.Count; //tamano de la lista 
            int totalColumns = 5; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listTable[i].Id.ToString();
                //Agrega la fila a la tabla existente
                Table.Rows.Add(tRow);
                // CABLEADO DE RESERVA
                string statusTable = string.Empty;
                string user = string.Empty;
                string status = listTable[i].Status.ToString();
                string statusActive = FreeTableStatus.Instance.ToString();
                string statusInactive = FreeTableStatus.Instance.ToString();
                int quantity = 0;
                if (status == statusActive)
                {
                    status = ResourceRestaurant.Active;
                    user = "N/A";
                    quantity = 0;
                }
                else if (status == statusInactive)
                {
                    status = ResourceRestaurant.Inactive;
                    user = "Usuario" + listTable[i].Id;
                    quantity = listTable[i].Capacity - 1;

                }
                // TERMINA EL CABLEADO DE RESERVA
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el ID de la mesa
                    if (j.Equals(0))
                        tCell.Text = listTable[i].Id.ToString();
                    //Agrega la capacidad de la mesa
                    else if (j.Equals(1))
                        tCell.Text = listTable[i].Capacity.ToString();
                    //Agrega el numero de comensales
                    else if (j.Equals(2))
                        tCell.Text = quantity.ToString();
                    //Agrega el usuario que realizo la reserva
                    else if (j.Equals(3))
                        tCell.Text = user;
                    //Agrega el status
                    else if (j.Equals(4))
                        tCell.Text = status;
                    //Agrega las acciones
                    else if (j.Equals(5))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton action = new LinkButton();
                        action.Attributes["data-toggle"] = "modal";
                        action.Attributes["data-target"] = "#modificar";
                        action.Text = ResourceRestaurant.ActionTableModify;
                        tCell.Controls.Add(action);
                        LinkButton active = new LinkButton();
                        active.Attributes["OnClick"] = "ChangeStatus";
                        active.Text = ResourceRestaurant.ActionTableBusyStatus;
                        tCell.Controls.Add(active);

                    }
                    //Agrega la celda
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            Table.Rows.AddAt(0, header);
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
            TableHeaderCell h6 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "ID";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Capacidad";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Comensales";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Usuario que realizo la reserva";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Estado";
            h5.Scope = TableHeaderScope.Column;
            h6.Text = "Acciones";
            h6.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);
            header.Cells.Add(h6);

            return header;
        }

        public void CleanTable()
        {
            Table.Rows.Clear();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AlertSuccess_AddTable.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            com.ds201625.fonda.Domain.Table _table = new com.ds201625.fonda.Domain.Table();
            int capacity = int.Parse(DDLcapacityA.SelectedValue); 
            _table.Capacity = capacity;
            _table.Status = FreeTableStatus.Instance;
            _tableDAO.Save(_table);
            LoadDataTable();
        }

        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModifyTable.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            string TableID = TableModifyId.Value;
            int idTable = int.Parse(TableID);
            com.ds201625.fonda.Domain.Table _tableM = _tableDAO.FindById(idTable);     
             int capacity = int.Parse(DDLcapacityM.SelectedValue);
            _tableM.Capacity = capacity;
            _tableDAO.Save(_tableM);
            LoadDataTable();

        }


        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo categoria
        /// </summary>
        /// <param name="Id">Id de la categoria a mostrar</param>
        /// <returns>Informacion de objeto categoria</returns>
        [WebMethod]
        public static com.ds201625.fonda.Domain.Table GetData(string Id)
        {
            int tableId = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            com.ds201625.fonda.Domain.Table _table = _tableDAO.FindById(tableId);

            return _table;
        }

        
        protected void ChangeStatus(object sender, EventArgs e)
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            string TableID = TableModifyId.Value;
            int idTable = int.Parse(TableID);
            com.ds201625.fonda.Domain.Table _table = _tableDAO.FindById(idTable);
            _table.Status = BusyTableStatus.Instance;
            _tableDAO.Save(_table);
            LoadDataTable();

        }

    }
}