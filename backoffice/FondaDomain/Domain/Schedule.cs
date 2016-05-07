using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Horario disponible de un Restaurante
    /// </summary>
    public class Schedule : BaseEntity
    {
        /// <summary>
        /// Hora de apertura del restaurante
        /// </summary>
        private TimeSpan _openingTime;

        /// <summary>
        /// Hora de cierre del restaurante
        /// </summary>
        private TimeSpan _closingTime;

        private List<Day> _day;

        /// <summary>
        /// Constructor
        /// </summary>
        public Schedule() : base()
        {

            _day = new List<Day>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <value>openingTime: Recibe la hora de apertura del restaurante</value>
        /// <value>closingTime: Recibe la hora de cierre del restaurante</value>
        public Schedule( TimeSpan openingTime, TimeSpan closingTime ) : base() {

        }

        public virtual TimeSpan OpeningTime
        {
            /// <summary>
            /// Obtiene la hora de apertura del Restaurante
            /// </summary>
            get { return _openingTime; }
            /// <summary>
            /// Asigna la hora de apertura del Restaurante
            /// </summary>
            /// <value>Recibe la hora de apertura del Restaurante</value>
            set { _openingTime = value; }
        }

        public virtual TimeSpan ClosingTime
        {
            /// <summary>
            /// Obtiene la hora de cierre del Restaurante
            /// </summary> 
            
            get { return _closingTime; }
            /// <summary>
            /// Asigna la hora de cierre del Restaurante
            /// </summary>
            /// <value>Recibe la hora de cierre del Restaurante</value>
            set { _closingTime = value; }
        }

        public virtual List<Day> Day
        {
            /// <summary>
            /// Obtiene el dia en el que abre el restaurante
            /// </summary>
            get { return _day; }
            /// <summary>
            /// Asigna el dia en el que abre el restaurante
            /// </summary>
            /// <value>Recibe el valor del dia en el que abre el restaurante</value>
            set { _day = value; }
        }


    }
}
