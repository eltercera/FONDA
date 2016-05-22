using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{

    /// <summary>
    /// Plato
    /// </summary>
    [DataContract]
    public class Dish : NounBaseEntity
    {
        /// <summary>
        /// Descripcion
        /// </summary>
        private string _description;

        /// <summary>
        /// Costo
        /// </summary>
      
        private float _cost;

        /// <summary>
        /// Imagen
        /// </summary>
        private string _image;

        /// <summary>
        /// Estado simple del Plato
        /// </summary>
        private SimpleStatus _status;

       
        /// <summary>
        /// Sugerencia del dia
        /// </summary>
        private Boolean _suggestion;


        
		/// <summary>
		/// Constructor
		/// </summary>
		public Dish () : base () {	}

        /// <summary>
        /// Obtiene o asigna la descripcion
        /// </summary>
        /// <value>La Descripcion</value>
        [DataMember]
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        /// <summary>
        /// Obtiene o asigna el costo
        /// </summary>
        /// <value>El Costo</value>
        [DataMember]
        public virtual float Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// <summary>
        /// Obtiene o asigna la imagen
        /// </summary>
        /// <value>La Imagen</value>
        [DataMember]
        public virtual string Image
        {
            get { return _image; }
            set { _image = value; }
        }


        /// <summary>
        /// Obtiene o asigna la sugerencia
        /// </summary>
        /// <value>La Sugerencia</value>
        public virtual Boolean Suggestion
        {
            get { return _suggestion; }
            set { _suggestion = value; }
        }

        /// <summary>
        /// Obtiene o asigna el estatus
        /// </summary>
        /// <value>El Estatus</value>
        public virtual SimpleStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Cambia el eltado actual del Plato.
        /// </summary>
        public virtual void changeStatus()
        {
            _status = _status.Change();
        }
    }
}
