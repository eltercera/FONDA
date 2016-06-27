using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface ICommensalDAO : IUserAccountDAO
	{
        Commensal GetCommensalByReservation(int reservationId);
	}
}

