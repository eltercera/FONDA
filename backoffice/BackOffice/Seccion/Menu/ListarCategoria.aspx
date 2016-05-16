<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Menu.ListarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Categorias del Menu
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

        <div id="AlertSuccess_AgregarCategoria" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La categoría fue agregada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

          <div id="AlertSuccess_ModificarCategoria" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La categoría fue modificada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

        <div class="row">
           <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Categorias</h3>
                                <a data-toggle="modal" data-target="#agregar_categoria" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                     <div class="row">
                    <table id="plantillacategoria" class="table table-bordered table-striped dataTable">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Estatus</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <asp:Literal ID="Tabla" runat="server"></asp:Literal>
                    </table>
                </div>
                                        
                                </div>
                            </div>
                        </div>
                    </div>
            
               
           <!-- aqui se carga la tabla con las categorias busca arreglar la de arriba para que solo salga esa-->
          
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
                                            <asp:TextBox ID="TextBoxModificar" CssClass="form-control" placeholder="" MaxLength="20"  runat="server" />
                                        </div>
                                    </div>
                                </div>
                       
                              
                            </div>
                        <div class="modal-footer">
                            <asp:Button ID="BotonModificarCategoria" Text="Modificar" CssClass="btn btn-success" OnClick="BotonModificarCategoria_Click" runat="server" />
                            <asp:Button ID="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
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
                                                <asp:TextBox ID="Value1" CssClass="form-control" placeholder="ej. Menú Navideño" runat="server"/>
                                            </div>
                                    </div>
                                 </div>
                            </div>
                         <div class="modal-footer">
                            <asp:Button id="BotonAgregarCategoria" Text="Agregar" CssClass="btn btn-success" OnClick="BotonAgregarCategoria_Click" runat="server"/>
                            <asp:Button id="BotonCancelarCategoria" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
                     </div>
                </div>
    </div> 

    </asp:Content>