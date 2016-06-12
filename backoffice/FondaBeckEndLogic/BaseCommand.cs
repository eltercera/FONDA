using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Clase Abstracta base para comandos
	/// </summary>
	public abstract class BaseCommand : ICommand
	{
		/// <summary>
		/// Los parametros
		/// </summary>
		private Parameter[] _parameters;

		/// <summary>
		/// El resultado
		/// </summary>
		private Object _result;

		/// <summary>
		/// Constructor
		/// </summary>
		public BaseCommand ()
		{
			_parameters = InitParameters ();
			_result = null;
		}

		/// <summary>
		/// Gets or sets the result.
		/// </summary>
		/// <value>The result.</value>
		public Object Result
		{
			get { return _result; }
			protected set { _result = value; }
		}

		/// <summary>
		/// Sets the parameter.
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="data">Data.</param>
		public void SetParameter(int index, Object data)
		{
			if ( index < 0 || index >= _parameters.Length)
				throw ParameterIndexOutOfRangeException.Generate(this, index);

			_parameters [index].Data = data;
		}

		/// <summary>
		/// Run this instance.
		/// </summary>
		public void  Run ()
		{
			ValidateParameters ();
			Invoke ();
		}

		/// <summary>
		/// Gets the parameter.
		/// </summary>
		/// <returns>The parameter.</returns>
		/// <param name="index">Index.</param>
		protected Object GetParameter(int index)
		{
			if ( index < 0 || index >= _parameters.Length)
				throw ParameterIndexOutOfRangeException.Generate(this, index);
			return _parameters [index].Data;
		}

		/// <summary>
		/// Inits the parameters.
		/// </summary>
		/// <returns>The parameters.</returns>
		protected abstract Parameter[] InitParameters ();

		/// <summary>
		/// Invoke this instance.
		/// </summary>
		protected abstract void Invoke();

		/// <summary>
		/// Validates the parameters.
		/// </summary>
		private void ValidateParameters()
		{
			for (int i = 0; i < _parameters.Length; i++)
			{
				if (_parameters[i].IsRequiered() && _parameters[i].Data == null)
					throw RequieredParameterNotFoundException.Generate(this, i);
			}
		}

		/// <summary>
		/// Gets the fac DAO.
		/// </summary>
		/// <value>The fac DAO.</value>
		protected FactoryDAO FacDao
		{
			get { return FactoryDAO.Intance; }
		}
	}
}

