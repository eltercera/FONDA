using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface INounBaseEntityDAO <T> : IBaseEntityDAO<T>
        where T : NounBaseEntity
	{

	}
}

