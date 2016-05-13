<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarRol.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.ListarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Rol
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Roles
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
            <li class="active">Listar Rol
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
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
                                <asp:Button id="Button2" Text="Agregar Nuevo Rol" CssClass="btn btn-lg btn-primary" runat="server" OnClick="Button1_Click"/>
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
                                    <th ALIGN="CENTER">Rol</th>
                                    <th ALIGN="CENTER">Descripción</th>
                                    <th ALIGN="CENTER">Status</th>
                                    <th ALIGN="CENTER">Acción</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Administrador de Sistema</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Es el encargado de la gestión de restaurantes</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Activo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/AgregarModificarRol.aspx?success=modificar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        &nbsp;&nbsp;&nbsp;
                                        <a href="#"><i class="fa fa-info-circle" aria-hidden="true"></i></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Administrador de Restaurant</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Es el encargado a todo lo referente a la labor interna del restaurante</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Activo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/AgregarModificarRol.aspx?success=modificar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        &nbsp;&nbsp;&nbsp;
                                        <a href="#"><i class="fa fa-info-circle" aria-hidden="true"></i></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Cajero</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Es el encargado de llevar toda la gestión de Caja.</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Inactivo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/AgregarModificarRol.aspx?success=modificar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        &nbsp;&nbsp;&nbsp;
                                        <a href="#"><i class="fa fa-info-circle" aria-hidden="true"></i></a>
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
