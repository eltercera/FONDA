﻿using System;
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

		public ITokenDAO GetTokenDAO()
		{
			return new HibernateTokenDAO ();
		}

		public ActiveSimpleStatus GetActiveSimpleStatus()
		{
			IActiveSimpleStatusDAO s = new HibernateActiveSimpleStatus ();
			return s.getActiveSimpleStatus ();
		}

    }
}

