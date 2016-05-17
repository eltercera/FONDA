<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="MenuDia.aspx.cs" Inherits="BackOffice.Seccion.Menu.MenuDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Menu del Dia
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
Menú Del Día
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
      <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="#">Menú</a>
            </li>
            <li class="active">Menú Del Día
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
                       <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Sugerencia del Día</h3>
                   <div class="clearfix"></div>
                   </div>
                   <div class="panel-body">
                       <div class="table-responsive">
                           <asp:HiddenField ID="SugerenciaId" runat="server" Value="" />
                           <asp:Table ID="CategoryMenu" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                       </div>
                   </div>
               </div>
           </div>
         </div>

                <!-- /.row -->
     <!-- Modal Ver Plato-->
     <div class="modal fade" id="ver_plato" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Platillo</h4>
                            </div>
                                <div class="modal-body">
                                     <div class="row">
                                             <div class="col-lg-4 col-md-10 col-sm-10 col-xs-10">
                                                    <div class="form-group">
                                                          <img class="img-thumbnail" src="http://placehold.it/2600x2600" alt=""></td>
                                                    </div>
                                            </div>

                                             <div class="col-lg-8 col-md-10 col-sm-10 col-xs-10">
                                                   <div class="row">
                                                      <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                             <div class="form-group">
                                                                  <label class="control-label">Nombre del plato</label>
                                                                  <asp:TextBox ID="dishNombre" CssClass="form-control" placeholder="" MaxLength="20" Enabled="false" runat="server"/>
                                        
                                                            </div>
                                                      </div>
                                                   </div>  
                                                   <div class="row">
                                                         <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                                                            <div class="form-group">
                                                                <label class="control-label">Descripción del Platillo</label>
                                                                  <asp:TextBox ID="dishDescripcion" CssClass="form-control" placeholder="" MaxLength="20" Enabled="false" runat="server"/>
                                                            </div>
                                                        </div> 
                                                    </div> 
                                                     <div class="row">
                                                         <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                            <div class="form-group">
                                                                <label class="control-label">Precio</label>
                                                                 <asp:TextBox ID="dishPrecio" CssClass="form-control" placeholder="" MaxLength="20" Enabled="false" runat="server"/>
                                                            </div>
                                                        </div> 
                                                    </div> 
                                            </div> 
                                    
                                </div>
                         </div>
                    
                </div>
            </div>


     <%-- codigo de jascript pendiente aqui el numero 3 es para seleccionar elementos de la 3era columna de la tabla   --%>
       <%--  en el modal es importante que las areas de texto donde se muestran las cosas en el modal sean del tipo asp textBox si no no furula --%>
         <%--recordar que deben de correr primero la prueba de dish 2 o 3 veces y despues la de menu category por que si no no va a parecer nada en la tabla--%>
    <script type="text/javascript">



        $(document).ready(function () {
            setValue();
            ajaxRes();
        });

        function ajaxRes() {
            $('.table > tbody > tr > td:nth-child(3) > a')
                .click(function (e) {
                    e.preventDefault();
                    var prueba = document.getElementById("<%=SugerenciaId.ClientID%>").value;
                    var params = "{'Id':'" + prueba + "'}";

                    $.ajax({
                        type: "POST",
                        url: "MenuDia.aspx/GetData",
                        data: params,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var local = response;
                            document.getElementById("<%=dishNombre.ClientID%>").value = local.d.Name;
                            document.getElementById("<%=dishDescripcion.ClientID%>").value = local.d.Description;
                            document.getElementById("<%=dishPrecio.ClientID%>").value = local.d.Cost;

                            ////aqui es donde tomo los valores de los textbox y se lo mando al modal con el getdata
                            //fijate que aqui estan los valores del modal de mostrar plato con sus elementos 
                            //el sabe que es el modal de mostrar plato por que asi defini el evento cuando arme la tabla
                           },
                           failure: function (response) {
                               alert("_");
                           }
                       });
                });
               }
               function setValue() {
                   $('.table > tbody > tr > td:nth-child(3) > a')
                   .click(function () {
                       var padreId = $(this).parent().parent().attr("data-id");
                       document.getElementById("<%=SugerenciaId.ClientID%>").value = padreId;

                                });
                            }






    </script>

            <!-- /.container-fluid -->
</asp:Content>
