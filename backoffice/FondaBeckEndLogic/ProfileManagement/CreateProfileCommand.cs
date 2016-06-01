using System;
using com.ds201625.fonda.Logic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	public class CreateProfileCommand : BaseCommand
	{
		public CreateProfileCommand () : base () { }

		protected override Parameter[] InitParameters ()
		{
			Parameter[] paramters = new Parameter[2];

			paramters [0] = new Parameter (typeof(Commensal), true);
			paramters [1] = new Parameter (typeof(Profile), true);

			return paramters;
		}

		protected override void Invoke()
		{
			Commensal commensal = (Commensal) GetParameter (0);
			Profile profile = (Profile) GetParameter (1);

			ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

			if (profile.ProfileName == null || profile.Person == null || profile.Person.Name == null
				|| profile.Person.LastName == null || profile.Person.Ssn == null)
				// TODO: Crear Excepcion personalizada
				throw new Exception("Datos de Perfil Invalidos");

			profile.Status = FacDao.GetActiveSimpleStatus();
			profile.Person.Status = FacDao.GetActiveSimpleStatus();
			commensal.Profiles.Add(profile);
			profile.Person.Gender = ' ';
			profile.Person.BirthDate = DateTime.Now;

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

			Result = profile;
		}
	}
}

