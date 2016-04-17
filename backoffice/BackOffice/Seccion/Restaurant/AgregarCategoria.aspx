<%@ Page Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Agregar Categoria
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Agregar Categoria
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
             Agregar Categoria
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Categoria</label>
                      <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. Japonesa" MaxLength="3" runat="server"/>

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


