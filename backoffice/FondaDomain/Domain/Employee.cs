using System;

namespace com.ds201625.fonda.Domain
{
	public class Employee : Person
	{
        /// <summary>
        /// nombre de usuario 
        /// </summary>
        private string _username;

        /// <summary>
        /// cuenta
        /// </summary>
        private Account _account;
        /// <summary>
        /// Rol de un trabajador
        /// </summary>
        private Role _role;

        /// <summary>
        /// Constructor
        /// </summary>
        public Employee() : base() {}

        /// <summary>
        /// Obtiene o asigna el nombre de usuario
        /// </summary>
        /// <value>El nombre de Usuario</value>
	
        public virtual string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Obtiene o asigna la cuenta del usuario
        /// </summary>
        /// <value>Cuenta de usuario</value>
        public virtual Account Account
        {
            get { return _account; }
            set { _account = value; }
	}

        /// <summary>
        /// Obtiene o asigna el rol del usuario
        /// </summary>
        /// <value>Rol del usuario</value>
       public virtual Role Role
        {
            get { return _role; }
            set { _role = value; }

        }

   }
}


