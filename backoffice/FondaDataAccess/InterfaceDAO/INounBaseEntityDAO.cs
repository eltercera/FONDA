using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface INounBaseEntityDAO <T> : IBaseEntityDAO<T>
        where T : NounBaseEntity
	{

		/// <summary>
		/// Obtiene una lista de 
		/// </summary>
		/// <returns>The by name.</returns>
		/// <param name="name">Name.</param>
		/// <param name="max">Max.</param>
		/// <param name="offset">Offset.</param>
		IList<T> FindByName(string name, int max, int offset);

		IList<T> FindByLikeName(string name, int max, int offset);
			
	}
}

