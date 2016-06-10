using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion utilizada para registrar los errores 
    /// arrojados en la logica de negocios
    /// </summary>
    public class CommandException : Exception
    {
        #region Fields
        private string _id;
        private string _className;
        private string _method;
        private string _messageException;
        private Exception _ex;
        #endregion

        #region Constructors
        public CommandException(string message, Exception ex)
        {
            this._messageException = message;
            this._ex = ex;
        }

        public CommandException(string id, string classname, string method, string message, Exception ex)
        {
            this._id = id;
            this._className = classname;
            this._method = method;
            this._messageException = message;
            this._ex = ex;
        }
        #endregion

        #region Properties
        public string Id
        {
            get { return _id; }
        }

        public string ClassName
        {
            get { return _className; }
        }

        public string Method
        {
            get { return _method; }
        }

        public string MessageException
        {
            get { return _messageException; }
        }

        public Exception Ex
        {
            get { return _ex; }
        }
        #endregion
    }
}
