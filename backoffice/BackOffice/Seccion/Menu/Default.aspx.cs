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

namespace BackOffice.Seccion.Menu
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AddDish.Visible = false;
            AlertSuccess_ModifyDish.Visible = false;
            AlertDanger_AddDish.Visible = false;
            AlertDanger_ModifyDish.Visible = false;
            LoadDishTable();
        }

        protected void LoadDishTable()
        {

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta

            //FactoryDAO factoryDAO = FactoryDAO.Intance;
            //IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            //IList<MenuCategory> listMenuC = _mencatDAO.GetAll();

            FactoryDAO _factoryDAO = FactoryDAO.Intance;
            IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
            IMenuCategoryDAO _menCatDAO = _factoryDAO.GetMenuCategoryDAO();
            IList<Dish> _listDish = _dishDAO.GetAll();
            IList<MenuCategory> _listMenCat = _menCatDAO.GetAll();

            int totalRows = _listDish.Count; //tamano de la lista 
            int totalColumns = 4; //numero de columnas de la tabla

            //Recorremos la lista
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

                    //Agrega el checkbox de sugerencia de la tabla
                    else if (j.Equals(2))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones

                        //LinkButton action = new LinkButton();
                        //action.Attributes["data-toggle"] = "modal";
                        //action.Attributes["data-target"] = "#modificar";
                        //action.Text = ResourceMenu.Acciones;

                        CheckBox CheckBoxSuggestion = new CheckBox();
                        CheckBoxSuggestion.ToolTip = "Marcar Sugerencia";
                        CheckBoxSuggestion.Checked = false;
                        tCell.Controls.Add(CheckBoxSuggestion);
                    }
                    if (j.Equals(3))
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
                    //  tCell.Text = _listDish[i].Status.ToString();

                    //Agrega las acciones de la tabla
                    else if (j.Equals(4))
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
                        LinkButtonChangeDishStatusActive.Attributes["data-target"] = "#";
                        LinkButtonChangeDishStatusActive.Text = ResourceMenu.ActionSetActiveDishMenuPrincipal;
                        LinkButtonChangeDishStatusActive.ToolTip = "Activar Plato";
                        //   LinkButtonChangeDishStatusActive.Click += LinkButtonChangeDishStatusActive_Click();
                        tCell.Controls.Add(LinkButtonChangeDishStatusActive);


                        LinkButton LinkButtonChangeDishStatusInactive = new LinkButton();
                        LinkButtonChangeDishStatusInactive.Attributes["data-toggle"] = "modal";
                        LinkButtonChangeDishStatusInactive.Attributes["data-target"] = "#";
                        LinkButtonChangeDishStatusInactive.Text = ResourceMenu.ActionSetInactiveDishMenuPrincipal;
                        LinkButtonChangeDishStatusInactive.ToolTip = "Desactivar Plato";
                        tCell.Controls.Add(LinkButtonChangeDishStatusInactive);
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }
            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateDishTableHeader();
            TableDish.Rows.AddAt(0, header);
        }

        protected void LoadCategoryTable()
        {
            ////limpio la tabla
            //CleanTable();
            ////Genero los objetos para la consulta
            //FactoryDAO _factoryDAO = FactoryDAO.Intance;
            //IMenuCategoryDAO _menCatDAO = _factoryDAO.GetMenuCategoryDAO();
            ////Genero la lista de la consulta
            //IList<MenuCategory> _listMenCat = _menCatDAO.GetAll();

            //int totalRows = _listMenCat.Count; //tamano de la lista 
            //int totalColumns = 1; //numero de columnas de la tabla

            ////Recorremos la lista
            //for (int i = 0; i <= totalRows - 1; i++)
            //{
            //    //Crea una nueva fila de la tabla
            //    TableRow tRow = new TableRow();
            //    //Le asigna el Id a cada fila de la tabla
            //    tRow.Attributes["data-id"] = _listMenCat[i].Id.ToString();
            //    //Agrega la fila a la tabla existente
            //    TableCategory.Rows.Add(tRow);
            //    for (int j = 0; j <= totalColumns; j++)
            //    {
            //        //Crea una nueva celda de la tabla
            //        TableCell tCell = new TableCell();
            //        //Agrega el nombre de la categoria
            //        if (j.Equals(0))
            //            tCell.Text = _listMenCat[i].Name;
            //        tCell.CssClass = "panel-title pull-left";
            //        //Crea hipervinculo para las acciones
            //        LinkButton addDish = new LinkButton();
            //        addDish.Attributes["data-toggle"] = "modal";
            //        addDish.Attributes["data-target"] = "#modify_dish";
            //        addDish.Text = ResourceMenu.AddDishMenuPrincipal;
            //        tCell.Controls.Add(addDish);
            //        if (j.Equals(1))
            //            tCell.Text = _listDish[i].Cost.ToString();

            //        //Agrega el checkbox de sugerencia de la tabla
            //        else if (j.Equals(2))
            //        {
            //            tCell.CssClass = "text-center";
            //            //Crea hipervinculo para las acciones

            //            //LinkButton action = new LinkButton();
            //            //action.Attributes["data-toggle"] = "modal";
            //            //action.Attributes["data-target"] = "#modificar";
            //            //action.Text = ResourceMenu.Acciones;

            //            CheckBox CheckBoxSuggestion = new CheckBox();
            //            CheckBoxSuggestion.ToolTip = "Marcar Sugerencia";
            //            tCell.Controls.Add(CheckBoxSuggestion);
            //        }
            //        if (j.Equals(3))
            //            tCell.Text = _listDish[i].Status.ToString();

            //        //Agrega las acciones de la tabla
            //        else if (j.Equals(4))
            //        {
            //            tCell.CssClass = "text-center";
            //            //Crea hipervinculo para las acciones
            //            LinkButton action = new LinkButton();
            //            action.Attributes["data-toggle"] = "modal";
            //            action.Attributes["data-target"] = "#modify_dish";
            //            action.Text = ResourceMenu.ActionMenuPrincipal;
            //            tCell.Controls.Add(action);
            //        }
            //        //Agrega la 
            //        tRow.Cells.Add(tCell);

            //    }
            //    //Agrega el encabezado a la Tabla
            //    TableHeaderRow header = GenerateCategoryTableHeader(_listMenCat[i].Name, _listMenCat[i].Id);
            //    TableCategory.Rows.AddAt(0, header);
            //}


        }

        // private TableHeaderRow GenerateCategoryTableHeader(string menCat, int menCatId)
        // {
        //  //Se crea la fila en donde se insertara el header
        //  TableHeaderRow header = new TableHeaderRow();

        //  //Se crean las columnas del header
        //  TableHeaderCell h1 = new TableHeaderCell();
        ////  HiddenField HiddenFieldMenCatId = new HiddenField();
        //  //TableHeaderCell h2 = new TableHeaderCell();
        //  //TableHeaderCell h3 = new TableHeaderCell();
        //  //TableHeaderCell h4 = new TableHeaderCell();
        //  //TableHeaderCell h5 = new TableHeaderCell();

        //  //Se indica que se trabajara en el header y se asignan los valores a las columnas
        //  header.TableSection = TableRowSection.TableHeader;
        //  h1.Text = menCat;
        //  h1.CssClass = "panel-title pull-left";
        //  LinkButton addDish = new LinkButton();
        //  addDish.Attributes["data-toggle"] = "modal";
        //  addDish.Attributes["data-target"] = "#add_dish";
        //  addDish.Text = ResourceMenu.AddDishMenuPrincipal;
        //  h1.Controls.Add(addDish);
        //  h1.Scope = TableHeaderScope.Column;
        //  //h2.Text = "Precio";
        //  //h2.Scope = TableHeaderScope.Column;
        //  //h3.Text = "Sugerencia del dia";
        //  //h3.Scope = TableHeaderScope.Column;
        //  //h4.Text = "Estado";
        //  //h4.Scope = TableHeaderScope.Column;
        //  //h5.Text = "Acciones";
        //  //h5.Scope = TableHeaderScope.Column;

        //  //Se asignan las columnas a la fila
        //  header.Cells.Add(h1);
        //  //header.Cells.Add(h2);
        //  //header.Cells.Add(h3);
        //  //header.Cells.Add(h4);
        //  //header.Cells.Add(h5);

        //  return header;
        //  }

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

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Plato";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Precio";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Sugerencia del dia";
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
            //TableCategory.Rows.Clear();  
            TableDish.Rows.Clear();

        }

        protected void ButtonModifyDish_Click(object sender, EventArgs e)
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

        protected void ButtonAddDish_Click(object sender, EventArgs e)
        {

            try
            {
                //creo una instancia del factory
                FactoryDAO _factoryDAO = FactoryDAO.Intance;
                //creo una instancia del IDishDAO
                IDishDAO _dishDAO = _factoryDAO.GetDishDAO();
                //Creo una instancia de Dish
                Dish _dish = new Dish();

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
                //guardo el plato
                _dishDAO.Save(_dish);

                //muestro la alerta de exito
                AlertSuccess_AddDish.Visible = true;
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
                //cargo la tabla
                LoadDishTable();
            }
        }


        //protected EventHandler LinkButtonChangeDishStatusActive_Click()
        //{
        //    return true;
        //}

        protected void ButtonCancelAddDish_Click(object sender, EventArgs e)
        {

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
    }
}