using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Web.Services;

namespace BackOffice.Seccion.Menu
{
    public partial class ListarCategoria : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = false;
            AlertSuccess_ModificarCategoria.Visible = false;
            AlertDanger_AgregarCategoria.Visible = false;
            AlertDanger_ModificarCategoria.Visible = false;
            LoadTable();
        }
        protected void LoadTable()
        {

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
            IList<MenuCategory> listMenuC = _mencatDAO.GetAll();


            int totalRows = listMenuC.Count; //tamano de la lista 
            int totalColumns = 2; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listMenuC[i].Id.ToString();
                //Agrega la fila a la tabla existente
                CategoryMenu.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria
                    if (j.Equals(0))
                        tCell.Text = listMenuC[i].Name;
                    if (j.Equals(1))
                        tCell.Text = listMenuC[i].Status.ToString();
                    //Agrega las acciones de la tabla
                    else if (j.Equals(2))
                    {
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton action = new LinkButton();
                        action.Attributes["data-toggle"] = "modal";
                        action.Attributes["data-target"] = "#modificar";
                        action.Text = RecursosMenu1.Acciones;
                        tCell.Controls.Add(action);
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

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

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Estado";
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
            CategoryMenu.Rows.Clear();

        }

        protected void BotonAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                FactoryDAO factoryDAO = FactoryDAO.Intance;
                IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
                MenuCategory _mencat = new MenuCategory();
                String nombre = Value1.Text;
                _mencat.Name = nombre;
                _mencat.ListDish = null;
                _mencat.Status = factoryDAO.GetActiveSimpleStatus();
                _mencatDAO.Save(_mencat);
                AlertSuccess_AgregarCategoria.Visible = true;
            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                AlertDanger_AgregarCategoria.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                LoadTable();
            }
        }

        protected void BotonModificarCategoria_Click(object sender, EventArgs e)
        {

            try
            {
                FactoryDAO factoryDAO = FactoryDAO.Intance;
                IMenuCategoryDAO _mencatDAO = factoryDAO.GetMenuCategoryDAO();
                string nameCM;
                string MenuCatID = MenuCatModifyId.Value;
                int idMenCat = int.Parse(MenuCatID);
                MenuCategory _menucat = _mencatDAO.FindById(idMenCat);
                nameCM = TextBoxModifyCategoryName.Text;
                _menucat.Name = nameCM;
                _menucat.Status = factoryDAO.GetActiveSimpleStatus();
                _mencatDAO.Save(_menucat);
             
                AlertSuccess_ModificarCategoria.Visible = true;

            }
            //Deberiamos cambiar al tipo de excepcion correcta una vez definamos las excepciones
            catch (Exception exc)
            {
                AlertDanger_ModificarCategoria.Visible = true;
                System.Console.WriteLine("Excepcion capturada: {0}", exc);
            }
            finally
            {
                LoadTable();
            }


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

    }
}
