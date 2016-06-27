<%@ Page Title="Detalle de la Reservacion" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="VerDetalleReserva.aspx.cs" Inherits="BackOffice.Seccion.Reservas.VerDetalleReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Detalle de Reservacion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Detalle 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Reservacion # <%=Session["ReservationNumber"]%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Reservas/ListarReservas.aspx">Inicio</a>
            </li>
            <li>
                <a href="../Reservas/ListarReservas.aspx">Listar Reservas</a>

            </li>
            <li class="active">Detalle
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    <div id="SuccessLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>
                <asp:Label ID="SuccessLabelMessage" runat="server"> 
                </asp:Label>
            </div>
        </div>
    </div>

    <div id="ErrorLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-ban"></i>
                <asp:Label ID="ErrorLabelMessage" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>



    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-calendar-check-o" aria-hidden="true"></i>Detalle de  la Reservacion</h3>
                    <%--<asp:Button class="btn btn-default pull-right" text="Imprimir" Visible="false" ID="invoicePrint" OnClick="print_Click" runat="server" />--%>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Usuario</label>
                                <asp:Label ID="userAccount" CssClass="form-control" placeholder="Nombre" MaxLength="10" runat="server" /><span style="color: #FF6633" class="form-control-feedback"></span>
                                <div id="Div1" style="color: #FF9999" runat="server"></div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label"># de Comensales</label>
                                <asp:Label ID="numberCommensal" CssClass="form-control" placeholder="Apellido" MaxLength="10" runat="server" /><span style="color: #FF6633" class="form-control-feedback"></span>
                                <div id="Div2" style="color: #FF9999" runat="server"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Restaurante</label>
                                <asp:Label ID="restaurant" CssClass="form-control" placeholder="Nombre" MaxLength="10" runat="server" /><span style="color: #FF6633" class="form-control-feedback"></span>
                                <div id="Div3" style="color: #FF9999" runat="server"></div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Mesa</label>
                                <asp:Label ID="restaurantTable" CssClass="form-control" placeholder="Apellido" MaxLength="10" runat="server" /><span style="color: #FF6633" class="form-control-feedback"></span>
                                <div id="Div4" style="color: #FF9999" runat="server"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Fecha de Creacion</label>
                                <asp:Label ID="creationDate" CssClass="form-control" placeholder="Nombre" MaxLength="10" runat="server" /><span style="color: #FF6633" class="form-control-feedback"></span>
                                <div id="Div5" style="color: #FF9999" runat="server"></div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Fecha de Reservacion</label>
                                <asp:Label ID="reservationDate" CssClass="form-control" placeholder="Apellido" MaxLength="10" runat="server" /><span style="color: #FF6633" class="form-control-feedback"></span>
                                <div id="Div6" style="color: #FF9999" runat="server"></div>
                            </div>
                        </div>
                    </div>
                    <div class="pull-right">
                         <a href="ListarReservas.aspx"><i class="fa fa-arrow-circle-left"></i> Volver a la lista</a>
                </div>
                </div>
            </div>
        </div>
</asp:Content>
