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
            this.alert.Attributes.Clear();
            this.alert.InnerHtml = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }

        protected void ModalInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Configuracion/AgregarModificarUsuario.aspx?success=agregar");
        }
        protected void ModalAgregar_Click(object sender, EventArgs e)
        {
            ClearModalAgregar();   
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#formUser').modal('show');", true);
        }
        protected void ClearModalAgregar()
        {
            this.nameUser.Text = "";
            this.nameUser.Attributes["placeholder"] = "Nombre";
            this.lastNameUser.Text = "";
            this.lastNameUser.Attributes["placeholder"] = "Apellido";
            this.nss1.Text = "";
            this.nss2.Text = "";
            this.nss2.Attributes["placeholder"] = "ej. 965831535-1";
            this.address.Text = "";
            this.address.Attributes["placeholder"] = "Dirección";
            this.email.Text = "";
            this.address.Attributes["placeholder"] = "Email";
            this.userNameU.Text = "";
            this.address.Attributes["placeholder"] = "Usuario";
            this.statusI.Checked = true;
            this.ButtonAgrMod.Text = "Agregar";
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
            LinkButton clickedLink = (LinkButton)sender;
            this.nameUser.Text = clickedLink.Attributes["data-id"];
            this.statusA.Checked = true;
            this.ButtonAgrMod.Text = "Modificar";
            ClientScript.RegisterStartupScript(GetType(), "mostrarModal", "$('#formUser').modal('show');", true);

        }
    }
}