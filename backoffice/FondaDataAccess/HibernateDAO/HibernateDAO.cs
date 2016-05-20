using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
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
			return new HibernateTokenDAO ();
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


		public ActiveSimpleStatus GetActiveSimpleStatus()
		{
			IActiveSimpleStatusDAO s = new HibernateActiveSimpleStatus ();
			return s.getActiveSimpleStatus ();
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
    }
}

