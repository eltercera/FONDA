using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Login
{
    // comando que busca restaurante dado un id
    public class CommandGetRestaurantById : Command
    {
        // fabrica que me da el dao que contiene metodo a encapsular en este comando
        FactoryDAO _facDAO = FactoryDAO.Intance;
        // restaurante q contiene id 
        Restaurant _restaurant;
        public CommandGetRestaurantById(Object receiver) : base(receiver)
        {
            try
            {
                _restaurant = (Restaurant)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }
        /// <summary>
        /// metodo que ejecuta el metodo del dao
        /// </summary>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD
                FactoryDAO _facDAO = FactoryDAO.Intance;
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

                //se ejecuta metodo del dao
                Receiver = _restaurantDAO.FindById(_restaurant.Id);
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
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameGetRestaurantId, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(Resources.FondaResources.Login.Errors.ClassNameGetRestaurantId, e);
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
