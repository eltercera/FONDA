using System;


namespace com.ds201625.fonda.Domain
{
    public abstract class AccountStatus : Status
    {
        /// <summary>
        /// Constructor
        /// </summary>
		protected AccountStatus() : base()	{ }

        /// <summary>
        /// Cambio el estado de una entidad
        /// </summary>
        /// <returns> rotorna el estado de la entidad</returns>
        public virtual AccountStatus Change()
        {
            if (Equals(OpenAccountStatus.Instance))
                return ClosedAccountStatus.Instance;

            return OpenAccountStatus.Instance;
        }

    }
}
