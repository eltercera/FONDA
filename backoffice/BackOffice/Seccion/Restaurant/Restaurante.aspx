<%@ Page Title="Restaurantes" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Restaurante.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Restaurantes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Listado de Restaurantes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
<div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-shopping-basket fa-fw"></i> Restaurantes disponibles en sistema</h3>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Info</th>
                                                <th>Nombre</th>
                                                <th>Direccion</th>
                                                <th>Tipo</th>
                                                <th>Estado</th>
                                                <th >Modificar</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><a data-toggle="modal" data-target="#elCine"><i class="fa fa-info-circle" aria-hidden="true"></i></a></td>
                                                <td><a href="MenuRest.aspx">El Cine</a></td>
                                                <td>Calle Comercio, entre Sucre y Bellavista - El Hatillo</td>
                                                <td>Japonesa</td>
                                                <td bgcolor="#ACD691">Activo</td>
                                                <td><a href="ModificarRest.aspx">Modificar <i class="fa fa-arrow-circle-right"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td><i class="fa fa-info-circle" aria-hidden="true"></i></td>
                                                <td>St. Honoré</td>
                                                <td>Transversal 1 - Los Palos Grandes</td>
                                                <td>Cafetería, pastelería</td>
                                                <td bgcolor="#E08E79">Inactivo</td>
                                                <td><a href="ModificarRest.aspx">Modificar <i class="fa fa-arrow-circle-right"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td><i class="fa fa-info-circle" aria-hidden="true"></i></td>
                                                <td>Ávila Burger</td>
                                                <td>4ta Avenida con 6ta Transversal. Cuadra Gastronomica - Los Palos Grandes</td>
                                                <td>Americana</td>
                                                <td bgcolor="#ACD691">Activo</td>
                                                <td><a href="ModificarRest.aspx">Modificar <i class="fa fa-arrow-circle-right"></i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="text-right">
                                        <a href="AgregarRest.aspx">Agregar restaurante nuevo <i class="fa fa-arrow-circle-right"></i></a>
                                    </div>
       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
                <!-- /.row -->
            <!-- /.container-fluid -->
            <!-- Modal -->
            <div class="modal fade" id="elCine" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">El Cine</h4>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>Nombre</th>
                                            <th>RIF</th>
                                            <th>Tipo</th>
                                            <th>Estado</th>
                                            <th>Direccion</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>El Cine</td>
                                            <td>J-34857861-1</td>
                                            <td>Japonesa</td>
                                            <td bgcolor="#81F79F">Activo</td>
                                            <td>Calle Comercio, entre Sucre y Bellavista - El Hatillo</td>
                                        </tr>
                                    </tbody>
                                </table><div class="table-responsive">
                                    <table class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Mapa</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15695.913224648662!2d-66.82501238465575!3d10.423295992847969!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xa4f83f07bee2d359!2sEl+Cine+Restaurant!5e0!3m2!1ses!2sve!4v1460401053970" width="400" height="300" frameborder="0" style="border:0" allowfullscreen></iframe></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
            <!--/Modal-->

</asp:Content>
