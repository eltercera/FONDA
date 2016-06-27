using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    public class CommandAddCategory : Command
    {
        //Fabrica DAO para el metodo que ejecutara el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        //Objeto -nombre de la catgeoria- que recibe el comando
        string name;

        public CommandAddCategory(object receiver)
            : base(receiver)
        {
            name = (string)receiver;
        }
        public override void Execute()
        {
            try
            {
                IRestaurantCategoryDAO _restcatDAO = _facDAO.GetRestaurantCategoryDAO();

                Receiver = _restcatDAO.GetRestaurantCategory(name);
            }
            catch (AddCategoryFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionAddCategory(RestaurantErrors.AddCategoryFondaDAOException, e);
            }
            catch (InvalidCastException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionAddCategory(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionAddCategory(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionAddCategory(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionAddCategory(RestaurantErrors.ClassNameAddCategory, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionAddCategory(RestaurantErrors.ClassNameAddCategory, e);
            }
        }
    }
}