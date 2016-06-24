using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Log;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    class CommandModifyRestaurant : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        Object[] _object;
        int _restaurantO;
        Restaurant _restaurantN;
         

        public CommandModifyRestaurant (object receiver)
            : base (receiver)
        {
            _object = (Object[])receiver;
            _restaurantN = (Restaurant)_object[0];
            _restaurantO = (int)_object[1];

        }
        
        public override void Execute()
        {
            try
            {
                IRestaurantDAO _RestaurantDAO = _facDAO.GetRestaurantDAO();

                Receiver = _RestaurantDAO.ModifyRestaurant(_restaurantO, _restaurantN);

            }
            catch (ModifyRestaurantFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionModifyRestaurant(RestaurantErrors.ModifyRestaurantFondaDAOException, e);
            }
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionModifyRestaurant(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionModifyRestaurant(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionModifyRestaurant(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionModifyRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
            }
        }
    }
}
