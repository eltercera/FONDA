using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Data;
using System.Web.Services;
using System.Text.RegularExpressions;
using com.ds201625.fonda.Resources.FondaResources.Login;
using BackOffice.Content;

namespace BackOffice.Seccion.Menu
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                AlertSuccess_AddDish.Visible = false;
                AlertSuccess_SuggestionDish.Visible = false;
                AlertSuccess_ModifyDish.Visible = false;
                AlertSuccess_ActivateDish.Visible = false;
                AlertSuccess_DeactivateDish.Visible = false;
                AlertDanger_AddDish.Visible = false;
                AlertDanger_ModifyDish.Visible = false;
                AlertDanger_ActivateDish.Visible = false;
                AlertDanger_DeactivateDish.Visible = false;
                AlertWarning_ActivateDish.Visible = false;
                AlertWarning_DeactivateDish.Visible = false;
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
            LoadDishTable();
        }

        protected void LoadDishTable()
        {
           
            FillMenuCategoryDropdown();
            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO _factoryDAO = FactoryDAO.Intance;
            IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
            IMenuCategoryDAO _menCatDAO = _factoryDAO.GetMenuCategoryDAO();
            IList<MenuCategory> _listMenCat = _menCatDAO.GetAll();

            int totalRowsCategory = _listMenCat.Count; //tamano de la lista 
            int totalColumns = 5; //numero de columnas de la tabla

            //Recorremos la lista de categorias
            for (int k = 0; k <= totalRowsCategory - 1; k++)
            {
                if (_listMenCat != null)
                {
                    IList<Dish> _listDish = new List<Dish>();

                    _listDish = _listMenCat[k].ListDish;
                    if (_listDish != null)
                    {
                        int totalRows = _listDish.Count; //tamano de la lista platos
                                                         //recorro la lista de platos
                        for (int i = 0; i <= totalRows - 1; i++)
                        {
                            //Crea una nueva fila de la tabla
                            TableRow tRow = new TableRow();
                            //Le asigna el Id a cada fila de la tabla
                            tRow.Attributes["data-id"] = _listDish[i].Id.ToString();
                            //Agrega la fila a la tabla existente
                            TableDish.Rows.Add(tRow);
                            for (int j = 0; j <= totalColumns; j++)
                            {
                                //Crea una nueva celda de la tabla
                                TableCell tCell = new TableCell();
                                //Agrega el nombre de la categoria
                                if (j.Equals(0))
                                    tCell.Text = _listDish[i].Name;
                                if (j.Equals(1))
                                    tCell.Text = _listDish[i].Cost.ToString();
                                if (j.Equals(2))
                                    tCell.Text = _listMenCat[k].Name;

                                //Agrega el checkbox de sugerencia de la tabla
                                else if (j.Equals(3))
                                {
                                    tCell.CssClass = "text-center";
                                    if (_listDish[i].Suggestion == true)
                                    {
                                        tCell.Text = ResourceMenu.Active;

                                    }
                                    if (_listDish[i].Suggestion == false)
                                    {
                                        tCell.Text = ResourceMenu.Inactive;
                                    }
                                }
                                if (j.Equals(4))
                                {
                                    tCell.CssClass = "text-center";

                                    if (_listDish[i].Status.StatusId == 1)
                                    {
                                        tCell.Text = ResourceMenu.Active;

                                    }
                                    else if (_listDish[i].Status.StatusId == 2)
                                    {
                                        tCell.Text = ResourceMenu.Inactive;
                                    }
                                }
                                //Agrega las acciones de la tabla
                                else if (j.Equals(5))
                                {
                                    tCell.CssClass = "text-center";
                                    //Crea hipervinculo para las acciones
                                    LinkButton LinkButtonModifyDish = new LinkButton();
                                    LinkButtonModifyDish.Attributes["data-toggle"] = "modal";
                                    LinkButtonModifyDish.Attributes["data-target"] = "#modify_dish";
                                    LinkButtonModifyDish.Text = ResourceMenu.ActionModifyDishMenuPrincipal;
                                    LinkButtonModifyDish.ToolTip = "Modificar Plato";
                                    tCell.Controls.Add(LinkButtonModifyDish);

                                    LinkButton LinkButtonChangeDishStatusActive = new LinkButton();
                                    LinkButtonChangeDishStatusActive.Attributes["data-toggle"] = "modal";
                                    LinkButtonChangeDishStatusActive.Attributes["data-target"] = "#activate_dish";
                                    LinkButtonChangeDishStatusActive.Text = ResourceMenu.ActionSetActiveDishMenuPrincipal;
                                    LinkButtonChangeDishStatusActive.ToolTip = "Activar Plato";
                                    tCell.Controls.Add(LinkButtonChangeDishStatusActive);

                                    LinkButton LinkButtonChangeDishStatusInactive = new LinkButton();
                                    LinkButtonChangeDishStatusInactive.Attributes["data-toggle"] = "modal";
                                    LinkButtonChangeDishStatusInactive.Attributes["data-target"] = "#deactivate_dish";
                                    LinkButtonChangeDishStatusInactive.Text = ResourceMenu.ActionSetInactiveDishMenuPrincipal;
                                    LinkButtonChangeDishStatusInactive.ToolTip = "Desactivar Plato";
                                    tCell.Controls.Add(LinkButtonChangeDishStatusInactive);

                                    LinkButton LinkButtonChangeSuggestion = new LinkButton();
                                    LinkButtonChangeSuggestion.Attributes["data-toggle"] = "modal";
                                    LinkButtonChangeSuggestion.Attributes["data-target"] = "#";
                                    LinkButtonChangeSuggestion.Text = ResourceMenu.ActionDefaultSuggestion;
                                    LinkButtonChangeSuggestion.ToolTip = "Hacer Sugerencia";
                                    tCell.Controls.Add(LinkButtonChangeSuggestion);
                                }
                                //Agrega la 
                                tRow.Cells.Add(tCell);

                            }
                        }
                    }

                }
         }
            

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateDishTableHeader();
            TableDish.Rows.AddAt(0, header);
        }

     

        private TableHeaderRow GenerateDishTableHeader()
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
            h2.Text = "Precio";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Categoría";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Sugerencia del dia";
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

            TableDish.Rows.Clear();

        }

        public void CleanMenuCategoryDropDown()
        {
            DropDownListMenuCategoryAddDish.Items.Clear();
        }

        protected void ButtonModifyDish_Click(object sender, EventArgs e)
        {

            try
            {
                String dishM = TextBoxModifyDishName.Text;
                String descriptionM = TextBoxModifyDishDescription.Text;
                String costM = TextBoxModifyDishPrice.Text;

                if (DishValidate(dishM, descriptionM, costM))
                {
                    //creo una instancia del factory
                    FactoryDAO _factoryDAO = FactoryDAO.Intance;
                    //creo una instancia del IDishDAO
                    IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
                    //obtengo el id del plato desde el hidden field
                    string _dishIdString = HiddenFieldDishModifyId.Value;
                    //convierto el id en integer
                    int _dishIdInt = int.Parse(_dishIdString);
                    //busco el plato por el id que lo asigna a la variable
                    Dish _dish = _dishDAO.FindById(_dishIdInt);

                    //Lleno los campos del objeto Dish en la BD con los inputs del modal
                    _dish.Name = TextBoxModifyDishName.Text;
                    // _mencat.ListDish = null; Deberia añadir el plato a la lista de donde se llamo el modal de add_dish
                    _dish.Description = TextBoxModifyDishDescription.Text;
                    //hay que manejar la carga de imagenes de platos
                    // _dish.Image = null;
                    //sugerencia en falso por defecto
                    //    _dish.Suggestion = false;
                    _dish.Cost = float.Parse(TextBoxModifyDishPrice.Text);

                    //guardo el plato
                    _dishDAO.Save(_dish);

                    //muestro la alerta de exito
                    AlertSuccess_ModifyDish.Visible = true;
                }
                else
                {
                    AlertDanger_ModifyDish.Visible = true;
                }
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //si da error muestro la alerta de fallo
                AlertDanger_ModifyDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                TextBoxModifyDishName.Text = string.Empty;
                TextBoxModifyDishDescription.Text = string.Empty;
                TextBoxModifyDishPrice.Text = string.Empty;

                //cargo la tabla
                LoadDishTable();

            }

        }

        /// <summary>
        /// Valida los datos ingresados al agregar categoria
        /// </summary>
        /// <param name="name">Nombre del plato</param>
        /// /// <param name="description">Descripcion del plato</param>
        /// /// <param name="cost">EL precio del plato</param>
        /// <returns>Devuelve true si son validos los datos, false si son incorrectos</returns>
        private bool DishValidate(string name, string description, string cost)
        {
            bool valid = true;
           // string patron = "^[A-Za-z]*$";
            string patronFloat = "^[0-9]*$"; // "^\-{0,1}\d+(.\d+){0,1}$"

            if (name == "" || description == "" || cost == null)
            {
                valid = false;
            }

         //   if (!Regex.IsMatch(name, patron))
        //    {
         //       valid = false;
        //    }

      //      if (!Regex.IsMatch(description, patron))
        //    {
        //        valid = false;
        //    }

            if (!Regex.IsMatch(cost, patronFloat))
            {
                valid = false;
            }
            return valid;
        }

        protected void ButtonAddDish_Click(object sender, EventArgs e)
        {

            try
            {
                String dishA = TextBoxAddDishName.Text;
                String descriptionA = TextBoxAddDishDescription.Text;
                String costA = TextboxAddDishPrice.Text;

                if ((DishValidate(dishA, descriptionA, costA)))
                {

                    //creo una instancia del factory
                    FactoryDAO _factoryDAO = FactoryDAO.Intance;
                    //Creo una instancia de Dish
                    Dish _dish = new Dish();
                    //obtengo el IMenuCategoryDAO
                    IMenuCategoryDAO _menCatDAO = _factoryDAO.GetMenuCategoryDAO();
                    //creao la lista de categorias
                    IList<MenuCategory> _listMenCat = _menCatDAO.GetAll();
                    //creo un objeto tipo MenuCategory
                    MenuCategory _menCat = new MenuCategory();
                    //obtengo el objeto por el id del valor seleccionado en el DropDownList
                    _menCat = _menCatDAO.FindById(int.Parse(DropDownListMenuCategoryAddDish.SelectedValue));


                    //Lleno los campos del objeto Dish en la BD con los inputs del modal
                    _dish.Name = TextBoxAddDishName.Text;
                    // _mencat.ListDish = null; Deberia añadir el plato a la lista de donde se llamo el modal de add_dish
                    _dish.Description = TextBoxAddDishDescription.Text;
                    //hay que manejar la carga de imagenes de platos
                    _dish.Image = null;
                    //sugerencia en falso por defecto
                    _dish.Suggestion = false;
                    _dish.Cost = float.Parse(TextboxAddDishPrice.Text);
                    //status en activo por defecto
                    _dish.Status = _factoryDAO.GetActiveSimpleStatus();
                    //guardo el plato en la lista de platos de la categoria
                    _menCat.ListDish.Add(_dish);
                    //guardo la categoria
                    _menCatDAO.Save(_menCat);


                    //muestro la alerta de exito
                    AlertSuccess_AddDish.Visible = true;
                }
                else
                {
                    AlertDanger_AddDish.Visible = true;

                }
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //Muestro la alerta de fallo
                AlertDanger_AddDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                CleanMenuCategoryDropDown();
                //cargo la tabla
                LoadDishTable();
                TextBoxAddDishName.Text = string.Empty;
                TextBoxAddDishDescription.Text = string.Empty;
                TextboxAddDishPrice.Text = string.Empty;
            }
        }
        protected void ButtonCancelAddDish_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonModifySuggestion_Click(object sender, EventArgs e)
        {
            try
            {
                
                //creo una instancia del factory
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                //creo una instancia del IDishDAO
                IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
                //obtengo el id del plato desde el hidden field
                string _dishIdString = HiddenFieldDishModifyId.Value;
                //convierto el id en integer
                int _dishIdInt = int.Parse(_dishIdString);
                //busco el plato por el id que lo asigna a la variable
                Dish _dish = _dishDAO.FindById(_dishIdInt);
                if (_dish.Status.StatusId == 1)
                {
                    if (_dish.Suggestion == true)
                    {
                        _dish.Suggestion = false;
                    }
                    else
                    {
                        _dish.Suggestion = true;
                    }

                    //guardo el plato
                    _dishDAO.Save(_dish);

                    //muestro la alerta de exito
                    AlertSuccess_SuggestionDish.Visible = true;

                }
                else
                {
                    AlertDanger_ModifyDish.Visible = true;
                }

               
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //si da error muestro la alerta de fallo
                AlertDanger_ModifyDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                //cargo la tabla
                LoadDishTable();
            }
        }

        /// <summary>
        /// Llena el Dropdownlist de la la categoria del menu con informacion de la Base de Datos
        /// </summary>
        public void FillMenuCategoryDropdown()
        {
            try
            {
                //Genero los objetos para la consulta
                //Genero la lista de la consulta
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                IMenuCategoryDAO _menCatDAO = _factoryDAO.GetMenuCategoryDAO();
                IList<MenuCategory> _listMenCat = _menCatDAO.GetAll();
                int i = 0;
                //Se llenan los Dropdownlist con los registros existentes
                foreach (MenuCategory _mencat in _listMenCat)
                {

                    DropDownListMenuCategoryAddDish.Items.Add(_mencat.Name);
                    DropDownListMenuCategoryAddDish.Items[i].Value = _mencat.Id.ToString();
                    //  DropDownListMenuCategoryModifyDish.Items.Add(_mencat.Name);

                    i++;
                }
            }
            catch (Exception exc)
            {
                System.Console.WriteLine("Excepcion capturada: {0}", exc);

            }
        }



        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo plato
        /// </summary>
        /// <param name="Id">Id del plato a mostrar</param>
        /// <returns>Informacion de objeto plato</returns>
        [WebMethod]
        public static Dish GetData(string Id)
        {
            int _dishID = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IDishDAO _dishDAO = factoryDAO.GetDishDAO();
            Dish _dish = _dishDAO.FindById(_dishID);

            return _dish;
        }

        protected void ButtonActivateDish_Click(object sender, EventArgs e)
        {

            try
            {
                //creo una instancia del factory
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                //creo una instancia del IDishDAO
                IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
                //obtengo el id del plato desde el hidden field
                string _dishIdString = HiddenFieldDishModifyId.Value;
                //convierto el id en integer
                int _dishIdInt = int.Parse(_dishIdString);
                //busco el plato por el id que lo asigna a la variable
                Dish _dish = _dishDAO.FindById(_dishIdInt);
                //cambio el estado a activo  
                if (_dish.Status.StatusId == 1)
                {
                    //muestro la alerta de fallo
                    AlertWarning_ActivateDish.Visible = true;
                }
                else if (_dish.Status.StatusId == 2)
                {
                    _dish.Status = _factoryDAO.GetActiveSimpleStatus();
                    //guardo el plato
                    _dishDAO.Save(_dish);
                    //muestro la alerta de exito
                    AlertSuccess_ActivateDish.Visible = true;
                }
                else
                {
                    //muestro la alerta de advertencia
                    AlertDanger_ActivateDish.Visible = true;
                }
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //si da error muestro la alerta de fallo
                AlertDanger_ActivateDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                //cargo la tabla
                LoadDishTable();
            }
        }

        protected void ButtonDeactivateDish_Click(object sender, EventArgs e)
        {


            try
            {
                //creo una instancia del factory
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                //creo una instancia del IDishDAO
                IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
                //obtengo el id del plato desde el hidden field
                string _dishIdString = HiddenFieldDishModifyId.Value;
                //convierto el id en integer
                int _dishIdInt = int.Parse(_dishIdString);
                //busco el plato por el id que lo asigna a la variable
                Dish _dish = _dishDAO.FindById(_dishIdInt);
                //cambio el estado a activo  
                if (_dish.Status.StatusId == 2)
                {
                    //muestro la alerta de advertencia
                    AlertWarning_DeactivateDish.Visible = true;
                }
                else if (_dish.Status.StatusId == 1)
                {
                    _dish.Status = _factoryDAO.GetDisabledSimpleStatus();
                    //guardo el plato
                    _dishDAO.Save(_dish);
                    //muestro la alerta de exito
                    AlertSuccess_DeactivateDish.Visible = true;
                }
                else
                {
                    //muestro la alerta de fallo
                    AlertDanger_DeactivateDish.Visible = true;
                }
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //si da error muestro la alerta de fallo
                AlertDanger_DeactivateDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                //cargo la tabla
                LoadDishTable();
            }
        }

    }
}