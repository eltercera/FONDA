using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.FactoryDAO
{
	public interface IFactoryDAO
	{
		ICommensalDAO GetCommensalDAO ();
		IProfileDAO GetProfileDAO ();
		IUserAccountDAO GetUserAccountDAO ();
		IPersonDAO GetPersonDao ();
		ICompanyDAO GetCompanyDAO();
        IOrderAccountDao GetOrderAccountDAO();
        IDishOrderDAO GetDishOrderDAO();
        IDishDAO GetDishDAO();
        IMenuCategoryDAO GetMenuCategoryDAO();
        IRoleDAO GetRoleDAO();
        IEmployeeDAO GetEmployeeDAO();
        ITokenDAO GetTokenDAO();
        ActiveSimpleStatus GetActiveSimpleStatus();
        DisableSimpleStatus GetDisableSimpleStatus();
        FreeTableStatus GetFreeTableStatus();
        BusyTableStatus GetBusyTableStatus();
        CanceledReservationStatus GetCanceledReservationStatus();
        ReservedReservationStatus GetReservedReservationStatus();
        IInvoiceDao GetInvoiceDAO();
        ICreditCardPaymentDAO GetCreditCardPaymentDAO();
        ICashPaymentDAO GetCashPaymentDAO();
        ICoordinateDAO GetCoordinateDAO();
        ICurrencyDAO GetCurrencyDAO();
        IDayDAO GetDayDAO();
        IRestaurantCategoryDAO GetRestaurantCategoryDAO();
        IRestaurantDAO GetRestaurantDAO();
        IScheduleDAO GetScheduleDAO();
        ITableDAO GetTableDAO();
        IZoneDAO GetZoneDAO();
        IReservationDAO GetReservationDAO();
        OpenAccountStatus GetOpenAccountStatus();
        ClosedAccountStatus GetCloseAccountStatus();
        GeneratedInvoiceStatus GetGeneratedInvoiceStatus();

		void CloseSession ();
    }
}

