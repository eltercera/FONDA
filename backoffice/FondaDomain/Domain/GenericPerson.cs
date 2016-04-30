using System;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Persona Generica
	/// </summary>
	public class GenericPerson : NounBaseEntity
	{

		/// <summary>
		/// Direccion de una persona
		/// </summary>
		private string _address;

		/// <summary>
		/// Numero de telefono
		/// </summary>
		private string _phoneNumber;

		/// <summary>
		/// Identificador Personal (CI, RIF)
		/// </summary>
		private string _ssn;

		/// <summary>
		/// Estado simple de una persona
		/// </summary>
		private SimpleStatus _status;

		/// <summary>
		/// Constructor
		/// </summary>
		public GenericPerson () : base () {	}

		/// <summary>
		/// Obtiene o asigna la direccion
		/// </summary>
		/// <value>La Direccion</value>
		public virtual string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		/// <summary>
		/// Obtiene o asigna el numero de telefono.
		/// </summary>
		/// <value>El numero de telefono</value>
		public virtual string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		/// <summary>
		/// Obtiene o asigna el Identificador Personal
		/// </summary>
		/// <value>Identificador Personal</value>
		public virtual string Ssn
		{
			get { return _ssn; }
			set { _ssn = value; }
		}

		/// <summary>
		/// CAmbia el eltado actual de la persona.
		/// </summary>
		public void changeStatus ()
		{
			_status = _status.Change ();
		}
	}
}

