<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ModificarOrden.aspx.cs" Inherits="BackOffice.Seccion.Caja.ModificarOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Orden
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Orden
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Caja/Default.aspx">Caja</a>
            </li>

            <li class="active">Modificar Orden
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    <script type="text/javascript">


        $(document).ready(function () {
            $('#Menu1').DataTable({
                "language": spanish,
                "bAutoWidth": false,
                "aoColumns": [
                    null,
                     null,
                    null,
                    null,
                    { "bSearchable": false },
                    { "bSearchable": false }
                ]
            });
        });

        $(document).ready(function () {
            $('#Menu2').DataTable({
                "language": spanish,
                "bAutoWidth": false,
                "aoColumns": [
                    null,
                     null,
                    null,
                    null,
                    { "bSearchable": false },
                    { "bSearchable": false }
                ]
            });
        });

        $(document).ready(function () {
            $('#Menu3').DataTable({
                "language": spanish,
                "bAutoWidth": false,
                "aoColumns": [
                    null,
                     null,
                    null,
                    null,
                    { "bSearchable": false },
                    { "bSearchable": false }
                ]
            });
        });

        $(document).ready(function () {
            $('#ModificarOrden').DataTable({
                "language": spanish,
                "aoColumns": [
                    null,
                    null,
                    null,
                    null,
                    { "bSearchable": false },
                    { "bSearchable": false }
                ]
            });
        });



    </script>

    <div class="row">
        <div class="col-lg-10 col-md-8 col-sm-8 col-xs-8">
            <div id="exitoFormulario" class="alert alert-success alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                La orden ha sido modificada con <strong>EXITO</strong>!
            </div>
            <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                La orden <strong>NO SE HA PODIDO MODIFICAR!</strong>
            </div>
        </div>
    </div>


    <!-- /.row -->

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-money fa-fw">Factura #1 Cliente: @dhshga </i></h3>
                    <a data-toggle="modal" data-target="#ver_menus" class="btn btn-default pull-right"><i class="fa fa-plus" aria-hidden="true"></i></a>
                    <div class="clearfix"></div>

                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table id="ModificarOrden" class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>

                                    <th style="vertical-align: middle">Plato</th>

                                    <th style="vertical-align: middle">Precio</th>
                                    <th style="vertical-align: middle">IVA</th>
                                    <th style="vertical-align: middle">Cantidad</th>
                                    <th style="vertical-align: middle">Total</th>

                                    <th style="vertical-align: middle">Accion</th>


                                </tr>
                            </thead>
                            <tbody>
                                <tr>

                                    <td style="vertical-align: middle">Pasta Carbonara</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>
                                        
                                    

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Vegetales</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Salmon</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                </tr>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
        <div class="col-md-10 col-sm-10 col-xs-10 ">
            <asp:Button ID="Button1" Text="Aceptar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click" />
            <asp:Button ID="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click" />
        </div>
    </div>

    <!-- /.row -->

    <div class="modal fade" id="ver_menus" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modificar Platillo</h4>
                </div>
                <div class="modal-body">
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home">Pastas</a></li>
                        <li><a data-toggle="tab" href="#menu1">Carnes</a></li>
                        <li><a data-toggle="tab" href="#menu2">Pescados</a></li>
                    </ul>

                    <div class="tab-content">
                        <div id="home" class="tab-pane fade in active">
                            <div class="table-responsive">
                        <table id="Menu1" class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>

                                    <th style="vertical-align: middle">Plato</th>

                                    <th style="vertical-align: middle">Precio</th>
                                    <th style="vertical-align: middle">IVA</th>
                                    <th style="vertical-align: middle">Cantidad</th>
                                    <th style="vertical-align: middle">Total</th>

                                    <th style="vertical-align: middle">Accion</th>


                                </tr>
                            </thead>
                            <tbody>
                                <tr>

                                    <td style="vertical-align: middle">Pasta Carbonara</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Vegetales</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Salmon</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                            </tbody>
                        </table>

                    </div>
                        </div>
                        <div id="menu1" class="tab-pane fade">
                            <div class="table-responsive">
                        <table id="Menu2" class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>

                                    <th style="vertical-align: middle">Plato</th>

                                    <th style="vertical-align: middle">Precio</th>
                                    <th style="vertical-align: middle">IVA</th>
                                    <th style="vertical-align: middle">Cantidad</th>
                                    <th style="vertical-align: middle">Total</th>

                                    <th style="vertical-align: middle">Accion</th>


                                </tr>
                            </thead>
                            <tbody>
                                <tr>

                                    <td style="vertical-align: middle">Pasta Carbonara</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Vegetales</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Salmon</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                            </tbody>
                        </table>

                    </div>
                        </div>
                        <div id="menu2" class="tab-pane fade">
                            <div class="table-responsive">
                        <table id="Menu3" class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>

                                    <th style="vertical-align: middle">Plato</th>

                                    <th style="vertical-align: middle">Precio</th>
                                    <th style="vertical-align: middle">IVA</th>
                                    <th style="vertical-align: middle">Cantidad</th>
                                    <th style="vertical-align: middle">Total</th>

                                    <th style="vertical-align: middle">Accion</th>


                                </tr>
                            </thead>
                            <tbody>
                                <tr>

                                    <td style="vertical-align: middle">Pasta Carbonara</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Vegetales</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                                <tr>

                                    <td style="vertical-align: middle">Pasta con Salmon</td>

                                    <td style="vertical-align: middle">2350</td>
                                    <td style="vertical-align: middle">650</td>
                                    <td style="vertical-align: middle">
                                        <input type="number" name="quantity" min="1" max="10"></td>
                                    <td style="vertical-align: middle">3000</td>

                                    <td style="text-align: center; vertical-align: middle"><a data-toggle="modal" data-target="#"><i class="fa fa-check"></i></a></td>

                                </tr>
                            </tbody>
                        </table>

                    </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                            <asp:Button id="Button5" Text="Modificar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button6" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
            </div>

        </div>
    </div>

</asp:Content>
