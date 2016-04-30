

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Entidad Base
	/// </summary>
    public class BaseEntity
    {

		/// <summary>
		/// Identidicador de la entidad
		/// </summary>
		public int _id;


		private EntityRecordStatus _recordStatus;

		/// <summary>
		/// Constructor.
		/// </summary>
		public BaseEntity() { }

		/// <summary>
		/// Obtiene o asigna el identificador de la entidad.
		/// </summary>
		/// <value>El identificador</value>
		public virtual int Id
		{
			get { return _id; }
			protected set { _id = value; }
		}

		/// <summary>
		/// Cambiar el estado actual de la entidad
		/// </summary>
		public void ChangeStatus()
		{
			_recordStatus = _recordStatus.Change ();
		}

    }
}
