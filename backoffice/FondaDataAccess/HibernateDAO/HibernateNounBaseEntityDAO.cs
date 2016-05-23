using System;
using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateNounBaseEntityDAO<T>
		: HibernateBaseEntityDAO<T>,INounBaseEntityDAO<T>
        where T : NounBaseEntity
	{

		/// <summary>
		/// Obtiene una lista de 
		/// </summary>
		/// <returns>The by name.</returns>
		/// <param name="name">Name.</param>
		/// <param name="max">Max.</param>
		/// <param name="offset">Offset.</param>
		public IList<T> FindByName(string name, int max, int offset)
		{
			return null;
		}

		public IList<T> FindByLikeName(string name, int max, int offset)
		{
			return null;
		}
	}
}

