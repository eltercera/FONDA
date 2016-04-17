<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ConsultarFactura.aspx.cs" Inherits="BackOffice.Seccion.Caja.ConsultarFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Orden
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Factura
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Caja/Default.aspx">Caja</a>
          </li>
 
          <li class="active">
           Ver Factura
          </li>
      </ol>
  </div>
  <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
 
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
       

</asp:Content>

