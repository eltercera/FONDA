using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.HibernateDAO.Session;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace FondaDataAccessTest
{
    /// <summary>
    /// Clase de pruebas de dominio y Dao 
    /// </summary>
	public class FOUserRegisterTests
    {
        //Atributos para las Pruebas
		private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;
		private IPersonDAO _personDAO;
		private IProfileDAO _profileDAO;
		private ICommensalDAO _commensalDAO;

		private Person _person;
		private Profile _profile;
		private Commensal _commensal;
		private Token _token;

		private int _personId = 0;
		private int _profileId = 0;
		private int _comensalId = 0;
		private int _tokenId = 0;

		private string _dataPersonName;
		private string _dataPersonLastName;
		private string _dataPersonSsn;
		private string _dataPersonPhoneNumber;
		private string _dataPersonAddress;
		private char _dataPersonGender;
		private DateTime _dataPersonBirthDate;

		private string _dataProfileName;
		private SimpleStatus _dataProfileStatus;

		private string _dataCommensalEmail;
		private string _dataCommensalPassword;
		private SimpleStatus _dataCommensalStatus;

		private string _dataTokenStrToken;


		/// <summary>
        /// Genera los datos de una persona
		/// </summary>
		/// <param name="edit">true en caso de edicion, false en cualquier otro caso</param>
		private void generatePerson(bool edit = false)
		{
			if (_person != null & !edit)
				return;

			if((edit & _person==null) | _person==null)
				_person = EntityFactory.GetPerson();

			string editadd = "";

			if (edit)
				editadd = "Editado";

			Random rand = new Random ();

			_dataPersonName = "Jessika Beatriz" + editadd;
			_dataPersonLastName = "Daboin Lira" + editadd;
			if (!edit)
				_dataPersonSsn = "" + rand.Next(19000000,30000000);

			Console.WriteLine ("SSn Creado: " + _dataPersonSsn);
			
			_dataPersonPhoneNumber = "0414-"+rand.Next(100,999)+"-96-54";
			_dataPersonAddress = "Direccion de Prueba " + editadd;
			_dataPersonGender = 'F';
			_dataPersonBirthDate = Convert.ToDateTime ("13/12/1991");


			_person.Name = _dataPersonName;
			_person.LastName = _dataPersonLastName;
			_person.Ssn = _dataPersonSsn;
			_person.PhoneNumber = _dataPersonPhoneNumber;
			_person.Address = _dataPersonAddress;
			_person.Gender = _dataPersonGender;
			_person.BirthDate = _dataPersonBirthDate;
			_person.Status = _facDAO.GetActiveSimpleStatus ();

		}

        /// <summary>
        /// Assertions de verificacion de persona
        /// </summary>
		private void PersonAssertions()
		{
			Assert.IsNotNull (_person);
			Assert.AreEqual (_person.Name, _dataPersonName);
			Assert.AreEqual (_person.LastName, _dataPersonLastName);
			Assert.AreEqual (_person.Ssn, _dataPersonSsn);
			Assert.AreEqual (_person.PhoneNumber, _dataPersonPhoneNumber);
			Assert.AreEqual (_person.Address, _dataPersonAddress);
			Assert.AreEqual (_person.Gender, _dataPersonGender);
			Assert.AreEqual (_person.BirthDate, _dataPersonBirthDate);
			Assert.AreEqual (_person.Status, _facDAO.GetActiveSimpleStatus ());
		}

		/// <summary>
		/// Genera un Perfil
		/// </summary>
		private void generateProfile()
		{
			if (_profile != null)
				return;

            _profile = EntityFactory.GetProfile();

			_dataProfileName = "Nombre de Perfil";
			_dataProfileStatus = _facDAO.GetActiveSimpleStatus ();

			_profile.ProfileName = _dataProfileName;
			_profile.Status = _dataProfileStatus;
			generatePerson ();
			_profile.Person = _person;
		}

        /// <summary>
        /// Assertions de verificacion de perfil
        /// </summary>
		private void ProfileAssertions()
		{
			Assert.IsNotNull (_profile);
			Assert.AreEqual (_profile.ProfileName, _dataProfileName);
			Assert.AreEqual (_profile.Status, _dataProfileStatus);
			if (_person == null)
				_person = _profile.Person;
			PersonAssertions ();
		}

		/// <summary>
		/// Genera un comensal
		/// </summary>
		private void generateCommensal()
		{
			if (_commensal != null)
				return;

            _commensal = EntityFactory.GetCommensal();

			Random random = new Random ();

			_dataCommensalEmail = random.Next(100,600)+"jessikadaboin@gmail.com";
			_dataCommensalPassword = "jessi12345";
			_dataCommensalStatus = _facDAO.GetActiveSimpleStatus ();

			_commensal.Email = _dataCommensalEmail;
			_commensal.Password = _dataCommensalPassword;
			_commensal.Status = _dataCommensalStatus;
			generateProfile ();
			_commensal.AddProfile (_profile);

            _token = EntityFactory.GetToken();

			_commensal.AddToken (_token);

			_dataTokenStrToken = _token.StrToken;

		}

        /// <summary>
        /// Assertions de verificacion de un commensal
        /// </summary>
		private void CommensalAssertions()
		{
			Assert.IsNotNull (_commensal);
			Assert.IsNotNull (_commensal.Profiles);
			Assert.IsNotNull (_commensal.SesionTokens);
			Console.WriteLine ("Numero: " + _commensal.Profiles.Count);
			Assert.AreEqual (1, _commensal.Profiles.Count);
			Assert.AreEqual (1, _commensal.SesionTokens.Count);

			if (_profile == null)
				_profile = _commensal.Profiles [0];

			if (_token == null)
				_token = _commensal.SesionTokens [0];

			ProfileAssertions ();

			Assert.AreEqual (_token.StrToken, _dataTokenStrToken);
			Assert.AreEqual (_token.Commensal, _commensal);
		}

		/// <summary>
		/// Instancia la Fabrica de DAO
		/// </summary>
		private void getDao()
		{
			if (_facDAO == null)
                _facDAO = com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO.Intance;
		}

        /// <summary>
        /// Obtiene el PersonDAO
        /// </summary>
		private void getPersonDao()
		{
			getDao ();
			if (_personDAO == null)
				_personDAO = _facDAO.GetPersonDao();

		}

        /// <summary>
        /// Obtiene el ProfileDAO
        /// </summary>
		private void getProfileDao()
		{
			getDao ();
			if (_profileDAO == null)
				_profileDAO = _facDAO.GetProfileDAO ();

		}

        /// <summary>
        /// Obtiene el CommensalDAO
        /// </summary>
		private void getCommensalDao()
		{
			getDao ();
			if (_commensalDAO == null)
				_commensalDAO = _facDAO.GetCommensalDAO ();

		}
			
		/// <summary>
		/// Pruebas unitarias de Persona
		/// </summary>
		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de dominio.
		/// </summary>
		public void PersonDomainTerst ()
		{
            //Se genera una persoma
			generatePerson ();
            //Se verifica si se creo la persona de forma correcta en el dominio
			PersonAssertions ();
            //Se genera la Persona Editada
			generatePerson (true);
            //Se verifica si se edito la persona de forma correcta en el dominio
			PersonAssertions ();
		}

		[Test ()]
		/// <summary>
		/// Pruebas de creación y edicion a nivel de DAO.
		/// </summary>
		public void PersonDaoSaveTest()
		{
            //Se genera una persoma
			generatePerson ();
            //Se obtiene el PersonDAO
			getPersonDao ();
            //Se guarda la persona
			_personDAO.Save (_person);
            //verifica si se guardo la persona en la base de datos
			Assert.AreNotEqual (_person.Id, _personId);
			_personId = _person.Id;

			_personDAO.ResetSession ();
            //Se obtiene el PersonDAO
			getPersonDao ();
			_person = null;
			_person = _personDAO.FindById (_personId);
            //Se verifica si se agrego bien en la base de datos
			PersonAssertions ();
            //se genera una persona modificada
			generatePerson (true);
            //se guardan los cambios
			_personDAO.Save (_person);
            
			_personDAO.ResetSession ();
            //se verifica si se guardaron bien los cambios
			getPersonDao ();
			_person = null;
			_person = _personDAO.FindById (_personId);
			PersonAssertions ();


		}

		/// <summary>
		/// Pruebas de Profile
		/// </summary>
		[Test ()]
		/// <summary>
		/// Pruebas de creación y edicion a nivel de dominio.
		/// </summary>
		public void ProfileDomainTerst ()
		{
			generateProfile ();
			ProfileAssertions ();
		}

		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de DAO.
		/// </summary>
		public void ProfileDaoSaveTest()
		{
            //se genera un perfil
			generateProfile ();
			getProfileDao ();
            //se guarda el perfil
			_profileDAO.Save (_profile);

			Assert.AreNotEqual (_profile.Id, _profileId);
			_profileId = _profile.Id;

			_profileDAO.ResetSession ();

			getProfileDao ();
			_profile = null;
			_person = null;

            //se verifica si se guardo  en la base de datos 
			_profile = _profileDAO.FindById (_profileId);
			_person = _profile.Person;
			ProfileAssertions ();

		}


		/// <summary>
		/// Pruebas de Commensal
		/// </summary>
		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de dominio.
		/// </summary>
		public void CommensalDomainTerst ()
		{
			generateCommensal ();
			CommensalAssertions ();
		}

		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de DAO.
		/// </summary>
		public void CommensalDaoSaveTest()
		{
            //se genera el commensal
			generateCommensal ();
			getCommensalDao ();
            //se guarda el commensal
			_commensalDAO.Save (_commensal);
            //se verifica si se guardo el commensal y el token
			Assert.AreNotEqual (_commensal.Id, _comensalId);
			_comensalId = _commensal.Id;
			Assert.AreNotEqual (_token.Id, _tokenId);
			_tokenId = _token.Id;

			_commensalDAO.ResetSession ();
			_commensal = null;
			_token = null;
			_profile = null;
			_person = null;
            //se verifica si se guardaron bien los datos
			_commensal = (Commensal)_commensalDAO.FindById (_comensalId);
			CommensalAssertions ();

		}
			
		[Test]
		/// <summary>
		/// Prueba de unicidad de un token
		/// </summary>
		public void TokenDomainTest()
		{
			int cant = 2500;

            Token[] tokenA = EntityFactory.GetTokenA(cant);
			for (int i = 0; i < cant; i++)
			{
				tokenA [i] = EntityFactory.GetToken();
			}

			for (int i = 0; i < cant; i++)
			{
				for (int j = i+1; j < cant; j++)
				{
                    Assert.AreNotEqual(tokenA[j].StrToken, tokenA[i].StrToken);
				}
			}
		}


        /// <summary>
        /// prueba excepcion al buscar por id
        /// </summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindCommensalByIdNullReferenceTest()
        {
            _commensalDAO.FindById(0);
        }
        /// <summary>
        /// prueba excepcion guardar
        /// </summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void SaveCommensalNullReferenceTest()
        {
            _commensalDAO.Save(null);
        }

        //Al inicio de cada prueba
		[SetUp]
		public void BeginTest()
		{
			getDao ();
			NHibernateSessionManager.CloseSession();
		}

        // al final de cada prueba
		[TearDown]
		public void EndTests()
		{
			if (_personId != 0)
			{
				getPersonDao ();
				_personDAO.Delete (_person);
				_personId = 0;
			}

			if (_profileId != 0)
			{
				getProfileDao ();
				_profileDAO.Delete (_profile);
				_profileId = 0;
			}

			if (_comensalId != 0)
			{
				getCommensalDao ();
				_commensalDAO.Delete (_commensal);
				_comensalId = 0;
			}
			_person = null;
			_profile = null;
			_commensal = null;
			_token = null;

			getCommensalDao ();
			_commensalDAO.ResetSession ();
		}
	}
}

