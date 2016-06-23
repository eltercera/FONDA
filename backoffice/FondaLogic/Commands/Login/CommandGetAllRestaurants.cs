using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Login
{
    public class CommandGetAllRestaurants : Command
    {
        //fabrica de dao que me dara el metodo que se ejecuatara en el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        /// <summary>
        /// constructor de comando, no recibe nada
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllRestaurants(Object receiver) : base(receiver)
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para buscar todos los restaurantes del sistema
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IRestaurantDAO _RestaurantDAO = _facDAO.GetRestaurantDAO();

                // se ejecuta metodo que me devuelve todos los restaurantes
                Receiver = _RestaurantDAO.GetAll();
            }
            // se capturan excepciones que pueden ser generadas en la capa de acceso a datos
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameGetRestaurantAll, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameGetRestaurantAll, e);
            }
            // Guarda el resultado.
            Object Result = Receiver;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resources.FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
