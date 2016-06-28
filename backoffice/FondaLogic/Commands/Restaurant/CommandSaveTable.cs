using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Restaurante
{
    class CommandSaveTable : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        Table _table;

        public CommandSaveTable(Object receiver) : base(receiver)
        {
            try
            {
                _table = (Table)receiver;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Execute()
        {
            try
            {
                //defino los dao
                ITableDAO _tableDAO = _facDAO.GetTableDAO();

                //ejecuto el metodo del dao
                _tableDAO.Save(_table);
            }
            catch
            {
                throw new NotImplementedException();

            }
            
        }
    }
}
