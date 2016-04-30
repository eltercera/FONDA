<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="MenuDia.aspx.cs" Inherits="BackOffice.Seccion.Menu.MenuDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Menu del Dia
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
Menú Del Día
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
      <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="#">Menú</a>
            </li>
            <li class="active">Menú Del Día
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
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Menu del día</h3>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="MenuDia" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                            
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Acciones</th>
                                   
 
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                              
                                          
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#ver_plato"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></td>

                                       
                                         
                                        </tr>
                                            <tr>
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#ver_plato"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></td>
                                     
                                        </tr>
                                            <tr>
                                          
                                            <td style="vertical-align: middle">Pasta con Vegetales</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#ver_plato"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></td>
                                     </tr>
                                            <tr>
                                           
                                            <td style="vertical-align: middle">Pasta con Salmon</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#ver_plato"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></td>
                                                
                                        </tr>
                                                
                                             
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
           
                <!-- /.row -->
     <!-- Modal Ver Plato-->
     <div class="modal fade" id="ver_plato" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Platillo</h4>
                            </div>
                                <div class="modal-body">
                                     <div class="row">
                                             <div class="col-lg-4 col-md-10 col-sm-10 col-xs-10">
                                                    <div class="form-group">
                                                          <img class="img-thumbnail" src="http://placehold.it/2600x2600" alt=""></td>
                                                    </div>
                                            </div>

                                             <div class="col-lg-8 col-md-10 col-sm-10 col-xs-10">
                                                   <div class="row">
                                                      <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                             <div class="form-group">
                                                                <label class="control-label">Nombre del platillo</label>
                                                                      <p class="form-control-static">ej. pasta carbonara</p>
                                                           </div>
                                                      </div>
                                                   </div>  
                                                   <div class="row">
                                                         <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                                                            <div class="form-group">
                                                                <label class="control-label">Descripcion del platillo</label>
                                                               <p class="form-control-static">ej. pasta con tocineta y queso parmesano</p>
                                                            </div>
                                                        </div> 
                                                    </div> 
                                                     <div class="row">
                                                         <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                            <div class="form-group">
                                                                <label class="control-label">Precio</label>
                                                                    <p class="form-control-static">ej. 1000 bsf</p>
                                                            </div>
                                                        </div> 
                                                    </div> 
                                            </div> 
                                    
                                </div>
                         </div>
                    
                </div>
            </div>

            <!-- /.container-fluid -->
</asp:Content>
