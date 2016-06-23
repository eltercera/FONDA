<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModalAgregar.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.ModalAgregar" %>
<body>
    <form id="Usuario" runat="server">
    <!-- Modal Agregar-->
            <div class="modal fade" id="agregar" role="dialog">
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
                            <asp:TextBox ID="lastNameUser" CssClass="form-control" placeholder="Nombre" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="nss1" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>E</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
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
                            <asp:TextBox ID="address" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                         <label class="control-label">Status</label>
                            <div class="form-group">
                                <label class="radio-inline">
                                    <asp:RadioButton runat="server" Text="Activo" type="radio" GroupName="statusUsuario" name="statusUsuario"  id="statusDojoA"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton runat="server" Text="Inactivo" type="radio" GroupName="statusUsuario" name="statusUsuario"  id="statusDojoI" Checked="true"  />
                                </label>
                            </div>
                </div>
             </div> 
            </div>
                        <div class="modal-footer">
                            <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
            </div>
            </div>
            </div>
    </form>
</body>