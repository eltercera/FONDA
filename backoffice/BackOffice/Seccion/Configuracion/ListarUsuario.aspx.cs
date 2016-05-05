using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Seccion.Configuracion
{
    public partial class ListarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }

        protected void ModalInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.alert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
            this.alert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
            this.alert.InnerHtml = G1RecursosInterfaz.dangerModificacioninicio + "El Rol" + G1RecursosInterfaz.dangerModificacionFinal;
        }
        protected void ModalAgregarModificar_Click(object sender, EventArgs e)
        {
           
            if (ButtonAgrMod.Text.CompareTo("Agregar")==0)
            {
                //agrego
            }
            else
            {
                //modifico
            }
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            //sender;
            //this.nameUser.Text = button1;
            //this.statusA.Checked = true;
            //this.ButtonAgrMod.Text = "Modificar";
            //PageMethods
            //ClientScript.RegisterStartupScript(GetType(), "tomarID", " PageMethods", true);
            //ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#formUser').modal('show');", true);

        }
    }
}