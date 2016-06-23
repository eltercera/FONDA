using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Cuenta de usuario
	/// </summary>
	public class UserAccount : BaseEntity
	{
		/// <summary>
		/// Correo Electronico
		/// </summary>
		private string _email;

		/// <summary>
		/// Clave de la cuenta de usuario
		/// </summary>
		private string _password;

		/// <summary>
		/// Estado simple de la cuenta de usuario
		/// </summary>
		private SimpleStatus _status;

		public UserAccount () : base ()
		{
			
		}

		/// <summary>
		/// Obtiene o asigna el correo electronico
		/// </summary>
		/// <value>el correo electronico</value>
		[DataMember]
		public virtual string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		/// <summary>
		/// Obtiene o asigna la clave
		/// </summary>
		/// <value>la clave</value>
		[DataMember]
		public virtual string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		/// <summary>
		/// Obtiene o asigna el estado de una cuenta de usuario
		/// </summary>
		/// <value>El estado simple</value>
		public virtual SimpleStatus Status
		{
			get { return _status; }
			set { _status = value; }
		}
	}
}

