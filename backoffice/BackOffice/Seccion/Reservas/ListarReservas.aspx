<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarReservas.aspx.cs" Inherits="BackOffice.Seccion.Reservas.ListarReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
      de <%=Session["NameRestaurant"]%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
         
            <li>
                <a href="../Reservas/ListarReservas.aspx">Inicio</a>
            </li>
            <li class="active">Listar Reservas
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    
     <%--Alertas--%> 
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
            <div class="alert  alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-ban"></i>
                 <asp:Label id="ErrorLabelMessage" runat="server"> 
                </asp:Label>
             </div>
        </div>
    </div>

    <div id="WarningLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-warning fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-exclamation-triangle"></i>
                       <asp:Label id="WarningLabelMessage" runat="server"> 
                </asp:Label>
            </div>
        </div>
    </div>

    
     <%--/Alertas--%>
  
    <%--Tabla Reservas--%> 
      <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-calendar fa-fw"></i>Reservaciones</h3>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:HiddenField ID="HiddenFieldMenuCategoryModifyId" runat="server" Value="" />
                        <asp:Table ID="ReservationsList" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--/Tabla Reservas--%>

 
</asp:Content>
