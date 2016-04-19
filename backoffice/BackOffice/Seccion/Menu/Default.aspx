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
     <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
    <div class="row">
        <div class="col-lg-4">   
            <div class="form-group input-group">
                <input type="text" class="form-control">
                <span class="input-group-btn"><button class="btn btn-default" type="button"><i class="fa fa-search"></i></button></span>
            </div>
        </div>
       </div>


        </div>
        <!-- /.row -->
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-11">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Pastas </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="tabla1" class="table table-bordered table-striped dataTable">
                                    <thead>
                                        <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Descripción</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                            <th style="vertical-align: middle">Acción</th>

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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="text-right">
                                    <a href="../Menu/ModificarMenu.aspx">Modificar Categoría <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->

            <!-- /.row -->


            <div class="row">
                <div class="col-lg-11">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Carnes </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Descripción</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                            <th style="vertical-align: middle">Acción</th>
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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="text-right">
                                    <a href="../Menu/ModificarMenu.aspx">Modificar Categoría <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->

            <!-- /.row -->

            <div class="row">
                <div class="col-lg-11">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Pescados y Mariscos </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th style="vertical-align: middle">Foto</th>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Descripción</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                            <th style="vertical-align: middle">Acción</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Rueda de Carite</td>
                                            <td style="vertical-align: middle">Pescado fresco cocinado al ajillo</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox"  id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Calamares Rebosados</td>
                                            <td style="vertical-align: middle">Calamares empanizados y fritos</td>
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
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img class="img-thumbnail" src="http://placehold.it/75x75" alt=""></td>
                                            <td style="vertical-align: middle">Salmon Ahumado</td>
                                            <td style="vertical-align: middle">Acompañado de vegetales al vapor</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1"  aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <a href="../Menu/ModificarPlatillo.aspx"><i class="fa fa-pencil-square-o fa-2x" aria-hidden="true"></i></a>
                                                <a href=""><i class="fa fa-check fa-2x" aria-hidden="true"></i></a>
                                                 <a href=""><i class="fa fa-times fa-2x" aria-hidden="true"></i></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="text-right">
                                    <a href="../Menu/ModificarMenu.aspx">Modificar Categoría <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->


            
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('tabla1').DataTable();
        });

        
        </script>
</asp:Content>
