using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Resources.FondaResources.Login;
using BackOffice.Content;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.View.BackOfficeModel.Restaurante;
using System.Web.UI.HtmlControls;
using com.ds201625.fonda.View.BackOfficePresenter.Restaurante;

namespace BackOffice.Seccion.Restaurant
{
    public partial class Mesas : System.Web.UI.Page, ITableModel
    {
        FactoryDAO factoryDAO = FactoryDAO.Intance;
        int _idRestaurant =1;
        com.ds201625.fonda.Domain.Restaurant _restaurant = new com.ds201625.fonda.Domain.Restaurant();

        //SegundaEntrega

        #region Presenter
        private TablePresenter _presenter;
        #endregion

        #region Constructor 
        public Mesas()
        {
            //presentador que se encargará del MVP 
            _presenter = new TablePresenter(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                if (Session[ResourceLogin.sessionRol].ToString() == "Sistema")
                {
                    AlertSuccess_AddTable.Visible = false;
                    AlertSuccess_ModifyTable.Visible = false;
                    //LoadDataTable();
                    _presenter.LoadDataTable();
                }
                else
                {
                    if (Session[ResourceLogin.sessionRol].ToString() == "Restaurante")
                    {
                        // redireccion la pagina como empleado de un restaurante
                        Response.Redirect("Default.aspx");
                    }
                    if (Session[ResourceLogin.sessionRol].ToString() == "Caja")
                    {
                        // redireccion la pagina como empleado de un restaurante
                        Response.Redirect("~/Seccion/Caja/Ordenes.aspx");
                    }
                }
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }

        //Alertas del IModel 
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

        //Alertas de Agregar mesa
        public System.Web.UI.HtmlControls.HtmlGenericControl alertSuccess_AddTable
        {
            get { return AlertSuccess_AddTable; }
            set { AlertSuccess_AddTable = value; }
        }
        //Alertas de modificar mesa
        public System.Web.UI.HtmlControls.HtmlGenericControl alertSuccess_ModifyTable
        {
            get { return AlertSuccess_ModifyTable; }
            set { AlertSuccess_ModifyTable = value; }
        }
        //Modal de agregar mesa
        public System.Web.UI.WebControls.DropDownList dddlCapacityA
        {
            get { return DDLcapacityA; }
            set { DDLcapacityA = value; }
        }
        public System.Web.UI.WebControls.Button buttonAdd
        {
            get { return ButtonAdd; }
            set { ButtonAdd = value; }
        }
        public System.Web.UI.WebControls.Button buttonCancelA
        {
            get { return ButtonCancelA; }
            set { ButtonCancelA = value; }
        }
        //Modal de Modificar mesa
        public System.Web.UI.WebControls.DropDownList dddlCapacityM
        {
            get { return DDLcapacityM; }
            set { DDLcapacityM = value; }
        }
        public System.Web.UI.WebControls.Button buttonModify
        {
            get { return ButtonModify; }
            set { ButtonModify = value; }
        }
        public System.Web.UI.WebControls.Button buttonCancelM
        {
            get { return ButtonCancelM; }
            set { ButtonCancelM = value; }
        }
        //página
        public System.Web.UI.WebControls.HiddenField tableModifyId
        {
            get { return TableModifyId; }
            set { TableModifyId = value; }
        }
        public System.Web.UI.WebControls.Table tablePage
        {
            get { return tablepage; }
            set { tablepage = value; }
        }


        //llamada a los metodos
        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            ButtonModify_Click();
        }
        public void ButtonModify_Click()
        {
         
               _presenter.ButtonModify_Click();
           
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            ButtonAdd_Click();
        }
        public void ButtonAdd_Click()
        {

            _presenter.ButtonAdd_Click();

        }

   

        /// <summary>
        /// Recibe el Id de la fila y obtiene un objeto de tipo categoria
        /// </summary>
        /// <param name="Id">Id de la categoria a mostrar</param>
        /// <returns>Informacion de objeto categoria</returns>
        [WebMethod]
        public static com.ds201625.fonda.Domain.Table GetData(string Id)
        {
            int tableId = int.Parse(Id);
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            com.ds201625.fonda.Domain.Table _table = _tableDAO.FindById(tableId);

            return _table;
        }
        

        /// <summary>
        /// Cambia el Status de la mesa
        /// </summary>
        /// <param name="Id">Recibe el Id de la mesa</param>
        /// <param name="Status">Recibe el Status al que se va a cambiar</param>
        /// <returns>El Status a mostrar en la tabla</returns>
        [WebMethod]
        public static string ChangeStatus(string Id, string Status)
        {
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            string TableID = Id;
            string response = "";
            int idTable = int.Parse(TableID);
            com.ds201625.fonda.Domain.Table _table = _tableDAO.FindById(idTable);

            if (Status.Equals("Free"))
            {
                _table.Status = factoryDAO.GetFreeTableStatus();
                response = RestaurantResource.Active;
            }
            else if(Status.Equals("Busy"))
            {
                _table.Status = factoryDAO.GetBusyTableStatus();
                response = RestaurantResource.Inactive; 
            }

            _tableDAO.Save(_table);
            return response;

        } 
        
        
        
    }
}