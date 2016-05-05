<%@ Page Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.Mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Mesas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Mesas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
NOMBRE DEL RESTAURANTE
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
   <div>
      <ol class="breadcrumb">
          <li>
              <a href="~/Default.aspx" runat="server">Inicio</a>
          </li>
          <li class="active">
             Mesas
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
       <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Mesas</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div> 
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="mesa" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Cantidad de puestos</th>
                                                <th>Cantidad de comensales</th>
                                                <th>Reservación realizada por</th>
                                                <th>Estado</th>
                                                <th class="no-sort">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>#1</td>
                                                <td>6</td>
                                                <td>4</td>
                                                <td>@pperez</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p class="stat">I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#2</td>
                                                <td>10</td>
                                                <td>0</td>
                                                <td></td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
     <!--modal modificar mesa-->
    <div class="modal fade" id="modificar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Mesas</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-">
                                <label class="control-label">Cantidad de Puestos</label>
                                <asp:DropDownList id="DropDownList3" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList> 
                             </div>
                             </div>
                         </div>       

                        <div class="modal-footer">
                            <asp:Button id="Button1" Text="Modificar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
                    </div>
           </div>
     </div>

<!--modal agregar mesa-->
    <div class="modal fade" id="agregar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Mesas</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-">
                                <label class="control-label">Cantidad de Puestos</label>
                                <asp:DropDownList id="DropDownList1" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList> 
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
    </div>
</asp:Content>