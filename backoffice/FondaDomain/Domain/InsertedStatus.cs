
namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Estado eliminado de una entidad
	/// </summary>
	public class InsertedStatus : EntityRecordStatus
	{
		/// <summary>
		/// La intancia unica
		/// </summary>
		private static InsertedStatus _instance;

		/// <summary>
		/// Consructor
		/// </summary>
		protected InsertedStatus () : base ()
		{
			StatusId = 4;
			Description = "Registro no eliminado";
		}

		/// <summary>
		/// Obtiene el Estado eliminado de una entidad
		/// </summary>
		public static InsertedStatus Instance
		{
			get {
				if (_instance == null)
					_instance = new InsertedStatus ();

				return _instance;
			}
		}

		public override string ToString ()
		{
			return "Eliminado";
		}
	}
}



