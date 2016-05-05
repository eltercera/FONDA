<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarModificarPrivilegio.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.AgregarModificarPrivilegio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Privilegio
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
                document.write("Modificar Privilegio");
            else
                document.write("Agregar Privilegio");
        }
            
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="#">Inicio</a>
            </li>
            <li>
                <a href="#">Configuración</a>
            </li>
            <li>
                <a href="#">Rol</a>
            </li>
            <li class="active"> <script>
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

                                    if (op) {
                                        if (op == "modificar")
                                            document.write("Modificar Privilegio");
                                        else
                                            document.write("Agregar Privilegio");
                                    }

    </script>
            </li>

        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
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
                            <asp:TextBox ID="nombrePrivilegio" CssClass="form-control" placeholder="Nombre" MaxLength="3" runat="server"/>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Descripción del Privilegio</label>
                            <asp:TextBox ID="descripcionPrivilegio" CssClass="form-control" placeholder="Descripción" MaxLength="3" runat="server"/>
                        </div>
                      <div class="form-group">
                            <label class="control-label">Status</label>
                          <div class="form-group">
                           <label class="radio-inline">
                                <asp:RadioButton runat="server" Text="Activo" type="radio" GroupName="statusPrivi" name="statusDojo"  id="statusDojoA"  />
                            </label>
                            <label class="radio-inline">
                                <asp:RadioButton runat="server" Text="Inactivo" type="radio" GroupName="statusPrivi" name="statusDojo"  id="statusDojoI" Checked="true"  />
                            </label>
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
