using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Representa una información de perfil
	/// </summary>
	public class Profile : BaseEntity
	{

		private string _profileName;

		private Person _person;

		private SimpleStatus _status;

		/// <summary>
		/// Constructor
		/// </summary>
		public Profile () { }

		/// <summary>
		/// Obtiene o asigna el nombre de perfil
		/// </summary>
		/// <value>el nombre de perfil</value>
		[DataMember]
		public virtual string ProfileName
		{
			get { return _profileName; }
			set { _profileName = value; }
		}

		/// <summary>
		///  Obtiene o asigna una persona o organizacion
		/// </summary>
		/// <value>una persona o organizacion</value>
		[DataMember]
		public virtual Person Person
		{
			get { return _person; }
			set { _person = value; }
		}

		// <summary>
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

