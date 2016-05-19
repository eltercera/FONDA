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

    <div id="AlertError_ModifyRestaurant" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-ban"></i> <strong>Error</strong> al modificar el restaurante
            </div>
        </div>
    </div>

<div id="AlertError_AddRestaurant" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-ban"></i> <strong>Error</strong> al agregar el restaurante
            </div>
        </div>
    </div>

    <div id="AlertSuccess_AddRestaurant" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> El restaurante fue agregado <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ModifyRestaurant" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> El restaurante fue modificado <strong>exitosamente!</strong>
            </div>
        </div>
    </div>
<div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Restaurantes</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right" ><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                        <asp:HiddenField ID="RestaurantModifyId" runat="server" Value="" />
                                        <asp:Table ID="Restaurant" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>                                                                         
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
                            <h4 class="modal-title">Restaurante</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                           <img class="img-thumbnail img-responsive img-center" id="ImageC" src="http://placehold.it/150x150" alt=""/>
                        </div>
                    </div>

                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="NameC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:TextBox ID="CategoryC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
            </div>
          </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:TextBox ID="NacionalityC" CssClass="form-control" readonly="true"  runat="server"/>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="RifC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                            <asp:TextBox ID="CurrencyC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="AddressC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                            <asp:TextBox ID="ZoneC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                            <asp:TextBox ID="OpeningTimeC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                            <asp:TextBox ID="ClosingTimeC" CssClass="form-control" readonly="true"  runat="server"/>
                        </div>
                </div>
            </div>   
          
                        <div class="modal-footer">
                            <asp:Button id="CloseConsult" Text="Cerrar" CssClass="btn btn-danger" runat="server"/>
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
                            <asp:TextBox ID="NameM" CssClass="form-control" placeholder="ej. El Budare"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:DropDownList id="CategoryM" CssClass="form-control" AutoPostBack="False" runat="server">
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
                        <asp:DropDownList id="NacionalityM" CssClass="form-control" AutoPostBack="False" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="RifM" CssClass="form-control" placeholder="ej. 965831535-1"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="CurrencyM" CssClass="form-control" AutoPostBack="False" runat="server">
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
                            <asp:TextBox ID="AddressM" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                        <asp:DropDownList id="ZoneM" CssClass="form-control" AutoPostBack="False" runat="server">
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
                            <asp:TextBox ID="LongM" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="LatM" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546"  runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Dias de apertura</label>
                            <label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day1M" runat="server" value="Lunes" text="Lun"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day2M" runat="server" value="Martes" text="Mar"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day3M" runat="server" value="Miercoles" text="Mie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day4M" runat="server" value="Jueves" text="Jue"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day5M" runat="server" value="Viernes" text="Vie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day6M" runat="server" value="Sabado" text="Sab"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day7M" runat="server" value="Domingo" text="Dom"/>
                            </label>
                            </label>
                            </div>    
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="OpeningTimeM" CssClass="form-control" AutoPostBack="False" runat="server">
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
                                <asp:DropDownList id="ClosingTimeM" CssClass="form-control" AutoPostBack="False" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                              <label for="ejemplo_archivo_1">Imagen del Restaurante</label>
                              <input type="file" id="ImageM"/>
                              <p class="help-block">Imagen .jpg o .png</p>
                         </div>
                </div>
             </div>            
          </div>
                        <div class="modal-footer">
                            <asp:Button id="ButtonModify" Text="Modificar" CssClass="btn btn-success" onclick="ButtonModify_Click" runat ="server"/>
                            <asp:Button id="ButtonCancelM" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>

                    </div>
                    </div>
                    </div>
        <!-- /Modal Modificar-->

            <!-- Modal Agregar-->
            <div class="modal fade" id="agregar" role="dialog" >
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
                            <asp:TextBox ID="NameA" CssClass="form-control" placeholder="ej. El Budare"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:DropDownList id="CategoryA" CssClass="form-control" AutoPostBack="False" runat="server">
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
                        <asp:DropDownList id="NacionalityA" CssClass="form-control" AutoPostBack="False" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="RifA" CssClass="form-control" placeholder="ej. 965831535-1"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="CurrencyA" CssClass="form-control" AutoPostBack="False" runat="server">
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
                            <asp:TextBox ID="AddressA" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                        <asp:DropDownList id="ZoneA" CssClass="form-control" AutoPostBack="False" runat="server">
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
                            <asp:TextBox ID="LongA" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546"  runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="LatA" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546"  runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Dias de apertura</label>
                            <label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day1A" runat="server" value="Lunes" text="Lun"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day2A" runat="server" value="Martes" text="Mar"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day3A" runat="server" value="Miercoles" text="Mie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day4A" runat="server" value="Jueves" text="Jue"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day5A" runat="server" value="Viernes" text="Vie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day6A" runat="server" value="Sabado" text="Sab"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Day7A" runat="server" value="Domingo" text="Dom"/>
                            </label>
                            </label>
                            </div>    
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="OpeningTimeA" CssClass="form-control" AutoPostBack="False" runat="server">
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
                                <asp:DropDownList id="ClosingTimeA" CssClass="form-control" AutoPostBack="False" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                              <label for="ejemplo_archivo_1">Imagen del Restaurante</label>
                              <input type="file" id="ImageA"/>
                              <p class="help-block">Imagen .jpg o .png</p>
                         </div>
                </div>
                        
             </div> 
            </div>
                        <div class="modal-footer">
                            <asp:Button id="ButtonAdd" Text="Agregar" CssClass="btn btn-success " OnClick="ButtonAdd_Click" runat="server"/>
                            <asp:Button id="ButtonCancelA" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
            </div>
            </div>
            </div>  
            
    <script type="text/javascript">



        $(document).ready(function () {
            setValue();
            ajaxRes();
                });

                    function ajaxRes(){
                    $('.table > tbody > tr > td:nth-child(5) > a')
                        .click(function (e) {
                                    e.preventDefault();
                                    var prueba = document.getElementById("<%=RestaurantModifyId.ClientID%>").value;
                                    var params = "{'Id':'" + prueba + "'}";

                                    $.ajax({
                                    type: "POST",
                                    url: "Mesas.aspx/GetData",
                                    data: params,
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (response) {
                                        var local = response;
                                        document.getElementById("<%=NameC.ClientID%>").value = local.d.Name;
                                        document.getElementById("<%=NameM.ClientID%>").value = local.d.Name;
                                        document.getElementById("<%=CategoryC.ClientID%>").value = local.d.Name;
                                        document.getElementById("<%=CategoryM.ClientID%>").value = local.d.Name;
                                        document.getElementById("<%=NacionalityC.ClientID%>").value = local.d.Nacionality;
                                        document.getElementById("<%=NacionalityM.ClientID%>").value = local.d.Nacionality;
                                        document.getElementById("<%=RifC.ClientID%>").value = local.d.Rif;
                                        document.getElementById("<%=RifM.ClientID%>").value = local.d.Rif;
                                        document.getElementById("<%=CurrencyC.ClientID%>").value = local.d.Currency;
                                        document.getElementById("<%=CurrencyM.ClientID%>").value = local.d.Currency;
                                        document.getElementById("<%=AddressC.ClientID%>").value = local.d.Address;
                                        document.getElementById("<%=AddressM.ClientID%>").value = local.d.Address;
                                        document.getElementById("<%=ZoneC.ClientID%>").value = local.d.Name;
                                        document.getElementById("<%=ZoneM.ClientID%>").value = local.d.Name;
                                        document.getElementById("<%=OpeningTimeC.ClientID%>").value = local.d.OpeningTime;
                                        document.getElementById("<%=OpeningTimeM.ClientID%>").value = local.d.OpeningTime;
                                        document.getElementById("<%=ClosingTimeC.ClientID%>").value = local.d.OpeningTime;
                                        document.getElementById("<%=ClosingTimeM.ClientID%>").value = local.d.OpeningTime;
                                        document.getElementById("<%=LongM.ClientID%>").value = local.d.Longitude;
                                        document.getElementById("<%=LatM.ClientID%>").value = local.d.Latitude;
                                        document.getElementById("<%=Day1M.ClientID%>").value = local.d.Day;
                                        document.getElementById("<%=Day2M.ClientID%>").value = local.d.Day;
                                        document.getElementById("<%=Day3M.ClientID%>").value = local.d.Day;
                                        document.getElementById("<%=Day4M.ClientID%>").value = local.d.Day;
                                        document.getElementById("<%=Day5M.ClientID%>").value = local.d.Day;
                                        document.getElementById("<%=Day6M.ClientID%>").value = local.d.Day;
                                        document.getElementById("<%=Day7M.ClientID%>").value = local.d.Day;
                                        

                                        

                                    },
                                    failure: function (response) {
                                          alert("_");
                                    }
                                    });
                        });
                    }
                    function setValue() {
                        $('.table > tbody > tr > td:nth-child() > a')
                        .click(function () {
                            var padreId = $(this).parent().parent().attr("data-id");
                            document.getElementById("<%=RestaurantModifyId.ClientID%>").value = padreId;

                        });
                    }
        



    </script>         
            
      
</asp:Content>
