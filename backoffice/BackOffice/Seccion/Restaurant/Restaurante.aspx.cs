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
            OpeningTimeA.Attributes.Add("type","time");
            ClosingTimeA.Attributes.Add("type", "time");
            LoadDataTable();
            FillDropdown();


            AlertError_AddRestaurant.Visible = false;
            AlertError_ModifyRestaurant.Visible = false;

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
                    status = RestaurantResource.Active;
                else if (status == statusInactive)
                    status = RestaurantResource.Inactive;

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
                    {
                        tCell.Text = status;
                        tCell.CssClass = "text-center";
                    }
                    else if (j.Equals(4))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton actionInfo = new LinkButton();
                        LinkButton actionModify = new LinkButton();
                        LinkButton actionActive = new LinkButton();
                        LinkButton actionInactive = new LinkButton();

                        actionInfo.Attributes["data-toggle"] = "modal";
                        actionInfo.Attributes["data-target"] = "#consultar";
                        actionInfo.Text = RestaurantResource.ActionInfo;
                        tCell.Controls.Add(actionInfo);

                        actionModify.Attributes["data-toggle"] = "modal";
                        actionModify.Attributes["data-target"] = "#modificar";
                        actionModify.Text = RestaurantResource.ActionModify;
                        tCell.Controls.Add(actionModify);

                        actionActive.Attributes["data-status"] = "true";
                        actionActive.Text = RestaurantResource.ActionCheckStatus;
                        tCell.Controls.Add(actionActive);

                        actionInactive.Attributes["data-status"] = "false";
                        actionInactive.Text = RestaurantResource.ActionUnCheckStatus;
                        tCell.Controls.Add(actionInactive);


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

        /// <summary>
        /// Limpia las filas de la tabla mostrada en pantalla
        /// </summary>
        public void CleanTable()
        {
            Restaurant.Rows.Clear();
        }

        /// <summary>
        /// Llena los Dropdownlist de la pagina con informacion de la Base de Datos
        /// </summary>
        public void FillDropdown()
        {
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _categoryDAO = factoryDAO.GetRestaurantCategoryDAO();
            IList<com.ds201625.fonda.Domain.RestaurantCategory> listCategories = _categoryDAO.GetAll();
            ICurrencyDAO _currencyDAO = factoryDAO.GetCurrencyDAO();
            IList<com.ds201625.fonda.Domain.Currency> listCurrencies = _currencyDAO.GetAll();
            IZoneDAO _zoneDAO = factoryDAO.GetZoneDAO();
            IList<com.ds201625.fonda.Domain.Zone> listZones = _zoneDAO.allZone();

            //Se llenan los Dropdownlist con los registros existentes
            foreach (RestaurantCategory category in listCategories)
            {
                CategoryA.Items.Add(category.Name);
                CategoryM.Items.Add(category.Name);
            }
            foreach (Currency currency in listCurrencies)
            {
                CurrencyA.Items.Add(currency.Name);
                CurrencyM.Items.Add(currency.Name);
            }
            foreach (Zone zone in listZones)
            {
                ZoneA.Items.Add(zone.Name);
                ZoneM.Items.Add(zone.Name);
            }
        }

        /// <summary>
        /// Valida los campos enviados por el usuario para crear o actualizar un Restaurante
        /// </summary>
        /// <param name="name">Nombre del Restaurante</param>
        /// <param name="category">Categoria del Restaurante</param>
        /// <param name="nationality">Nacionalidad</param>
        /// <param name="rif">Rif del Restaurante</param>
        /// <param name="currency">Tipo de Moneda usada</param>
        /// <param name="address">Direccion fisica del Restaurante</param>
        /// <param name="zone">Zona de ubicacion del restaurante</param>
        /// <param name="longitud">Coordenada de longitud para ubicacion</param>
        /// <param name="latitud">Coordenada de latitud para ubicacion</param>
        /// <returns>true si los datos son validos, false si no son validos</returns>
        public bool ValidarRestaurant(string name, string category, string nationality, string rif, string currency, string address,
            string zone, string longitud, string latitud)
        {
            bool valid = true;
            int cont = 0;
            string patronNumero = "^[0-9]*$";
            string patronPunto = @"[(.)]";
            string patronFloat = @"^-?[0-9]\d*(\.\d+)?$"; // "^\-{0,1}\d+(.\d+){0,1}$"


            // valida campos vacio
            if (name == "" | rif == "" | address == "" | longitud == "" | latitud == ""
                | category == "" | nationality == "" | zone == "" | currency == "")
            {
                valid = false;

            }
            //valida campos de numeros
            if ((!Regex.IsMatch(rif, patronNumero)))
            {
                valid = false;
            }
            //valida campos float
            if ((!Regex.IsMatch(longitud, patronFloat)) | (!Regex.IsMatch(latitud, patronFloat)))
            {
                valid = false;
            }
            //Valida
            if ((!Regex.IsMatch(longitud, patronPunto)) | (!Regex.IsMatch(latitud, patronPunto)))
            {
                valid = false;
            }
            //Valida que al menos un check esté seleccionado
            if (Day1A.Checked)
                cont = cont+1;
            if (Day2A.Checked)
                cont = cont + 1;
            if (Day3A.Checked)
                cont = cont + 1;
            if (Day4A.Checked)
                cont = cont + 1;
            if (Day5A.Checked)
                cont = cont + 1;
            if (Day6A.Checked)
                cont = cont + 1;
            if (Day7A.Checked)
                cont = cont + 1;
            if (cont<1)
            {
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Agrega un nuevo Restaurante
        /// </summary>
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();

            #region Campos del Restaurante
            //Datos basicos del Restaurante
            string Name = NameA.Text;
            string Logo = ImageA.PostedFile.FileName;
            char Nationality = Convert.ToChar(NacionalityA.Text);
            string Rif = RifA.Text;
            string Address = AddressA.Text;

            //Categoria del Restaurante
            string Category = CategoryA.Text;

            //Tipo de Moneda
            string Currency = CurrencyA.Text;

            //Zona
            string Zone = ZoneA.Text;

            //Coordenadas
            string Long = LongA.Text;
            string Lat = LatA.Text;
            double LongD = Convert.ToDouble(Long);
            double LatD = Convert.ToDouble(Lat);

            //Horario de apertura y cierre
            TimeSpan OT = TimeSpan.Parse(OpeningTimeA.Text);
            TimeSpan CT = TimeSpan.Parse(ClosingTimeA.Text);

            //Dias laborales
            bool Day1 = Day1A.Checked;
            bool Day2 = Day2A.Checked;
            bool Day3 = Day3A.Checked;
            bool Day4 = Day4A.Checked;
            bool Day5 = Day5A.Checked;
            bool Day6 = Day6A.Checked;
            bool Day7 = Day7A.Checked;
            bool[] days = new bool[] { Day1, Day2, Day3, Day4, Day5, Day6 };
            #endregion

            //Verifica si los campos ingresados son validos
            if (ValidarRestaurant(Name, Category, Nationality.ToString(), Rif, Currency,
                Address, Zone, Long, Lat))
            {

                //Genera un nuevo Restaurante
                com.ds201625.fonda.Domain.Restaurant _restaurant =
                    _restaurantDAO.GenerateRestaurant(Name, Logo, Nationality, Rif, Address,
                    Category, Currency, Zone, LongD, LatD, OT, CT, days);

                //Salva nuevo Restaurante en la Base de Datos
                _restaurantDAO.Save(_restaurant);
                
                //Refresca la tabla de Restaurantes
                LoadDataTable();

                //Mensaje exitoso
                AlertSuccess_AddRestaurant.Visible = true;

            }
            else
            {
                //Mensaje de error
                AlertError_AddRestaurant.Visible = true;
            }

            //Limpia los campos
            CleanAddModal();
           
        }

        /// <summary>
        /// Limpia los campos del modal para Agregar Restaurant
        /// </summary>
        public void CleanAddModal()
        {
            NameA.Text = string.Empty;
            NacionalityA.SelectedValue = string.Empty;
            RifA.Text = string.Empty;
            AddressA.Text = string.Empty;
            LongA.Text = string.Empty;
            LatA.Text = string.Empty;
            OpeningTimeA.Text = string.Empty;
            ClosingTimeA.Text = string.Empty;
            Day1A.Checked = false;
            Day2A.Checked = false;
            Day3A.Checked = false;
            Day4A.Checked = false;
            Day5A.Checked = false;
            Day6A.Checked = false;
            Day7A.Checked = false;
        }

        /// <summary>
        /// Modifica la informacion de un Restaurante
        /// </summary>
        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();

            #region Campos del Restaurante
            //Datos basicos del Restaurante
            string Name = NameM.Text;
            string Logo = ImageM.PostedFile.FileName;
            char Nationality = Convert.ToChar(NationalityM.Text);
            string Rif = RifM.Text;
            string Address = AddressM.Text;

            //Categoria del Restaurante
            string Category = CategoryM.Text;

            //Tipo de Moneda
            string Currency = CurrencyM.Text;

            //Zona
            string Zone = ZoneM.Text;

            //Coordenadas
            string Long = LongM.Text;
            string Lat = LatM.Text;
            double LongD = Convert.ToDouble(Long);
            double LatD = Convert.ToDouble(Lat);

            //Horario de apertura y cierre
            TimeSpan OT = TimeSpan.Parse(OpeningTimeM.Text);
            TimeSpan CT = TimeSpan.Parse(ClosingTimeM.Text);

            //Dias laborales
            bool Day1 = Day1M.Checked;
            bool Day2 = Day2M.Checked;
            bool Day3 = Day3M.Checked;
            bool Day4 = Day4M.Checked;
            bool Day5 = Day5M.Checked;
            bool Day6 = Day6M.Checked;
            bool Day7 = Day7M.Checked;
            bool[] days = new bool[] { Day1, Day2, Day3, Day4, Day5, Day6 };
            #endregion

            if (ValidarRestaurant(Name, Category, Nationality.ToString(), Rif, Currency,
                Address, Zone, Long, Lat))
            {
                // Obtiene id de la Base de Datos
                string RestaurantID = RestaurantModifyId.Value;
                int idRestaurant = int.Parse(RestaurantID);

                // Genera un objeto Restaurante a partir de los campos suministrados
                com.ds201625.fonda.Domain.Restaurant _restaurantM =
                    _restaurantDAO.GenerateRestaurant(Name, Logo, Nationality, Rif, Address,
                    Category, Currency, Zone, LongD, LatD, OT, CT, days);

                // Modifica un objeto restaurante
                com.ds201625.fonda.Domain.Restaurant _restaurant =
                    _restaurantDAO.ModifyRestaurant(idRestaurant, _restaurantM);

                //Salva Restaurante modificado en la Base de Datos
                _restaurantDAO.Save(_restaurant);

                //Refresca la tabla de Restaurantes
                LoadDataTable();

                //Mensaje exitoso
                AlertSuccess_ModifyRestaurant.Visible = true;

            }
            else
            {
                //Mensaje de error
                AlertError_ModifyRestaurant.Visible = true;
            }

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

        /// <summary>
        /// Cambia el Status del Restaurante
        /// </summary>
        /// <param name="Id">Recibe el Id del Restaurante</param>
        /// <param name="Status">Recibe el Status al que se va a cambiar</param>
        /// <returns>El Status a mostrar en la tabla</returns>
        [WebMethod]
        public static string ChangeStatus(string Id, string Status)
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            string RestaurantID = Id;
            string response = "";
            int idRestaurant = int.Parse(RestaurantID);
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);

            if (Status.Equals("Active"))
            {
                _restaurant.Status = factoryDAO.GetActiveSimpleStatus();
                response = RestaurantResource.Active;
            }
            else if (Status.Equals("Disable"))
            {
                _restaurant.Status = factoryDAO.GetDisabledSimpleStatus();
                response = RestaurantResource.Inactive;
            }

            _restaurantDAO.Save(_restaurant);
            return response;

        }

    }
}