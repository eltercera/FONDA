using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;

namespace FondaLogic.Commands.Login
{
    class ComandoGetUserAcountByEmail : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        string Email;
        public ComandoGetUserAcountByEmail(Object receiver) : base(receiver)
        {
            try
            {
                Email = (string)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }
        /// <summary>
        /// Metodo que ejecuta el comando para buscar un empleado de la bd
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IUserAccountDAO _userAccountDAO = _facDAO.GetUserAccountDAO();


                Receiver = _userAccountDAO.FindByEmail(Email);
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetUserAccount exceptionGetUserAccount = new CommandExceptionGetUserAccount(
                //Arrojar
                FondaResources.General.Errors.NullExceptionReferenceCode,
                FondaResources.Login.Errors.ClassNameGetUserAccountEmail,
                FondaResources.Login.Errors.CommandMethod,
                FondaResources.General.Errors.NullExceptionReferenceMessage,
                ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetUserAccount);

                throw exceptionGetUserAccount;
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);

            }
        }



    }
}
