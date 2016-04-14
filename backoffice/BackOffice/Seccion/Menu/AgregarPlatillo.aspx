<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="AgregarPlato.aspx.cs" Inherits="BackOffice.Seccion.Menu.AgregarPlato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar Platillo
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
            <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>
        
            <li>
                <a href="../Menu/Default.aspx">Menú</a> 
            </li>
            <li class="active">
                Agregar Platillo
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>

    </asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
    
     <div class="row m-b-3">

        <div class="row">
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-8">

                <div id="exitoFormulario" class="alert alert-success alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    Plato agregado con <strong>EXITO</strong>!
                </div>
                <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    El Platillo <strong>NO SE HA PODIDO AGREGAR!</strong>
                </div>
            </div>
        </div>
           <div class="invisible">...</div>
           <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
     
                        <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                                                         <label>Selecciona la categoría</label>
                                <select class="form-control" >
                                    <option>Pastas</option>
                                    <option>Carnes</option>
                                    <option>Pescados y Mariscos</option>
                                </select>


                        </div>
                 </div>
                 </div>

                 <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre del platillo</label>
                            <asp:TextBox ID="nombrePlato" CssClass="form-control" placeholder="ej. pasta carbonara" runat="server"/>
                        </div>
                 </div>
                 </div>
     
                     <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Descripcion del platillo</label>
                            <asp:TextBox ID="descripcionPlato" CssClass="form-control" placeholder="ej. pasta con tocineta y queso parmesano" runat="server"/>
                        </div>
                 </div>
                 </div>

                <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Precio del platillo</label>
                            <asp:TextBox ID="precioPlato" CssClass="form-control" placeholder="ej. 1000" MaxLength="5" runat="server"/>
                        </div>
                </div>
            </div>

               
  <div class="form-group">
    <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
    <input type="file" id="ejemplo_archivo_1"/>
    <p class="help-block">Imagen .jpg o .png</p>
  </div>

             <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10 ">
                    <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click"/>
                    <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click"/>
                </div>
          </div>
</div>
 

</asp:Content>