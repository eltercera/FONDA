<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ConsultarReservas.aspx.cs" Inherits="BackOffice.Seccion.Reservas.ConsultarReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Reservaciones
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="migas" runat="server">
      <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <%--<li>
                <a href="../Reservas/Default.aspx">Inicio</a>
            </li>--%>

            <%--<li>
                <a href="#">Reservaciones</a>
            </li>--%>
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
                    <h3 class="panel-title"><i class="fa fa-shopping-basket fa-fw"></i> Reservaciones</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Usuario</th>
                                    <th>Fecha</th>
                                    <th>Hora</th>
                                    <th>Comensales</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>jess27p</td>
                                    <td>27/09/2016</td>
                                    <td>3:00 p.m.</td>
                                    <td>2</td>
                                </tr>
                                <tr>
                                    <td>vickinsua</td>
                                    <td>30/09/2016</td>
                                    <td>8:00 p.m.</td>
                                    <td>4</td>
                                </tr>
                                <tr>
                                    <td>elio29</td>
                                    <td>01/10/2016</td>
                                    <td>6:50 p.m.</td>
                                    <td>2</td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="text-right">
                            <a href="#">Ok <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->
</asp:Content>
