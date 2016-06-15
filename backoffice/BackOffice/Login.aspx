<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BackOffice.Seccion.Configuracion.WebForm1" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
      <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
      <meta charset="utf-8"/>
      <title>Fonda - Inicio de Sesión</title>
      <meta name="generator" content="Bootply" />
      <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
      <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
      <!--[if lt IE 9]>
      <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
      <![endif]-->
       <link href="Content/css/sb-admin.css" rel="stylesheet"/>
      <link href="Content/css/styleslogin.css" rel="stylesheet" />
   </head>
   <body >
      <!--login-->
      <div class="container">
         <div class="row" id="pwd-container">
            <div class="col-md-4"></div>
            <div class="col-md-4">
               <section class="login-form">
                  <form  method="post" action="#" role="login" id="loginUser" runat="server">
                     <img src="../../Content/img/LogoWeb.png" class="img-responsive" height="242" width="230" alt="" />
                       <div>
                        <h1  class="FONDAtitle">Fonda</h1>
                     </div>

                      <div class="alert alert-danger" id="errorLogin" runat="server">
                       </div>
                       <div class="alert alert-warning" id="warningLog" runat="server">
                       </div>
                      <div class="alert alert-info" id="infoLog" runat="server">
                       </div>
                       <div class="alert alert-success" id="successLog" runat="server">
                       </div>

                     <input type="text" id="userIni" placeholder="Usuario" runat="server" class="form-control input-lg"  />         
                     <input type="password" class="form-control input-lg" id="passwordIni" runat="server"  placeholder="Contraseña" required="" />                    
                     <div class="pwstrength_viewport_progress"></div>
                     <button type="button"  runat="server" id="buttonLogin" name="go" onserverclick="Uservalidate" class="btn btn-lg btn-success btn-block" style="background-color: #643C25;border-color: #000;">Entrar</button>
                     <div>
                        <a data-toggle="modal" data-target="#modalform" href="#" >¿Olvidaste tu contraseña?</a>
                     </div>
                     <div class="modal fade" id="modalform"  tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
                        <div id="modalid" class="modal-dialog">
                           <div class="modal-content" id="ModalCont">
                              <div class="modal-header">
                                 <button type="button" class="close icon-white" id="closeModal" data-dismiss="modal" aria-hidden="true" >&times;</button>
                                 <h3>Restablecer contraseña</h3>
                              </div>
                                  <div class="modal-body">
                                     <p>Introduzca el correo asociado a su cuenta, de no conocerlo contacte a su administrador</p>
                                        <input type="text" name="correo" id="user" runat="server" placeholder="Usuario" 
                                      class="form-control input-lg" value="" />  
                                     <input type="email" name="correo" id="RestablecerCorreo" runat="server" placeholder="Correo" 
                                      class="form-control input-lg" value="" />   
                                            <input type="password" name="correo" id="password1" runat="server" placeholder="Contraseña nueva" 
                                      class="form-control input-lg" value="" />  
                                            <input type="password" name="correo" id="password2" runat="server" placeholder="Repita la contraseña" 
                                      class="form-control input-lg" value="" />        
                                  </div>
                                  <div class="modal-footer">
                                   <button type="button"   runat="server"    data-dismiss="modal" onserverclick="Recoverpassword" class="btn btn-lg btn-success btn-block" style="background-color: #643C25;border-color: #000;"  >Restablecer</button>
                                      
                                 
                                  </div>
                           </div>
                        </div>
                     </div>
                  </form>
                  <div class="form-links">
                     
                        
                         <a>Copyright © 2016 FONDA.</a>
                  </div>
                </section>
            </div>
            <div class="col-md-4"></div>
         </div>
      </div>
      <!-- script references -->
      <script src="../../Content/js/jquery.js"></script>
      <script src="../../Content/js/bootstrap.min.js"></script>
   </body>
</html>
