using System;

namespace com.ds201625.fonda.Domain
{
	public abstract class SimpleStatus : Status
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public SimpleStatus () : base()	{ }

		public SimpleStatus Change ()
		{
			if (Equals (ActiveSimpleStatus.Instance))
				return DisableSimpleStatus.Instance;

			return ActiveSimpleStatus.Instance;
		}
	}
}

