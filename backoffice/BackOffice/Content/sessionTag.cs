using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BackOffice.Content
{
    public  class sessionTag
    {

        public static string rol = "Sistema";///Rol del usuario
        public static string roles = "Sistema";///Roles que puede tener un usuario 
        public static string usuarioN = "Jose";///Nombre del usuario
        public static string usuarioA = "Garcia";///Apellido del usuario
        public static string usuarioC = "fonda@gmail.com";///Correo del usuario
                                 
        ///Tags asociados a las etiquetas XML
        public static string nameTag = "nombre";
        public static string linkTag = "link";
        public static string imgTag = "img";
        public static string rolTag = "rol";
    }
}