using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.HibernateDAO;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.FactoryDAO
{
	public class FactoryDAO
	{
		private static FactoryDAO _intance;

		private IFactoryDAO _factory;

		private FactoryDAO ()
		{
			_factory = new HibernateFactoryDAO();
		}

		public static FactoryDAO Intance
		{
			get {
				if (_intance == null)
					_intance = new FactoryDAO ();
				
				return _intance;
			}
		}

		public ICommensalDAO GetCommensalDAO ()
		{
			return _factory.GetCommensalDAO();
		}

		public IProfileDAO GetProfileDAO ()
		{
			return _factory.GetProfileDAO ();
		}

		public IUserAccountDAO GetUserAccountDAO ()
		{
			return _factory.GetUserAccountDAO ();
		}

        public IEmployeeDAO GetEmployeeDAO()
        {
            return _factory.GetEmployeeDAO();
        }

        public IPersonDAO GetPersonDao ()
		{
			return _factory.GetPersonDao ();
		}

		public ICompanyDAO GetCompanyDAO()
		{
			return _factory.GetCompanyDAO ();
		}

        public IOrderAccountDao GetOrderAccountDAO()
        {
            return _factory.GetOrderAccountDAO();
        }

        public IDishOrderDAO GetDishOrderDAO()
        {
            return _factory.GetDishOrderDAO();
        }

        public IDishDAO GetDishDAO()
        {
            return _factory.GetDishDAO();
        }

        public IMenuCategoryDAO GetMenuCategoryDAO()
        {
            return _factory.GetMenuCategoryDAO();
        }

        public IInvoiceDao GetInvoiceDao()
        {
            return _factory.GetInvoiceDAO();
        }

        public ICashPaymentDAO GetCashPaymentDAO()
        {
            return _factory.GetCashPaymentDAO();
        }

        public CanceledInvoiceStatus GetCancelInvoiceStatusDAO()
        {
            return _factory.GetCanceledInvoiceStatusDAO();
        }

        public ICreditCardPaymentDAO GetCreditCardPaymentDAO()
        {
            return _factory.GetCreditCardPaymentDAO();
        }

        public ICoordinateDAO GetCoordinateDAO()
        {
            return _factory.GetCoordinateDAO();
        }

        public ICurrencyDAO GetCurrencyDAO()
        {
            return _factory.GetCurrencyDAO();
        }

        public IDayDAO GetDayDAO()
        {
            return _factory.GetDayDAO();
        }

        public IRestaurantCategoryDAO GetRestaurantCategoryDAO()
        {
            return _factory.GetRestaurantCategoryDAO();
        }

        public IRestaurantDAO GetRestaurantDAO()
        {
            return _factory.GetRestaurantDAO();
        }

        public IScheduleDAO GetScheduleDAO()
        {
            return _factory.GetScheduleDAO();
        }

        public ITableDAO GetTableDAO()
        {
            return _factory.GetTableDAO();
        }

        public IZoneDAO GetZoneDAO()
        {
            return _factory.GetZoneDAO();
        }

        public ITokenDAO GetTokenDAO()
        {
            return _factory.GetTokenDAO();
        }

        public IRoleDAO GetRoleDAO()
        {
            return _factory.GetRoleDAO();
        }

        public IReservationDAO GetReservationDAO()
        {
            return _factory.GetReservationDAO();
        }

        public ReservedReservationStatus GetReservedReservationStatus()
        {
            return _factory.GetReservedReservationStatus();
        }

        public IPaymentDao<Payment> GetPaymentDAO()
        {
            return _factory.GetPaymentDAO();
        }

        public ActiveSimpleStatus GetActiveSimpleStatus()
        {
            return _factory.GetActiveSimpleStatus();
        }

        public DisableSimpleStatus GetDisabledSimpleStatus()
        {
            return _factory.GetDisableSimpleStatus();
        }

        public FreeTableStatus GetFreeTableStatus()
        {
            return _factory.GetFreeTableStatus();
        }

        public BusyTableStatus GetBusyTableStatus()
        {
            return _factory.GetBusyTableStatus();
        }
     
        public CanceledReservationStatus GetCanceledReservationStatus()
        {
            return _factory.GetCanceledReservationStatus();
        }  
		
		public OpenAccountStatus GetOpenAccountStatus()
        {
            return _factory.GetOpenAccountStatus();
        }

        public ClosedAccountStatus GetClosedAccountStatus()
        {
            return _factory.GetCloseAccountStatus();
        }

        public GeneratedInvoiceStatus GetGeneratedInvoiceStatus()
        {
            return _factory.GetGeneratedInvoiceStatus();
        }

		public void closeSession()
		{
			_factory.CloseSession ();
		}
    }
}

