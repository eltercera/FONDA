using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Token de un Commensal por su propiedad
    /// StrToken en FindByStrTokenFondaDAO
    /// </summary>
    public class FindByStrTokenFondaDAOException : FondaDAOException
    {
        public FindByStrTokenFondaDAOException() : base() { }

        public FindByStrTokenFondaDAOException(string message) : base(message) { }

        public FindByStrTokenFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
