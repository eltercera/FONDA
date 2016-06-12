using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Get Commensal Email Command
    /// </summary>
    class GetCommensalEmailCommand : BaseCommand
    {
        /// <summary>
        /// constructor obtener comensal
        /// </summary>
        public GetCommensalEmailCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El UserAccount
            paramters[0] = new Parameter(typeof(UserAccount), true);

            return paramters;
		}

        /// <summary>
        /// metodo invoke que ejecuta el buscar comensal por email 
        /// </summary>
        protected override void Invoke()
        {
            UserAccount answer;
            // Obtencion de parametros
            UserAccount commensal = (UserAccount)GetParameter(0);

            // Obtiene el dao que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
            // Ejecucion del Buscar.		
            try
            {
                 answer = (UserAccount)commensalDAO.FindByEmail(commensal.Email);
            }
            catch (FindByEmailUserAccountFondaDAOException e)
            {
                throw new GetCommensalEmailCommandException(
                   "Excepción al buscar el comensal por email",
                   e);
            }
            catch (NullReferenceException e)
            {
                throw new GetCommensalEmailCommandException(
                 "Excepción, apuntador nulo al buscar un comensal por email",
                 e);
            }
            catch (Exception e)
            {
                throw new GetCommensalEmailCommandException(
                 "Error al buscar el comensal",
                 e);
            }
            //FALTA LOGGER
            // Guardar el resultado.
            Result = answer;
        }
    }
}