<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="MenuDia.aspx.cs" Inherits="BackOffice.Seccion.Menu.MenuDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
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
       <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-shopping-basket fa-fw"></i> Menú del día</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Plato</th>
                                    <th>Precio</th>
                                    <th>IVA</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Pasta Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Lomito a la Parrilla</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Salmon Ahumado</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="text-right">
                            <a href="#">Modificar menú del día <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->
</asp:Content>
