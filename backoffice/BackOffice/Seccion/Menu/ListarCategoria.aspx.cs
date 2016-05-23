using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace BackOffice.Seccion.Menu
{
    public partial class ListarCategoria : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AddCategory.Visible = false;
            AlertSuccess_ModifyCategory.Visible = false;
            AlertDanger_AddCategory.Visible = false;
            AlertDanger_ModifyCategory.Visible = false;

            LoadMenuCategoryTable();
        }
        protected void LoadMenuCategoryTable()
        {
            FillRestaurantDropdown();
            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO _factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = _factoryDAO.GetMenuCategoryDAO();
            IRestaurantDAO _restaurantDAO = _factoryDAO.GetRestaurantDAO();
            IList<com.ds201625.fonda.Domain.Restaurant> _listRestaurant = _restaurantDAO.GetAll();

            int totalRowsRestaurant = _listRestaurant.Count; //tamano de la lista 
            int totalColumns = 3; //numero de columnas de la tabla


            for (int k = 0; k <= totalRowsRestaurant - 1; k++)
            {

                if (_listRestaurant != null)
                {
                    IList<MenuCategory> _listMenCat = new List<MenuCategory>();

                    _listMenCat = _listRestaurant[k].MenuCategories;
                    if (_listMenCat != null)
                    {
                        int totalRows = _listMenCat.Count; //tamano de la lista platos
                                                           //recorro la lista de platos


                        //Recorremos la lista
                        for (int i = 0; i <= totalRows - 1; i++)
                        {
                            //Crea una nueva fila de la tabla
                            TableRow tRow = new TableRow();
                            //Le asigna el Id a cada fila de la tabla
                            tRow.Attributes["data-id"] = _listMenCat[i].Id.ToString();
                            //Agrega la fila a la tabla existente
                            CategoryMenu.Rows.Add(tRow);
                            for (int j = 0; j <= totalColumns; j++)
                            {
                                //Crea una nueva celda de la tabla
                                TableCell tCell = new TableCell();
                                //Agrega el nombre de la categoria
                                if (j.Equals(0))
                                    tCell.Text = _listMenCat[i].Name;
                                if (j.Equals(1))
                                    tCell.Text = _listRestaurant[k].Name;

                                if (j.Equals(2))
                                {
                                    tCell.CssClass = "text-center";

                                    if (_listMenCat[i].Status.StatusId == 1)
                                    {
                                        tCell.Text = ResourceMenu.Active;

                                    }
                                    else if (_listMenCat[i].Status.StatusId == 2)
                                    {
                                        tCell.Text = ResourceMenu.Inactive;
                                    }
                                }

                                //Agrega las acciones de la tabla
                                else if (j.Equals(3))
                                {
                                    tCell.CssClass = "text-center";
                                    //Crea hipervinculo para las acciones
                                    LinkButton action = new LinkButton();
                                    action.Attributes["data-toggle"] = "modal";
                                    action.Attributes["data-target"] = "#modify_category";
                                    action.Text = ResourceMenu.ActionModificarCategoria;
                                    tCell.Controls.Add(action);

                                    LinkButton LinkButtonActivateCategory = new LinkButton();
                                    LinkButtonActivateCategory.Attributes["data-toggle"] = "modal";
                                    LinkButtonActivateCategory.Attributes["data-target"] = "#activate_category";
                                    LinkButtonActivateCategory.Text = ResourceMenu.ActionActivateCategory;
                                    LinkButtonActivateCategory.ToolTip = "Activar Categoria";
                                    tCell.Controls.Add(LinkButtonActivateCategory);

                                    LinkButton LinkButtonDactivateCategory = new LinkButton();
                                    LinkButtonDactivateCategory.Attributes["data-toggle"] = "modal";
                                    LinkButtonDactivateCategory.Attributes["data-target"] = "#deactivate_category";
                                    LinkButtonDactivateCategory.Text = ResourceMenu.ActionInactivateCategory;
                                    LinkButtonDactivateCategory.ToolTip = "Remover Sugerencia";
                                    tCell.Controls.Add(LinkButtonDactivateCategory);
                                }
                                //Agrega la 
                                tRow.Cells.Add(tCell);

                            }
                        }
                    }

             
                }
            }
            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            CategoryMenu.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Retorna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();


            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Restaurante";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Estado";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "Acciones";
            h4.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);

            return header;
        }


        public void CleanTable()
        {
            CategoryMenu.Rows.Clear();

        }

        public void CleanRestaurantDropDown()
        {
            DropDownListRestaurantAddCategory.Items.Clear();
        }

        protected void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                String CategoryAdd = TextBoxAddCategoryName.Text;
                if (MenuCategoryValidate(CategoryAdd))
                {
                    FactoryDAO _factoryDAO = FactoryDAO.Intance;
                    IMenuCategoryDAO _mencatDAO = _factoryDAO.GetMenuCategoryDAO();
                    MenuCategory _mencat = new MenuCategory();
                    String nombre = TextBoxAddCategoryName.Text;
                    IRestaurantDAO _restaurantDAO = _factoryDAO.GetRestaurantDAO();
                    IList<com.ds201625.fonda.Domain.Restaurant> _listRestaurant = _restaurantDAO.GetAll();


                    com.ds201625.fonda.Domain.Restaurant _restaurant = new com.ds201625.fonda.Domain.Restaurant();
                    //obtengo el objeto por el id del valor seleccionado en el DropDownList
                    _restaurant = _restaurantDAO.FindById(int.Parse(DropDownListRestaurantAddCategory.SelectedValue));

                    _mencat.Name = nombre;
                    _mencat.ListDish = null;
                    _mencat.Status = _factoryDAO.GetActiveSimpleStatus();
                    _restaurant.MenuCategories.Add(_mencat);
                    _restaurantDAO.Save(_restaurant);


                    //        _mencatDAO.Save(_mencat);
                    //muestro la alerta de exito
                    AlertSuccess_AddCategory.Visible = true;

                }
                else
                {
                    AlertDanger_AddCategory.Visible = true;
                }
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                AlertDanger_ModifyCategory.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                CleanRestaurantDropDown();
                TextBoxAddCategoryName.Text = string.Empty;
                
                LoadMenuCategoryTable();
            }
        }


        protected void ButtonActivateCategory_Click(object sender, EventArgs e)
        {

            try
            {

                //creo una instancia del factory
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                //creo una instancia del IMenuCategoryDAO
                IMenuCategoryDAO _categoryDAO = _factoryDAO.GetMenuCategoryDAO();
                //obtengo el id del plato desde el hidden field
                string _CategoryIdString = HiddenFieldMenuCategoryModifyId.Value;
                //convierto el id en integer
                int _CategoryIdInt = int.Parse(_CategoryIdString);
                //busco el plato por el id que lo asigna a la variable
                MenuCategory _category = _categoryDAO.FindById(_CategoryIdInt);
                //cambio el estado a activo                            
                _category.Status = _factoryDAO.GetActiveSimpleStatus();
                //guardo el plato
                _categoryDAO.Save(_category);
                //muestro la alerta de exito
                AlertSuccess_ModifyCategory.Visible = true;

            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //si da error muestro la alerta de fallo
                //AlertDanger_ModifyDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                //cargo la tabla
                //ListSuggestionDish = null;

                LoadMenuCategoryTable();
            }
        }




        protected void ButtonModifyCategory_Click(object sender, EventArgs e)
        {

            try
            {
                String CategoryModify = TextBoxModifyCategoryName.Text;
                if (MenuCategoryValidate(CategoryModify))
                {
                    FactoryDAO factoryDAO = FactoryDAO.Intance;
                    IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
                    string nameCM;
                    string MenuCatID = HiddenFieldMenuCategoryModifyId.Value;
                    int idMenCat = int.Parse(MenuCatID);
                    MenuCategory _menucat = _mencatDAO.FindById(idMenCat);
                    nameCM = TextBoxModifyCategoryName.Text;
                    _menucat.Name = nameCM;
                    _menucat.Status = factoryDAO.GetActiveSimpleStatus();
                    _mencatDAO.Save(_menucat);

                    AlertSuccess_ModifyCategory.Visible = true;
                }
                else
                {
                    AlertDanger_ModifyCategory.Visible = true;
                }

            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                AlertDanger_ModifyCategory.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                TextBoxModifyCategoryName.Text = string.Empty;
                LoadMenuCategoryTable();
            }


        }

        /// <summary>
        /// Valida los datos ingresados al agregar categoria
        /// </summary>
        /// <param name="name">Nombre de la categoria</param>
        /// <returns>Devuelve true si son validos los datos, false si son incorrectos</returns>
        private bool MenuCategoryValidate(string name)
        {
            bool valid = true;
            string patron = "^[A-Za-z]*$";
            if (name == "")
            {
                valid = false;
            }

            if (!Regex.IsMatch(name, patron))
            {
                valid = false;
            }
            return valid;
        }
        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo categoria
        /// </summary>
        /// <param name="Id">Id de la categoria a mostrar</param>
        /// <returns>Informacion de objeto categoria</returns>
        [WebMethod]
        public static MenuCategory GetData(string Id)
        {
            int menID = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            MenuCategory menCat = _mencatDAO.FindById(menID);

            return menCat;
        }

        public void FillRestaurantDropdown()
        {
            try
            {
                //Genero los objetos para la consulta
                //Genero la lista de la consulta
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                IRestaurantDAO _restaurantDAO = _factoryDAO.GetRestaurantDAO();
                IList<com.ds201625.fonda.Domain.Restaurant> _listRestaurant = _restaurantDAO.GetAll();

                int i = 0;
                //Se llenan los Dropdownlist con los registros existentes
                foreach (com.ds201625.fonda.Domain.Restaurant _restaurant in _listRestaurant)
                {
                    DropDownListRestaurantAddCategory.Items.Add(_restaurant.Name);
                    DropDownListRestaurantAddCategory.Items[i].Value = _restaurant.Id.ToString();
                    i++;
                }
            }

            catch (Exception exc)
            {
                System.Console.WriteLine("Excepcion capturada: {0}", exc);

            }
        }

        protected void ButtonDeactivateCategory_Click(object sender, EventArgs e)
        {

            try
            {
                //creo una instancia del factory
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                //creo una instancia del IMenuCategoryDAO
                IMenuCategoryDAO _categoryDAO = _factoryDAO.GetMenuCategoryDAO();
                //obtengo el id del plato desde el hidden field
                string _CategoryIdString = HiddenFieldMenuCategoryModifyId.Value;
                //convierto el id en integer
                int _CategoryIdInt = int.Parse(_CategoryIdString);
                //busco el plato por el id que lo asigna a la variable
                MenuCategory _category = _categoryDAO.FindById(_CategoryIdInt);
                //cambio el estado a activo                            
                _category.Status = _factoryDAO.GetDisabledSimpleStatus();
                //guardo el plato
                _categoryDAO.Save(_category);
                //muestro la alerta de exito
                AlertSuccess_ModifyCategory.Visible = true;

            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                //si da error muestro la alerta de fallo
                //AlertDanger_ModifyDish.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                //cargo la tabla
                //ListSuggestionDish = null;
                LoadMenuCategoryTable();
            }

        }
    }
}
