<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarUsuario.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.ListarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listado de Usuarios
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Configuracion/ListarUsuario.aspx">Inicio</a>
            </li>
            <li>
                <a href="#">Configuración</a>
            </li>
            <li class="active">Listar Usuario
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
    <div class="row">
        <div class="col-lg-4">    
                            <input type="text" class="form-control" placeholder="Búsqueda">
                        </div>
                        <div class="col-lg-8">
                            <div class="text-right">
                                <button onclick="../Configuracion/AgregarUsuario.aspx" type="button" class="btn btn-lg btn-primary">Agregar Nuevo Usuario</button>
                            </div>
                        </div>
        <br><br><br>
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-users" aria-hidden="true"></i> Lista de Usuarios</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped" >
                            <thead>
                                <tr>
                                    <th ALIGN="CENTER">Imagen</th>
                                    <th ALIGN="CENTER">Nombre</th>
                                    <th ALIGN="CENTER">Apellido</th>
                                    <th ALIGN="CENTER">CI</th>
                                    <th ALIGN="CENTER">Rol</th>
                                    <th ALIGN="CENTER">Status</th>
                                    <th ALIGN="CENTER">Acción</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <img src="../../Content/img/image-1.png" />
                                    </td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Javier</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Medina</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">19.335.400</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Administrador de Sistema</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Activo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/ModificarUsuario.aspx"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        &nbsp;&nbsp;&nbsp;
                                        <a href="#"><i class="fa fa-info-circle" aria-hidden="true"></i></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <img src="../../Content/img/image-1.png" />
                                    </td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Jessika</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Daboin</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">6.797.556</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Cliente</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Activo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/ModificarUsuario.aspx"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                        &nbsp;&nbsp;&nbsp;
                                        <a href="#"><i class="fa fa-info-circle" aria-hidden="true"></i></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <img src="../../Content/img/image-1.png" />
                                    </td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">José</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">García</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">15.865.488</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Cajero</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">Inactivo</td>
                                    <td VALIGN="MIDDLE" ALIGN="CENTER">
                                        <a href="../Configuracion/ModificarUsuario.aspx"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
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
