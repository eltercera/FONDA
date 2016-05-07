<%@ Page Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Agregar Categoria
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Agregar Categoria
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
             Categoria
          </li>

      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
        <div class="row">
           <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Categoria del Restaurante</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="CategoriaRest" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th class="no-sort">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Venezolana</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Japonesa</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                   
                                            <tr>
                                                <td>Americana</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>China</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Arabe</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Mexicana</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                                <tr>
                                                <td>Italiana</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                                <tr>
                                                <td>Mediterranea</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Internacional</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Peruana</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Tailandesa</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Suiza</td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>Francesa</td>
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

     <!-- Modal modificar categoria-->
     <div class="modal fade" id="modificar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Modificar Categoria</h4>
                        </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Nombre</label>
                                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. China" runat="server" />
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
    
         <!-- Modal agregar categoria-->
     <div class="modal fade" id="agregar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Agregar Categoria</h4>
                        </div>
                            <div class="modal-body">
                                 <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <label class="control-label">Nombre</label>
                                                <asp:TextBox ID="Value1" CssClass="form-control" placeholder="ej. Americana" runat="server"/>
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


