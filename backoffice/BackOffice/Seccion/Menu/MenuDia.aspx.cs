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
using com.ds201625.fonda.Resources.FondaResources.Login;
using BackOffice.Content;

namespace BackOffice.Seccion.Menu
{

    public partial class MenuDia : System.Web.UI.Page
    {
        //IList<Dish> ListSuggestionDish = new List<Dish>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                LoadDayMenuTable();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }

        protected void LoadDayMenuTable()
        {
            IList<Dish> ListSuggestionDish = new List<Dish>();

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            IList<MenuCategory> listMenuC = _mencatDAO.GetAll();


            int lenghtListMenuC = listMenuC.Count;
            for (int i = 0; i <= lenghtListMenuC - 1; i++)
            {
                MenuCategory categoria = listMenuC[i];
                if (categoria.ListDish != null)
                {
                    IList<Dish> listDish = categoria.ListDish;
                    int lenghtlistDish = listDish.Count;

                    for (int j = 0; j <= lenghtlistDish - 1; j++)
                    {
                        if (listDish[j].Suggestion == true)
                        {
                            ListSuggestionDish.Add(listDish[j]);
                        }
                    }
                }
            }



            int totalRows = ListSuggestionDish.Count; //tamano de la lista 
            int totalColumns = 2; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = ListSuggestionDish[i].Id.ToString();
                String ver_id = ListSuggestionDish[i].Id.ToString();
                //Agrega la fila a la tabla existente
                TableDayMenu.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {

                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria
                    if (j.Equals(0))
                        tCell.Text = ListSuggestionDish[i].Name;
                    if (j.Equals(1))
                        tCell.Text = ListSuggestionDish[i].Cost.ToString();
                    //Agrega las acciones de la tabla
                    else if (j.Equals(2))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton action = new LinkButton();
                        action.Attributes["data-toggle"] = "modal";
                        action.Attributes["data-target"] = "#ver_plato";
                        action.Text = ResourceMenu.ActionMenuDia;
                        tCell.Controls.Add(action);

                        LinkButton LinkButtonRemoveSuggestion = new LinkButton();
                        LinkButtonRemoveSuggestion.Attributes["data-toggle"] = "modal";
                        LinkButtonRemoveSuggestion.Attributes["data-target"] = "#remove_suggestion";
                        LinkButtonRemoveSuggestion.Text = ResourceMenu.ActionRemoveSuggestion;
                        LinkButtonRemoveSuggestion.ToolTip = "Remover Sugerencia";
                        tCell.Controls.Add(LinkButtonRemoveSuggestion);
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }


            }
            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableDayMenuHeader();
            TableDayMenu.Rows.AddAt(0, header);
            //listMenuC = null;
            //ListSuggestionDish = null;
        }


        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableDayMenuHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Precio";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Acciones";
            h3.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);

            return header;
        }


        public void CleanTable()
        {
            TableDayMenu.Rows.Clear();

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
                string _dishIdString = HiddenFieldSuggestionDishId.Value;
                //convierto el id en integer
                int _dishIdInt = int.Parse(_dishIdString);
                //busco el plato por el id que lo asigna a la variable
                Dish _dish = _dishDAO.FindById(_dishIdInt);

                _dish.Suggestion = false;






                //guardo el plato

                _dishDAO.Save(_dish);
                //muestro la alerta de exito
                //AlertSuccess_ModifyDish.Visible = true;

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
                LoadDayMenuTable();
            }
        }



        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo categoria
        /// </summary>
        /// <param name="Id">Id de la categoria a mostrar</param>
        /// <returns>Informacion de objeto categoria</returns>

        [WebMethod]
        public static Dish GetData(string Id)
        {
            int menID = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IDishDAO _mencatDAO = factoryDAO.GetDishDAO();
            Dish menCat = _mencatDAO.FindById(menID);

            return menCat;

        }
    }
}