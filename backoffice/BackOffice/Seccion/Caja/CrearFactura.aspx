<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="CrearFactura.aspx.cs" Inherits="BackOffice.Seccion.Caja.CrearFactura" %>
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
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Caja/Default.aspx">Caja</a>
          </li>
 
          <li class="active">
            Facturar
          </li>
      </ol>
  </div>
  <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
  <div class="row">
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-8">
                <div id="exitoFormulario" class="alert alert-success alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    Orden cerrada y factura generada con <strong>EXITO</strong>!
                </div>
                <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    La factura <strong>NO SE HA PODIDO CREAR!</strong>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-11">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Factura #1 Cliente: @dhshga </h3>
                            <h3 class="panel-title">Avila Burger, Las Mercedes. 10/10/2015 </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>              
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Cantidad</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>                    
                                            <th style="vertical-align: middle">Total</th>
                                   
                                        </tr>
                                        
                                    </thead>
                                    <tbody>
                                        <tr>
                                      
                                            <td style="vertical-align: middle">La silla Burger</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="vertical-align: middle">120</td> 
                                            <td style="vertical-align: middle">3200</td> 
                                            
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle">Meat Burger</td>
                                            <td style="vertical-align: middle">1</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="vertical-align: middle">120</td> 
                                            <td style="vertical-align: middle">3200</td>          
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle">Bacon Burger</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">4000</td>
                                            <td style="vertical-align: middle">120</td> 
                                            <td style="vertical-align: middle">4200</td> 
                                            
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle"></td>
                                            <td style="vertical-align: middle"></td>
                                            <td style="vertical-align: middle"></td>
                                            <th style="vertical-align: middle">Monto Total</th> 
                                            <td style="vertical-align: middle">10600</td> 
                                            
                                        </tr>
                                    </tbody>
                                </table>
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->

            
        </div>
    <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10 ">
                    <asp:Button ID="Button1" Text="Facturar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click" />
                </div>
            </div>
       

</asp:Content>
