using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Resources.FondaResources.Login;
using com.ds201625.fonda.View.BackOfficeModel.Restaurant;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using com.ds201625.fonda.DataAccess.Log;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.View.BackOfficePresenter.Restaurante
{
    public class RestaurantPresenter : Presenter
    {
        //enlace entre el modelo y la vista
        private IRestaurantModel _view;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public RestaurantPresenter(IRestaurantModel viewRestaurant)
            : base(viewRestaurant)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewRestaurant;
        }

        /// <summary>
        /// Construye una tabla de mesas
        /// Utilizando el control de asp: Table
        /// </summary>
        public void LoadTable()
        {
            Command commandGetAllRestaurants;
            CleanTable();

            //Llamada al comando para generar la lista de todos los restaurantes
            commandGetAllRestaurants = CommandFactory.GetCommandGetAllRestaurants("null");
            commandGetAllRestaurants.Execute();

            //Resultado del receiver
            IList<Restaurant> listRestaurant = (IList<Restaurant>)commandGetAllRestaurants.Receiver;

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
                _view.restaurantTable.Rows.Add(tRow);
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
            _view.restaurantTable.Rows.AddAt(0, header);
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
            _view.restaurantTable.Rows.Clear();
        }

        /// <summary>
        /// Llena los Dropdownlist de la pagina con informacion de la Base de Datos
        /// </summary>
        public void FillDropdown()
        {
            ClearDropdown();
            Command commandGetAllCategories;
            Command commandGetAllCurrencies;
            Command commandGetAllZone;

            //Llamada al comando para generar la lista de todos las categorias
            commandGetAllCategories = CommandFactory.GetCommandGetAllCategories("null");
            commandGetAllCategories.Execute();
            //Resultado del receiver
            IList<RestaurantCategory> listCategories = (IList<RestaurantCategory>)commandGetAllCategories.Receiver;

            //Llamada al comando para generar la lista de todos los currencies
            commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies("null");
            commandGetAllCurrencies.Execute();
            //Resultado del receiver
            IList<Currency> listCurrencies = (IList<Currency>)commandGetAllCurrencies.Receiver;

            //Llamada al comando para generar la lista de todos las zonas
            commandGetAllZone = CommandFactory.GetCommandGetAllZones("null");
            commandGetAllZone.Execute();
            //Resultado del receiver
            IList<Zone> listZones = (IList<Zone>)commandGetAllZone.Receiver;

            //Se llenan los Dropdownlist con los registros existentes
            foreach (RestaurantCategory category in listCategories)
            {
                _view.categoryAdd.Items.Add(category.Name);
                _view.categoryModify.Items.Add(category.Name);
            }
            foreach (Currency currency in listCurrencies)
            {
                _view.currencyAdd.Items.Add(currency.Name);
                _view.currencyModify.Items.Add(currency.Name);
            }
            foreach (Zone zone in listZones)
            {
                _view.zoneAdd.Items.Add(zone.Name);
                _view.zoneModify.Items.Add(zone.Name);
            }
        }

        public void ClearDropdown()
        {
            Command commandGetAllCategories;
            Command commandGetAllCurrencies;
            Command commandGetAllZone;

            //Llamada al comando para generar la lista de todos las categorias
            commandGetAllCategories = CommandFactory.GetCommandGetAllCategories("null");
            commandGetAllCategories.Execute();
            //Resultado del receiver
            IList<RestaurantCategory> listCategories = (IList<RestaurantCategory>)commandGetAllCategories.Receiver;

            //Llamada al comando para generar la lista de todos los currencies
            commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies("null");
            commandGetAllCurrencies.Execute();
            //Resultado del receiver
            IList<Currency> listCurrencies = (IList<Currency>)commandGetAllCurrencies.Receiver;

            //Llamada al comando para generar la lista de todos las zonas
            commandGetAllZone = CommandFactory.GetCommandGetAllZones("null");
            commandGetAllZone.Execute();
            //Resultado del receiver
            IList<Zone> listZones = (IList<Zone>)commandGetAllZone.Receiver;

            //Se limpia los Dropdownlist con los registros existentes
            foreach (RestaurantCategory category in listCategories)
            {
                _view.categoryAdd.Items.Clear();
                _view.categoryModify.Items.Clear();
            }
            foreach (Currency currency in listCurrencies)
            {
                _view.currencyAdd.Items.Clear();
                _view.currencyModify.Items.Clear();
            }
            foreach (Zone zone in listZones)
            {
                _view.zoneAdd.Items.Clear();
                _view.zoneModify.Items.Clear();
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
            string zone, string longitud, string latitud, string otime, string ctime)
        {
            bool valid = true;
            int cont = 0;
            //expresion regular para el rif, valida que sea numerico
            string patronNumero = "^[0-9]*$";
            //valida que la coordenada siempre tenga un punto
            string patronPunto = @"[(.)]";
            //patron que valida la coordenada acepte floats 
            string patronFloat = @"^-?[0-9]\d*(\.\d+)?$"; // "^\-{0,1}\d+(.\d+){0,1}$"


            // valida campos vacio
            if (name == "" | rif == "" | address == "" | longitud == "" | latitud == ""
                | category == "" | nationality == "" | zone == "" | currency == "" | otime == "" | ctime == "")
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
            if ((_view.day1Add.Checked) || (_view.day1Modify.Checked))
                cont = cont + 1;
            if ((_view.day2Add.Checked) || (_view.day2Modify.Checked))
                cont = cont + 1;
            if ((_view.day3Add.Checked) || (_view.day3Modify.Checked))
                cont = cont + 1;
            if ((_view.day4Add.Checked) || (_view.day4Modify.Checked))
                cont = cont + 1;
            if ((_view.day5Add.Checked) || (_view.day5Modify.Checked))
                cont = cont + 1;
            if ((_view.day6Add.Checked) || (_view.day6Modify.Checked))
                cont = cont + 1;
            if ((_view.day7Add.Checked) || (_view.day7Modify.Checked))
                cont = cont + 1;
            if (cont < 1)
            {
                valid = false;
            }

            return valid;
        }

        public bool ValidateRestaurantM(string name, string category, string nationality, string rif, string currency, string address,
string zone, string longitud, string latitud, string otime, string ctime)
        {
            bool valid = true;
            int cont = 0;
            string patronNumero = "^[0-9]*$";
            string patronPunto = @"[(.)]";
            string patronFloat = @"^-?[0-9]\d*(\.\d+)?$"; // "^\-{0,1}\d+(.\d+){0,1}$"


            // valida campos vacio
            if (name == "" | rif == "" | address == "" | longitud == "" | latitud == ""
                | category == "" | nationality == "" | zone == "" | currency == "" | otime == "" | ctime == "")
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
            if (_view.day1Modify.Checked)
                cont = cont + 1;
            if (_view.day2Modify.Checked)
                cont = cont + 1;
            if (_view.day3Modify.Checked)
                cont = cont + 1;
            if (_view.day4Modify.Checked)
                cont = cont + 1;
            if (_view.day5Modify.Checked)
                cont = cont + 1;
            if (_view.day6Modify.Checked)
                cont = cont + 1;
            if (_view.day7Modify.Checked)
                cont = cont + 1;
            if (cont < 1)
            {
                valid = false;
            }

            return valid;
        }


        /// <summary>
        /// Agrega un nuevo Restaurante
        /// </summary>
        public void ButtonAdd_Click()
        {
            //declaracion de los comandos
            Command commandGenerateRestaurant;
            Command commandSaveRestaurant;
            Restaurant _restaurant;

            #region Campos del Restaurante
            //Datos basicos del Restaurante
            string Name = _view.nameAdd.Text;
            string Logo = _view.imageAdd.PostedFile.FileName;
            char Nationality = Convert.ToChar(_view.nationalityAdd.Text);
            string Rif = _view.rifAdd.Text;
            string Address = _view.addressAdd.Text;

            //Categoria del Restaurante
            string Category = _view.categoryAdd.Text;

            //Tipo de Moneda
            string Currency = _view.currencyAdd.Text;

            //Zona
            string Zone = _view.zoneAdd.Text;

            //Coordenadas
            string Long = _view.longAdd.Text;
            string Lat = _view.latAdd.Text;
            //validar
            double LongD = Convert.ToDouble(Long);
            double LatD = Convert.ToDouble(Lat);

            System.Diagnostics.Debug.WriteLine(_view.openingTimeAdd.Text);
            System.Diagnostics.Debug.WriteLine(_view.closingTimeAdd.Text);
            //Horario de apertura y cierre

            //validar
            TimeSpan OT = TimeSpan.Parse(_view.openingTimeAdd.Text);
            TimeSpan CT = TimeSpan.Parse(_view.closingTimeAdd.Text);
            System.Diagnostics.Debug.WriteLine(CT);
            //Dias laborales
            bool Day1 = _view.day1Add.Checked;
            bool Day2 = _view.day2Add.Checked;
            bool Day3 = _view.day3Add.Checked;
            bool Day4 = _view.day4Add.Checked;
            bool Day5 = _view.day5Add.Checked;
            bool Day6 = _view.day6Add.Checked;
            bool Day7 = _view.day7Add.Checked;
            bool[] days = new bool[] { Day1, Day2, Day3, Day4, Day5, Day6 };
            #endregion

            //Verifica si los campos ingresados son validos
            if (ValidarRestaurant(Name, Category, Nationality.ToString(), Rif, Currency,
                Address, Zone, Long, Lat, _view.openingTimeAdd.Text, _view.closingTimeAdd.Text))
            {
                //Genera la lista del objeto para el comando
                Object[] _addlist = new Object[13];
                _addlist[0] = Name;
                _addlist[1] = Logo;
                _addlist[2] = Nationality;
                _addlist[3] = Rif;
                _addlist[4] = Address;
                _addlist[5] = Category;
                _addlist[6] = Currency;
                _addlist[7] = Zone;
                _addlist[8] = LongD;
                _addlist[9] = LatD;
                _addlist[10] = OT;
                _addlist[11] = CT;
                _addlist[12] = days;

                try
                {
                    //Llamada al comando para generar un restaurante
                    commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
                    commandGenerateRestaurant.Execute();

                    //Resultado del receiver
                    _restaurant = (Restaurant)commandGenerateRestaurant.Receiver;
                }
                catch (CommandExceptionGenerateRestaurant e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.GenerateRestaurantFondaDAOException, e);

                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.InvalidTypeParameterException, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ParameterIndexOutRangeException, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.RequieredParameterNotFoundException, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
                }
                                
                //Guarda nuevo Restaurante en la Base de Datos usando el comando saveRestaurant
                commandSaveRestaurant = CommandFactory.GetCommandSaveRestaurant(_restaurant);
                //ejecuto el comando
                commandSaveRestaurant.Execute();

                //Refresca la tabla de Restaurantes
                LoadTable();

                //Mensaje exitoso
                _view.alertSuccessAdd.Visible = true;

            }
            else
            {
                //Mensaje de error
                _view.alertErrorAdd.Visible = true;
            }

            //Limpia los campos
            CleanAddModal();

        }

        /// <summary>
        /// Limpia los campos del modal para Agregar Restaurant
        /// </summary>
        public void CleanAddModal()
        {
            _view.nameAdd.Text = string.Empty;
            _view.nationalityAdd.SelectedValue = string.Empty;
            _view.rifAdd.Text = string.Empty;
            _view.addressAdd.Text = string.Empty;
            _view.longAdd.Text = string.Empty;
            _view.latAdd.Text = string.Empty;
            _view.openingTimeAdd.Text = string.Empty;
            _view.closingTimeAdd.Text = string.Empty;
            _view.day1Add.Checked = false;
            _view.day2Add.Checked = false;
            _view.day3Add.Checked = false;
            _view.day4Add.Checked = false;
            _view.day5Add.Checked = false;
            _view.day6Add.Checked = false;
            _view.day7Add.Checked = false;
        }

        /// <summary>
        /// Modifica la informacion de un Restaurante
        /// </summary>
        public void ButtonModify_Click()
        {
            Command commandModifyRestaurant;
            Command commandGenerateRestaurant;
            Command commandSaveRestaurant;
            Restaurant _restaurantM;

            #region Campos del Restaurante
            //Datos basicos del Restaurante
            string Name = _view.nameModify.Text;
            string Logo = _view.imageModify.PostedFile.FileName;
            char Nationality = Convert.ToChar(_view.nationalityModify.Text);
            string Rif = _view.rifModify.Text;
            string Address = _view.addressModify.Text;

            //Categoria del Restaurante
            string Category = _view.categoryModify.Text;

            //Tipo de Moneda
            string Currency = _view.currencyModify.Text;

            //Zona
            string Zone = _view.zoneModify.Text;

            //Coordenadas
            string Long = _view.longModify.Text;
            string Lat = _view.latModify.Text;
            double LongD = Convert.ToDouble(Long);
            double LatD = Convert.ToDouble(Lat);

            //Dias laborales
            bool Day1 = _view.day1Modify.Checked;
            bool Day2 = _view.day2Modify.Checked;
            bool Day3 = _view.day3Modify.Checked;
            bool Day4 = _view.day4Modify.Checked;
            bool Day5 = _view.day5Modify.Checked;
            bool Day6 = _view.day6Modify.Checked;
            bool Day7 = _view.day7Modify.Checked;
            bool[] days = new bool[] { Day1, Day2, Day3, Day4, Day5, Day6 };
            #endregion
            System.Diagnostics.Debug.WriteLine(Name + Category + Nationality.ToString() + Rif + Currency +
                Address + Zone + Long + Lat + _view.openingTimeModify.Text + _view.closingTimeModify.Text);

            if (ValidateRestaurantM(Name, Category, Nationality.ToString(), Rif, Currency,
                Address, Zone, Long, Lat, _view.openingTimeModify.Text, _view.closingTimeModify.Text))
            {
                //Horario de apertura y cierre
                TimeSpan OT = TimeSpan.Parse(_view.openingTimeModify.Text);
                TimeSpan CT = TimeSpan.Parse(_view.closingTimeModify.Text);

                // Obtiene id de la Base de Datos
                string RestaurantID = _view.RestaurantModifyById.Value;
                int idRestaurant = int.Parse(RestaurantID);

                //Genera la lista del objeto para el comando
                Object[] _addlist = new Object[13];
                _addlist[0] = Name;
                _addlist[1] = Logo;
                _addlist[2] = Nationality;
                _addlist[3] = Rif;
                _addlist[4] = Address;
                _addlist[5] = Category;
                _addlist[6] = Currency;
                _addlist[7] = Zone;
                _addlist[8] = LongD;
                _addlist[9] = LatD;
                _addlist[10] = OT;
                _addlist[11] = CT;
                _addlist[12] = days;

                try
                {
                    //Llamada al comando para generar un restaurante antes de modificar
                    commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
                    commandGenerateRestaurant.Execute();

                    //Resultado del receiver
                    _restaurantM = (Restaurant)commandGenerateRestaurant.Receiver;
                }
                catch (CommandExceptionModifyRestaurant e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyRestaurant(RestaurantErrors.ModifyRestaurantFondaDAOException, e);
                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyRestaurant(RestaurantErrors.InvalidTypeParameterException, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyRestaurant(RestaurantErrors.ParameterIndexOutRangeException, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyRestaurant(RestaurantErrors.RequieredParameterNotFoundException, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
                }
                //Lista de objetos para el comando
                Object[] _modifylist = new Object[2];
                _modifylist[0] = _restaurantM;
                _modifylist[1] = idRestaurant;

                //Llamada al comando para modificar el restaurante
                commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
                commandModifyRestaurant.Execute();

                //Resultado del receiver
                Restaurant _restaurant = (Restaurant)commandModifyRestaurant.Receiver;

                //Guarda nuevo Restaurante en la Base de Datos usando el comando saveRestaurant
                commandSaveRestaurant = CommandFactory.GetCommandSaveRestaurant(_restaurant);
                //ejecuto el comando
                commandSaveRestaurant.Execute();

                //Refresca la tabla de Restaurantes
                LoadTable();

                //Mensaje exitoso
                _view.alertSuccessModify.Visible = true;

            }
            else
            {
                //Mensaje de error
                _view.alertErrorModify.Visible = true;
            }

        }


    }
}

