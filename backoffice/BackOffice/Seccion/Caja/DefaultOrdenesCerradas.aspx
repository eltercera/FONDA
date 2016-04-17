<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="DefaultOrdenesCerradas.aspx.cs" Inherits="BackOffice.Seccion.Caja.DefaultOrdenesCerradas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Ordenes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Lista de Ordenes cerradas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Caja/Default.aspx">Caja</a>
          </li>
 
          <li class="active">
             Ver Ordenes Cerradas
          </li>
      </ol>
  </div>
  <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
   
    <div class="text-right">
                   <asp:Button id="Button2" Text="Cerrar Caja" CssClass="btn btn-primary" runat="server" OnClick="Button1_Click"/>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-money fa-fw"></i> Ordenes Cerradas </h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>N° Orden</th>
                                    <th>Cliente</th>                          
                                    <th>Fecha</th>
                                    <th>Monto Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><a href="VerDetalleOrdenCerrada.aspx">#1</a></td>
                                    <td>@pperez</td>
                                    <td>10/10/2014</td>
                                    <td>8000</td>
                                </tr>
                                <tr>
                                    <td><a href="VerDetalleOrdenCerrada.aspx">#2</a></td>
                                    <td>@jero1604</td>
                                    <td>10/10/2014</td>
                                    <td>6000</td>
                                </tr>
                                <tr>
                                    <td><a href="VerDetalleOrdenCerrada.aspx">#3</a></td>
                                    <td>@vero12</td>
                                    <td>10/10/2014</td>
                                    <td>7000</td>
                                </tr>
                            </tbody>
                        </table>
       
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->


</asp:Content>
