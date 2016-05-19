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


        public bool ValidarRestaurant()
        {
            bool valid = true;
            string patronLetras = "^[A-Za-z]*$";
            string patronNumero = "^[0-9]*$";
            string patronFloat = @"^-?[0-9]*(?:\.[0-9]*)?$";
            string name = NameA.Text;
            string category = CategoryA.Text;
            string nationality = NacionalityA.Text;
            string rif = RifA.Text;
            string currency = CurrencyA.Text;
            string address = AddressA.Text;
            string zone = ZoneA.Text;
            string longitud = LongA.Text;
            string latitud = LatA.Text;
            string logitud = LongA.Text;


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