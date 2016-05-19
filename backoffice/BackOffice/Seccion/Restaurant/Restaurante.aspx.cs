using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Seccion.Restaurant
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccess_AddRestaurant.Visible = false;
            AlertSuccess_ModifyRestaurant.Visible = false;
            AlertError_AddRestaurant.Visible = false;
            AlertError_ModifyRestaurant.Visible = false;
        }

        public void ButtonAdd_Click()
        {
            
           /* if (ValidarRestaurant(NameA.Text, CategoryA.Text, NacionalityA.Text, RifA.Text, CurrencyA.Text,
                AddressA.Text, ZoneA.Text, LongA.Text, LatA.Text))
            {

            }
            else
            {
                AlertError_AddRestaurant.Visible = true;
            }
            NameA.Text = string.Empty;
            RifA.Text = string.Empty;
            AddressA.Text = string.Empty;
            LongA.Text = string.Empty;
            LatA.Text = string.Empty;*/
        }

        public bool ValidarRestaurant(string name, string category, string nationality, string rif, string currency, string address,
            string zone, string longitud, string latitud)
        {
            bool valid = true;
            string patronLetras = "^[A-Za-z]*$";
            string patronNumero = "^[0-9]*$";
            string patronFloat = @"^-?[0-9]*(?:\.[0-9]*)?$";


            if (name == "" | rif == "" | address == "" | longitud == "" | latitud == ""
                | category == "" | nationality == "" | zone == "" | currency == "")
            {
                valid = false;

            }
            if ((!Regex.IsMatch(name, patronLetras)) | (!Regex.IsMatch(address, patronLetras)))
            {
                valid = false;
            }

            if ((!Regex.IsMatch(rif, patronNumero)))
            {
                valid = false;
            }

            if ((!Regex.IsMatch(longitud, patronFloat)) | (!Regex.IsMatch(latitud, patronFloat)))
            {

            }

            return valid;
        }

    }
}