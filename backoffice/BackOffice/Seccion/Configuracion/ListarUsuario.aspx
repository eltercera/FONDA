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
         <div class="col-lg-10 col-md-8 col-sm-8 col-xs-8">
        <div id="alert" runat="server">
    </div>
            </div>
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Usuarios</h3>
                                <asp:LinkButton runat="server" class="btn btn-default pull-right" onclick="ModalAgregar_Click" data-id="12345"><i class="fa fa-plus"></i></asp:LinkButton>
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
                                                <td class="text-center" /><asp:LinkButton runat="server" onclick="ModalInfo_Click" data-id="12345"><i class="fa fa-info-circle" aria-hidden="true"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-pencil"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-check" aria-hidden="true"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-times"></i></asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td><img src="../../Content/img/image-1.png" /></td>
                                                <td>Jessika</td>
                                                <td>Daboin</td>
                                                <td>6.797.556</td>
                                                <td>Cliente</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                               <td class="text-center" /><asp:LinkButton runat="server" onclick="ModalInfo_Click" data-id="12345"><i class="fa fa-info-circle" aria-hidden="true"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-pencil"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-check" aria-hidden="true"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-times"></i></asp:LinkButton></td>
                                            </tr>                                           
                                            <tr>
                                                <td><img src="../../Content/img/image-1.png" /></td>
                                                <td>José</td>
                                                <td>García</td>
                                                <td>15.865.488</td>
                                                <td>Cajero</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                               <td class="text-center" /><asp:LinkButton runat="server" onclick="ModalInfo_Click" data-id="12345"><i class="fa fa-info-circle" aria-hidden="true"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-pencil"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-check" aria-hidden="true"></i></asp:LinkButton><asp:LinkButton runat="server" onclick="Modificar_Click" data-id="12345"><i class="fa fa-times"></i></asp:LinkButton></td>
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

     <!-- Modal Agregar-->
            <div class="modal fade" id="formUser" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Usuario</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre del Usuario</label>
                            <asp:TextBox ID="nameUser" CssClass="form-control" placeholder="Nombre" MaxLength="3" runat="server"/>
                        </div>
                      </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Apellido del Usuario</label>
                            <asp:TextBox ID="lastNameUser" CssClass="form-control" placeholder="Apellido" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="nss1" CssClass="form-control" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem Value="E">E</asp:ListItem>
                            <asp:ListItem Value="V">V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">Cédula</label>
                            <asp:TextBox ID="nss2" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Dirección</label>
                            <asp:TextBox ID="address" CssClass="form-control" placeholder="Dirección" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                         <label class="control-label">Status</label>
                            <div class="form-group">
                                <label class="control-label">Status</label>
                                            <br/>
                                                <asp:RadioButton GroupName="Disponibilidad" ID="statusA" runat="server" Text="  Activo" />
                                                <asp:RadioButton GroupName="Disponibilidad" ID="statusI" runat="server" Text=" Inactivo" Checked="true"/>  
                            </div>
                </div>
             </div> 
            </div>
                        <div class="modal-footer">
                            <asp:Button id="ButtonAgrMod" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="ModalAgregarModificar_Click"/>
                            <asp:Button id="ButtonCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="ButtonCancelar_Click"/>
                        </div>
            </div>
            </div>
            </div>

</asp:Content>
