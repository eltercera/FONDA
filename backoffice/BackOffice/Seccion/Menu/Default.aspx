<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Seccion.Menu.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Menú Principal
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
            <li class="active">Menú Principal
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
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Pastas</h3>
                                <a data-toggle="modal" data-target="#agregar_platillo" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="default" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Descripción</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                            <th>Estado</th>
                                            <th class="no-sort">Acciones</th>
 
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
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                 <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                        </tr>
                                            <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">Pasta con trozos de tocineta y queso parmesano</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                        </tr>
                                            <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta con Vegetales</td>
                                            <td style="vertical-align: middle">Pasta con brocoli y pimentón</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                     
                                              
                                        </tr>
                                            <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Pasta con Salmon</td>
                                            <td style="vertical-align: middle">Pasta con trozos de salmon y queso</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                           
                                           
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
        


        <div class="row">
                <div class="col-lg-12">
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Carnes</h3>
                                <a data-toggle="modal" data-target="#agregar_platillo" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="default1" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Descripción</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                                 <th style="vertical-align: middle">Estado</th>
                                            <th class="no-sort">Acciones</th>
 
                                            </tr>
                                       </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Lomito a la Parrilla</td>
                                            <td style="vertical-align: middle">Sazonado con hiervas</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                             <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                             <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Solomo a la Plancha</td>
                                            <td style="vertical-align: middle">Acompañado con vegetales</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Chuleta Ahumada</td>
                                            <td style="vertical-align: middle">Acompañado de papas al vapor</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-times"></i></a></td>
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

       <!-- Modal modificar plato-->
     <div class="modal fade" id="modificar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Modificar Platillo</h4>
                        </div>
                            <div class="modal-body">
                            
                                <div class="row">
                                      <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                         <div class="form-group">
                                            <label class="control-label">Nombre del platillo</label>
                                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Pasta Carbonara" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Descripcion del platillo</label>
                                            <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Pasta con tocineta y queso parmesano"  runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Precio del platillo</label>
                                            <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="1000" MaxLength="5" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
                                            <input type="file" id="ejemplo_archivo_1"/>
                                            <p class="help-block">Imagen .jpg o .png</p>
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


    <!-- Modal agregar platillo-->
    <div class="modal fade" id="agregar_platillo" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Agregar Platillo</h4>
                        </div>
                            <div class="modal-body">
                              
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                         <div class="form-group">
                                            <label class="control-label">Nombre del platillo</label>
                                            <asp:TextBox ID="nombrePlato" CssClass="form-control" placeholder="ej. pasta carbonara" runat="server"/>
                                        </div>
                                    </div>       
                                </div>
                                <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Descripcion del platillo</label>
                                            <asp:TextBox ID="descripcionPlato" CssClass="form-control" placeholder="ej. pasta con tocineta y queso parmesano" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Precio del platillo</label>
                                            <asp:TextBox ID="precioPlato" CssClass="form-control" placeholder="ej. 1000" MaxLength="5" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
                                            <input type="file" id="ejemplo_archivo_1"/>
                                            <p class="help-block">Imagen .jpg o .png</p>
                                        </div>
                                    </div>
                                </div>
                        <div class="modal-footer">
                           <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="Button1_Click"/>
                           <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="Button2_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>


</asp:Content>
