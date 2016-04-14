<%@ Page Title="Modificar Mesa" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ModificarMesa.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.ModificarMesa"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Modificar Mesa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Modificar Mesa
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
              <a href="../Restaurant/MenuRest.aspx">Restaurante</a> 
          </li>
          <li class="active">
             Modificar Mesa
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Cantidad de Puestos</label>
                            <asp:DropDownList id="DropDownList3" CssClass="form-control" AutoPostBack="True" runat="server">
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList> 

                        </div>
                </div>
                      <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Comensales</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" text="4" MaxLength="3" runat="server"/>
                        </div>
                </div>
              </div>
                <div class= "row">
                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                            <div class="form-group">
                                <label class="control-label">Disponibilidad</label>
                                <br/>
                                    <asp:RadioButton GroupName="Disponibilidad" runat="server" Text="  Activo" />
                                    <asp:RadioButton GroupName="Disponibilidad" runat="server" Text="  Inactivo" />    
                            </div>
                  </div>
              </div>
            
          
       </div>

            <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10">
                    <asp:Button id="Button1" Text="Aceptar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server"/>
                    <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server"/>
                </div>
            </div>



</asp:Content>
