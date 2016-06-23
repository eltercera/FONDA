using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.Login
{
    class mensajes
    {
        public static string logErr = "Contraseña y/o usuario incorrecto.";//mensae para alertar sobre usuario y/o contrasea incorrecto en el login
        public static string logInfo = "Se reestableció con exito su contraseña";//mensaje para indicar al usuario que se restablecio su contraseña
        public static string logWarning = "¡El correo no se encuentra registrado en FONDA.!";//mensaje para indicar que el correo no so encuentra registrado
        public static string logWarningcamp = "¡El correo o Usuario no se encuentra registrado en FONDA.!";//mensaje para incar que el correo no se encuentra registrado
        public static string logSuccess = "Se reestableció con exito su contraseña";//mensaje para indicar que se restablecio con exito su contraseña
        public static string logErrcamp = "Debe llenar los campos Contraseña y/o usuario ";//mensae para alertar sobre llenado de campo
        public static string logErrcampvac = "Debe llenar Todos los campos";//mensae para alertar sobre llenado de campo
        public static string logErrpasword = "No coinciden las contraseñas";//mensae para alertar sobre las contraseñas no coinciden
        public static string logState = "Usuario en estado inactivo";//mensaje para aletar sobre usuario inactivo
        public static string loguserInvalid = "Formato Inválido en usuario! Sólo Alfanumérico y sin espacios";
        public static string logpassInvalid = "Formato Inválido en password! Sólo Alfanumérico y sin espacios";
        public static string logemailInvalid = "Formato Inválido en email! Sólo Alfanumérico y sin espacios";
        //Tipo de mensajes que pueden ser desplegado
        public static string tipoErr = "Error";
        public static string tipoWarning = "Warning";
        public static string tipoInfo = "Info";
        public static string tipoSucess = "Success";
        public static string tipoState = "State";
        public static string tipoUserInvalid = "userInvalid";
        public static string tipoPasswordInvalid = "passwodInvalid";
        public static string tipoEmailInvalidad = "emailInvalid";
    }
}
