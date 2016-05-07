using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccessTests
{
	[TestFixture ()]
	public class FOUserRegisterTests
	{

		private FactoryDAO _facDAO;

		private IPersonDAO _personDAO;
		private IProfileDAO _profileDAO;
		private ITokenDAO _tokenDAO;
		private ICommensalDAO _commensalDAO;


		private Person _person;

		private Profile _profile;

		private Commensal _commensal;

		private DateTime _personBirthDate = Convert.ToDateTime("10/05/2016");
		private int _personId;
		private int _profileId;
		private int _comensalId;
		private string _TokenString;

        /// <summary>
        /// Prueba de Dominio.
        /// Solo crea a una persona y se veridica si los campos
        /// estan correctamente asignados.
        /// </summary>
		[Test ()]
		public void PersonDomainTerst ()
		{
			generatePerson ();
			PersonAssertions ();
		}

		[Test ()]
		public void ProfileDomainTerst ()
		{
			generateProfile ();
			ProfileAssertions ();
		}

		[Test ()]
		public void CommensalDomainTerst ()
		{
			generateCommensal ();
			commensalAssertions ();
		}

		[Test ()]
		public void CommensalSave ()
		{
			generateCommensal ();
			getCommensalDao ();
			getTokenDao ();

			_commensalDAO.Save (_commensal);
			Assert.AreNotEqual (_profile.Id, 0);

			_TokenString = _commensal.SesionToken.StrToken;
			_comensalId = _commensal.Id;

			_commensalDAO.ResetSession ();
			_commensal = null;

			_commensal = _commensalDAO.FindByToken (_TokenString);
			commensalAssertions ();

			_commensalDAO.ResetSession ();
			_commensal = null;
			_profile = null;
			_person = null;

			_commensal = (Commensal)_commensalDAO.FindByEmail ("ADasdasd@asdas.com");
			commensalAssertions ();

			_profile = _commensal.Profiles[0];
			_person = _profile.Person;
			ProfileAssertions ();
			PersonAssertions ();
		}


		[Test ()]
		public void ProfileSave ()
		{
			// Genera una persona
			getProfileDao ();
			generateProfile ();

			// La persiste
			_profileDAO.Save (_profile);

			// Verificación de la asignacion de Identificador de DB
			Assert.AreNotEqual (_profile.Id, 0);
			_profileId = _profile.Id;

			// Reinicio de session de DAO
			_profileDAO.ResetSession ();

			_profile = null;

			// Obencion del la persona por su identificador
			_profile = _profileDAO.FindById (_profileId);

			// Verificacion de los cambios.
			ProfileAssertions ();
			PersonAssertions (_personId == 0 ? false : true);
		}

        /// <summary>
        /// Prueba de Acceso a Datos.
        /// Genera una persona, La persiste, la edita, la guarda,
        /// la obtiene y verifica si los cambios son correctos.
        /// </summary>
		[Test ()]
		public void PersonSave ()
		{
            // Genera una persona
			getPersonDao ();
			generatePerson ();

            // La persiste
			_personDAO.Save (_person);

            // Verificación de la asignacion de Identificador de DB
			Assert.AreNotEqual (_person.Id, 0);
			_personId = _person.Id;

            // Agrega los cambio a propiedades
			generatePerson (true);

            // Se Guarda
			_personDAO.Save (_person);

            // Reinicio de session de DAO
			_personDAO.ResetSession ();

			_person = null;

            // Obencion del la persona por su identificador
			_person = _personDAO.FindById (_personId);

            // Verificacion de los cambios.
			PersonAssertions (true);

		}

		private void getPersonDao()
		{
			getDao ();
			if (_personDAO == null)
				_personDAO = _facDAO.GetPersonDao();
				
		}

		private void getTokenDao()
		{
			getDao ();
			if (_tokenDAO == null)
				_tokenDAO = _facDAO.GetTokenDAO();

		}

		private void getProfileDao()
		{
			getDao ();
			if (_profileDAO == null)
				_profileDAO = _facDAO.GetProfileDAO();

		}

		private void getCommensalDao()
		{
			getDao ();
			if (_commensalDAO == null)
				_commensalDAO = _facDAO.GetCommensalDAO();

		}

		private void getDao()
		{
			if (_facDAO == null)
				_facDAO = FactoryDAO.Intance;
		}

		private void generateCommensal()
		{
			if (_commensal != null)
				return;

			_commensal = new Commensal ();
			_commensal.Email = "ADasdasd@asdas.com";
			_commensal.Password = "asdasdasd";
			generateProfile ();
			_commensal.AddProfile (_profile);
			_commensal.SesionToken = new Token ();
			_commensal.Status = ActiveSimpleStatus.Instance;

		}

		private void commensalAssertions()
		{
			Assert.IsNotNull (_commensal);
			Assert.AreEqual (_commensal.Email, "ADasdasd@asdas.com");
			Assert.AreEqual (_commensal.Password, "asdasdasd");
			Assert.Less (0, _commensal.Profiles.Count);
		}

		private void generateProfile()
		{
			if (_profile != null)
				return;

			_profile = new Profile ();

			_profile.ProfileName = "Nombre de Perfil";
			_profile.Status = DisableSimpleStatus.Instance;
			generatePerson ();
			_profile.Person = _person;
		}

		private void ProfileAssertions()
		{
			Assert.IsNotNull (_profile);
			Assert.AreEqual (_profile.ProfileName, "Nombre de Perfil");
		}

		private void generatePerson(bool edit = false)
		{
			if (_person != null & !edit)
				return;

			if((edit & _person==null) | _person==null)
				_person = new Person ();
			
			string editadd = "";

			if (edit)
				editadd = "Editado";

			_person.Name = "Rómulo José" + editadd;
			_person.LastName = "Rodríguez Rojas" + editadd;
			_person.Ssn = "19513536";
			_person.PhoneNumber = "0414-445-44-45";
			_person.Address = "Direccion de Prueba" + editadd;
			_person.Gender = 'M';
			_person.BirthDate = _personBirthDate;
			_person.Status = ActiveSimpleStatus.Instance;

		}

		private void PersonAssertions(bool edit = false)
		{
			string editadd = "";
			if (edit)
				editadd = "Editado";

			Assert.IsNotNull (_person);
			Assert.AreEqual (_person.Name, "Rómulo José" + editadd);
			Assert.AreEqual (_person.LastName, "Rodríguez Rojas" + editadd);
			Assert.AreEqual (_person.Ssn, "19513536");
			Assert.AreEqual (_person.PhoneNumber, "0414-445-44-45");
			Assert.AreEqual (_person.Address, "Direccion de Prueba" + editadd);
			Assert.AreEqual (_person.Gender, 'M');
			Assert.AreEqual (_person.BirthDate, _personBirthDate);
			Assert.AreEqual (_person.Status, ActiveSimpleStatus.Instance);
		}

        [TestFixtureTearDown]
        public void EndTests()
        {
            _personDAO.ResetSession();
        }
	}
}

