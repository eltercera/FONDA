using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Seccion.Configuracion
{
    public class mensajes
    {

        public static string logErr = "Contraseña y/o usuario incorrecto.";//mensae para alertar sobre usuario y/o contrasea incorrecto en el login
        public static string logInfo = "¡Correo enviado!";
        public static string logWarning = "¡El correo no se encuentra registrado en FONDA.!";
        public static string logWarningcamp = "¡El correo o Usuario no se encuentra registrado en FONDA.!";
        public static string logSuccess = "Se reestableció con exito su contraseña";
        public static string logErrcamp = "Debe llenar los campos Contraseña y usuario ";//mensae para alertar sobre llenado de campo
        public static string logErrcampvac= "Debe llenar Todos los campos";//mensae para alertar sobre llenado de campo
        public static string logErrpasword = "No coinciden las contraseñas";//mensae para alertar sobre llenado de campo

        public static string tipoErr = "Error";
        public static string tipoWarning = "Warning";
        public static string tipoInfo = "Info";
        public static string tipoSucess = "Success";
    }
}