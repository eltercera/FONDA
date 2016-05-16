<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="ModificarCategoria.aspx.cs" Inherits="BackOffice.Seccion.Menu.ModificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Modificar Categoría
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Categorías
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Categoría 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
     <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="../Menu/Default.aspx">Menú</a>
            </li>
            <li class="active">Modificar Categoría
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
     <div class="row">
          <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
              <div class="form-group">
                  <label class="control-label">Nombre de la Categoria del menú</label>
                  <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="" MaxLength="20"  runat="server" />
              </div>
              <div class="form-group">
                  <asp:Button ID="Button1" Text="Modificar" CssClass="btn btn-success" OnClick="BotonModificarCategoria_Click" runat="server" />
                  <asp:Button ID="Button2" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
              </div>
          </div>
     </div>
    
         
   
</asp:Content>