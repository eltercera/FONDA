using com.ds201625.fonda;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.Commands.Login;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using System.Collections.Generic;
using com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations;
using System;

namespace com.ds201625.fonda.Logic.FondaLogic.Factory
{
    /// <summary>
    /// Fabrica que genera los comandos del sistema
    /// </summary>
    public class CommandFactory
    {

        #region Logger

        /// <summary>
        /// Inicializa el Logger de la aplicacion
        /// </summary>
        public static void InitLog()
        {
            new Logger();
        }

        #endregion

        #region OrderAccount

        //Se obtienen los comandos a a utilizar

        /// <summary>
        /// Metodo de la fabrica para el Comando CancelInvoice
        /// </summary>
        /// <param name="entity">Lista de ints (invoiceId, accountId)</param>
        /// <returns>comando CancelInvoice</returns>
        public static Command GetCommandCancelInvoiced(object receiver)
        {
            return new CommandCancelInvoice(receiver);
        }

        //Se obtienen los comandos a a utilizar

        /// <summary>
        /// Metodo de la fabrica para el Comando ReleaseTableByRestaurant
        /// </summary>
        /// <param name="entity">Lista de objetos (Restaurante, tableId)</param>
        /// <returns>comando ReleaseTableByRestaurant</returns>
        public static Command GetCommandGetDishOrdersByAccountId(object receiver)
        {
            return new CommandGetDishOrdersByAccountId(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando ReleaseTableByRestaurant
        /// </summary>
        /// <param name="entity">Lista de objetos (Restaurante, tableId)</param>
        /// <returns>comando ReleaseTableByRestaurant</returns>
        public static Command GetCommandReleaseTableByRestaurant(object receiver)
        {
            return new CommandReleaseTableByRestaurant(receiver);
        }

        //Se obtienen los comandos a a utilizar

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandFindInvoicesByRestaurant
        /// </summary>
        /// <param name="entity">Id del Restaurante</param>
        /// <returns>comando CommandGetOrders</returns>
        public static Command GetCommandFindInvoicesByRestaurant(object receiver)
        {
            return new CommandFindInvoicesByRestaurant(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando FindInvoices
        /// </summary>
        /// <param name="entity">Id Account</param>
        /// <returns>comando CommandFindInvoices</returns>
        public static Command GetCommandTotalOrder(object receiver)
        {
            return new CommandTotalOrder(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando FindInvoices
        /// </summary>
        /// <param name="entity">Id Account</param>
        /// <returns>comando CommandFindInvoices</returns>
        public static Command GetCommandFindInvoicesByAccount(object receiver)
        {
            return new CommandFindInvoicesByAccount(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandPrintInvoice
        /// </summary>
        /// <param name="entity">Id del Restaurante</param>
        /// <returns>comando CommandGetOrders</returns>
        public static Command GetCommandPrintInvoice(object receiver)
        {
            return new CommandPrintInvoice(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetOrders
        /// </summary>
        /// <param name="entity">Id del Restaurante</param>
        /// <returns>comando CommandGetOrders</returns>
        public static Command GetCommandGetOrders(object receiver)
        {
            return new CommandGetOrders(receiver);
        }


        /// <summary>
        /// Metodo de la fabrica para el ComandoGetOrder
        /// </summary>
        /// <param name="receiver">Id de la orden</param>
        /// <returns>comando CommandGetOrder</returns>
        public static Command GetCommandGetOrder(object receiver)
        {
            return new CommandGetOrder(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el ComandoClosedOrders
        /// </summary>
        /// <param name="receiver">Id del restaurant</param>
        /// <returns>comando CommandClosedOrders</returns>
        public static Command GetCommandClosedOrders(object receiver)
        {
            return new CommandClosedOrders(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el CommandGetDishOrdersByAccountId
        /// </summary>
        /// <param name="receiver">Id Orden</param>
        /// <returns>List DishOrder</returns>
        /// 
        public static Command GetDetailOrder(object receiver)
        {
            return new CommandGetDishOrdersByAccountId(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el CommmandGetDetailOrder
        /// </summary>
        /// <param name="receiver">Parametros, Id Orden, Id Restaurante</param>
        /// <returns>List DishOrder, Account, Currency</returns>
        /// 
        public static Command GetCommandGetDetailOrder(object receiver)
        {
            return new CommandGetDetailOrder(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el CommmandGetDetailInvoice
        /// </summary>
        /// <param name="receiver">Parametros, Id Orden, Id Invoice</param>
        /// <returns>List DishOrder, Account, Currency</returns>
        /// 
        public static Command GetCommandGetDetailInvoice(object receiver)
        {
            return new CommandGetDetailInvoice(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el CommmandGetInvoice
        /// </summary>
        /// <param name="receiver">Id de la factura</param>
        /// <returns>comando CommandGetInvoice</returns>
        /// 
        public static Command GetCommandGetInvoice(object receiver)
        {
            return new CommandGetInvoice(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el CCommandGenerateException
        /// </summary>
        public static Command GetCommandGenerateException(object receiver)
        {
            return new CommandGenerateException(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el CommandCloseCashRegister
        /// </summary>
        /// <param name="receiver">Id del Restaurante</param>
        public static Command GetCommandCloseCashRegister(object receiver)
        {
            return new CommandCloseCashRegister(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el CommandGetCurrency
        /// </summary>
        /// <param name="receiver">Id del Restaurante</param>
        public static Command GetCommandGetCurrency(object receiver)
        {
            return new CommandGetCurrencyByRestaurantId(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el CommandGetCurrencyInvoice
        /// </summary>
        /// <param name="receiver">Id del Invoice</param>
        public static Command GetCommandGetCurrencyInvoice(object receiver)
        {
            return new CommandGetCurrencyInvoice(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetInvoice
        /// </summary>
        /// <param name="entity">Invoice</param>
        /// <returns>comando CommandGetOrders</returns>
        public static Command GetCommandGenerateInvoice(object receiver)
        {
            return new CommandGenerateInvoice(receiver);
        }
       


        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetInvoicesByProfile
        /// </summary>
        /// <param name="receiver">Profile</param>
        /// <returns>comando CommandGetInvoicesByProfile</returns>
        public static Command GetCommandGetInvoicesByProfile(object receiver)
        {
            return new CommandGetInvoicesByProfile(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandValidateProfileByCommensal
        /// </summary>
        /// <param name="receiver">Id del Profile</param>
        /// <param name="receiver">Commensal</param>
        /// <returns>comando CommandValidateProfileByCommensal</returns>
        public static Command GetCommandValidateProfileByCommensal(object receiver)
        {
            return new CommandValidateProfileByCommensal(receiver);
        }

        public static Command GetCommandGetPaymentHistoryByProfile(object receiver)
        {
            return new CommandGetPaymentHistoryByProfile(receiver);
        }

        public static Command GetCommandPayOrder(object receiver)
        {
            return new CommandPayOrder(receiver);
        }

        #endregion

        #region Restaurant

        //Defincion de los comandos a implementar del modulo Restaurante

        #endregion

        #region Menu

        //Defincion de los comandos a implementar del modulo Menu

        #endregion

        #region Login

        //Defincion de los comandos a implementar del modulo Login
        /// <summary>
        /// Metodo de la fabrica para el Comando GetCommandGetEmployeeByUser
        /// </summary>
        /// <param name="receiver">usuario del empleado a buscar</param>
        /// <returns>comando CommandGetEmployeeByUser</returns>
        public static Command GetCommandGetEmployeeByUser(object receiver)
        {
            return new CommandGetEmployeeByUser(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comand GetCommandGetRestaurantById
        /// </summary>
        /// <param name="receiver">id del restaurant a buscar</param>
        /// <returns>comando GetCommandGetRestaurantById</returns>
        public static Command GetCommandGetRestaurantById(object receiver)
        {
            return new CommandGetRestaurantById(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando GetCommandSaveEmployee
        /// </summary>
        /// <param name="receiver">emplado que se quiere guardar en la bd</param>
        /// <returns>Comando GetCommandSaveEmployee</returns>
        public static Command GetCommandSaveEmployee(object receiver)
        {
            return new CommandSaveEmployee(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando GetCommandGetAllRoles
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns>comando GetCommandGetAllRoles</returns>
        public static Command GetCommandGetAllRoles(object receiver)
        {
            return new CommandGetAllRoles(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetAllRestaurants
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns>comando CommandGetAllRestaurants</returns>
        public static Command GetCommandGetAllRestaurants(object receiver)
        {
            return new CommandGetAllRestaurants(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando GetCommandGetEmployeeById
        /// </summary>
        /// <param name="receiver">id del empleado a buscar</param>
        /// <returns>comando GetCommandGetEmployeeById</returns>
        public static Command GetCommandGetEmployeeById(object receiver)
        {
            return new CommandGetEmployeeById(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando GetCommandGetAllEmployee
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns>comando GetCommandGetAllEmployee</returns>
        public static Command GetCommandGetAllEmployee(object receiver)
        {
            return new CommanGetAllEmployee(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el Comando GetComandoGetUserAcountByEmail
        /// </summary>
        /// <param name="receiver">email del usuario a buscar</param>
        /// <returns>comando GetComandoGetUserAcountByEmail</returns>
        public static Command GetComandoGetUserAcountByEmail(object receiver)
        {
            return new ComandoGetUserAcountByEmail(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el comando GetComandGetEmployeeBySsn
        /// </summary>
        /// <param name="receiver">Ssn del empleado a buscar </param>
        /// <returns>comando GetComandGetEmployeeBySsn</returns>
        public static Command GetComandGetEmployeeBySsn(object receiver)
        {
            return new ComandGetEmployeeBySsn(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el comando GetCommandSaveEntity 
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns>comando GetCommandSaveEntity</returns>
        public static Command GetCommandSaveEntity(object receiver)
        {
            return new CommandSaveEntity(receiver);
        }
        /// <summary>
        /// Metodo de la fabrica para el comando CommandGetRolById
        /// </summary>
        /// <param name="receiver">id del rol a buscar</param>
        /// <returns>comando CommandGetRolById</returns>
        public static Command CommandGetRolById(object receiver)
        {
            return new CommandGetRolById(receiver);
        }

        #endregion

        #region Reservation

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandFindRestaurantById
        /// </summary>
        /// <param name="receiver">Id del Restaurante</param>
        /// <returns>comando CommandFindRestaurantById</returns>
        public static Command GetCommandFindRestaurantById(object receiver)
        {
            return new CommandFindRestaurantById(receiver);
        }


        /// <summary>
        /// Metodo de la fabrica para el Comando CommandFindReservationsByRestaurant
        /// </summary>
        /// <param name="receiver">Id del Restaurante</param>
        /// <returns>comando CommandFindReservationsByRestaurant</returns>
        public static Command GetCommandFindReservationsByRestaurant(object receiver)
        {
            return new CommandFindReservationsByRestaurant(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetTables
        /// </summary>
        /// <param name="receiver">Id del Restaurante</param>
        /// <returns>comando CommandGetTables</returns>
        public static Command GetCommandGetTables(object receiver)
        {
            return new CommandGetTables(receiver);
        }


        /// <summary>
        /// Metodo de la fabrica para el Comando CommandFindReservationsByTable
        /// </summary>
        /// <param name="receiver">Id de la tabla</param>
        /// <returns>comando CommandFindReservationsByTable</returns>
        public static Command GetCommandFindReservationsByTable(object receiver)
        {
            return new CommandFindReservationsByTable(receiver);
        }

        #endregion

    }
}
