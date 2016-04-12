<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Panel de control
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Panel de control
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Estado actual
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">  

    <!-- Page Heading -->

    <div class="row">
        <div class="col-lg-12">
            <div class="alert alert-info alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-info-circle"></i>  Recuerda hacer el <strong>cierre de caja</strong> al finalizar la jornada!
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div class="row m-b-3">
        <div class="row">
            <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                <div id="exitoFormulario" class="alert alert-success alert-dismissable col-lg-12" runat="server">
                    Informacion enviada con exito!
                </div>
                <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12" runat="server">
                    La informacion no ha podido ser enviada. 
                </div>
            </div>
        </div>
        <div class="invisible">...</div>
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombres</label>
                            <asp:TextBox ID="Value1" CssClass="form-control" placeholder="ej. Maria" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Apellidos</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. Rodriguez" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">V/E</label>
                        <asp:DropDownList id="DropDown" CssClass="form-control" AutoPostBack="True" runat="server"/>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">Cedula de identidad</label>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="ej. 26785432" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-10 col-sm-10 col-xs-10">
                    <div class="form-group">
                        <label class="control-label">Otro campo</label>
                        <asp:DropDownList id="DropDownList1" CssClass="form-control" AutoPostBack="True" runat="server"/>
                    </div>
                </div>
                <div class="col-lg-6 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Otro campo</label>
                            <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="ej. 26785432" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-10 col-sm-10 col-xs-10">
                    <div class="form-group">
                        <label class="control-label">Otro campo</label>
                        <asp:DropDownList id="DropDownList2" CssClass="form-control" AutoPostBack="True" runat="server"/>
                    </div>
                </div>
                <div class="col-lg-3 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Otro campo</label>
                            <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="ej. 26785432" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-4 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Otro campo</label>
                            <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="ej. 26785432" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10 ">
                    <asp:Button id="Button1" Text="Submit" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click"/>
                    <asp:Button id="Button2" Text="Cancel" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click"/>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-cutlery fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">26</div>
                            <div>Comensales!</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Ver más</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-calendar fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">12</div>
                            <div>Reservaciones</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Ver más</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-pencil-square-o fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">10</div>
                            <div>Mesas disponibles</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Ver más</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-credit-card fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">124k</div>
                            <div>Bs. por facturar!</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Ver más</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-shopping-basket fa-fw"></i> Menú del día</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Plato</th>
                                    <th>Precio</th>
                                    <th>IVA</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>2350</td>
                                    <td>650</td>
                                    <td>3000</td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="text-right">
                            <a href="#">Modificar menú del día <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-lg-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-money fa-fw"></i> Panel de Transacciones</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th># de Orden</th>
                                    <th>Fecha</th>
                                    <th>Hora</th>
                                    <th>Monto</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>3326</td>
                                    <td>10/21/2013</td>
                                    <td>3:29 PM</td>
                                    <td>34978.90 Bs</td>
                                </tr>
                                <tr>
                                    <td>3326</td>
                                    <td>10/21/2013</td>
                                    <td>3:29 PM</td>
                                    <td>34978.90 Bs</td>
                                </tr>
                                <tr>
                                    <td>3326</td>
                                    <td>10/21/2013</td>
                                    <td>3:29 PM</td>
                                    <td>34978.90 Bs</td>
                                </tr>
                                <tr>
                                    <td>3326</td>
                                    <td>10/21/2013</td>
                                    <td>3:29 PM</td>
                                    <td>34978.90 Bs</td>
                                </tr>
                                <tr>
                                    <td>3326</td>
                                    <td>10/21/2013</td>
                                    <td>3:29 PM</td>
                                    <td>34978.90 Bs</td>
                                </tr>
                                <tr>
                                    <td>3326</td>
                                    <td>10/21/2013</td>
                                    <td>3:29 PM</td>
                                    <td>34978.90 Bs</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="text-right">
                        <a href="#">Ver todas las transacciones <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-clock-o fa-fw"></i> Tasks Panel</h3>
                </div>
                <div class="panel-body">
                    <div class="list-group">
                        <a href="#" class="list-group-item">
                            <span class="badge">just now</span>
                            <i class="fa fa-fw fa-calendar"></i> Calendar updated
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">4 minutes ago</span>
                            <i class="fa fa-fw fa-comment"></i> Commented on a post
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">23 minutes ago</span>
                            <i class="fa fa-fw fa-truck"></i> Order 392 shipped
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">46 minutes ago</span>
                            <i class="fa fa-fw fa-money"></i> Invoice 653 has been paid
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">1 hour ago</span>
                            <i class="fa fa-fw fa-user"></i> A new user has been added
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">2 hours ago</span>
                            <i class="fa fa-fw fa-check"></i> Completed task: "pick up dry cleaning"
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">yesterday</span>
                            <i class="fa fa-fw fa-globe"></i> Saved the world
                        </a>
                        <a href="#" class="list-group-item">
                            <span class="badge">two days ago</span>
                            <i class="fa fa-fw fa-check"></i> Completed task: "fix error on sales page"
                        </a>
                    </div>
                    <div class="text-right">
                        <a href="#">View All Activity <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->

    <div class="page-header">
        <h1>EJEMPLOS</h1>
    </div>
    
    <div class="row">
        <div class="col-sm-12">
            <ul class="list-group">
                <li class="list-group-item"><a href="http://gbsojo.github.io/BackOfficeTemplate/bootstrap-elements.html">Elementos de Bootstrap</a></li>
                <li class="list-group-item"><a href="http://gbsojo.github.io/BackOfficeTemplate/bootstrap-grid.html">Sistema de Grilla de Bootstrap</a></li>
                <li class="list-group-item"><a href="http://gbsojo.github.io/BackOfficeTemplate/forms.html">Formularios y Validacion</a></li>
                <li class="list-group-item"><a href="http://gbsojo.github.io/BackOfficeTemplate/charts.html">Graficos</a></li>
                <li class="list-group-item"><a href="http://gbsojo.github.io/BackOfficeTemplate/tables.html">Tablas</a></li>
            </ul>
        </div>
    </div>
    
</asp:Content>
