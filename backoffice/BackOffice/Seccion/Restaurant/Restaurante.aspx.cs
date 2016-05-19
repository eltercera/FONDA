using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace BackOffice.Seccion.Restaurant
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AddRestaurant.Visible = false;
            AlertSuccess_ModifyRestaurant.Visible = false;

            LoadDataTable();



            AlertError_AddRestaurant.Visible = false;
            AlertError_ModifyRestaurant.Visible = false;

        }


        public bool ValidarRestaurant()
        {
            bool valid = true;
            string patronLetras = "^[A-Za-z]*$";
            string patronNumero = "^[0-9]*$";
            string patronFloat = @"^-?[0-9]*(?:\.[0-9]*)?$";
            string name = NameA.Text;
            string category = CategoryA.Text;
            string nationality = NacionalityA.Text;
            string rif = RifA.Text;
            string currency = CurrencyA.Text;
            string address = AddressA.Text;
            string zone = ZoneA.Text;
            string longitud = LongA.Text;
            string latitud = LatA.Text;
            string logitud = LongA.Text;


            if (name == "" | rif == "" | address == "" | longitud == "" | latitud == ""
                | category == "" | nationality == "" | zone == "" | currency == "")
            {
                valid = false;

            }
            if ((!Regex.IsMatch(name, patronLetras)) | (!Regex.IsMatch(address, patronLetras)))
            {
                valid = false;
            }

            if ((!Regex.IsMatch(rif, patronNumero)))
            {
                valid = false;
            }

            if ((!Regex.IsMatch(longitud, patronFloat)) | (!Regex.IsMatch(latitud, patronFloat)))
            {

            }

            return valid;
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
            IRestaurantDAO _RestaurantDAO = factoryDAO.GetRestaurantDAO();
            IList<com.ds201625.fonda.Domain.Restaurant> listRestaurant = _RestaurantDAO.GetAll();


            int totalRows = listRestaurant.Count; //tamano de la lista 
            int totalColumns = 4; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listRestaurant[i].Id.ToString();
                //Agrega la fila a la tabla existente
                Restaurant.Rows.Add(tRow);
                // Estado
                string statusRestaurant = string.Empty;
                string status = listRestaurant[i].Status.ToString();
                string statusActive = ActiveSimpleStatus.Instance.ToString();
                string statusInactive = DisableSimpleStatus.Instance.ToString();
                if (status == statusActive)
                    status = ResourceRestaurant.Active;
                else if (status == statusInactive)
                    status = ResourceRestaurant.Inactive;

                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre del restaurante
                    if (j.Equals(0))
                        tCell.Text = listRestaurant[i].Name;
                    //Agrega la direccion del restaurante
                    else if (j.Equals(1))
                        tCell.Text = listRestaurant[i].Address;
                    //Agrega la Categoria
                    else if (j.Equals(2))
                        tCell.Text = listRestaurant[i].RestaurantCategory.Name;
                    //Agrega el stauts
                    else if (j.Equals(3))
                        tCell.Text = status;
                    else if (j.Equals(4))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton action = new LinkButton();
                        action.Attributes["data-toggle"] = "modal";
                        action.Attributes["data-target"] = "#modificar";
                        action.Text = ResourceRestaurant.ActionRestaurant;
                        tCell.Controls.Add(action);
                    }
                    //Agrega la celda
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            Restaurant.Rows.AddAt(0, header);
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
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Direccion";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Categoria";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Estado";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Acciones";
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
            Restaurant.Rows.Clear();
        }



        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AlertSuccess_AddRestaurant.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant = new com.ds201625.fonda.Domain.Restaurant();
            string Name = NameA.Text;
            string Category = CategoryA.Text;
            string Nacionality = NacionalityA.Text;
            string Rif = RifA.Text;
            string Currency = CurrencyA.Text;
            string Address = AddressA.Text;
            string Zone = ZoneA.Text;
            string Long = LongA.Text;
            string Lat = LatA.Text;
            string Day1 = Day1A.Text;
            string Day2 = Day2A.Text;
            string Day3 = Day3A.Text;
            string Day4 = Day4A.Text;
            string Day5 = Day5A.Text;
            string Day6 = Day6A.Text;
            string Day7 = Day7A.Text;
            TimeSpan OT = TimeSpan.Parse(OpeningTimeA.Text);
            TimeSpan CT = TimeSpan.Parse(ClosingTimeA.Text);
            _restaurant.Status = ActiveSimpleStatus.Instance;
            _restaurantDAO.Save(_restaurant);
            LoadDataTable();
        }

        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            //AlertSuccess_ModifyRestaurant.Visible = true;
            //FactoryDAO factoryDAO = FactoryDAO.Intance;
            //ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            //string TableID = TableModifyId.Value;
            //int idTable = int.Parse(TableID);
            //com.ds201625.fonda.Domain.Table _tableM = _tableDAO.FindById(idTable);
            //int capacity = int.Parse(DDLcapacityM.SelectedValue);
            //_tableM.Capacity = capacity;
            //_tableDAO.Save(_tableM);
            //LoadDataTable();

        }


        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo categoria
        /// </summary>
        /// <param name="Id">Id de la categoria a mostrar</param>
        /// <returns>Informacion de objeto categoria</returns>
        [WebMethod]
        public static com.ds201625.fonda.Domain.Restaurant GetData(string Id)
        {
            int restaurantId = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant restaurant = _restaurantDAO.FindById(restaurantId);

            return restaurant;
        }

    }
}