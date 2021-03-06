﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.BackEndLogic;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    /// <summary>
    /// Clase GetAllRestaurantsCommandException
    /// </summary>
    public class GetAllRestaurantsCommandException : FondaBackendLogicException
    {
        public GetAllRestaurantsCommandException () : base() {	}

		public GetAllRestaurantsCommandException(string message) : base(message) {	}

        public GetAllRestaurantsCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
