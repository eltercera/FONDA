using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.HibernateDAO.Session;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateFactoryDAO : IFactoryDAO
	{
		public HibernateFactoryDAO () { }

		public ICommensalDAO GetCommensalDAO ()
		{
			return new HibernateCommensalDAO ();
		}

		public IProfileDAO GetProfileDAO ()
		{
			return new HibernateProfileDAO ();
		}

		public IUserAccountDAO GetUserAccountDAO ()
		{
			return new HibernateUserAccountDAO ();
		}

		public IPersonDAO GetPersonDao ()
		{
			return new HibernatePersonDAO ();
		}

		public ICompanyDAO GetCompanyDAO()
		{
			return new HibernateCompanyDAO ();
		}

        public IDishOrderDAO GetDishOrderDAO()
        {
            return new HibernateDishOrderDAO();
        }

        public IOrderAccountDao GetOrderAccountDAO()
        {
            return new HibernateOrderAccountDAO();
        }

        public IDishDAO GetDishDAO()
        {
            return new HibernateDishDAO();
        }

        public IMenuCategoryDAO GetMenuCategoryDAO()
        {
            return new HibernateMenuCategoryDAO();
        }

        public IRoleDAO GetRoleDAO()
        {
            return new HibernateRoleDAO();

        }
        public IEmployeeDAO GetEmployeeDAO()
        {
            return new HibernateEmployeeDAO();
        }

        public ITokenDAO GetTokenDAO()
        {
            return new HibernateTokenDAO();
        }

        public IInvoiceDao GetInvoiceDAO()
        {
            return new HibernateInvoiceDAO();
        }

        public ICreditCardPaymentDAO GetCreditCardPaymentDAO()
        {
            return new HibernateCreditCardPaymentDAO();
        }

        public ICashPaymentDAO GetCashPaymentDAO()
        {
            return new HibernateCashPaymentDAO();
        }

        public CanceledInvoiceStatus GetCanceledInvoiceStatusDAO()
        {
            ICanceledInvoiceStatusDAO s = new HibernateCanceledInvoiceStatus();
            return s.getCanceledInvoiceStatus();
        }

        public ICoordinateDAO GetCoordinateDAO()
        {
            return new HibernateCoordinateDAO();
        }

        public ICurrencyDAO GetCurrencyDAO()
        {
            return new HibernateCurrencyDAO();
        }

        public IDayDAO GetDayDAO()
        {
            return new HibernateDayDAO();
        }

        public IRestaurantCategoryDAO GetRestaurantCategoryDAO()
        {
            return new HibernateRestaurantCategoryDAO();
        }

        public IRestaurantDAO GetRestaurantDAO()
        {
            return new HibernateRestaurantDAO();
        }

        public IScheduleDAO GetScheduleDAO()
        {
            return new HibernateScheduleDAO();
        }

        public ITableDAO GetTableDAO()
        {
            return new HibernateTableDAO();
        }

        public IReservationDAO GetReservationDAO()
        {
            return new HibernateReservationDAO();
        }
        public IZoneDAO GetZoneDAO()
        {
            return new HibernateZoneDAO();
        }

        public IPaymentDao<Payment> GetPaymentDAO()
        {
            return new HibernatePaymentDAO<Payment>();
        }


        public ActiveSimpleStatus GetActiveSimpleStatus()
		{
			IActiveSimpleStatusDAO s = new HibernateActiveSimpleStatus ();
			return s.getActiveSimpleStatus ();
		}

        public DisableSimpleStatus GetDisableSimpleStatus()
        {
            IDisableSimpleStatusDAO s = new HibernateDisableSimpleStatus();
            return s.getDisableSimpleStatus();
        }

        public FreeTableStatus GetFreeTableStatus()
        {
            IFreeTableStatusDAO s = new HibernateFreeTableStatus();
            return s.getFreeTableStatus();
        }

        public BusyTableStatus GetBusyTableStatus()
        {
            IBusyTableStatusDAO s = new HibernateBusyTableStatus();
            return s.getBusyTableStatus();
        }
    
        public ActiveReservationStatus GetActiveReservationStatus()
        {
            IActiveReservationStatusDAO s = new HibernateActiveReservationStatus();
            return s.getActiveReservationStatus();
        }

        public CanceledReservationStatus GetCanceledReservationStatus()
        {
            ICanceledReservationStatusDAO s = new HibernateCanceledReservationStatus();
            return s.getCanceledReservationStatus();
        }

        public UsedReservationStatus GetUsedReservationStatus()
        {
            IUsedReservationStatusDAO s = new HibernateUsedReservationStatus();
            return s.getUsedReservationStatus();
        }

		public OpenAccountStatus GetOpenAccountStatus()
        {
            IOpenAccountStatusDAO status = new HibernateOpenAccountStatus();
            return status.getOpenAccountStatus();
        }

        public ClosedAccountStatus GetCloseAccountStatus()
        {
            IClosedAccountStatusDAO status = new HibernateClosedAccountStatus();
            return status.getClosedAccountStatus();
        }
        
        public GeneratedInvoiceStatus GetGeneratedInvoiceStatus()
        {
            IGeneratedInvoiceStatusDAO status = new HibernateGeneratedInvoiceStatus();
            return status.getGeneatedInvoiceStatus();
        }

		public void CloseSession()
		{
			NHibernateSessionManager.CloseSession ();
		}
    }
}


