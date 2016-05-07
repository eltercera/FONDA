using System;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Representa a un estado de una entidad
	/// </summary>
	public abstract class Status : Entity
	{
		/// <summary>
		/// Identificador del estado de una entidad
		/// </summary>
		private int _statusId;

		/// <summary>
		/// Descripción del estado de una entidad
		/// </summary>
		private string _description;

		/// <summary>
		/// Constructor
		/// </summary>
		public Status () {	}

		/// <summary>
		/// Obtiene o asigna el identificador del estado.
		/// </summary>
		/// <value>El identificador del estad.</value>
		public virtual int StatusId
		{
			get { return _statusId; }
			protected set { _statusId = value; }
		}

		/// <summary>
		/// Obtiene o asigna la descripcion del estado.
		/// </summary>
		/// <value>The description.</value>
		public virtual string Description
		{
			get { return _description; }
			protected set { _description = value; }
		}

		/// <summary>
		/// Comparacion con el objeto actual
		/// </summary>
		/// <param name="obj">
		/// objeto a comparar
		/// </param>
		/// <returns>
		/// <c>true</c> si obj es igual al objeto actual
		/// <c>false</c> en cualquier otro caso
		/// </returns>
		public override bool Equals (object obj)
		{
			Status _obj = null;
			try{
				_obj = (Status)obj;
			}
			catch (InvalidCastException e)
			{
				// TODO: Manejo de estos errores.
				Console.WriteLine (e.ToString ());
				return false;
			}
			return (_statusId == _obj.StatusId);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		/// <summary>
		/// retorna un string que representa al objeto.
		/// </summary>
		/// <returns>
		/// Atring que repesenta al objeto actual
		/// </returns>
		public override abstract string ToString ( );

	}
}

