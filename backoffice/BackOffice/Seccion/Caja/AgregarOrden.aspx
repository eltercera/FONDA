<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarOrden.aspx.cs" Inherits="BackOffice.Seccion.Caja.AgregarOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Orden
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar Orden
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Caja/Default.aspx">Caja</a>
            </li>

            <li class="active">Agregar Orden
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    <div class="row">
        <div class="col-lg-10 col-md-8 col-sm-8 col-xs-8">
            <div id="exitoFormulario" class="alert alert-success alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                La orden ha sido agregada con <strong>EXITO</strong>!
            </div>
            <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                La orden <strong>NO SE HA PODIDO AGREGAR!</strong>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Menu</h3>
                        
                        <div class="clearfix"></div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">

                            <asp:Table ID="Menu1" CssClass="table table-bordered table-hover table-striped" runat="server" ></asp:Table>

                        </div>
                    </div>
                </div>
            </div>
        </div>



    <asp:Label id="label22" runat="server"></asp:Label>




    <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
        <div class="col-md-10 col-sm-10 col-xs-10 ">
            <asp:Button ID="Button1" Text="Aceptar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click" />
        </div>
    </div>



</asp:Content>
