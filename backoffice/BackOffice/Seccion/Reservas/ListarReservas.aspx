<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ListarReservas.aspx.cs" Inherits="BackOffice.Seccion.Reservas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar Reservas
<%--      de <%=Session["NameRestaurant"]%>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
         
            <li>
                <a href="../Reservas/ListarReservas.aspx">Inicio</a>
            </li>
            <li class="active">Listar Reservas
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

    
     <%--Alertas--%> 
    <div id="SuccessLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>
                <%--La categoría fue agregada <strong>exitosamente!</strong>--%>
                 <asp:Label id="SuccessLabelMessage" runat="server"> 
                </asp:Label>
            </div>
        </div>
    </div>

    <div id="ErrorLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert  alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>
                <%--La categoría <strong>no</strong> pudo ser agregada exitosamente.--%>
                 <asp:Label id="ErrorLabelMessage" runat="server"> 
                </asp:Label>
             </div>
        </div>
    </div>

    <div id="WarningLabel" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-warning fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-exclamation-triangle"></i>
                       <asp:Label id="WarningLabelMessage" runat="server"> 
                </asp:Label>
                <%--El plato ya se encuentra <u>activado</u>.--%>
            </div>
        </div>
    </div>

    
     <%--/Alertas--%>
  
    <%--Tabla Reservas--%> 
      <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-calendar fa-fw"></i>Reservaciones</h3>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:HiddenField ID="HiddenFieldMenuCategoryModifyId" runat="server" Value="" />
                        <asp:Table ID="ReservationsList" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--/Tabla Reservas--%>

        <!-- Modal cancelar estado-->
        <div class="modal fade" id="cancel_reservation" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Cancelar Reservacion</h4>
                            </div>
                                <div class="modal-body">
                                     <div class="row">
                                             <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                                                    <div class="form-group">
                                                        <label class="control-label">¿Desea cancelar la reservacion?</label>
                                                    </div>
                                            </div>    
                                     </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="ButtonCancelReservation" Text="Aceptar" CssClass="btn btn-success" OnClick="ButtonCancelReservation_Click" runat= "server" />                                  
                                    <asp:Button ID="ButtonCancelCancelReservation" Text="Cancelar" CssClass="btn btn-danger"  runat="server" />
                                </div>
                      </div>
                </div>
         </div>









</asp:Content>
