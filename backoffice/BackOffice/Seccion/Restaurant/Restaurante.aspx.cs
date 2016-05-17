using System;
using System.Collections.Generic;
using System.Linq;
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


        }

        public void ValidarUsuario(object sender, EventArgs e)
        {

            validarUsuario();
        }

        public void mensajeLogin(Boolean visible, string tipo)
        {
            switch (tipo)
            {
                case "Error":
                    /*labelError.Visible = visible;*/ break;
                
            }
        }
        public void validarUsuario()
        {
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
            Console.WriteLine("imprimiendo valor :");
            Console.WriteLine(name);

            if (name == "" | rif == "" | address == "" | longitud == ""| latitud == "" 
                | category == "" | nationality=="" | zone=="" | currency=="")
            {
                Console.WriteLine("ERROR ");
                mensajeLogin(true, "Error");
            }
            else
            {
                Console.WriteLine("Correcto ");
            }

        }
    }
}