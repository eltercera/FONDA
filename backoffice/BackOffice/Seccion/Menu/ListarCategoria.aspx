<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Menu.ListarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
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
    <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
        <div class="row">
            <div class="col-lg-4">
                <div class="form-group input-group">
                    <input type="text" class="form-control">
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button"><i class="fa fa-search"></i></button>
                    </span>
                </div>
            </div>
        </div>


    </div>
    <!-- /.row -->
    <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
        <div class="row">
            <div class="col-lg-11">
                     <div class="text-right">
                                    <a href="../Menu/AgregarMenu.aspx">Agregar <i class="fa fa-plus"></i></a>
                                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Categorías </h3>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table id="tabla1" class="table table-bordered table-striped dataTable">
                                <thead>
                                    <tr>
                                        <th style="vertical-align: middle">Nombre</th>
                                        <th style="vertical-align: middle">Acción</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>

                                        <td style="vertical-align: middle">Pasta</td>
                                        <td style="text-align: center; vertical-align: middle">
                                            <a href="../Menu/ModificarMenu.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                            <a href="#"><i class="fa fa-info-circle fa-2x" aria-hidden="true"></i></a>
                                            <a href="#"><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                            <a href="#"><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="vertical-align: middle">Carnes </td>


                                        <td style="text-align: center; vertical-align: middle">
                                            <a href="../Menu/ModificarMenu.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                            <a href="#"><i class="fa fa-info-circle fa-2x" aria-hidden="true"></i></a>
                                            <a href="#"><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                            <a href="#"><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>

                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="vertical-align: middle">Aves</td>
                        </div>

                        <td style="text-align: center; vertical-align: middle">
                            <a href="../Menu/ModificarMenu.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                            <a href="#"><i class="fa fa-info-circle fa-2x" aria-hidden="true"></i></a>
                            <a href="#"><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                            <a href="#"><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>

                        </td>
                        </tr>
                                    </tbody>
                                </table>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
