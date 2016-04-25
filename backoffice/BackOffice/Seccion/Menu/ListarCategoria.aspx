<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Menu.ListarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Categorías
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar Categorías 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="../Menu/Default.aspx">Menú</a>
            </li>
            <li class="active">Listar Categorías
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
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Categorias</h3>
                                <a data-toggle="modal" data-target="#agregar_categoria" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="ListarCategoria" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th>Estado</th>
                                                <th class="no-sort">Acciones</th>
 
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Pasta</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                
                                                <td>Carnes</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                   
                                            <tr>
                                                
                                                <td>Vegetales</td>                              
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                
                                                <td>Jugos</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                
                                                <td>Postres</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                                </tr>
                                                <tr>
                                                
                                                <td>Postres</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Postres</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Postres</td>                                      
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Postres</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Ávila Burger</td>
                                               <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Postres</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Postres</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                                <tr>
                                                
                                                <td>Postres</td>
                                               <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                            </tr>
                                         
                                        </tbody>
                                    </table>       
                                </div>
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
                            <h4 class="modal-title">Modificar Categoría</h4>
                        </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Nombre de la Categoria del menú</label>
                                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Pastas" MaxLength="3" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Estatus</label>
                                            <br />
                                            <asp:RadioButton ID="RadioButton1" GroupName="Estatus" runat="server" Text="  Activo" />
                                            <asp:RadioButton ID="RadioButton2" GroupName="Estatus" runat="server" Text="  Inactivo" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button id="Button3" Text="Agregar" CssClass="btn btn-success" runat="server"/>
                                <asp:Button id="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                            </div>
                        </div>
                    </div>          
    </div>
    
         <!-- Modal agregar categoria-->
     <div class="modal fade" id="agregar_categoria" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Agregar Categoría</h4>
                        </div>
                            <div class="modal-body">
                                 <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <label class="control-label">Nombre de la Categoria del menú</label>
                                                <asp:TextBox ID="Value1" CssClass="form-control" placeholder="ej. Menú Navideño" MaxLength="3" runat="server"/>
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