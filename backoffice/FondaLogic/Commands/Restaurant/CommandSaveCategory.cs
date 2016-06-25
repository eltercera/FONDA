using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
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
    class CommandSaveCategory : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        RestaurantCategory _restCategory;

        public CommandSaveCategory(Object receiver) : base(receiver)
        {
            try
            {
                _restCategory = (RestaurantCategory)receiver;
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
                //defino los dao

                IRestaurantCategoryDAO _restCategoryDAO = _facDAO.GetRestaurantCategoryDAO();

                //ejecuto el metodo del dao
                _restCategoryDAO.Save(_restCategory);

            }
            catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveCategory(RestaurantErrors.SaveEntityCategoryFondaDAOException, e);
            }
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveCategory(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveCategory(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveCategory(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveCategory(RestaurantErrors.ClassNameSaveCategory, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionSaveCategory(RestaurantErrors.ClassNameSaveCategory, e);
            }

            System.Diagnostics.Debug.WriteLine("entro al execute de save category");
            RestaurantCategory Result = _restCategory;
        }
    }
}
