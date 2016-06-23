<%@ Page Title="Detalle de Factura" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="VerDetalleFactura.aspx.cs" Inherits="BackOffice.Seccion.Caja.VerDetalleFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Detalle 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Factura # <%=Session["InvoiceNumber"]%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Caja/Ordenes.aspx">Caja</a>
            </li>
            <li>
               Orden
            </li>
            <li class="active">
                Factura 
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
                <asp:Label id="SuccessLabelMessage" runat="server"> 
                </asp:Label>
            </div>
        </div>
    </div>

    <div id="ErrorLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-ban"></i> 
                <asp:Label id="ErrorLabelMessage" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-cutlery" aria-hidden="true"></i> Detalle la factura</h3>
                    <asp:Button class="btn btn-default pull-right" text="Imprimir" Visible="false" ID="invoicePrint" OnClick="print_Click" runat="server" />                        
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <h5>&nbsp;&nbsp;&nbsp;&nbsp;<b>Restaurante: </b>
                            <%=Session["NameRestaurant"]%>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Fecha: </b>
                            <asp:Label ID="date" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b># Orden: </b>
                            <%=Session["AccountNumber"]%>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Apellido, Nombre: </b>
                            <asp:Label ID="lastname" runat="server"></asp:Label>,  
                            <asp:Label ID="name" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Cedula: </b>
                            <asp:Label ID="ssn" runat="server"></asp:Label>
                        </h5>
                    </div>
                    <div class="table-responsive">
                        <asp:Table ID="invoiceDetail" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
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

</asp:Content>