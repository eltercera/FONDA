﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;


namespace BackOffice.Seccion.Restaurant
{
    public partial class AgregarCategoria : System.Web.UI.Page
    {

        public string restcat {
            get { return this.CategoryT.Text; }
            set { this.CategoryT.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = false;
            AlertSuccess_ModificarCategoria.Visible = false;
            CargarTabla();
        }
        
        protected void CargarTabla() {

            restcat = string.Empty;
            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            IList<RestaurantCategory> listRest = _restcatDAO.GetAll();


            int longitud = listRest.Count; //tamano de la lista 

            //Recorremos la lista
            for (int i = 0; i <= longitud - 1; i++)
            {
                //Se arma la tabla HTML
                // ResourceRestaurant llama a las acciones
                restcat += "<tr id= " + listRest[i].Id + "><td>" + listRest[i].Name + "</td>";

                restcat += ResourceRestaurant.ActionCategory;
                restcat += ResourceRestaurant.Close;

            }
        }
     

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            AlertSuccess_AgregarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            RestaurantCategory _restcat = new RestaurantCategory();
            String nombreA = NombreCatA.Text;
            _restcat.Name = nombreA;
            _restcatDAO.Save(_restcat);
            CargarTabla();
        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            AlertSuccess_ModificarCategoria.Visible = true;
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantCategoryDAO _restcatDAO = factoryDAO.GetRestaurantCategoryDAO();
            IList<RestaurantCategory> listRest = _restcatDAO.GetAll();
            int longitud = listRest.Count;
            string nameM;
            int idCat = 0;

            for (int i = 0; i <= longitud - 1; i++)
            {
                nameM = listRest[i].Name;
                idCat = listRest[i].Id;
            }

            RestaurantCategory _restaurant = _restcatDAO.FindById(idCat);
            nameM = NombreCatM.Text;
            _restaurant.Name = nameM;
            _restcatDAO.Save(_restaurant);
            CargarTabla();
        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            
        }
    }
}