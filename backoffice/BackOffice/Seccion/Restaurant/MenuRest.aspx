<%@ Page Title="Menu Restaurante" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="MenuRest.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Menu Restaurante
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
¡Bienvenido!
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
   <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Default.aspx">Inicio</a>
          </li>

          <li class="active">
             Restaurante
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
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
                                        <div class="huge">4</div>
                                        <div>Comensales</div>
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
                                        <div class="huge">2</div>
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
                <!-- /.row -->

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-shopping-basket fa-fw"></i> Mesas en sistema</h3>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Cantidad de puestos</th>
                                                <th>Cantidad de comensales</th>
                                                <th>Estado</th>
                                                <th>Reservación realizada por</th>
                                                <th >Modificar</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>#1</td>
                                                <td>6</td>
                                                <td>4</td>
                                                <td bgcolor="#E08E79">Inactivo</td>
                                                <td>@pperez</td>
                                                <td><a href="ModificarMesa.aspx">Modificar <i class="fa fa-arrow-circle-right"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#2</td>
                                                <td>2</td>
                                                <td>0</td>
                                                <td bgcolor="#ACD691">Activo</td>
                                                <td> </td>
                                                <td><a href="ModificarMesa.aspx">Modificar <i class="fa fa-arrow-circle-right"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#3</td>
                                                <td>10</td>
                                                <td>0</td>
                                                <td bgcolor="#ACD691">Activo</td>
                                                <td> </td>
                                                <td><a href="ModificarMesa.aspx">Modificar <i class="fa fa-arrow-circle-right"></i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="text-right">
                                        <a href="AgregarMesa.aspx">Agregar mesa nueva <i class="fa fa-arrow-circle-right"></i></a>
                                    </div>
       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

</asp:Content>
