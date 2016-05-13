using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
	public class Token : BaseEntity
	{
		private string _strToken;
		private DateTime _created;
		private DateTime _expiration;
		private Commensal _commensal;

		public Token () : base ()
		{
			_created = DateTime.Now;
			_expiration = _created.AddDays (5);
			_strToken = _created.ToString () + _expiration.ToString ();
		}

		[DataMember]
		public virtual string StrToken
		{
			get { return _strToken; }
			protected set { _strToken = value; }
		}

		[DataMember]
		public virtual DateTime Created
		{
			get { return _created; }
			protected set { _created = value; }
		}

		[DataMember]
		public virtual DateTime Expiration
		{
			get { return _expiration; }
			protected set { _expiration = value; }
		}

		public virtual Commensal Commensal
		{
			get { return _commensal; }
			set { _commensal = value; }
		}
	}
}

