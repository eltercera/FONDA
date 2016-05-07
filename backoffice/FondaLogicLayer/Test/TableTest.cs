using com.ds201625.fonda.FondaLogicLayer.Implementation;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using com.ds201625.fonda.LogicLayer.Exception;

namespace com.ds201625.fonda.LogicLayer.Test
{
    [TestFixture]
    public class TableTest
    {
        private com.ds201625.fonda.FondaLogicLayer.Implementation.Table _busyTable;
        private com.ds201625.fonda.FondaLogicLayer.Implementation.Table _freeTable;
        private com.ds201625.fonda.FondaLogicLayer.Implementation.Table table;
        private List<com.ds201625.fonda.FondaLogicLayer.Implementation.Table> _listTable;

        /// <summary>
        /// Instancia los objetos para Mesa
        /// Mesa Vacía (Free Table)
        /// Mesa Ocupada (Busy Table)
        /// Lista de Mesas (Para simular el acceso a datos)
        /// </summary>
        [SetUp]
        public void Init()
        {

            _busyTable = new com.ds201625.fonda.FondaLogicLayer.Implementation.Table(1, 2);
            _busyTable.Status = BusyTableStatus.Instance;

            _freeTable = new com.ds201625.fonda.FondaLogicLayer.Implementation.Table(2,4);

            _listTable = new List<FondaLogicLayer.Implementation.Table>();
        }

        [Test, Description("Prueba el metodo que valida que una mesa no tenga una capacidad distinta a la establecida")]
        //[ExpectedException(typeof WrongCapacityTable)]
        public void ValidateCapacity()
        {
            table = new com.ds201625.fonda.FondaLogicLayer.Implementation.Table(1, 2);

            Assert.AreEqual( 2 , table.Capacity );
        }

        [Test, Description("Prueba que el estado de una mesa ocupada cambie a vacia")]
        public void FreeTable()
        {
            _busyTable.Status.Change();

            Assert.IsInstanceOf<FreeTableStatus>(_busyTable.Status);
        }
        
        [Test, Description("Prueba que el estado de una mesa vacia cambie a ocupada")]
        public void BusyTable()
        {
            _freeTable.Status.Change();

            Assert.IsInstanceOf<BusyTableStatus>(_freeTable.Status);
        }

    }
}
