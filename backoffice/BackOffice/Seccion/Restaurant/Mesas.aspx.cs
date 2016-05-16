using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace BackOffice.Seccion.Restaurant
{
    public partial class Mesas : System.Web.UI.Page
    {
        public string table
        {
            get { return this.TableT.Text; }
            set { this.TableT.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AddTable.Visible = false;
            AlertSuccess_ModifyTable.Visible = false;
            LoadDataTable();
        }
        
        protected void LoadDataTable()
        {
            table = string.Empty;
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            IList<com.ds201625.fonda.Domain.Table> listTable = _tableDAO.GetAll();


            int longitud = listTable.Count; //tamano de la lista 
            
            //Recorremos la lista
            for (int i = 0; i <= longitud - 1; i++)
            {
                string status = string.Empty;
                string user = string.Empty;
                int quantity = 0;
                if (listTable[i].Status == FreeTableStatus.Instance)
                {
                    status = ResourceRestaurant.Active;
                    user = "N/A";
                    quantity = 0;
                }
                else 
                if (listTable[i].Status == BusyTableStatus.Instance)
                {
                    status = ResourceRestaurant.Inactive;
                    user = "Usuario" + listTable[i].Id;
                    quantity = listTable[i].Capacity - 1;

                }

                    //Se arma la tabla HTML
                    // ResourceRestaurant llama a las acciones
                    table += "<tr id= " + listTable[i].Id + "><td>" + listTable[i].Id + "</td><td>" + listTable[i].Capacity +
                             "</td><td>" + quantity + "</td><td>" + user + "</td>" + status;

                    table += ResourceRestaurant.ActionTable;
                    table += ResourceRestaurant.Close;
                
            }
        }


        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AlertSuccess_AddTable.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            com.ds201625.fonda.Domain.Table _table = new com.ds201625.fonda.Domain.Table();
            int capacity = Int32.Parse(DDLcapacityA.SelectedValue); 
            _table.Capacity = capacity;
            _table.Status = FreeTableStatus.Instance;
            _tableDAO.Save(_table);
            LoadDataTable();
        }

        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModifyTable.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            ITableDAO _tableDAO = factoryDAO.GetTableDAO();
            
            com.ds201625.fonda.Domain.Table _tableM = _tableDAO.FindById(1);     
             int capacity = Int32.Parse(DDLcapacityA.SelectedValue);
            _tableM.Capacity = capacity;
            _tableDAO.Save(_tableM);
            LoadDataTable();

        }
    }
}