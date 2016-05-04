
namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Estado eliminado de una entidad
	/// </summary>
	public class DeletedStatus : EntityRecordStatus
	{
		/// <summary>
		/// La intancia unica
		/// </summary>
		private static DeletedStatus _instance;

		/// <summary>
		/// Consructor
		/// </summary>
		public DeletedStatus () : base () {	}

		/// <summary>
		/// Obtiene el Estado eliminado de una entidad
		/// </summary>
		public static DeletedStatus Instance
		{
			get {
				if (_instance == null)
					_instance = new DeletedStatus ();

				return _instance;
			}
		}

		/// <summary>
		/// Retorna un string que representa al estado
		/// </summary>
		/// <returns>AEliminado</returns>
		public override string ToString ()
		{
			return "Eliminado";
		}
	}
}

