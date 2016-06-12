using System;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Representa un parametro para un comando
	/// </summary>
	public class Parameter
	{
		/// <summary>
		/// Tipo de dato que se espera guardar en el
		/// parametro
		/// </summary>
		private Type _dataType;

		/// <summary>
		/// El objeto que a contener
		/// </summary>
		private Object _data;

		/// <summary>
		/// Si el parametro es requerido
		/// </summary>
		private bool _required;

		/// <summary>
		/// Constructor de un parametro
		/// </summary>
		/// <param name="dataType">Tipo de dato</param>
		/// <param name="required">Si es requerido o no (Optional)</param>
		public Parameter (Type dataType, bool required = false)
		{
			_data = null;
			_dataType = dataType;
			_required = required;
		}

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public Object Data
		{
			set
			{
				if (value == null)
					return;
				if (!_dataType.IsAssignableFrom(value.GetType()))
					throw InvalidTypeOfParameterException.Generate(_dataType,value.GetType());
				_data = value;
			}
			get { return _data; }
		}

		/// <summary>
		/// Determina si el parametro es requerico.
		/// </summary>
		/// <returns><c>true</c> si el parametro es requerido; en cotro caso, <c>false</c>.</returns>
		public bool IsRequiered()
		{
			return _required;
		}

	}
}

