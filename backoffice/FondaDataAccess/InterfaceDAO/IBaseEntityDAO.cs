using System;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IBaseEntityDAO <T>
	{
		/// <summary>
		/// Persiste o actualiza una entidad
		/// </summary>
		/// <param name="entity"> La entidad </param>
		void Save (T entity);

		/// <summary>
		/// Elimina una entidad en espesifico
		/// </summary>
		/// <param name="entity">La entidad</param>
		void Delete (T entity);

		/// <summary>
		/// Obtiene un objeto a partir de su identificador
		/// </summary>
		/// <param name="id">Identificador de la entidad.</param>
		/// <returns> Objeto de la entidad.</returns>
		T FindById (int id);

		void ResetSession();
	}
}

