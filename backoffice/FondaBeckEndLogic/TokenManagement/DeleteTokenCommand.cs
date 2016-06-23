using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FondaBeckEndLogic;

namespace com.ds201625.fonda.BackEndLogic.TokenManagement
{
    /// <summary>
    /// Comando para Eliminar Token
    /// </summary>
    public class DeleteTokenCommand : BaseCommand
    {
        /// <summary>
        /// constructor DeleteTokenCommand
        /// </summary>
        public DeleteTokenCommand() : base() { }
        /// <summary>
        /// Metodo para inicializar los parametros
        /// </summary>
        /// <returns>Un arreglo con los parametros Commensal y Token </returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 2 Parametro
            Parameter[] paramters = new Parameter[2];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);
            // [1] El Token
            paramters[1] = new Parameter(typeof(Token), true);

            return paramters;
        }

        /// <summary>
        /// Metodo Invoke para la ejecucion del 
        /// eliminar un Token
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                // Obtencion de parametros
                Commensal commensal = (Commensal)GetParameter(0);
                Token token = (Token)GetParameter(1);

                // Obtiene el dao CommensalDAO
                ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

                //Remueve el token del comensal
                commensal.RemoveToken(token);
                //Actualizacion de los cambios
                commensalDAO.Save(commensal);
                //Logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 ResourceMessages.Token + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteTokenCommandException(ResourceMessages.DeleteTokenException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteTokenCommandException(ResourceMessages.DeleteTokenException, e);
            }

            //Logger al Culminar el metodo
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, "",
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
    }
}
