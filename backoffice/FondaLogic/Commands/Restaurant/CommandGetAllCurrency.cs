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
    public class CommandGetAllCurrency : Command
    {
        //Fabrica que da el metodo para ejecutar el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;


        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllCurrency(object receiver)
            : base(receiver)
        {

        }

        /// <summary>
        /// Metodo para ejecutar el comando para obtener todas las currencies
        /// </summary>
        public override void Execute()
        {
            try
            {
                ICurrencyDAO _CurrencyDAO = _facDAO.GetCurrencyDAO();

                Receiver = _CurrencyDAO.GetAll();
            }
            catch (FindAllFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.GetAllCurrenciesFondaDAOException, e);
            }
            catch (FindByFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.GetAllCurrenciesFondaDAOException, e);
            }
            catch (GetAllCurrenciesFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.GetAllCurrenciesFondaDAOException, e);
            }
            catch (InvalidTypeParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.ClassNameGetAllCurrencies, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllCurrencies(RestaurantErrors.ClassNameGetAllCurrencies, e);
            }

        }
    }
}
