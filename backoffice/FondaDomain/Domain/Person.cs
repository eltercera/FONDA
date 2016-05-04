using System;

namespace com.ds201625.fonda
{
	/// <summary>
	/// Persona (Humano)
	/// </summary>
	public class Person
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
		public virtual string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		/// <summary>
		/// Obtiene o asigna el genero
		/// </summary>
		/// <value>Genero</value>
		public virtual char Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		/// <summary>
		/// Obtiene o asigna la fecha de nacimiento
		/// </summary>
		/// <value>La fecha de nacimiento</value>
		public virtual DateTime BirthDate
		{
			get { return _birthDate; }
			set { _birthDate = value; }
		}
	}
}

