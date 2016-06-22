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
using FondaResources.Login;
using BackOffice.Content;
using BackOfficeModel.Restaurant;
using System.Web.UI.HtmlControls;
using BackOfficePresenter.Restaurante;

namespace BackOffice.Seccion.Restaurant
{
    public partial class Default : System.Web.UI.Page, IRestaurantModel
    {
        FactoryDAO factoryDAO = FactoryDAO.Intance;

        #region Presenter
        private RestaurantPresenter _presenter;
        #endregion

        #region Model


        //Tabla de Restaurante
        public System.Web.UI.WebControls.Table restaurantTable
        {
            get { return Restaurant; }

            set { Restaurant = value; }
        }

        public System.Web.UI.WebControls.HiddenField RestaurantModifyById
        {
            get { return RestaurantModifyId; }
            set { RestaurantModifyId = value; }
        }

        //Alertas
        public System.Web.UI.HtmlControls.HtmlGenericControl alertErrorModify
        {
            get { return AlertError_ModifyRestaurant; }

            set { AlertError_ModifyRestaurant = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertErrorAdd
        {
            get { return AlertError_AddRestaurant; }

            set { AlertError_AddRestaurant = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertSuccessAdd
        {
            get { return AlertSuccess_AddRestaurant; }

            set { AlertSuccess_AddRestaurant = value; }

        }
        public System.Web.UI.HtmlControls.HtmlGenericControl alertSuccessModify
        {
            get { return AlertSuccess_ModifyRestaurant; }

            set { AlertSuccess_ModifyRestaurant = value; }
        }

        //Elementos Consultar
        public System.Web.UI.WebControls.TextBox nameConsult
        {
            get { return NameC; }

            set { NameC = value; }
        }
        public System.Web.UI.WebControls.TextBox categoryConsult
        {
            get { return CategoryC; }

            set { CategoryC = value; }
        }
        public System.Web.UI.WebControls.TextBox nationalityConsult
        {
            get { return NationalityC; }

            set { NationalityC = value; }
        }
        public System.Web.UI.WebControls.TextBox rifConsult
        {
            get { return RifC; }

            set { RifC = value; }
        }
        public System.Web.UI.WebControls.TextBox currencyConsult
        {
            get { return CurrencyC; }

            set { CurrencyC = value; }
        }
        public System.Web.UI.WebControls.TextBox addressConsult
        {
            get { return AddressC; }

            set { AddressC = value; }
        }
        public System.Web.UI.WebControls.TextBox zoneConsult
        {
            get { return ZoneC; }

            set { ZoneC = value; }
        }
        public System.Web.UI.WebControls.TextBox openingTimeConsult
        {
            get { return OpeningTimeC; }

            set { OpeningTimeC = value; }
        }
        public System.Web.UI.WebControls.TextBox closingTimeConsult
        {
            get { return ClosingTimeC; }

            set { ClosingTimeC = value; }
        }
        public System.Web.UI.WebControls.CheckBox day1Consult
        {
            get { return Day1C; }

            set { Day1C = value; }
        }
        public System.Web.UI.WebControls.CheckBox day2Consult
        {
            get { return Day2C; }

            set { Day2C = value; }
        }
        public System.Web.UI.WebControls.CheckBox day3Consult
        {
            get { return Day3C; }

            set { Day3C = value; }
        }
        public System.Web.UI.WebControls.CheckBox day4Consult
        {
            get { return Day4C; }

            set { Day4C = value; }
        }
        public System.Web.UI.WebControls.CheckBox day5Consult
        {
            get { return Day5C; }

            set { Day5C = value; }
        }
        public System.Web.UI.WebControls.CheckBox day6Consult
        {
            get { return Day6C; }

            set { Day6C = value; }
        }
        public System.Web.UI.WebControls.CheckBox day7Consult
        {
            get { return Day7C; }

            set { Day7C = value; }
        }
        public System.Web.UI.WebControls.Button closeConsult
        {
            get { return CloseConsult; }

            set { CloseConsult = value; }
        }
        public System.Web.UI.HtmlControls.HtmlImage imageConsult
        {
            get { return ImageC; }

            set { ImageC = value; }
        }
        //Elementos Modificar
        public System.Web.UI.WebControls.TextBox nameModify
        {
            get { return NameM; }

            set { NameM = value; }
        }
        public System.Web.UI.WebControls.DropDownList categoryModify
        {
            get { return CategoryM; }

            set { CategoryM = value; }
        }
        public System.Web.UI.WebControls.DropDownList nationalityModify
        {
            get { return NationalityM; }

            set { NationalityM = value; }
        }
        public System.Web.UI.WebControls.TextBox rifModify
        {
            get { return RifM; }

            set { RifM = value; }
        }
        public System.Web.UI.WebControls.DropDownList currencyModify
        {
            get { return CurrencyM; }

            set { CurrencyM = value; }
        }
        public System.Web.UI.WebControls.TextBox addressModify
        {
            get { return AddressM; }

            set { AddressM = value; }
        }
        public System.Web.UI.WebControls.DropDownList zoneModify
        {
            get { return ZoneM; }

            set { ZoneM = value; }
        }
        public System.Web.UI.WebControls.TextBox longModify
        {
            get { return LongM; }

            set { LongM = value; }
        }
        public System.Web.UI.WebControls.TextBox latModify
        {
            get { return LatM; }

            set { LatM = value; }
        }
        public System.Web.UI.WebControls.CheckBox day1Modify
        {
            get { return Day1M; }

            set { Day1M = value; }
        }
        public System.Web.UI.WebControls.CheckBox day2Modify
        {
            get { return Day2M; }

            set { Day2M = value; }
        }
        public System.Web.UI.WebControls.CheckBox day3Modify
        {
            get { return Day3M; }

            set { Day3M = value; }
        }
        public System.Web.UI.WebControls.CheckBox day4Modify
        {
            get { return Day4M; }

            set { Day4M = value; }
        }
        public System.Web.UI.WebControls.CheckBox day5Modify
        {
            get { return Day5M; }

            set { Day5M = value; }
        }
        public System.Web.UI.WebControls.CheckBox day6Modify
        {
            get { return Day6M; }

            set { Day6M = value; }
        }
        public System.Web.UI.WebControls.CheckBox day7Modify
        {
            get { return Day7M; }

            set { Day7M = value; }
        }
        public System.Web.UI.WebControls.TextBox showOpeningTimeModify
        {
            get { return ShowOpeningTimeM; }

            set { ShowOpeningTimeM = value; }
        }
        public System.Web.UI.WebControls.TextBox openingTimeModify
        {
            get { return OpeningTimeM; }

            set { OpeningTimeM = value; }
        }
        public System.Web.UI.WebControls.TextBox showClosingTimeModify
        {
            get { return ShowClosingTimeM; }

            set { ShowClosingTimeM = value; }
        }
        public System.Web.UI.WebControls.TextBox closingTimeModify
        {
            get { return ClosingTimeM; }

            set { ClosingTimeM = value; }
        }
        public System.Web.UI.HtmlControls.HtmlInputFile imageModify
        {
            get { return ImageM; }

            set { ImageM = value; }
        }
        public System.Web.UI.WebControls.Button buttonModify
        {
            get { return ButtonModify; }

            set { ButtonModify = value; }
        }
        public System.Web.UI.WebControls.Button buttonCancelModify
        {
            get { return ButtonCancelM; }

            set { ButtonCancelM = value; }
        }

        //Elementos Agregar
        public System.Web.UI.WebControls.TextBox nameAdd
        {
            get { return NameA; }

            set { NameA = value; }
        }
        public System.Web.UI.WebControls.DropDownList categoryAdd
        {
            get { return CategoryA; }

            set { CategoryA = value; }
        }
        public System.Web.UI.WebControls.DropDownList nationalityAdd
        {
            get { return NacionalityA; }

            set { NacionalityA = value; }
        }
        public System.Web.UI.WebControls.TextBox rifAdd
        {
            get { return RifA; }

            set { RifA = value; }
        }
        public System.Web.UI.WebControls.DropDownList currencyAdd
        {
            get { return CurrencyA; }

            set { CurrencyA = value; }
        }
        public System.Web.UI.WebControls.TextBox addressAdd
        {
            get { return AddressA; }

            set { AddressA = value; }
        }
        public System.Web.UI.WebControls.DropDownList zoneAdd
        {
            get { return ZoneA; }

            set { ZoneA = value; }
        }
        public System.Web.UI.WebControls.TextBox longAdd
        {
            get { return LongA; }

            set { LongA = value; }
        }
        public System.Web.UI.WebControls.TextBox latAdd
        {
            get { return LatA; }

            set { LatA = value; }
        }
        public System.Web.UI.WebControls.CheckBox day1Add
        {
            get { return Day1A; }

            set { Day1A = value; }
        }
        public System.Web.UI.WebControls.CheckBox day2Add
        {
            get { return Day2A; }

            set { Day2A = value; }
        }
        public System.Web.UI.WebControls.CheckBox day3Add
        {
            get { return Day3A; }

            set { Day3A = value; }
        }
        public System.Web.UI.WebControls.CheckBox day4Add
        {
            get { return Day4A; }

            set { Day4A = value; }
        }
        public System.Web.UI.WebControls.CheckBox day5Add
        {
            get { return Day5A; }

            set { Day5A = value; }
        }
        public System.Web.UI.WebControls.CheckBox day6Add
        {
            get { return Day6A; }

            set { Day6A = value; }
        }
        public System.Web.UI.WebControls.CheckBox day7Add
        {
            get { return Day7A; }

            set { Day7A = value; }
        }
        public System.Web.UI.WebControls.TextBox openingTimeAdd
        {
            get { return OpeningTimeA; }

            set { OpeningTimeA = value; }
        }
        public System.Web.UI.WebControls.TextBox closingTimeAdd
        {
            get { return ClosingTimeA; }

            set { ClosingTimeA = value; }
        }
        public System.Web.UI.HtmlControls.HtmlInputFile imageAdd
        {
            get { return ImageA; }

            set { ImageA = value; }
        }
        public System.Web.UI.WebControls.Button buttonAdd
        {
            get { return ButtonAdd; }

            set { ButtonAdd = value; }
        }
        public System.Web.UI.WebControls.Button buttonCancelAdd
        {
            get { return ButtonCancelA; }

            set { ButtonCancelA = value; }
        }

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


        #endregion

        #region Constructor
        public Default()
        {
            _presenter = new RestaurantPresenter(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                AlertSuccess_AddRestaurant.Visible = false;
                AlertSuccess_ModifyRestaurant.Visible = false;
                OpeningTimeA.Attributes.Add("type", "time");
                ClosingTimeA.Attributes.Add("type", "time");
                OpeningTimeM.Attributes.Add("type", "time");
                ClosingTimeM.Attributes.Add("type", "time");
                _presenter.LoadTable();
                _presenter.FillDropdown();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);


            AlertError_AddRestaurant.Visible = false;
            AlertError_ModifyRestaurant.Visible = false;

        }

        /// <summary>
        /// Llamada al metodo para agregar un restaurante
        /// </summary>
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            ButtonAdd_Click();
        }
        public void ButtonAdd_Click()
        {
            _presenter.ButtonAdd_Click();

        }
        /// <summary>
        /// Llamada al metodo para modificar un restaurante
        /// </summary>
        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            ButtonModify_Click();
        }
        public void ButtonModify_Click()
        {
            _presenter.ButtonModify_Click();
        }

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