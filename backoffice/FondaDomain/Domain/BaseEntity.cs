using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Entidad Base
	[DataContract]
	public class BaseEntity : Entity
    {

		/// <summary>
		/// Identidicador de la entidad
		/// </summary>
		private int _id;


		//private EntityRecordStatus _recordStatus;

		/// <summary>
		/// Constructor.
		/// </summary>
		public BaseEntity() {
			//_recordStatus = InsertedStatus.Instance;
		}

		/// <summary>
		/// Obtiene o asigna el identificador de la entidad.
		/// </summary>
		/// <value>El identificador</value>
		[DataMember]
		public virtual int Id
		{
			get { return _id; }
		    set { _id = value; }
		}

		

    }
}
