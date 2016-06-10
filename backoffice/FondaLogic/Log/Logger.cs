using FondaLogic.FondaCommandException;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Log
{
    public class Logger
    {

        public Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Escribir en Log en caso de Error
        /// </summary>
        /// <param name="ex">Excepcion arrojada</param>
        public static void WriteErrorLog(CommandException e)
        {
            ILog Log = LogManager.GetLogger(e.ClassName);

            Log.Error(string.Format("======= Codigo de Error: {0} =======", e.Id));
            Log.Error(string.Format("Clase que arroja el error: {0}", e.ClassName));
            Log.Error(string.Format("Metodo que arroja el error: {0}", e.Method));
            Log.Error(string.Format("Informacion del error: {0}", e.Message));
            Log.Error(string.Format("Detalles del error: {0}, {1}", e.Ex.StackTrace, e.Ex.InnerException));
        }

        /// <summary>
        /// Escribir en Log en caso de Exito
        /// </summary>
        /// <param name="ex">Mensaje de exito</param>
        public static void WriteSuccessLog(string message)
        {
            ILog Log = LogManager.GetLogger(message);

            Log.Error(string.Format("[ Operacion exitosa: {0} ]", message));

        }

    }
}
