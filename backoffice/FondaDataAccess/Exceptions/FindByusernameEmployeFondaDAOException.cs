﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindByusernameEmployeFondaDAOException : FondaDAOException
    {
        public FindByusernameEmployeFondaDAOException () : base() {	}

		public FindByusernameEmployeFondaDAOException (string message) : base(message) {	}

        public FindByusernameEmployeFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
