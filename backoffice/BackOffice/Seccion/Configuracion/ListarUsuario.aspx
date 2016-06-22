<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarUsuario.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.ListarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Gestión de Empleados
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Empleados
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
            <li class="active">Listar Empleados
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
                                <asp:LinkButton runat="server" class="btn btn-default pull-right"><i class="fa fa-refresh"></i></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-default pull-right" onclick="Add_Click"><i class="fa fa-plus"></i></asp:LinkButton>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:Table class="table table-bordered table-hover table-striped" runat="server" id="TablaEmployee" >
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Apellido</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>CI</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Rol</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Acciones</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>                                   
                                    </asp:Table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            <!-- /.container-fluid -->

     <!-- Modal Agregar-->
            <div class="modal fade" id="modalAddModify" role="dialog">
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
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="nameUser" CssClass="form-control" placeholder="Nombre" MaxLength="10" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messageNameUser" style="color:#FF9999" runat="server"></div>
                        </div>
                      </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Apellido</label>
                            <asp:TextBox ID="lastNameUser" CssClass="form-control" placeholder="Apellido" MaxLength="10" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messageLastName" style="color:#FF9999" runat="server"></div>
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
                            <asp:TextBox ID="nss2" CssClass="form-control" placeholder="Ej. 19245998" MaxLength="9" runat="server"/><span style="color:#FF6633" class="form-control-feedback" disabled>*</span>
                            <div id="menssageSsn" style="color:#FF9999" runat="server" ></div>
                            <div id="messageDni" style="color:#FF9999" runat="server" ></div>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Fecha de Nacimiento</label>
                            <!--<asp:TextBox ID="birtDate" CssClass="form-control" placeholder="DD/MM/YYYY" MaxLength="10" runat="server"/>-->
                            <input type="date" class="form-control" placeholder="DD/MM/YYYY" id="birtDate2" MaxLength="10" runat="server">
                                <span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messageBirthdate" style="color:#FF9999" runat="server" ></div>
                        </div>
                </div>
            </div>
                    <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Teléfono</label>
                            <asp:TextBox ID="phoneNumber" CssClass="form-control" placeholder="Ej. 04127890544" MaxLength="11" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messagePhone" style="color:#FF9999" runat="server" ></div>
                        </div>
                      </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Género</label>
                            <asp:DropDownList id="gender" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem value="F">F</asp:ListItem>
                                <asp:ListItem value="M">M</asp:ListItem>
                                </asp:DropDownList><span style="color:#FF6633" class="form-control-feedback">*</span>
                        </div>
                </div>
            </div>
                    <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Dirección</label>
                            <asp:TextBox ID="address" CssClass="form-control" placeholder="Dirección" MaxLength="30" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messageAddress" style="color:#FF9999" runat="server" ></div>
                        </div>
                      </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Rol</label>
                               <asp:DropDownList id="role" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                </asp:DropDownList><span style="color:#FF6633" class="form-control-feedback">*</span>
                        </div>
                </div>
            </div>
                    <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Usuario</label>
                            <asp:TextBox ID="userNameU" CssClass="form-control" placeholder="Usuario" MaxLength="10" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="menssageUsername" style="color:#FF9999" runat="server">
                            </div><div id="messageUser" style="color:#FF9999" runat="server"></div>
                        </div>
                      </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Email</label>
                            <asp:TextBox ID="email" CssClass="form-control" placeholder="nickname@ejemplo.com" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="menssageEmail" style="color:#FF9999" runat="server" ></div>
                            <div id="messageEmail" style="color:#FF9999" runat="server" ></div>
                        </div>
                </div>
            </div>
                    <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Password</label>
                            <asp:TextBox type="password" ID="password" CssClass="form-control" placeholder="Password" MaxLength="10" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messagePassword1" style="color:#FF9999" runat="server" ></div>
                        </div>
                      </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Repetir Password</label>
                            <asp:TextBox type="password" ID="repitPassword" CssClass="form-control" MaxLength="10" placeholder="Repetir Password" runat="server"/><span style="color:#FF6633" class="form-control-feedback">*</span>
                            <div id="messagePassword2" style="color:#FF9999" runat="server" ></div>
                            <div id="messagePasswordEqual" style="color:#FF9999" runat="server" ></div>
                        </div>
                </div>
            </div>
                    <div class="row">
                        
                <div class="col-lg-3 col-md-10 col-sm-10 col-xs-10">
                    </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                    <div class="form-group">
                        <label class="control-label">Restaurant</label>
                        <asp:DropDownList id="restaurant" CssClass="form-control" runat="server">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
                    <div id="messageEmpty" style="color:#FF6633" runat="server" ></div>
            </div>
                        <div class="modal-footer">
                            <asp:Button id="ButtonAddModify" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="ModalAddModify_Click"/>
                            <asp:Button id="ButtonCancel" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="Cancel_Click"/>
                        </div>
            </div>
            </div>
            </div>

</asp:Content>
