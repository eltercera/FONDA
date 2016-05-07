using com.ds201625.fonda.Domain;
using com.ds201625.fonda.LogicLayer.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaLogicLayer.Implementation
{
    public class Table : com.ds201625.fonda.Domain.Table
    {
        public Table(int Number, int Capacity)
        {
            this.Number = Number;
            if(!ValidateCapacity(Capacity))
                throw new WrongCapacityTable();

            this.Capacity = Capacity;
            this.Status = FreeTableStatus.Instance;
        }


    }
}
