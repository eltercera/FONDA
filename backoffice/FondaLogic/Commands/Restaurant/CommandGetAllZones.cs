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
    public class CommandGetAllZones : Command
    {
        //Fabrica que dara el metodo para el execute
        FactoryDAO _facDAO = FactoryDAO.Intance;

        /// <summary>
        /// Constructor del metodo
        /// </summary>
        /// <param name="receiver"></param>
        public CommandGetAllZones()
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para obtener todas las zonas
        /// </summary>
        public override void Execute()
        {
            try
            {
                IZoneDAO _zoneDAO = _facDAO.GetZoneDAO();

                Receiver = _zoneDAO.allZone();
            }
            catch (FindAllFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.GetAllZonesFondaDAOException, e);
            }
            catch (FindByFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.GetAllZonesFondaDAOException, e);
            }
            catch (GetAllZonesFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.GetAllZonesFondaDAOException, e);
            }
            catch (InvalidCastException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.InvalidTypeParameterException, e);
            }
            catch (ParameterIndexOutRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.ParameterIndexOutRangeException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.RequieredParameterNotFoundException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.ClassNameGetAllZones, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetAllZones(RestaurantErrors.ClassNameGetAllZones, e);
            }
        }
    }
}
