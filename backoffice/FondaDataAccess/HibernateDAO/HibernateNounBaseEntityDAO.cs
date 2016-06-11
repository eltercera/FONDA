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

		protected IList<T> FindAllLikeName (
			string query = null, int max = -1, int page = 1,ICriterion restric = null,
			string baseAlias = null)
		{
			ICriterion newRestric;
			if (restric != null)
				newRestric = Restrictions.And (
					restric, Restrictions.InsensitiveLike ("Name", "%" + query + "%"));
			else
				newRestric = Restrictions.InsensitiveLike ("Name", "%" + query + "%");

			return FindAllSortedByName (true, newRestric,max, (page - 1) * max,baseAlias);
		}

		protected IList<T> FindAllSortedByName(
			bool asc, ICriterion restrictions = null, int max = -1, int offset = -1,
			string baseAlias = null)
		{
			Order order = asc ? Order.Asc ("Name") : Order.Desc("Name");
			return FindAll(restrictions, max, offset, order,baseAlias);
		}
	}
}

