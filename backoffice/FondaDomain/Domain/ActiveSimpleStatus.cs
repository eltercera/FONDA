using System;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Estado eliminado de una entidad
	/// </summary>
	public class ActiveSimpleStatus : SimpleStatus
	{
		/// <summary>
		/// La intancia unica
		/// </summary>
		private static ActiveSimpleStatus _instance;

		/// <summary>
		/// Consructor
		/// </summary>
		protected ActiveSimpleStatus () : base () 
		{
			StatusId = 1;
			Description = GeneralRes.ActiveSimpleStatusDes;
		}

		/// <summary>
		/// Obtiene el Estado eliminado de una entidad
		/// </summary>
		public static ActiveSimpleStatus Instance
		{
			get {
				if (_instance == null)
					_instance = new ActiveSimpleStatus ();

				return _instance;
			}
		}

		/// <summary>
		/// Retrona una descripcion de este estado
		/// </summary>
		/// <returns>Activo en String</returns>
		public override string ToString ()
		{
            return GeneralRes.ActiveSimpleStatusString;
		}
	}
}

