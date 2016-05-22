<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="CrearFactura.aspx.cs" Inherits="BackOffice.Seccion.Caja.CrearFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Pago de Orden
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Facturar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Caja/Default.aspx">Caja</a>
            </li>

            <li class="active">Facturar
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    <div id="AlertSuccess_AgregarFactura" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i> La Orden fue cerrada <strong>exitosamente!</strong>
            </div>
        </div>
    </div>
    <!-- /.row -->
        
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Factura <asp:Label ID="Label1" runat="server"></asp:Label> Cliente: <asp:Label ID="Label2" runat="server"></asp:Label> </h3>
                        <h3 class="panel-title">Restaurante: <asp:Label ID="Label3" runat="server"></asp:Label>, <asp:Label ID="Label4" runat="server"></asp:Label> </h3>
                        <div class="clearfix"></div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">

                            <asp:Table ID="Pago" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>

                        </div>
                    </div>
                </div>
            </div>

        </div>
     <asp:Label ID="Label5" text="HOLA" runat="server" Font-Bold="true"></asp:Label>
        <!-- /.row -->

    <!-- Modal modificar categoria-->

             <div class="modal fade" id="modificar" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Añada los últimos 4 digitos de su tarjeta</h4>
                                </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                <div class="form-group">
                                                    <label class="control-label">Tarjeta</label>
                                                    <asp:TextBox ID="NumCard" CssClass="form-control" placeholder="ej. 1234" runat="server" />
                                                    <label class="control-label">Seleccionar Perfil</label>
                                                    <asp:DropDownList id="DropDownProfiles" CssClass="form-control" AutoPostBack="False" runat="server">
                                                        
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button id="ButtonPay" Text="Pagar" CssClass="btn btn-success" runat="server" OnClick="ButtonCloseOrder_Click"/>
                                        <asp:Button id="ButtonCancel" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                                    </div>
                                </div>
                            </div>          
            </div>

   
    
    <div class="text-right">
        <p class="text-center">
            <asp:Label ID="LabelMontoTotal" runat="server" Font-Bold="true"></asp:Label>
        </p>
      
        
          <asp:LinkButton ID="ButtonPayment" data-toggle="modal" data-target="#modificar" Text="Pagar" CssClass="btn btn-success pull-right" runat="server" > </asp:LinkButton>
            
    </div>


   

</asp:Content>
