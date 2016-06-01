using System;

namespace com.ds201625.fonda.Logic
{
	public class Parameter
	{
		private Type _dataType;

		private Object _data;

		private bool _required;

		public Parameter (Type dataType, bool required = false)
		{
			_data = null;
			_dataType = dataType;
			_required = required;
		}

		public Object Data
		{
			set
			{
				if (!_dataType.IsAssignableFrom(value.GetType()))
					// TODO: Crear excepción personalizada
					throw new Exception(
						"Se espera un tipo (" + _dataType.ToString() + ") y se recivio ("
						+ value.GetType().ToString() + ")"
					);
				_data = value;
			}
			get { return _data; }
		}

		public bool IsRequiered()
		{
			return _required;
		}

	}
}

