using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Persona (Humano)
	/// </summary>
	public class Person : GenericPerson
	{
		/// <summary>
		/// Apellidos
		/// </summary>
		private string _lastName;

		/// <summary>
		/// Genero
		/// </summary>
		private char _gender;

		/// <summary>
		/// Fecha de Nacimiento
		/// </summary>
		private DateTime _birthDate;

		/// <summary>
		/// Constructor
		/// </summary>
		public Person () : base() {	}

		/// <summary>
		/// Obtiene o asigna el apellido
		/// </summary>
		/// <value>El apellido</value>
		[DataMember]
		public virtual string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		/// <summary>
		/// Obtiene o asigna el genero
		/// </summary>
		/// <value>Genero</value>
		[DataMember]
		public virtual char Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		/// <summary>
		/// Obtiene o asigna la fecha de nacimiento
		/// </summary>
		/// <value>La fecha de nacimiento</value>
		[DataMember]
		public virtual DateTime BirthDate
		{
			get { return _birthDate; }
			set { _birthDate = value; }
		}
	}
}

