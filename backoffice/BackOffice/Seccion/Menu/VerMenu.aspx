<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="VerMenu.aspx.cs" Inherits="BackOffice.Seccion.Menu.VerMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Ver Menú
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="#">Menú</a>
            </li>
            <li class="active">Ver Menú
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
    <div class="row m-b-3">
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">



    <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Seleccionar Menú</label>
                             <select class="form-control" name="menu" id="Select1">

                                      <option>Pastas</option>
                                    <option>Carnes</option>
                                    <option>Pescados</option>
                                    <option>Vegetariano</option>


			                </select>
                       </div>
                </div>
            </div>
            <!-- /.row -->

            <div class="row">
                <div class="col-lg-10">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-cutlery fa-fw"></i>Menú de Pastas </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>Foto</th>
                                            <th>Plato</th>
                                            <th>Descripción</th>
                                            <th>Precio</th>
                                            <th>IVA</th>
                                            <th>Total</th>
                                            <th>Sugerencia del día</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Foto</td>
                                            <td>Pasta Carbonara</td>
                                            <td>Pasta con trozos de carne y queso</td>
                                            <td>2350</td>
                                            <td>650</td>
                                            <td>3000</td>
                                            <td style ="text-align:center">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Foto</td>
                                            <td>Pasta con Vegetales</td>
                                            <td>Pasta con brocoli y pimentón</td>
                                            <td>2350</td>
                                            <td>650</td>
                                            <td>3000</td>
                                            <td style ="text-align:center">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Foto</td>
                                            <td>Pasta con Salmon</td>
                                            <td>Pasta con trozos de salmon y queso</td>
                                            <td>2350</td>
                                            <td>650</td>
                                            <td>3000</td>
                                            <td style ="text-align:center">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="text-right">
                                    <a href="#">Modificar menú seleccionado <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->

            <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10 ">
                    <asp:Button ID="Button1" Text="Aceptar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click" />
                </div>
            </div>

        </div>
</asp:Content>
