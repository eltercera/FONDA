using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.Restaurante
{
    public class CommandGetAllCategories : Command
    {
        //Fabrica que me dara el metodo que utilizara el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllCategories()
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para obtener todas las categorias
        /// </summary>
        public override void Execute()
        {
            try
            {
                IRestaurantCategoryDAO _categoryDAO = _facDAO.GetRestaurantCategoryDAO();

                Receiver = _categoryDAO.GetAll();
            }
            catch (FindAllFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.GetAllCategoriesFondaDAOException, e);
            }
            catch (GetAllCategoriesFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.GetAllCategoriesFondaDAOException, e);
            }
            catch (InvalidCastException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ClassNameGetAllCategories, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCategories(RestaurantErrors.ClassNameGetAllCategories, e);
            }
        }
    }
}
