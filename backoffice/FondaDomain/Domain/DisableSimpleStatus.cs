
namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Estado eliminado de una entidad
	/// </summary>
	public class DisableSimpleStatus : SimpleStatus
	{
		/// <summary>
		/// La intancia unica
		/// </summary>
		private static DisableSimpleStatus _instance;

		/// <summary>
		/// Consructor
		/// </summary>
		protected DisableSimpleStatus () : base ()
		{
			StatusId = 2;
			Description = GeneralRes.DisableSimpleStatusDes;
		}

		/// <summary>
		/// Obtiene el Estado eliminado de una entidad
		/// </summary>
		public static DisableSimpleStatus Instance
		{
			get {
				if (_instance == null)
					_instance = new DisableSimpleStatus ();

				return _instance;
			}
		}

		/// <summary>
		/// Retorna un string con la represtacion de este estado.
		/// </summary>
		/// <returns>No Activo</returns>
		public override string ToString ()
		{
			return GeneralRes.DisableSimpleStatusString;
		}
	}
}

