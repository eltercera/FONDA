using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    public class Role : NounBaseEntity
    {
        /// <summary>
        /// descripcion de un rol
        /// </summary>
        private string _descripcion;
       	/// <summary>
		/// Estado simple de un rol 
		/// </summary>
		private SimpleStatus _status;

        /// <summary>
        /// Obtiene o asigna la descripcion del Rol
        /// </summary>
        ///<value>La descripcion del rol</value>
    public virtual string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Obtener o asignar el status del rol
        /// </summary>
        /// <value>El estatus dle rol</value>
    public virtual SimpleStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }

    /// <summary>
    /// CAmbia el eltado actual del rol.
    /// </summary>
    public virtual void changeStatus()
    {
        _status = _status.Change();
    }
    
    }
}
