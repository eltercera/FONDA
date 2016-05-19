using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccessTests
{
	public class FOUserRegisterTests
    {

		private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;
		private IPersonDAO _personDAO;
		private IProfileDAO _profileDAO;
		private ITokenDAO _tokenDAO;
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

		private DateTime _dataTokenCreate;
		private DateTime _dataTokenExpite;
		private string _dataTokenStrToken;


		// Ayudantes Person.

		private void generatePerson(bool edit = false)
		{
			if (_person != null & !edit)
				return;

			if((edit & _person==null) | _person==null)
				_person = new Person ();

			string editadd = "";

			if (edit)
				editadd = "Editado";

			Random rand = new Random ();

			_dataPersonName = "Rómulo José" + editadd;
			_dataPersonLastName = "Rodríguez Rojas" + editadd;
			if (!edit)
				_dataPersonSsn = "" + rand.Next(19000000,30000000);
			
			_dataPersonPhoneNumber = "0414-"+rand.Next(100,999)+"-44-45";
			_dataPersonAddress = "Direccion de Prueba " + editadd;
			_dataPersonGender = 'M';
			_dataPersonBirthDate = Convert.ToDateTime ("10/05/2016");


			_person.Name = _dataPersonName;
			_person.LastName = _dataPersonLastName;
			_person.Ssn = _dataPersonSsn;
			_person.PhoneNumber = _dataPersonPhoneNumber;
			_person.Address = _dataPersonAddress;
			_person.Gender = _dataPersonGender;
			_person.BirthDate = _dataPersonBirthDate;
			//_person.Status = _facDAO.GetActiveSimpleStatus ();

		}

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
	//		Assert.AreEqual (_person.Status, _facDAO.GetActiveSimpleStatus ());
		}

		// Ayudantes Profile

		private void generateProfile()
		{
			if (_profile != null)
				return;

			_profile = new Profile ();

			_dataProfileName = "Nombre de Perfil";
		//	_dataProfileStatus = _facDAO.GetActiveSimpleStatus ();

			_profile.ProfileName = _dataProfileName;
			_profile.Status = _dataProfileStatus;
			generatePerson ();
			_profile.Person = _person;
		}

		private void ProfileAssertions()
		{
			Assert.IsNotNull (_profile);
			Assert.AreEqual (_profile.ProfileName, _dataProfileName);
			Assert.AreEqual (_profile.Status, _dataProfileStatus);
			if (_person == null)
				_person = _profile.Person;
			PersonAssertions ();
		}

		// Ayudante commensal

		private void generateCommensal()
		{
			if (_commensal != null)
				return;

			_commensal = new Commensal ();

			_dataCommensalEmail = "rodriguezrjrr@gmail.com";
			_dataCommensalPassword = "1234567890";
	//		_dataCommensalStatus = _facDAO.GetActiveSimpleStatus ();

			_commensal.Email = _dataCommensalEmail;
			_commensal.Password = _dataCommensalPassword;
			_commensal.Status = _dataCommensalStatus;
			generateProfile ();
			_commensal.AddProfile (_profile);

			_token = new Token ();

			_commensal.AddToken (_token);

			_dataTokenCreate = _token.Created;
			_dataTokenExpite = _token.Expiration;
			_dataTokenStrToken = _token.StrToken;

		}

		private void CommensalAssertions()
		{
			Assert.IsNotNull (_commensal);
			Assert.IsNotNull (_commensal.Profiles);
			Assert.IsNotNull (_commensal.SesionTokens);
			Assert.AreEqual (1, _commensal.Profiles.Count);
			Assert.AreEqual (1, _commensal.SesionTokens.Count);

			if (_profile == null)
				_profile = _commensal.Profiles [0];

			if (_token == null)
				_token = _commensal.SesionTokens [0];

			ProfileAssertions ();

			//Assert.AreEqual (_token.Created, _dataTokenCreate);
			//Assert.AreEqual (_token.Expiration, _dataTokenExpite);
			Assert.AreEqual (_token.StrToken, _dataTokenStrToken);
			Assert.AreEqual (_token.Commensal, _commensal);
		}

		// Ayudantes DAO

		private void getDao()
		{
			if (_facDAO == null)
                _facDAO = com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO.Intance;
		}

		private void getPersonDao()
		{
			getDao ();
			if (_personDAO == null)
				_personDAO = _facDAO.GetPersonDao();

		}

		private void getProfileDao()
		{
			getDao ();
			if (_profileDAO == null)
				_profileDAO = _facDAO.GetProfileDAO ();

		}

		private void getCommensalDao()
		{
			getDao ();
			if (_commensalDAO == null)
				_commensalDAO = _facDAO.GetCommensalDAO ();

		}
			
		// Pruebas de persona.

		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de dominio.
		/// </summary>
		public void PersonDomainTerst ()
		{
			generatePerson ();
			PersonAssertions ();
			generatePerson (true);
			PersonAssertions ();
		}

		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de DAO.
		/// </summary>
		public void PersonDaoSaveTest()
		{
			generatePerson ();
			getPersonDao ();

			_personDAO.Save (_person);

			Assert.AreNotEqual (_person.Id, _personId);
			_personId = _person.Id;

			_personDAO.ResetSession ();

			getPersonDao ();
			_person = null;
			_person = _personDAO.FindById (_personId);
			PersonAssertions ();

			generatePerson (true);
			_personDAO.Save (_person);

			_personDAO.ResetSession ();

			getPersonDao ();
			_person = null;
			_person = _personDAO.FindById (_personId);
			PersonAssertions ();


		}

		// Pruebas de Perfil

		[Test ()]
		/// <summary>
		/// Purebas de creación y edicion a nivel de dominio.
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
			generateProfile ();
			getProfileDao ();

			_profileDAO.Save (_profile);

			Assert.AreNotEqual (_profile.Id, _profileId);
			_profileId = _profile.Id;

			_profileDAO.ResetSession ();

			getProfileDao ();
			_profile = null;
			_person = null;

			_profile = _profileDAO.FindById (_profileId);
			_person = _profile.Person;

			ProfileAssertions ();

		}


		// Pruebas de Commensal

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
			generateCommensal ();
			getCommensalDao ();

			_commensalDAO.Save (_commensal);

			Assert.AreNotEqual (_commensal.Id, _comensalId);
			_comensalId = _commensal.Id;
			Assert.AreNotEqual (_token.Id, _tokenId);
			_tokenId = _token.Id;

			_commensalDAO.ResetSession ();
			_commensal = null;
			_token = null;
			_profile = null;
			_person = null;

			_commensal = (Commensal)_commensalDAO.FindById (_tokenId);
			CommensalAssertions ();

		}
			
		[Test]
		/// <summary>
		/// Prueba de unicidad de un token
		/// </summary>
		public void TokenDomainTest()
		{
			int cant = 2500;

			Token [] t = new Token [cant];
			for (int i = 0; i < cant; i++)
			{
				t [i] = new  Token ();
			}

			for (int i = 0; i < cant; i++)
			{
				for (int j = i+1; j < cant; j++)
				{
					Assert.AreNotEqual (t[j].StrToken,t[i].StrToken);
				}
			}
		}

		[SetUp]
		public void BeginTest()
		{
			getDao ();
		}

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

