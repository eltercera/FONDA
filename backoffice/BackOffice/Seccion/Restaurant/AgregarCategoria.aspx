<%@ Page Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Agregar Categoria
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Agregar Categoria
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
   <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Default.aspx">Inicio</a>
          </li>
      
          <li> 
             <a href="~/Seccion/Restaurant/Restaurante.aspx" runat="server">Restaurante</a> 
          </li>
          <li class="active">
             Categoria
          </li>

      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    <div id="AlertSuccess_AgregarCategoria" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La categoría fue agregada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ModificarCategoria" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La categoría fue modificada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

        <div class="row">
           <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Categoria del Restaurante</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                        <asp:HiddenField ID="CategoryModifyId" runat="server" Value="" />

                                        <asp:Table ID="CategoryRest" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            <!-- /.container-fluid -->

     <!-- Modal modificar categoria-->

             <div class="modal fade" id="modificar" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Modificar Categoria</h4>
                                </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                <div class="form-group">
                                                    <label class="control-label">Nombre</label>
                                                    <asp:TextBox ID="NombreCatM" CssClass="form-control" placeholder="ej. China" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button id="ButtonModificar" Text="Modificar" CssClass="btn btn-success" runat="server" OnClick="ButtonModificar_Click"/>
                                        <asp:Button id="ButtonCancelarM" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                                    </div>
                                </div>
                            </div>          
            </div>

    
         <!-- Modal agregar categoria-->
     <div class="modal fade" id="agregar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Agregar Categoria</h4>
                        </div>
                            <div class="modal-body">
                                 <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <label class="control-label">Nombre</label>
                                                <asp:TextBox ID="NombreCatA" CssClass="form-control" placeholder="ej. Americana" runat="server"/>
                                            </div>
                                    </div>
                                 </div>
                            </div>
                         <div class="modal-footer">
                            <asp:Button id="ButtonAgregar" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="ButtonAgregar_Click" OnClientClick="cambiarValor"/>
                            <asp:Button id="ButtonCancelarA" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>

                             <asp:LinkButton ID="elegido" OnClick="LinkButton_Click" runat="server" >Aqui va</asp:LinkButton>
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
                    $('.table > tbody > tr > td:nth-child(2) > a')
                        .click(function (e) {
                                    e.preventDefault();
                                    var prueba = document.getElementById("<%=CategoryModifyId.ClientID%>").value;
                                    var params = "{'Id':'" + prueba + "'}";
                            alert(prueba);
                                    $.ajax({
                                    type: "POST",
                                    url: "AgregarCategoria.aspx/GetData",
                                    data: params,
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (response) {
                                          alert("Vengo del servidor y mi id es"+ response);

                                    },
                                    failure: function (response) {
                                          alert("_");
                                    }
                                    });
                        });
                    }
                    function setValue() {
                        $('.table > tbody > tr > td:nth-child(2) > a')
                        .click(function () {
                            var padreId = $(this).parent().parent().attr("data-id");
                            document.getElementById("<%=CategoryModifyId.ClientID%>").value = padreId;

                        });
                    }
        



    </script>

    </asp:Content>


