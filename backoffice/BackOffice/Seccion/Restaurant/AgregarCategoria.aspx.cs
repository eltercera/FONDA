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
using System.Text.RegularExpressions;
using com.ds201625.fonda.Resources.FondaResources.Login;
using com.ds201625.fonda.View.BackOfficeModel.Restaurant;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficePresenter.Restaurante;
using BackOffice.Content;


namespace BackOffice.Seccion.Restaurant
{
    public partial class AgregarCategoria : System.Web.UI.Page, ICategoryModel
    {

        FactoryDAO factoryDAO = FactoryDAO.Intance;

        //SegundaEntrega
        #region presenter 
        private CategoryPresenter _presenter;
        #endregion

        #region constructor
        public AgregarCategoria()
        {
            //presentador que se encargará del MVP
            _presenter = new CategoryPresenter(this);
        }
        #endregion

        //carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                if (Session[ResourceLogin.sessionRol].ToString() == "Sistema")
                {
                    AlertSuccess_AgregarCategoria.Visible = false;
                AlertSuccess_ModificarCategoria.Visible = false;
                AlertError_AgregarCategoria.Visible = false;
                AlertError_ModificarCategoria.Visible = false;
                //NombreCatA.Attributes.Add("required", "required");
                _presenter.LoadTable();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }



        #region Model
        //alertas de IModel
        public string SessionRestaurant
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HtmlGenericControl SuccessLabel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Label SuccessLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HtmlGenericControl ErrorLabel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Label ErrorLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        //alertas de Agregar Categoria
        public System.Web.UI.HtmlControls.HtmlGenericControl alertAddCategoryError
        {
            get { return AlertError_AgregarCategoria; }
            set { AlertError_AgregarCategoria = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertAddCategorySuccess
        {
            get { return AlertSuccess_AgregarCategoria; }
            set { AlertSuccess_AgregarCategoria = value; }
        }
        //alertas de Modificar Categoria
        public System.Web.UI.HtmlControls.HtmlGenericControl alertModifyCategoryError
        {
            get { return AlertError_ModificarCategoria; }
            set { AlertError_ModificarCategoria = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertModifyCategorySuccess
        {
            get { return AlertSuccess_ModificarCategoria; }
            set { AlertSuccess_ModificarCategoria = value; }
        }
        //Modal de modificar categoria
        public System.Web.UI.WebControls.TextBox nameCategoryM
        {
            get { return NombreCatM; }
            set { NombreCatM = value; }
        }
        public System.Web.UI.WebControls.Button buttonModificar
        {
            get { return ButtonModificar; }
            set { ButtonModificar = value; }
        }
        public System.Web.UI.WebControls.Button buttonCancelarM
        {
            get { return ButtonCancelarM; }
            set { ButtonCancelarM = value; }
        }
        //Modelas de agregar categoria
        public System.Web.UI.WebControls.TextBox nameCategoryA
        {
            get { return NombreCatA; }
            set { NombreCatA = value; }
        }
        public System.Web.UI.WebControls.Button buttonAgregar
        {
            get { return ButtonAgregar; }
            set { ButtonAgregar = value; }
        }
        public System.Web.UI.WebControls.Button buttonCancelarA
        {
            get { return ButtonCancelarA; }
            set { ButtonCancelarA = value; }
        }
        //pagina
        public System.Web.UI.WebControls.HiddenField categoryModifyId
        {
            get { return CategoryModifyId; }
            set { CategoryModifyId = value; }
        }
        public System.Web.UI.WebControls.Table categoryRest
        {
            get { return CategoryRest; }
            set { CategoryRest = value; }
        }

        #endregion


        //llamadas a los metodos

        /// <summary>
        /// llamada al metodo para Agrega una nueva categoria
        /// </summary>
        public void ButtonAgregar_Click(object sender, EventArgs e)
        {
            ButtonAgregar_Click();
        }
        public void ButtonAgregar_Click()
        {
            _presenter.ButtonAgregar_Click();

        }
        /// <summary>
        /// llamada al metodo para modificar una categoria
        /// </summary>
        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            ButtonModificar_Click();
        }
        public void ButtonModificar_Click()
        {
            _presenter.ButtonModificar_Click();
        }

        [WebMethod]
        public static RestaurantCategory GetData(string Id)
        {
            System.Diagnostics.Debug.WriteLine("aqui llegoiahsiahsi");
            int categoryId = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            RestaurantCategory restCategory = _restcatDAO.FindById(categoryId);
            System.Diagnostics.Debug.WriteLine("aqui llego"+ restCategory.ToString());
            return restCategory;

        }

    }
}