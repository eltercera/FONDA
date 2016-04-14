<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarPrivilegioUsuario.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.ListarPrivilegioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Privilegios de Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Privilegios
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
    
      <div class="row">
        <div class="col-lg-4">   
            <div class="form-group input-group">
                <input type="text" class="form-control">
                <span class="input-group-btn"><button class="btn btn-default" type="button"><i class="fa fa-search"></i></button></span>
            </div>
        </div>
                        <div class="col-lg-8">
                            <div class="text-right">
                                <asp:Button id="Button2" Text="Agregar Privilegio" CssClass="btn btn-lg btn-primary" runat="server" OnClick="Button1_Click"/>
                            </div>
                        </div>
        <br><br><br>
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-users" aria-hidden="true"></i> Lista de Roles</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped" >
                            <thead>
                                <tr>
                                    <th ALIGN="CENTER">Privilegio</th>
                                    <th ALIGN="CENTER">Descripción</th>
                                    <th ALIGN="CENTER">Permisos</th>
                                    <th ALIGN="CENTER">Acción</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Gestionar Usuarios</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Registro de Usuario y su permisología</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER"><i class="fa fa-plus" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-pencil-square-o" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-search" aria-hidden="true"></i></td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Activo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/AgregarModificarPriviRol.aspx?success=modificar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        >
                                    </td>
                                </tr>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Gestionar Rol</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Registro de roles</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER"><i class="fa fa-plus" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-pencil-square-o" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-search" aria-hidden="true"></i></td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Activo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/AgregarModificarPriviRol.aspx?success=modificar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Gestionar Privilegios</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Registro de privilegios</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER"><i class="fa fa-plus" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-pencil-square-o" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-search" aria-hidden="true"></i></td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Inactivo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/AgregarModificarPriviRol.aspx?success=modificar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                       
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
