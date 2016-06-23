using System;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Interfaz para comandos
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Ejecuta el commando
		/// </summary>
		void Run();

		/// <summary>
		/// Asigna el valor de un parametro
		/// </summary>
		/// <param name="index">Indice del parametro</param>
		/// <param name="data">Objeto a contener</param>
		void SetParameter (int index, Object data);

		/// <summary>
		/// Obtiene el resultado.
		/// </summary>
		/// <value>The result.</value>
		Object Result
		{
			get;
		}
	}
}

