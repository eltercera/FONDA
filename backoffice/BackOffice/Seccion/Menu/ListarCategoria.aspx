<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="True" CodeBehind="ListarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Menu.ListarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Categorias del Menu
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Categorías
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar Categorías 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="../Menu/Default.aspx">Menú</a>
            </li>
            <li class="active">Listar Categorías
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

     <%--Alertas--%> 
    <div id="AlertSuccess_AddCategory" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>La categoría fue agregada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ModifyCategory" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>La categoría fue modificada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertDanger_AddCategory" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert  alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>La categoría <strong>no</strong> pudo ser agregada exitosamente.
            </div>
        </div>
    </div>

    <div id="AlertDanger_ModifyCategory" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>La categoría <strong>no</strong> pudo ser modificada exitosamente.
            </div>
        </div>
    </div>

     <%--/Alertas--%>
  
    <%--Tabla Categorias--%> 
      <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Categorias</h3>
                    <a data-toggle="modal" data-target="#add_category" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:HiddenField ID="HiddenFieldMenuCategoryModifyId" runat="server" Value="" />
                        <asp:Table ID="CategoryMenu" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--/Tabla Categorias--%>

    <!-- Modal modificar categoria-->
    <div class="modal fade" id="modify_category" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modificar Categoría</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Nombre de la Categoria del menú</label>
                                <asp:TextBox ID="TextBoxModifyCategoryName" CssClass="form-control" placeholder="" MaxLength="20" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonModifyCategory" Text="Modificar" CssClass="btn btn-success" OnClick="ButtonModifyCategory_Click" runat="server" />
                    <asp:Button ID="ButtonCancelModifyCategory" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal agregar categoria-->
    <div class="modal fade" id="add_category" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Agregar Categoría</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Nombre de la Categoria del menú</label>
                                <asp:TextBox ID="TextBoxAddCategoryName" CssClass="form-control" placeholder="ej. Menú Navideño" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonAddCategory" Text="Agregar" CssClass="btn btn-success" OnClick="ButtonAddCategory_Click" runat="server" />
                    <asp:Button ID="ButtonCancelAddCategory" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
        </div>
    </div>

      <!-- script -->
    <script type="text/javascript">

        $(document).ready(function () {
            setValue();
            ajaxRes();
        });

        function ajaxRes() {
            <%-- El numero dentro del td:nth-child(3) referencia al numero de la columna de izquierda a derecha donde va a correr el script  --%>
            $('.table > tbody > tr > td:nth-child(3) > a')
                .click(function (e) {
                    e.preventDefault();
                    var prueba = document.getElementById("<%=HiddenFieldMenuCategoryModifyId.ClientID%>").value;
                    var params = "{'Id':'" + prueba + "'}";
                    $.ajax({
                        type: "POST",
                        url: "ListarCategoria.aspx/GetData",
                        data: params,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var local = response;
                            <%-- Aqui se ponen tantas asignaciones como inputs haya en el modal --%>
                            document.getElementById("<%=TextBoxModifyCategoryName.ClientID%>").value = local.d.Name;
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
                    document.getElementById("<%=HiddenFieldMenuCategoryModifyId.ClientID%>").value = padreId;
            });
        }
    </script>

</asp:Content>
