using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    public class CommandGetRestaurants : Command
    {
        //Fabrica que da el metodo para ejecutar el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetRestaurants(object receiver)
            : base(receiver)
        {

        }

        public override void Execute()
        {
            try
            {
                IRestaurantDAO _RestaurantDAO = _facDAO.GetRestaurantDAO();

                // se ejecuta metodo que me devuelve todos los restaurantes
                Receiver = _RestaurantDAO.GetAll();
            }
            catch (FindAllFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.GetAllRestaurantsFondaDAOException, e);
            }
            catch (GetAllRestaurantsFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.GetAllRestaurantsFondaDAOException, e);
            }
            catch (InvalidCastException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.ClassNameGetAllRestaurants, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRestaurants(RestaurantErrors.ClassNameGetAllRestaurants, e);
            }
        }
    }
}
