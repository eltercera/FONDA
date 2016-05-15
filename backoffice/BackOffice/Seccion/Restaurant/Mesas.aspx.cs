using System;
using System.Collections.Generic;
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
                if (listTable[i].Status == FreeTableStatus.Instance)
                {
                    status = ResourceRestaurant.Active;
                }
                else 
                if (listTable[i].Status == BusyTableStatus.Instance)
                {
                    status = ResourceRestaurant.Inactive;
                }

                    //Se arma la tabla HTML
                    // ResourceRestaurant llama a las acciones
                    table += "<tr id= " + listTable[i].Id + "><td>" + listTable[i].Id + "<td>" + listTable[i].Capacity + "<td>" + status + "</td>";

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
            ITableDAO _restcatDAO = factoryDAO.GetTableDAO();
            com.ds201625.fonda.Domain.Table _table = new com.ds201625.fonda.Domain.Table();
            int capacity = Int32.Parse(DDLcapacityA.SelectedValue);
            _table.Capacity = capacity;
            _table.Status = FreeTableStatus.Instance;
            _restcatDAO.Save(_table);
            LoadDataTable();

        }
    }
}