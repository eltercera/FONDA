<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Seccion.Menu.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Menu Principal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Menú Principal
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
            <li class="active">Menú Principal
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    <%--Alertas--%>
    <div id="AlertSuccess_AddDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El platillo fue <u>agregado</u> <strong>exitosamente!</strong>
            </div>
        </div>
    </div>
        <div id="AlertSuccess_SuggestionDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El platillo fue <u>pasado a Sugerencia del día</u> <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ModifyDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El plato fue <u>modificado</u> <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ActivateDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El plato fue <u>activado</u> <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_DeactivateDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El plato fue <u>desactivado</u> <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertDanger_AddDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert  alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>El plano <strong>no</strong> pudo ser <u>agregado</u> exitosamente.
            </div>
        </div>
    </div>

    <div id="AlertDanger_ModifyDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>El plato <strong>no</strong> pudo ser <u>modificado</u> exitosamente.
            </div>
        </div>
    </div>

    <div id="AlertDanger_ActivateDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>El plato <strong>no</strong> pudo ser <u>activado</u> exitosamente.
            </div>
        </div>
    </div>

    <div id="AlertDanger_DeactivateDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>El plato <strong>no</strong> pudo ser <u>desactivado</u> exitosamente.
            </div>
        </div>
    </div>

    <div id="AlertWarning_ActivateDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-warning fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-exclamation-triangle"></i>El plato ya se encuentra <u>activado</u>.
            </div>
        </div>
    </div>

    <div id="AlertWarning_DeactivateDish" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-warning fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-exclamation-triangle"></i>El plato ya se encuentra <u>desactivado</u>.
            </div>
        </div>
    </div>


    <%--/Alertas--%>


    <%--Tabla Platos nueva--%>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Platos</h3>
                    <a data-toggle="modal" data-target="#add_dish" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:HiddenField ID="HiddenFieldDishModifyId" runat="server" Value="" />
                        <asp:Table ID="TableDish" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--/ Tabla Platos nueva--%>

    <%-- Modals --%>
    <!-- Modal modificar plato-->
    <div class="modal fade" id="modify_dish" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modificar Platillo</h4>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Nombre del platillo</label>
                                <asp:TextBox ID="TextBoxModifyDishName" CssClass="form-control" placeholder="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Descripcion del platillo</label>
                                <asp:TextBox ID="TextBoxModifyDishDescription" CssClass="form-control" placeholder="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Precio del platillo</label>
                                <asp:TextBox ID="TextBoxModifyDishPrice" CssClass="form-control" placeholder="" MaxLength="5" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
                                <input type="file" id="ejemplo_archivo_1" />
                                <p class="help-block">Imagen .jpg o .png</p>
                            </div>
                        </div>
                    </div>

                </div>


                <div class="modal-footer">
                    <asp:Button ID="ButtonModifyDish" Text="Modificar" CssClass="btn btn-success" OnClick="ButtonModifyDish_Click" runat="server" />
                    <asp:Button ID="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Ver Plato-->
    <div class="modal fade" id="see_dish" role="dialog">
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
                                        <label class="control-label">Nombre del platillo</label>
                                        <p class="form-control-static">ej. Pasta Carbonara</p>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                                    <div class="form-group">
                                        <label class="control-label">Descripcion del platillo</label>
                                        <p class="form-control-static">ej. pasta con tocineta y queso parmesano</p>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                    <div class="form-group">
                                        <label class="control-label">Precio</label>
                                        <p class="form-control-static">ej. 1000 bsf</p>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Modal agregar platillo-->
    <div class="modal fade" id="add_dish" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Agregar Platillo</h4>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Nombre del platillo</label>
                                <asp:TextBox ID="TextBoxAddDishName" CssClass="form-control" placeholder="ej. pasta carbonara" runat="server" />
                            </div>
                            <div class="form-group">
                                <label class="control-label">Descripcion del platillo</label>
                                <asp:TextBox ID="TextBoxAddDishDescription" CssClass="form-control" placeholder="ej. pasta con tocineta y queso parmesano" runat="server" />
                            </div>
                            <div class="form-group">
                                <label class="control-label">Precio del platillo</label>
                                <asp:TextBox ID="TextboxAddDishPrice" CssClass="form-control" placeholder="ej. 1000" MaxLength="5" runat="server" />
                            </div>
                             <div class="form-group">
                            <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
                            <input type="file" id="ejemplo_archivo_1" />
                            <p class="help-block">Imagen .jpg o .png</p>
                        </div>
                        </div>
                       
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Categoria</label>
                                <asp:DropDownList ID="DropDownListMenuCategoryAddDish" CssClass="form-control"  AutoPostBack="False" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonAddDish" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="ButtonAddDish_Click" />
                    <asp:Button ID="ButtonCancelAddDish" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="ButtonCancelAddDish_Click" />
                </div>
            </div>
        </div>
    </div>
    

    <!-- Modal desactivar plato-->
    <div class="modal fade" id="deactivate_dish" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Desactivar Plato</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">¿Desea desactivar el estado de este plato?</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonDeactivateDish" Text="Aceptar" CssClass="btn btn-success" OnClick="ButtonDeactivateDish_Click" runat="server" />
                    <asp:Button ID="ButtonCancelDeactivateDish" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal activar plato-->
    <div class="modal fade" id="activate_dish" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Activar Plato</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">¿Desea activar el estado de este plato?</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonActivateDish" Text="Aceptar" CssClass="btn btn-success" OnClick="ButtonActivateDish_Click" runat="server" />
                    <asp:Button ID="ButtonCancelActivateDish" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
        </div>
    </div>


    <!-- Modal sugerencia-->
    <div class="modal fade" id="suggestion" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Sugerencia de día</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Desea realizar accion de sugerencia del día a este platillo</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonModifySuggestion" Text="Aceptar" CssClass="btn btn-success" OnClick="ButtonModifySuggestion_Click" runat="server" />
                    <asp:Button ID="Button1" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
        </div>
    </div>


    <%-- /Modals --%>




    <!-- script -->
    <script type="text/javascript">

        $(document).ready(function () {
            setValue();
            ajaxRes();
        });

        function ajaxRes() {
             <%-- El numero dentro del td:nth-child(3) referencia al numero de la columna de izquierda a derecha donde va a correr el script  --%>
            $('.table > tbody > tr > td:nth-child(6) > a')
                .click(function (e) {
                    e.preventDefault();
                    var test = document.getElementById("<%=HiddenFieldDishModifyId.ClientID%>").value;
                    var params = "{'Id':'" + test + "'}";
                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/GetData",
                        data: params,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var local = response;
             <%-- Aqui se ponen tantas asignaciones como inputs haya en el modal --%>
                            document.getElementById("<%=TextBoxModifyDishName.ClientID%>").value = local.d.Name;
                            document.getElementById("<%=TextBoxModifyDishDescription.ClientID%>").value = local.d.Description;
                            document.getElementById("<%=TextBoxModifyDishPrice.ClientID%>").value = local.d.Cost;
                        },
                        failure: function (response) {
                            alert("_");
                        }
                    });
                });
            }

            function setValue() {
                $('.table > tbody > tr > td:nth-child(6) > a')
                .click(function () {
                    var parentId = $(this).parent().parent().attr("data-id");
                    document.getElementById("<%=HiddenFieldDishModifyId.ClientID%>").value = parentId;
                });
            }
    </script>

</asp:Content>
