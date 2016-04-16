<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="VerDetalleOrdenCerrada.aspx.cs" Inherits="BackOffice.Seccion.Caja.VerDetalleOrdenCerrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Ordenes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Detalle de Orden
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Caja/Default.aspx">Caja</a>
          </li>
 
          <li class="active">
            Detalle de la Orden Cerrada
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
                            <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Orden #1 Cliente: @pfren12 </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Descripción</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Cantidad</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Fecha</th>
                                   
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">Pasta con trozos de tocineta y queso parmesano</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="vertical-align: middle">10/10/2015</td> 
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta con Vegetales</td>
                                            <td style="vertical-align: middle">Pasta con brocoli y pimentón</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">1</td>
                                            <td style="vertical-align: middle">3000</td> 
                                            <td style="vertical-align: middle">10/10/2015</td>         
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta con Salmon</td>
                                            <td style="vertical-align: middle">Pasta con trozos de salmon y queso</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle"></td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="vertical-align: middle">10/10/2015</td> 
                                            
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="text-right">
                            <a href="ConsultarFactura.aspx"><i class="fa fa-plus"></i> Ver factura</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->

            
        </div>
    
       

</asp:Content>
