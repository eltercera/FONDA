﻿

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Entidad Base
	/// </summary>
    public class BaseEntity : Entity
    {

		/// <summary>
		/// Identidicador de la entidad
		/// </summary>
		private int _id;


        private EntityRecordStatus _recordStatus;

        /// <summary>
        /// Constructor.
        /// </summary>
        //public BaseEntity() {
        //	_recordStatus = InsertedStatus.Instance;
        //}

        /// <summary>
        /// Obtiene o asigna el identificador de la entidad.
        /// </summary>
        /// <value>El identificador</value>
        public virtual int Id
		{
			get { return _id; }
		    set { _id = value; }
		}

        public virtual EntityRecordStatus RecordStatus
        {
            get { return _recordStatus; }
            set { _recordStatus = value; }
        }

        /// <summary>
        /// Cambiar el estado actual de la entidad
        /// </summary>
        public virtual void ChangeRecordStatus()
        {
            _recordStatus = _recordStatus.Change();
        }

    }
}
