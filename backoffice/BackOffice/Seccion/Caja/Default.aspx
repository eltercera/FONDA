<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Seccion.Caja.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Ordenes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Lista de Ordenes
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Caja/Default.aspx">Caja</a>
          </li>
 
          <li class="active">
             Ver Ordenes abiertas
          </li>
      </ol>
  </div>
  <%--Fin_Breadcrumbs--%>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
   
    <div class="text-right">
                   <asp:Button id="Button1" Text="Cerrar Caja" CssClass="btn btn-primary" runat="server" OnClick="Button1_Click"/>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-money fa-fw"></i> Ordenes Abiertas </h3>
                    <a  href="AgregarOrden.aspx" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table id="ListarOrden" class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th style="vertical-align: middle">N° Orden</th>
                                    <th style="vertical-align: middle">Cliente</th>                          
                                    <th style="vertical-align: middle">Accion</th>
                                   
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="vertical-align: middle">#1</td>
                                    <td style="vertical-align: middle">@pperez</td>
                                    <td class="text-center" style="text-align:center; vertical-align:middle"><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a>  <a href="CrearFactura.aspx"><i class="fa fa-money fa-fw"></i></a> <a data-toggle="modal" data-target="#ver_orden"><i class="fa fa-info-circle" aria-hidden="true"></i></a></td>
                                    
                                </tr>
                                <tr>
                                    <td style="vertical-align: middle">#2</td>
                                    <td style="vertical-align: middle">@jero1604</td>
                                    <td class="text-center" style="text-align:center; vertical-align:middle"><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a>  <a href="CrearFactura.aspx"><i class="fa fa-money fa-fw"></i></a> <a data-toggle="modal" data-target="#ver_orden"><i class="fa fa-info-circle" aria-hidden="true"></i></a></td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: middle">#3</td>
                                    <td style="vertical-align: middle">@vero12</td>
                                    <td class="text-center" style="text-align:center; vertical-align:middle"><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a>  <a href="CrearFactura.aspx"><i class="fa fa-money fa-fw"></i></a> <a data-toggle="modal" data-target="#ver_orden"><i class="fa fa-info-circle" aria-hidden="true"></i></a></td>
                                </tr>
                            </tbody>
                        </table>
                        
                       
       
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="text-right">
                            
                            <a href="DefaultOrdenesCerradas.aspx"><i class="fa fa-plus"></i> Ver ordenes cerradas</a>
    </div>
    <!-- /.row -->

   <!-- Modal Ver Detalle Orden-->
     <div class="modal fade" id="ver_orden" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Detalle de la Orden</h4>
                            </div>
                                <div class="modal-body">
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
                                <table id="Detalle" class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>                                           
                                            <th style="vertical-align: middle">Cantidad</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Accion</th>
                                   
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2</td>
                                            <td style="vertical-align: middle">3000</td> 
                                            <td><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a></td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta con Vegetales</td>
                                            <td style="vertical-align: middle">1</td>
                                            <td style="vertical-align: middle">3000</td>  
                                            <td><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a></td>      
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta con Salmon</td>                                          
                                            <td style="vertical-align: middle"></td>
                                            <td style="vertical-align: middle">3000</td>                         
                                            <td><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a></td>
                                            
                                        </tr>
                                    </tbody>
                                </table>
                
                            </div>
                            <div class="text-right">
                            <a href="CrearFactura.aspx"><i class="fa fa-plus"></i> Pagar </a>
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