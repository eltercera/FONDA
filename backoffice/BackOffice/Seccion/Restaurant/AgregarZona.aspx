<%@ Page Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarZona.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.AgregarZona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Agregar Zona
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Agregar Zona
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Default.aspx">Inicio</a>
          </li>
      
          <li> 
             <a href="~/Seccion/Restaurant/Restaurante.aspx" runat="server">Restaurante</a> 
          </li>
          <li class="active">
             Zona
          </li>

      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
        <div class="row">
           <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left">Zona del Restaurante</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="ZonaRest" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th class="no-sort">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Altamira</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Bello Monte</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                   
                                            <tr>
                                                <td>Chacao</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>El Bosque</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Santa Fé</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>San Roman</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                                <tr>
                                                <td>Los Samanes</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                                <tr>
                                                <td>Campo Alegre</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Los Dos Caminos</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Las Palmas</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Las Mercedes</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Galipán</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>El Recreo</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>                                               
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            <!-- /.container-fluid -->

     <!-- Modal modificar zona-->
     <div class="modal fade" id="modificar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Modificar Zona</h4>
                        </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Nombre</label>
                                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. Altamira" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button id="Button3" Text="Modificar" CssClass="btn btn-success" runat="server"/>
                                <asp:Button id="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                            </div>
                        </div>
                    </div>          
    </div>
    
         <!-- Modal agregar zona-->
     <div class="modal fade" id="agregar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Agregar Zona</h4>
                        </div>
                            <div class="modal-body">
                                 <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <label class="control-label">Nombre</label>
                                                <asp:TextBox ID="Value1" CssClass="form-control" placeholder="ej. Altamira" runat="server"/>
                                            </div>
                                    </div>
                                 </div>
                            </div>
                         <div class="modal-footer">
                            <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
                     </div>
                </div>
    </div>


    </asp:Content>

