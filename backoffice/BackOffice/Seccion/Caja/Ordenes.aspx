<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="BackOffice.Seccion.Caja.Ordenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Ordenes Abiertas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    de <%=Session["NameRestaurant"]%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Caja/Ordenes.aspx">Caja</a>
          </li>
          <li class="active">
             Ver Ordenes abiertas
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
                    <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Cuentas abiertas</h3>
                    <asp:Button onClick="CloseCashRegister_Click" ID="closeCR" class="btn btn-default pull-right" text="Cerrar Caja" runat="server"></asp:Button>                               
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">

                            <asp:Table ID="orderList" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="text-right">                            
        <a href="OrdenesCerradas.aspx"><i class="fa fa-plus"></i> Ver ordenes cerradas</a>
    </div>
        
</asp:Content>