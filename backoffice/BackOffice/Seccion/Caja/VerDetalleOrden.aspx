<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="VerDetalleOrden.aspx.cs" Inherits="BackOffice.Seccion.Caja.VerDetalleOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Pago de Orden
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Facturar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Caja/Default.aspx">Caja</a>
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
                        <h3 class="panel-title">Orden # <asp:Label ID="Label1" runat="server"></asp:Label> Cliente: <asp:Label ID="Label2" runat="server"></asp:Label> </h3>
                        <h3 class="panel-title">Restaurante: <asp:Label ID="Label3" runat="server"></asp:Label><%=Session["NameRestaurant"]%><asp:Label ID="Label4" runat="server"></asp:Label> </h3>
                        <div class="clearfix"></div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">

                            <asp:Table ID="Pago" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->
    </asp:Content>