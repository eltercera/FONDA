using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

namespace com.ds201625.fonda.Logic
{
	public abstract class BaseCommand
	{
		
		private Parameter[] _parameters;

		private Object _result;

		public BaseCommand ()
		{
			_parameters = InitParameters ();
			_result = null;
		}

		public Object Result
		{
			get { return _result; }
			protected set { _result = value; }
		}

		public void SetParameter(int index, Object data)
		{
			if ( index < 0 || index >= _parameters.Length)
				// TODO: Exeption personalizada
				throw new Exception("Index (" + index + " fuera de rango." );

			_parameters [index].Data = data;
		}

		public void  Run ()
		{
			ValidateParameters ();
			Invoke ();
		}

		protected Object GetParameter(int index)
		{
			if ( index < 0 || index >= _parameters.Length)
				// TODO: Exeption personalizada
				throw new Exception("Index (" + index + " fuera de rango." );
			return _parameters [index].Data;
		}

		protected abstract Parameter[] InitParameters ();

		protected abstract void Invoke();

		private void ValidateParameters()
		{
			for (int i = 0; i < _parameters.Length; i++)
			{
				if (_parameters[i].IsRequiered() && _parameters[i].Data == null)
					// TODO: Exeption personalizada
					throw new Exception("Parametro requerido no espesificado index (" + i + ")");
			}
		}

		protected FactoryDAO FacDao
		{
			get { return FactoryDAO.Intance; }
		}
	}
}

