using System;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
	public class Token : BaseEntity
	{
		/// <summary>
		/// String del Token
		/// </summary>
		private string _strToken;

		/// <summary>
		/// Fecha de creación
		/// </summary>
		private DateTime _created;

		/// <summary>
		/// Fecha de expiración
		/// </summary>
		private DateTime _expiration;

		/// <summary>
		/// Perteneca a comensal.
		/// </summary>
		private Commensal _commensal;

		/// <summary>
		/// Ramdom Generator
		/// </summary>
		private static Random _rand = new Random();

		/// <summary>
		/// Inicializador de una instancia
		/// agrega todos los atributos.
		/// </summary>
		public Token () : base ()
		{
			_created = DateTime.Now;
			_expiration = _created.AddDays (5);
			_strToken =  Generatehash(GenerateStrToken());
		}

		[DataMember]
		public virtual string StrToken
		{
			get { return _strToken; }
			protected set { _strToken = value; }
		}

		[DataMember]
		/// <summary>
		/// Obtiene o asigna la fecha de cración
		/// </summary>
		/// <value>The created.</value>
		public virtual DateTime Created
		{
			get { return _created; }
			protected set { _created = value; }
		}

		[DataMember]
		/// <summary>
		/// Obtiene o asigna la fecha de expitación
		/// </summary>
		/// <value>The created.</value>
		public virtual DateTime Expiration
		{
			get { return _expiration; }
			protected set { _expiration = value; }
		}

		/// <summary>
		/// Obtiene o asigna un commansal
		/// </summary>
		/// <value>El comensal.</value>
		public virtual Commensal Commensal
		{
			get { return _commensal; }
			set { _commensal = value; }
		}

		/// <summary>
		/// Genera un string que representa a un token
		/// </summary>
		/// <returns>El string.</returns>
		private string GenerateStrToken()
		{
			StringBuilder builder = new StringBuilder();
			char ch;
			for (int i = 1; i < Token._rand.Next(10,50); i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Token._rand.NextDouble() + 65)));
				builder.Append(ch);
			}
	
			return builder.ToString();
		}

		/// <summary>
		/// Genera el hash de un testo espesificado
		/// </summary>
		/// <param name="text">El texto.</param>
		private string Generatehash(string text)
		{
			SHA512Managed hashTool = new SHA512Managed();
			Byte[] hashAsByte = Encoding.UTF8.GetBytes (text);
			Byte[] hncryptedBytes = hashTool.ComputeHash(hashAsByte);
			hashTool.Clear();
			return Convert.ToBase64String(hncryptedBytes);
		}
	}
}

