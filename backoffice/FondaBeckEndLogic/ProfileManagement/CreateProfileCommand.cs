﻿using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.BackEndLogic;
using FondaLogic.Log;
using FondaBeckEndLogic.Exceptions;


namespace FondaBeckEndLogic.ProfileManagement
{
	/// <summary>
    /// Comando para agregar un perfil a un Commensal
	/// </summary>
	public class CreateProfileCommand : BaseCommand
	{
        /// <summary>
        /// constructor CreateProfileCommand
        /// </summary>
		public CreateProfileCommand () : base () { }

		protected override Parameter[] InitParameters ()
		{
			// Requiere 2 Parametros
			Parameter[] paramters = new Parameter[2];

			// [0] El Commensal
			paramters [0] = new Parameter (typeof(Commensal), true);

			// [1] El Profile
			paramters [1] = new Parameter (typeof(Profile), true);
            //Retorno de los Parametros
			return paramters;
		}

        /// <summary>
        /// Metodo Invoke para la ejecucion del
        /// guardado de un profile de un commensal
        /// </summary>
		protected override void Invoke()
		{
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                   ResourceMessages.BeginLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

			    // Se obtienen los parametros Commensal y Profile
			    Commensal commensal = (Commensal) GetParameter (0);
			    Profile profile = (Profile) GetParameter (1);

                // Obtiene el dao CommensalDAO
			    ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

			    // Validacion basica de datos
                if (profile.ProfileName == null || profile.Person == null || profile.Person.Name == null
                    || profile.Person.LastName == null || profile.Person.Ssn == null)
                    throw new CreateProfileCommandException(ResourceMessagesProfile.InvalidInformationProfile);
               
            try
            {    
                // Set Status del Perfil Activo por Defecto
			    profile.Status = FacDao.GetActiveSimpleStatus();
                // Set Status de la persona Activo por Defecto
			    profile.Person.Status = FacDao.GetActiveSimpleStatus();
                // Se agrega el perfil al commensal
			    commensal.Profiles.Add(profile);
                //Debo agregar genero y fecha nacimento
			    profile.Person.Gender = ' ';
			    profile.Person.BirthDate = DateTime.Now;

			    //Se Guarda el commensal con el nuevo perfil
				commensalDAO.Save(commensal);
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ResourceMessagesProfile.ProfileAdded + commensal.Id + ResourceMessages.Slash + profile.ProfileName,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
			}
			catch (SaveEntityFondaDAOException e)
			{
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateProfileCommandException(ResourceMessagesProfile.AddProfileException, e);
			}
			catch (Exception e)
			{
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateProfileCommandException(ResourceMessagesProfile.AddProfileException, e);
			}

			// Guardar el resultado.
			Result = profile;

            //Logger al Culminar el metodo
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, Result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
		}
	}
}

