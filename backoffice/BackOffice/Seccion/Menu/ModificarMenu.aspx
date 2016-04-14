<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master"  CodeBehind="ModificarMenu.aspx.cs" Inherits="BackOffice.Seccion.Menu.ModificarMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Categoria del menú
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
              Modificar Categoria del menú
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
                    Categoria del menú modificado con <strong>EXITO</strong>!
                </div>
                <div id="alertaFormulario" class="alert alert-danger alert-dismissable col-lg-12 col-md-10 col-sm-10 col-xs-10 col-lg-offset-1 col-md-offset-4 col-sm-offset-4 col-xs-offset-4" runat="server">
                    La Categoria del menú <strong>NO HA PODIDO SER MODIFICADO!</strong>
                </div>
            </div>
        </div>
        <div class="invisible">...</div>
        <div class="row col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
           
            <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Elija la categoria que desea modificar</label>
                             <select class="form-control" name="menu" id="option">

                                <option value="">Pastas</option>

			                </select>
                       </div>
                </div>
            </div>

           
            <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre de la Categoria del menú</label>
                            <asp:TextBox ID="Value1" CssClass="form-control" placeholder="Pastas" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>

              <div class="row">
                 <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Estatus</label>
                             <select class="form-control" name="menu" id="Select1">

                                <option value="">Activo</option>
                                <option value="">Inactivo</option>

			                </select>
                       </div>
                </div>
            </div>

            <!-- /.row -->
    <div class="row">
        <div class="col-lg-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-shopping-basket fa-fw"></i> Menú</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Plato</th>
                                    <th>Agregar o quitar plato del menu</th>
               
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Pasta a la Carbonara</td>
                                    <td>
                                       <select class="form-control" name="menu" id="Select2">
                                             <option value="">Agregar</option>
                                             <option value="">Quitar</option>
			                            </select>    
                                    </td>
                                </tr>
                                <tr>
                                    <td>Pasta Napole</td>
                                    <td>
                                       <select class="form-control" name="menu" id="Select3">
                                             <option value="">Agregar</option>
                                             <option value="">Quitar</option>
			                            </select>    
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Pasta 4 quesos</td>
                                    <td>
                                       <select class="form-control" name="menu" id="Select4">
                                             <option value="">Agregar</option>
                                             <option value="">Quitar</option>
			                            </select>    
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>Pasta al pesto</td>
                                    <td>
                                       <select class="form-control" name="menu" id="Select5">
                                             <option value="">Agregar</option>
                                             <option value="">Quitar</option>
			                            </select>    
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>Pasta marinera</td>
                                    <td>
                                       <select class="form-control" name="menu" id="Select6">
                                             <option value="">Agregar</option>
                                             <option value="">Quitar</option>
			                            </select>    
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Ñoquis</td>
                                    <td>
                                       <select class="form-control" name="menu" id="Select7">
                                             <option value="">Agregar</option>
                                             <option value="">Quitar</option>
			                            </select>    
                                    </td>
                                    
                                </tr>
                            </tbody>
                        </table>
                      
                    </div>
                </div>
            </div>
        </div>
    </div>

             
            
             <div class="row col-lg-offset-8 col-md-offset-1 col-sm-offset-1 col-xs-offset-1">
                <div class="col-md-10 col-sm-10 col-xs-10 ">
                    <asp:Button id="Button1" Text="Aceptar" CssClass="btn btn-success col-md-5 col-sm-5 col-xs-5 m-r-1" runat="server" OnClick="Button1_Click"/>
                    <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger col-md-5 col-sm-5 col-xs-5" runat="server" OnClick="Button2_Click"/>
                </div>
            </div>

           
        
      

    </div>


</asp:Content>