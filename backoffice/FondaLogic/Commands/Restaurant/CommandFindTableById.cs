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
    //comando que busca una mesa por un id dado
    public class CommandFindTableById : Command
    {
        //fabrica del DAO
        FactoryDAO _facDAO = FactoryDAO.Intance;
        //Objeto que contiene el id
        int _idTable;

        public CommandFindTableById(Object receiver) : base(receiver)
        {
            try
            {
                _idTable = (int)receiver;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// metodo que ejecuta el metodo del dao
        /// </summary>
        public override void Execute()
        {
            try
            {

                //Metodos para acceder a la bd
                FactoryDAO _facDAO = FactoryDAO.Intance;
                ITableDAO _tableDAO = _facDAO.GetTableDAO();

                //se ejecuta el metodo
                Receiver = _tableDAO.FindById(_idTable);
            }
            catch (Exception)
            {

            }
        }
    }
}
