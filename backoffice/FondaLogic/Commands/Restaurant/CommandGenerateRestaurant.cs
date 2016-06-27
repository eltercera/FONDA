using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.Restaurante
{
    public class CommandGenerateRestaurant : Command
    {
        //Fabrica DAO para el metodo que ejecutara el Execute
        FactoryDAO _facDAO = FactoryDAO.Intance;
        /// <summary>
        /// Lista de objeto que se recibe
        /// y objetos que posee 
        /// </summary>
        /// <param name="receiver"></param>
        Object[] _object;
        string name;
        string logo;
        char nationality;
        string rif;
        string address;
        string category;
        string currency;
        string zone;
        double _long;
        double _lat;
        TimeSpan openingTime;
        TimeSpan closingTime;
        bool[] days;
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGenerateRestaurant(object receiver)
            : base(receiver)
        {
            _object = (Object[])receiver;
            name = (string)_object[0];
            logo = (string)_object[1];
            nationality = (char)_object[2];
            rif = (string)_object[3];
            address = (string)_object[4];
            category = (string)_object[5];
            currency = (string)_object[6];
            zone = (string)_object[7];
            System.Diagnostics.Debug.WriteLine(_long);
            System.Diagnostics.Debug.WriteLine(_lat);
            _long = (double)_object[8];
            _lat = (double)_object[9];
            openingTime = (TimeSpan)_object[10];
            closingTime = (TimeSpan)_object[11];
            days = (bool[])_object[12];
        }
        /// <summary>
        /// Metodo que ejecuta el comando para Generar el Restaurante
        /// </summary>
        public override void Execute()
        {
            try
            {
                IRestaurantDAO _RestaurantDAO = _facDAO.GetRestaurantDAO();

                Receiver = _RestaurantDAO.GenerateRestaurant(name, logo, nationality, rif, address, category, currency, zone, _long, _lat, openingTime, closingTime, days);
            }
            catch(GenerateRestaurantFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGenerateRestaurant(RestaurantErrors.GenerateRestaurantFondaDAOException, e);
            }
            catch (InvalidCastException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGenerateRestaurant(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGenerateRestaurant(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGenerateRestaurant(RestaurantErrors.ClassNameGenerateRestaurant, e);
            }
        }
    }
}
