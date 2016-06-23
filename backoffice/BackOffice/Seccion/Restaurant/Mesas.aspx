<%@ Page Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.Mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Mesas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Mesas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
<%=Session["NameRestaurant"]%>
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

    <div id="AlertSuccess_AddTable" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La mesa fue agregada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ModifyTable" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La mesa fue modificada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

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
                                        <asp:HiddenField ID="TableModifyId" runat="server" Value="" />

                                        <asp:Table ID="table" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>                      
                                             
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
                                <asp:DropDownList id="DDLcapacityM" CssClass="form-control" AutoPostBack="False" runat="server">
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                </asp:DropDownList> 
                             </div>
                             </div>
                         </div>       

                        <div class="modal-footer">
                            <asp:Button id="ButtonModify" Text="Modificar" CssClass="btn btn-success" OnClick="ButtonModify_Click" runat="server"/>
                            <asp:Button id="ButtonCancelM" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
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
                                <asp:DropDownList id="DDLcapacityA" CssClass="form-control" AutoPostBack="False" runat="server">
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                </asp:DropDownList> 
                             </div>
                             </div>
                         </div> 
                        <div class="modal-footer">
                            <asp:Button id="ButtonAdd" Text="Agregar" CssClass="btn btn-success" onclick="ButtonAdd_Click" runat="server"/>
                            <asp:Button id="ButtonCancelA" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
                    
                </div>   
               </div>
           </div>

    <script type="text/javascript">


//Modificar
        $(document).ready(function () {
            setValue();
            ajaxRes();
            Free();
            Busy();
                });

                    function Free(){
                    $('.table > tbody > tr > td:nth-child(6) > a[data-status=true]')
                        .click(function (e) {
                                    e.preventDefault();
                                    var rowId = document.getElementById("<%=TableModifyId.ClientID%>").value;
                                    var status = "Free";
                                    changeStatus(rowId, status);

                        });
                    }

                    function Busy(){
                        $('.table > tbody > tr > td:nth-child(6) > a[data-status=false]')
                        .click(function (e) {
                                    e.preventDefault();
                                    var rowId = document.getElementById("<%=TableModifyId.ClientID%>").value;
                                    var status = "Busy";
                                    changeStatus(rowId, status);
                            
                        });
                    }

                function changeStatus(rowId, status) {
                    var params = "{'Id':'" + rowId + "','Status':'" + status + "'}"
                    debugger;
                        $.ajax({
                            type: "POST",
                            url: "Mesas.aspx/ChangeStatus",
                            data: params,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                $('.table > tbody > tr[data-id=' + rowId + '] > td:nth-child(5)').html(response.d);
                            },
                            failure: function (response) {
                                console.log("Peticion al servidor fallida");
                            }
                        });
                    }

                    function ajaxRes(){
                    $('.table > tbody > tr > td:nth-child(6) > a')
                        .click(function (e) {
                                    e.preventDefault();
                                    var rowId = document.getElementById("<%=TableModifyId.ClientID%>").value;

                                    $.ajax({
                                    type: "POST",
                                    url: "Mesas.aspx/GetData",
                                    data: "{'Id':'" + rowId + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (response) {
                                        var local = response;
                                        document.getElementById("<%=DDLcapacityM.ClientID%>").value = local.d.Capacity;
                                    },
                                    failure: function (response) {
                                        console.log("Peticion al servidor fallida");
                                    }
                                    });
                        });
                    }

                    function setValue() {
                        $('.table > tbody > tr > td:nth-child(6) > a')
                        .click(function () {
                            var padreId = $(this).parent().parent().attr("data-id");
                            document.getElementById("<%=TableModifyId.ClientID%>").value = padreId;

                        });
                    }
        
       


    </script>
</asp:Content>