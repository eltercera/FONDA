using System;
using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateNounBaseEntityDAO<T>
		: HibernateBaseEntityDAO<T>,INounBaseEntityDAO<T>
        where T : NounBaseEntity
	{

		public IList<T> FindAllLikeName (string query = null, int max = -1, int page = 1)
		{
			return FindAllSortedByName (
				true, Restrictions.InsensitiveLike("Name","%" + query + "%"),max, (page - 1) * max);
		}

		protected IList<T> FindAllSortedByName(
			bool asc, ICriterion restrictions = null, int max = -1, int offset = -1)
		{
			Order order = asc ? Order.Asc ("Name") : Order.Desc("Name");
			return FindAll(restrictions, max, offset, order);
		}
	}
}

