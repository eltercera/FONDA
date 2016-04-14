<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarModificarPriviRol.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.AgregarModificarPriviRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Privilegios del Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    <script>
        var parameter = "success";
            // Obtiene la cadena completa de URL
            var url = location.href;
            /* Obtiene la posicion donde se encuentra el signo ?, 
            ahi es donde empiezan los parametros */
            var index = url.indexOf("?");
            /* Obtiene la posicion donde termina el nombre del parametro
            e inicia el signo = */
            index = url.indexOf(parameter, index) + parameter.length;
            /* Verifica que efectivamente el valor en la posicion actual 
            es el signo = */
            if (url.charAt(index) == "=") {
                // Obtiene el valor del parametro
                var result = url.indexOf("&", index);
                if (result == -1) { result = url.length; };
                // Despliega el valor del parametro
                var op = url.substring(index + 1, result);
            }

        if  (op)
        {
            if (op == "modificar")
                document.write("Modificar Privilegios de Usuario");
            else
                document.write("Agregar Privilegios de Usuario");
        }
            
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
    <div class="row m-b-3">
        <div class="row">
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-8">
                <div id="exitoFormulario" class="alert alert-success alert-dismissable col-lg-12 col-md-10 col-sm-10
                     col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    Privilegio aregado con <strong>EXITO</strong>!
                </div>
                <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12 col-md-10 col-sm-10 
                    col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    El Privilegio <strong>NO SE HA PODIDO AGREGAR!</strong>
                </div>
            </div>
        </div>
        <div class="invisible">...</div>
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
           <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre del Privilegio</label>
                                       <asp:DropDownList ID="nombrePrivilegio"  class="btn btn-default dropdown-toggle" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Value="" Selected="True">Seleccione Privilegio: </asp:ListItem>
                                            <asp:ListItem Value="1">Gestionar Usuarios</asp:ListItem>
                                            <asp:ListItem Value="2">Gestionar Restaurantes</asp:ListItem>
                                            <asp:ListItem Value="3">Gestionar Roles</asp:ListItem>
                                            <asp:ListItem Value="4">Gestionar Privilegios</asp:ListItem>
                                            <asp:ListItem Value="5">Gestionar Menú</asp:ListItem>
                                            <asp:ListItem Value="6">Gestionar Privilegios de los Roles</asp:ListItem>
                                            <asp:ListItem Value="7">Gestionar Caja</asp:ListItem>
                                       </asp:DropDownList>
                         </div>
                         <div class="form-group">
                                <label class="control-label">Acciones Permitidas</label>
                              <div class="form-group">
                                    <asp:CheckBox runat="server" Text="Agregar" type="radio" name="accionPermitida"  id="accionPermitidaA"  />
                                  </div>
                             <div class="form-group">
                                    <asp:CheckBox runat="server" Text="Modificar" type="radio" name="accionPermitida"  id="accionPermitidaM" />
                                 </div>
                             <div class="form-group">
                                    <asp:CheckBox runat="server" Text="Consultar" type="radio" name="accionPermitida"  id="accionPermitidaC"  />
                                 </div>
                             <div class="form-group">
                                    <asp:CheckBox runat="server" Text="Eliminar" type="radio" name="accionPermitida"  id="accionPermitidaE" />
                               </div>
                            </div>
                          </div>
            </div>
            <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10 ">
                    <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click"/>
                    <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click"/>
                </div>
            </div>
        
        </div>

    </div>
</asp:Content>
