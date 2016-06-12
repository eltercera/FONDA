<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="OrdenesCerradas.aspx.cs" Inherits="BackOffice.Seccion.Caja.OrdenesCerradas" %>
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
   
    <div class="row">
           <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Cuentas Cerradas</h3>
                                
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">

                                        <asp:Table ID="_closedOrders" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    <!-- /.row -->

    <!-- Modal Ver Detalle Orden-->
     <div class="modal fade" id="ver_factura" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Factura</h4>
                            </div>
                                <div class="modal-body">
                                     <!-- /.row -->
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-11">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Orden #1 Cliente: @pfren12 </h3>
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
                                            <th style="vertical-align: middle">Iva</th>
                                            <th style="vertical-align: middle">Total</th>
                                            
                                   
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                          
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">3000</td> 
                                            <td style="vertical-align: middle">200</td> 
                                            <td style="vertical-align: middle">3200</td> 
                                            
                                        </tr>
                                        <tr>
                                          <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">3000</td> 
                                            <td style="vertical-align: middle">200</td> 
                                            <td style="vertical-align: middle">3200</td>  
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">3000</td> 
                                            <td style="vertical-align: middle">200</td> 
                                            <td style="vertical-align: middle">3200</td> 
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
    </div> 
 
                         
                         <div class="modal-footer">
                            <asp:Button id="Button5" Text="Aceptar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button6" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
                </div>
            </div>
         </div>

</asp:Content>
