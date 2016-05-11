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

		public IUserAccountDAO UserAccountDAO ()
		{
			return _factory.GetUserAccountDAO ();
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

		public ITokenDAO GetTokenDAO()
		{
			return _factory.GetTokenDAO ();
		}

		public ActiveSimpleStatus GetActiveSimpleStatus()
		{
			return _factory.GetActiveSimpleStatus ();
		}
    }
}

