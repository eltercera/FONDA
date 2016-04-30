<%@ Page Title="Restaurantes" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Restaurante.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Restaurantes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Restaurantes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
   <div>
      <ol class="breadcrumb">
          <li>
              <a href="~/Default.aspx" runat="server">Inicio</a>
          </li>
          <li class="active">
             Restaurante
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
<div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Restaurantes</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="example" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th>Direccion</th>
                                                <th>Tipo</th>
                                                <th>Estado</th>
                                                <th class="no-sort">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><a href="MenuRest.aspx">El Cine</a></td>
                                                <td>Calle Comercio, entre Sucre y Bellavista - El Hatillo</td>
                                                <td>Japonesa</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                
                                                <td>St. Honoré</td>
                                                <td>Transversal 1 - Los Palos Grandes</td>
                                                <td>Cafetería, pastelería</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>                                           
                                            <tr>
                                                
                                                <td>Ávila Burger</td>
                                                <td>4ta Avenida con 6ta Transversal. Cuadra Gastronomica - Los Palos Grandes</td>
                                                <td>Americana</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
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
            <!-- Modal Consultar-->
            <div class="modal fade" id="consultar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">El Cine</h4>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>Nombre</th>
                                            <th>RIF</th>
                                            <th>Tipo</th>
                                            <th>Estado</th>
                                            <th>Direccion</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>El Cine</td>
                                            <td>J-34857861-1</td>
                                            <td>Japonesa</td>
                                            <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                            <td>Calle Comercio, entre Sucre y Bellavista - El Hatillo</td>
                                        </tr>
                                    </tbody>
                                </table><div class="table-responsive">
                                    <table class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Mapa</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15695.913224648662!2d-66.82501238465575!3d10.423295992847969!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xa4f83f07bee2d359!2sEl+Cine+Restaurant!5e0!3m2!1ses!2sve!4v1460401053970" width="400" height="300" frameborder="0" style="border:0" allowfullscreen></iframe></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>

                    </div>
                </div>

            </div>

                <!-- Modal Modificar-->
                <div class="modal fade" id="modificar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Restaurante</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. El Budare" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:DropDownList id="DropDownList3" CssClass="form-control" AutoPostBack="True" runat="server">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Venezolana</asp:ListItem>
                                <asp:ListItem>Americana</asp:ListItem>
                                <asp:ListItem>Japonesa</asp:ListItem>
                                <asp:ListItem>China</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="DropDownList4" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="DropDownList5" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>VEF</asp:ListItem>
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                        <asp:DropDownList id="DropDownList6" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>Altamira</asp:ListItem>
                            <asp:ListItem>Las Mercedes</asp:ListItem>
                            <asp:ListItem>Macaracuay</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Longitud</label>
                            <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                              <label for="ejemplo_archivo_1">Imagen del Restaurante</label>
                              <input type="file" id="ejemplo_archivo_2"/>
                              <p class="help-block">Imagen .jpg o .png</p>
                         </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="DropDownList7" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Apertura</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                                <asp:DropDownList id="DropDownList12" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>            
          </div>
                        <div class="modal-footer">
                            <asp:Button id="Button3" Text="Agregar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>

                    </div>
                    </div>
                    </div>
        <!-- /Modal Modificar-->

            <!-- Modal Agregar-->
            <div class="modal fade" id="agregar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Restaurante</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="ej. El Budare" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:DropDownList id="DropDownList1" CssClass="form-control" AutoPostBack="True" runat="server">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Venezolana</asp:ListItem>
                                <asp:ListItem>Americana</asp:ListItem>
                                <asp:ListItem>Japonesa</asp:ListItem>
                                <asp:ListItem>China</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="DropDownList2" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="DropDownList9" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>VEF</asp:ListItem>
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                        <asp:DropDownList id="DropDownList8" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>Altamira</asp:ListItem>
                            <asp:ListItem>Las Mercedes</asp:ListItem>
                            <asp:ListItem>Macaracuay</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Longitud</label>
                            <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                              <label for="ejemplo_archivo_1">Imagen del Restaurante</label>
                              <input type="file" id="ejemplo_archivo_1"/>
                              <p class="help-block">Imagen .jpg o .png</p>
                         </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="DropDownList10" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Apertura</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                                <asp:DropDownList id="DropDownList11" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
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

       
          
</asp:Content>
