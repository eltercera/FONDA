<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="BackOffice.Seccion.Caja.Default" %>
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
   
    <div class="row">
           <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Cuentas abiertas</h3>
                                <a href="AgregarOrden.aspx" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                        <asp:HiddenField ID="AccountPopOrder" runat="server" Value="" />

                                        <asp:Table ID="_orderList" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

    <div class="text-right">
                            
                            <a href="OrdenesCerradas.aspx"><i class="fa fa-plus"></i> Ver ordenes cerradas</a>
    </div>
    <!-- /.row -->

   <!-- Modal Ver Detalle Orden-->
     

             <div class="modal fade" id="ver_orden" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Ver Detalle Orden</h4>
                                </div>
                                    <div class="modal-body">
                                        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                                             <div class="row">
                                                 <div class="col-lg-11">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                           <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Orden #1 Cliente: @pfren12 </h3>
                                                         </div>
                                                        <div class="panel-body">
                                                          <div class="table-responsive">                                           

                                                                <asp:Table ID="Detalle" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                                                           </div>
                                    </div>
                                   </div>
                                  </div>                     
                                </div>
                            </div>          
                        </div>
                 </div>
               </div>
                 <div class="text-right">
                            <a href="CrearFactura.aspx"><i class="fa fa-plus"></i> Pagar </a>
                            </div>
             </div>
                            
                      
            <!-- /.row -->


    
</asp:Content>