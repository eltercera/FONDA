using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.View.BackOfficeModel.Restaurant;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using System.Web;
using com.ds201625.fonda.Logic.FondaLogic;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.DataAccess.Log;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.View.BackOfficePresenter.Restaurante
{
    public class CategoryPresenter : Presenter
    {
        //enlace entre el modelo y la vista
        private ICategoryModel _view;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public CategoryPresenter(ICategoryModel viewAddCategory)
            : base(viewAddCategory)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewAddCategory;

        }


        /// <summary>
        /// Construye una tabla de categorias
        /// Utilizando el control de asp: Table
        /// </summary>
        public void LoadTable()
        {
            Command commandGetAllCategories;
            CleanTable();
            IList<RestaurantCategory> listRest;
            try
            {
                //Llamada al comando para generar la lista de todos las categorias
                commandGetAllCategories = CommandFactory.GetCommandGetAllCategories("null");
                commandGetAllCategories.Execute();
                //Resultado del receiver
                listRest = (IList<RestaurantCategory>)commandGetAllCategories.Receiver;
            }
            catch (CommandExceptionGetAllCategories e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ClassNameGetAllCategories, e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ClassNameGetAllCategories, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ClassNameGetAllCategories, e);
            }

            int totalRows = listRest.Count; //tamano de la lista 
            int totalColumns = 1; //numero de columnas de la tabla

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listRest[i].Id.ToString();
                //Agrega la fila a la tabla existente
                _view.categoryRest.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria
                    if (j.Equals(0))
                        tCell.Text = listRest[i].Name;
                    //Agrega las acciones de la tabla
                    else if (j.Equals(1))
                    {
                        //Centrar contenido de las celdas
                        tCell.CssClass = "text-center";
                        //Crea hipervinculo para las acciones
                        LinkButton actionModify = new LinkButton();
                        //Agregar atributos de la celda
                        actionModify.Attributes["data-toggle"] = "modal";
                        actionModify.Attributes["data-target"] = "#modificar";
                        actionModify.Text = com.ds201625.fonda.Resources.FondaResources.Login.RestaurantResource.ActionModify;
                        tCell.Controls.Add(actionModify);
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.categoryRest.Rows.AddAt(0, header);
        }


        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        public TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Nombre";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Acciones";
            h2.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla mostrada en pantalla
        /// </summary>
        public void CleanTable()
        {
            _view.categoryRest.Rows.Clear();

        }

        /// <summary>
        /// Valida los datos ingresados al agregar categoria
        /// </summary>
        /// <param name="name">Nombre de la categoria</param>
        /// <returns>Devuelve true si son validos los datos, false si son incorrectos</returns>
        public bool CategoryValidate(string name)
        {
            bool valid = true;
            //expresion regular para validar campos de letra
            string patron = "^[A-Za-z]*$";
            //valida que el campo no este vacio 
            if (name == "")
            {
                valid = false;
            }
            // valida la expresion regular con el campo name
            if (!Regex.IsMatch(name, patron))
            {
                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// Agrega una nueva categoria
        /// </summary>
        public void ButtonAgregar_Click()
        {
            Command commandAddCategory;
            Command commandSaveCategory;
            String nombreA = _view.nameCategoryA.Text;
            RestaurantCategory _restcat;

            //si el campo es valido se registra la la nueva categoria y activa el mensaje de éxito
            if (CategoryValidate(nombreA))
            {
                _view.alertAddCategorySuccess.Visible = true;

                //Try-Catch para Comando de agregar una categoria
                try
                {
                    //Llamada al comando para generar la lista de todos los restaurantes
                    commandAddCategory = CommandFactory.GetCommandAddCategory(nombreA);
                    commandAddCategory.Execute();
                    //Resultado del receiver
                    _restcat = (RestaurantCategory)commandAddCategory.Receiver;
                }
                catch (CommandExceptionAddCategory e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionAddCategory(RestaurantErrors.CommandExceptionAddCategory, e);
                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionAddCategory(RestaurantErrors.InvalidTypeParameterException, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionAddCategory(RestaurantErrors.ParameterIndexOutRangeException, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionAddCategory(RestaurantErrors.RequieredParameterNotFoundException, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionAddCategory(RestaurantErrors.ClassNameAddCategory, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionAddCategory(RestaurantErrors.ClassNameAddCategory, e);
                }

                //Try Catch del comando guardar una categoria
                try
                {
                    //Guarda nuevo Restaurante en la Base de Datos usando el comando saveRestaurant
                    commandSaveCategory = CommandFactory.GetCommandSaveCategory(_restcat);
                    //ejecuto el comando
                    commandSaveCategory.Execute();
                }
                catch (CommandExceptionSaveCategory e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.CommandExceptionSaveCategory, e);
                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.InvalidTypeParameterException, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.ParameterIndexOutRangeException, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.RequieredParameterNotFoundException, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.ClassNameSaveCategory, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.ClassNameSaveCategory, e);
                }


                //_restcatDAO.Save(_restcat);
                LoadTable();
            }
            else
            {
                //mensaje de error por insertar caracteres invalidos
                _view.alertAddCategoryError.Visible = true;
            }
            _view.nameCategoryA.Text = string.Empty;
        }

        /// <summary>
        /// Modifica una categoria
        /// </summary>
        public void ButtonModificar_Click()
        {
            Command commandSaveCategory;
            Command commandModifyCategory;
            RestaurantCategory _restcat;
            string nameM = _view.nameCategoryM.Text;
            if (CategoryValidate(nameM))
            {
                _view.alertModifyCategorySuccess.Visible = true;
                string CategoryID = _view.categoryModifyId.Value;
                int idCat = int.Parse(CategoryID);

                //Lista de objetos que se le pasara al comando
                Object[] _modifylist = new Object[2];
                _modifylist[0] = idCat;
                _modifylist[1] = nameM;

                try
                {
                    //Llamada al comando para modificar el nombre de la categoria
                    commandModifyCategory = CommandFactory.GetCommandModifyCategory(_modifylist);
                    commandModifyCategory.Execute();

                    //Resultado del receiver
                    _restcat = (RestaurantCategory)commandModifyCategory.Receiver;
                }
                catch (CommandExceptionModifyCategory e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyCategory(RestaurantErrors.CommandExceptionModifyCategory, e);
                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyCategory(RestaurantErrors.InvalidTypeParameterException, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyCategory(RestaurantErrors.ParameterIndexOutRangeException, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyCategory(RestaurantErrors.RequieredParameterNotFoundException, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyCategory(RestaurantErrors.ClassNameModifyCategory, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionModifyCategory(RestaurantErrors.ClassNameModifyCategory, e);
                }

                //Try Catch del Comando Save Category
                try
                {
                    //Guarda nueva Categoria en la Base de Datos usando el comando saveCategory
                    commandSaveCategory = CommandFactory.GetCommandSaveCategory(_restcat);
                    //ejecuto el comando
                    commandSaveCategory.Execute();
                }
                catch (CommandExceptionSaveCategory e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.CommandExceptionSaveCategory, e);
                }
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.InvalidTypeParameterException, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.ParameterIndexOutRangeException, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.RequieredParameterNotFoundException, e);
                }
                catch (NullReferenceException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.ClassNameSaveCategory, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionSaveCategory(RestaurantErrors.ClassNameSaveCategory, e);
                }

                LoadTable();
            }
            else
            {
                _view.alertModifyCategoryError.Visible = true;
            }
            _view.nameCategoryM.Text = string.Empty;
        }

    }
}
