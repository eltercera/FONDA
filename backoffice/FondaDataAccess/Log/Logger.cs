﻿using log4net;
using System;

namespace com.ds201625.fonda.DataAccess.Log
{
    public class Logger
    {
        public Logger()
        {

            log4net.Config.XmlConfigurator.Configure();

        }

        /// <summary>
        /// Escribir log de error 
        /// </summary>
        /// <param name="classe"></param>
        /// <param name="e"></param>
        public static void WriteErrorLog(string classe, Exception e)
        {
            ILog Log = LogManager.GetLogger(classe);

            Log.Error(string.Format("======= Mensaje de Error: {0} =======", e.Message));
            Log.Error(string.Format("Clase que arroja el error: {0}", classe));
            Log.Error(string.Format("Metodo que arroja el error: {0}", e.TargetSite));
            Log.Error(string.Format("Informacion del error: {0}", e.Message));
            Log.Error(string.Format("Detalles del error: {0}, {1}", e.StackTrace, e.InnerException));


        }

        /// <summary>
        /// Escribir log en ejecución 
        /// </summary>
        /// <param name="classe"></param>
        /// <param name="message"></param>
        /// <param name="method"></param>
        public static void WriteSuccessLog(string classe, string message, string method)
        {
            ILog log = LogManager.GetLogger(classe);
            log.Debug("Clase: " + classe);
            log.Debug("Mensaje: " + message);
            log.Debug("Metodo: " + method);

        }
    }
}
