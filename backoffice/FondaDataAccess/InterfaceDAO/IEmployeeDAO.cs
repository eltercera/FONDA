using System;
﻿using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IEmployeeDAO : IGenericPersonDAO<Employee>
    {
        IList<Employee> GetAll();
        Employee FindByusername(string user);
    }
}
