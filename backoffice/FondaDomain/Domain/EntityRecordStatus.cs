
namespace com.ds201625.fonda.Domain
{
	public abstract class EntityRecordStatus : Status
	{

		/// <summary>
		/// Constructor
		/// </summary>
		public EntityRecordStatus () : base () { }

		/// <summary>
		/// Retorna el estado contrario al actual.
		/// </summary>
		public virtual EntityRecordStatus Change ()
		{
			if ( Equals ( InsertedStatus.Instance ) )
				return DeletedStatus.Instance;

			return InsertedStatus.Instance;
		}
	}
}

