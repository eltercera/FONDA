using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.Log;
using FondaLogic.FondaCommandException;
using com.ds201625.fonda.DataAccess.Exceptions;
using FondaLogic.FondaCommandException.Login;

namespace FondaLogic.Commands.Login
{
    public class CommandGetRestaurantById : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
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
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD
                FactoryDAO _facDAO = FactoryDAO.Intance;
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();


                Receiver = _restaurantDAO.FindById(_restaurant.Id);
            }
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(FondaResources.Login.Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(FondaResources.Login.Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(FondaResources.Login.Errors.ClassNameParameterNotFound, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(FondaResources.Login.Errors.ClassNameGetRestaurantId, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurant(FondaResources.Login.Errors.ClassNameGetRestaurantId, e);
            }
            // Guarda el resultado.
            Object Result = Receiver;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                FondaResources.Login.Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
    }
}
