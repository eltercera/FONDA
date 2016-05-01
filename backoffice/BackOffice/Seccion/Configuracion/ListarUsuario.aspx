<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarUsuario.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.ListarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Gestión de Usuarios
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
                <a href="#">Inicio</a>
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
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Usuarios</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="example" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Imagen</th>
                                                <th>Nombre</th>
                                                <th>Apellido</th>
                                                <th>CI</th>
                                                <th>Rol</th>
                                                <th>Status</th>
                                                <th>Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><img src="../../Content/img/image-1.png" /></td>
                                                <td>Javier</td>
                                                <td>Medina</td>
                                                <td>19.335.400</td>
                                                <td>Administrador de Sistema</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                                <td class="text-center"><a runat="server" onserverclick="ModalInfo_Click"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td><img src="../../Content/img/image-1.png" /></td>
                                                <td>Jessika</td>
                                                <td>Daboin</td>
                                                <td>6.797.556</td>
                                                <td>Cliente</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                                <td class="text-center"><a runat="server" onserverclick="ModalInfo_Click"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>                                           
                                            <tr>
                                                <td><img src="../../Content/img/image-1.png" /></td>
                                                <td>José</td>
                                                <td>García</td>
                                                <td>15.865.488</td>
                                                <td>Cajero</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a runat="server" onserverclick="ModalInfo_Click"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            <!-- /.container-fluid -->

    <asp:Literal runat="server" ID="modal"></asp:Literal>

</asp:Content>
