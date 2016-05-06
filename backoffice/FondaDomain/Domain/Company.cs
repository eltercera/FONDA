using System;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Representa a una persona juridica
	/// </summary>
	public class Company : GenericPerson
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public Company () : base () { }

        /// <summary>
        /// Nacionalidad del Rif del restaurante
        /// </summary>
        private char _nationality;

        public virtual char Nationality
        {
            /// <summary>
            /// Obtiene la Nacionalidad del Rif de un restaurante
            /// </summary>
            get { return _nationality; }
            /// <summary>
            /// Asigna la Nacionalidad del Rif de un restaurante 
            /// </summary>
            /// <value>Recibe la Nacionalidad del Rif de un restaurante </value>
            set { _nationality = value; }
        }

    }
}

