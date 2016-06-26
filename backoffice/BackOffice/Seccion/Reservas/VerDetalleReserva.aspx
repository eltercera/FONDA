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

                    <%--TODO Reservation: Tratar de hacerlo con bootstrap--%>
                    <div class="row">
                        <h5>&nbsp;&nbsp;&nbsp;&nbsp;<b>Usuario: </b>
                            <asp:Label ID="userAccount" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b># de Comensales: </b>
                            <asp:Label ID="numberCommensal" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Restaurante: </b>
                            <asp:Label ID="restaurant" runat="server"></asp:Label>
                            <%-- <%=Session["NameRestaurant"]%>--%>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Mesa: </b>
                            <asp:Label ID="table" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Fecha de Creacion: </b>
                            <asp:Label ID="creationDate" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Fecha de Reservacion: </b>
                            <asp:Label ID="reservationDate" runat="server"></asp:Label>
                            <br />
                            <br />
                            <%--   &nbsp;&nbsp;&nbsp;&nbsp;<b>: </b>
                            <asp:Label ID="reservationNumber" runat="server"></asp:Label>
                            <br />
                            <br />--%>
                            <%--   &nbsp;&nbsp;&nbsp;&nbsp;<b>Apellido, Nombre: </b>
                            <asp:Label ID="lastname" runat="server"></asp:Label>,  
                            <asp:Label ID="name" runat="server"></asp:Label>
                            <br />
                            <br />--%>
                            <%--                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Cedula: </b>
                            <asp:Label ID="ssn" runat="server"></asp:Label>--%>
                        </h5>
                    </div>
                    <div class="table-responsive">
                        <asp:Table ID="reservationDetail" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>

                    <div class="row">
                        <h5>&nbsp;&nbsp;&nbsp;&nbsp;<b>Sub-total: </b>
                            <asp:Label ID="subtotal" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Iva: </b>
                            <asp:Label ID="iva" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Propina: </b>
                            <asp:Label ID="propina" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Total: </b>
                            <asp:Label ID="total" runat="server"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            </div>
        </div>
</asp:Content>
