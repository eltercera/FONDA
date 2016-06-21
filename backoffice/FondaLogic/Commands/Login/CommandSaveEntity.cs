using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;

namespace FondaLogic.Commands.Login
{
    class CommandSaveEntity : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        UserAccount _userAccount;


        public CommandSaveEntity(Object receiver) : base(receiver)
        {
            try
            {
                _userAccount = (UserAccount)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IUserAccountDAO _UserAccountDAO = _facDAO.GetUserAccountDAO();


                _UserAccountDAO.Save(_userAccount);

            }
            catch (Exception ex)
            {
                //throw new System.InvalidOperationException(ex.Message);

            }

        }


    }
}
