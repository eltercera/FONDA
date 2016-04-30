<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    ¡Bienvenido!
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    NOMBRE DE RESTAURANT
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server"> 

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

    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-cutlery fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">Menu</div>
                            <div>Menu del dia</div>
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
                <a href="~/Seccion/Restaurant/Mesas.aspx" runat="server">
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
                            <div>Bs. por facturar</div>
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
       <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Mesas</h3>
                               <div class="clearfix"></div> 
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="dt-mesa" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Cantidad de puestos</th>
                                                <th>Cantidad de comensales</th>
                                                <th>Reservación realizada por</th>
                                                <th>Estado</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>#1</td>
                                                <td>6</td>
                                                <td>4</td>
                                                <td>@pperez</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p class="stat">I</p></i></span></td>
                                            </tr>
                                            <tr>
                                                <td>#2</td>
                                                <td>10</td>
                                                <td>0</td>
                                                <td></td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                            </tr>
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
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
    
</asp:Content>
