using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.FactoryDAO
{
	public interface IFactoryDAO
	{
		ICommensalDAO GetCommensalDAO ();
		IProfileDAO GetProfileDAO ();
		IUserAccountDAO GetUserAccountDAO ();
		IPersonDAO GetPersonDao ();
		ICompanyDAO GetCompanyDAO();
		IStatusDAO GetStatusDAO();
        IOrderAccountDao GetOrderAccountDAO();
        IDishOrderDAO GetDishOrderDAO();
        IDishDAO GetDishDAO();
        IMenuCategoryDAO GetMenuCategoryDAO();
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

    }
}

