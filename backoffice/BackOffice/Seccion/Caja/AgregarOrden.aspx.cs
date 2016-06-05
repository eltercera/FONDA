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
using System.Web.UI.HtmlControls;
using BackOffice.Content;
using BackOffice.Seccion.Restaurant;

namespace BackOffice.Seccion.Caja
{
    public partial class AgregarOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            exitoFormulario.Visible = false;
            alertaFormulario.Visible = false;

            loadPage();
            fillDropDown();


        }

        protected void Page_Init(object sender, EventArgs e)
        {
            exitoFormulario.Visible = false;
            alertaFormulario.Visible = false;
            if (!this.IsPostBack)
                loadPage();
        }

        protected void loadPage()
        {

            CleanTable();


            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IDishDAO _DishDAO = factoryDAO.GetDishDAO();
            IList<Dish> listDish = _DishDAO.GetAll();

            int totalRows = listDish.Count;
            int totalColumns = 5; //numero de columnas de la tabla



            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {


                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listDish[i].Id.ToString();
                //Agrega la fila a la tabla existente
                Menu1.Rows.Add(tRow);


                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria

                    if (j.Equals(0))
                        tCell.Text = listDish[i].Name;
                    //Agrega las acciones de la tabla
                    else if (j.Equals(1))
                    {

                        tCell.Text = ResourceCaja.AgregarCantidadOrden;


                    }
                    else if (j.Equals(2))
                    {
                        tCell.Text = listDish[i].Cost.ToString();
                    }
                    else if (j.Equals(3))
                    {
                        tCell.Text = "10%";
                    }
                    else if (j.Equals(4))
                    {
                        tCell.Text = (listDish[i].Cost * 0.1).ToString();
                    }
                    else if (j.Equals(5))
                    {
                        CheckBox checkbox = new CheckBox();
                        checkbox.ID = listDish[i].Id.ToString();

                        tCell.Controls.Add(checkbox);
                    }

                    //Agrega la 
                    tRow.Cells.Add(tCell);

                    tRow.Controls.Add(tCell);
                }
                Menu1.Controls.Add(tRow);
            }



            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            Menu1.Rows.AddAt(0, header);


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
            h6.Text = "Accion";
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
            Menu1.Rows.Clear();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IDishDAO _DishDAO = factoryDAO.GetDishDAO();
            IList<Dish> listDish = _DishDAO.GetAll();
            IDishOrderDAO _DishOrder = factoryDAO.GetDishOrderDAO();


            Account account = new Account();
            IOrderAccountDao _orderAccount = factoryDAO.GetOrderAccountDAO();

            int totalRows = listDish.Count;
            int i = 0;

            foreach (TableRow row in Menu1.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    
                    foreach (Control ctrl in cell.Controls)
                    {

                        CheckBox box = ctrl.FindControl(listDish[i].Id.ToString()) as CheckBox;

                        if (box is CheckBox)
                        {
                            if (box.Checked)
                            {
                                //label22.Text = "hey";
                                DishOrder dishOrder = new DishOrder();
                                dishOrder.Count = 1;
                                dishOrder.Dish = listDish[i];
                                _DishOrder.Save(dishOrder);
                                account.addDish(dishOrder);
                                
                            }
                        }
                        i++;
                    }

                }
            }


           // string iduser = (string)(Session[RecursoMaster.sessionUserID]);
            Commensal comensal = new Commensal();
            comensal.Id = 17;

            String selectedTable = DropDownTables.Text;
            com.ds201625.fonda.Domain.Table tableSelected = new com.ds201625.fonda.Domain.Table();
            tableSelected.Id = int.Parse(selectedTable);
           
            // Salvar en bd.


            account.Commensal = comensal;
            account.Table = tableSelected;
            account.Status = OpenAccountStatus.Instance;
              _orderAccount.Save(account);

                
              






        }

        private int GetSessionRestaurantId()
        {
            string idSessionRestaurant;
            int idRestaurant;

            try
            {
                idSessionRestaurant = Session[RestaurantResource.SessionRestaurant].ToString();
            }
            catch (Exception)
            {

                throw;
            }

            //REVISAR USO DE TRY PARSE PARA MANEJAR CASTEOS ERRONEOS    
            bool castSessionRestaurant = int.TryParse(idSessionRestaurant, out idRestaurant);

            return idRestaurant;
        }

        public void fillDropDown()
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _TableDAO = factoryDAO.GetTableDAO();
            IList<com.ds201625.fonda.Domain.Table> listTable;
            IList<com.ds201625.fonda.Domain.Table> availableTable;

            int idRestaurant = GetSessionRestaurantId();

            //REVISAR MANEJO DE EXCEPCIONES
            try
            {
                    listTable = _TableDAO.GetTables(idRestaurant);
                    availableTable = _TableDAO.GetAvailableTables(listTable);

                }
                catch (Exception)
                {
                    //TODO: Excepcion personalizada
                    throw;
                }



            foreach (com.ds201625.fonda.Domain.Table table in availableTable)
            {
                DropDownTables.Items.Add(table.Id.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }


}