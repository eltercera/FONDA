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
        /// Obtiene o asigna la descripcion del Rol
        /// </summary>
        ///<value>La descripcion del rol</value>
    public virtual string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    
    }
}
