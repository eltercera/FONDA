using System;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Representa los clientes.
	/// </summary>
	public class Commensal : UserAccount
	{
		/// <summary>
		/// Token de session de la cuenta.
		/// </summary>
		private string _sesionToken;

		public Commensal () : base () {	}

		/// <summary>
		/// Obtiene o asigna la clave
		/// </summary>
		/// <value>la clave</value>
		public virtual string SesionToken
		{
			get { return _sesionToken; }
			set { _sesionToken= value; }
		}
	}
}

