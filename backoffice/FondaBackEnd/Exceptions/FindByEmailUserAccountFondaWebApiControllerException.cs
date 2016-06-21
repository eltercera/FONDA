﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase FindByEmailUserAccountFondaWebApiControllerException
    /// </summary>
    public class FindByEmailUserAccountFondaWebApiControllerException : FondaBackendException
    {
        public FindByEmailUserAccountFondaWebApiControllerException () : base() {	}

		public FindByEmailUserAccountFondaWebApiControllerException (string message) : base(message) {	}

        public FindByEmailUserAccountFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
