<%@ Page Title="Modificar Restaurante" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ModificarRest.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Modificar Restaurante
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Modificar Restaurante
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
   <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
          <li>
              <a href="../Default.aspx">Inicio</a>
          </li>
      
          <li>
              <a href="../Default.aspx">Restaurante</a> 
          </li>
          <li class="active">
             Modificar Restaurante
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="Value1" CssClass="form-control" placeholder="ej. El Budare" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <a href="#"><i class="fa fa-plus"></i></a>
                            <asp:DropDownList id="DropDownList3" CssClass="form-control" AutoPostBack="True" runat="server">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Venezolana</asp:ListItem>
                                <asp:ListItem>Americana</asp:ListItem>
                                <asp:ListItem>Japonesa</asp:ListItem>
                                <asp:ListItem>China</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="DropDown" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Disponibilidad</label>
                            <br/>
                                <asp:RadioButton GroupName="Disponibilidad" runat="server" Text="  Activo" />
                                <asp:RadioButton GroupName="Disponibilidad" runat="server" Text="  Inactivo" />    
                        </div>
              </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                            <a href="#"><i class="fa fa-plus"></i></a>
                        <asp:DropDownList id="DropDownList1" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>Altamira</asp:ListItem>
                            <asp:ListItem>Las Mercedes</asp:ListItem>
                            <asp:ListItem>Macaracuay</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Longitud</label>
                            <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="DropDownList4" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>VEF</asp:ListItem>
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                        </div>
     g           </div>
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="DropDownList2" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Apertura</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                                <asp:DropDownList id="DropDownList5" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>            
          </div>
            <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10">
                    <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server"/>
                    <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server"/>
                </div>
            </div>



</asp:Content>