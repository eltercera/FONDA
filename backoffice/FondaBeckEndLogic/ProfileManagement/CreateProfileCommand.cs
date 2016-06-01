using System;
using com.ds201625.fonda.Logic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Comando para la agregacion de un perfil a un Commensal
	/// </summary>
	public class CreateProfileCommand : BaseCommand
	{
		
		public CreateProfileCommand () : base () { }

		protected override Parameter[] InitParameters ()
		{
			// Requiere 2 Parametros
			Parameter[] paramters = new Parameter[2];

			// [0] el Commensal
			paramters [0] = new Parameter (typeof(Commensal), true);

			// [1] El profile
			paramters [1] = new Parameter (typeof(Profile), true);

			return paramters;
		}

		protected override void Invoke()
		{
			// Obtencion de parametros
			Commensal commensal = (Commensal) GetParameter (0);
			Profile profile = (Profile) GetParameter (1);

			// Obtiene el dao que se requiere
			ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

			// Validacion basica de datos
			if (profile.ProfileName == null || profile.Person == null || profile.Person.Name == null
				|| profile.Person.LastName == null || profile.Person.Ssn == null)
				// TODO: Crear Excepcion personalizada
				throw new Exception("Datos de Perfil Invalidos");

			// Set Varios
			profile.Status = FacDao.GetActiveSimpleStatus();
			profile.Person.Status = FacDao.GetActiveSimpleStatus();
			commensal.Profiles.Add(profile);
			profile.Person.Gender = ' ';
			profile.Person.BirthDate = DateTime.Now;

			// Ejecucion del Guardado.
			try
			{
				commensalDAO.Save(commensal);
			}
			catch (SaveEntityFondaDAOException e)
			{
				// TODO: Crear Excepcion personalizada
				throw new Exception("Error al gualrdar los datos",e);
			}
			catch (Exception e)
			{
				// TODO: Crear Excepcion personalizada
				throw new Exception("Error Desconocido",e);
			}

			// Guardar el resultado.
			Result = profile;
		}
	}
}

