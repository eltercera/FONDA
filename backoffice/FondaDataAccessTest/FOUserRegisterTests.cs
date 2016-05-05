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
		private Person _person;

		//private Company _company;

		//private Profile _profile;

		//private Commensal _commensal;

		private DateTime _personBirthDate = Convert.ToDateTime("10/05/2016");
		private int _personId;

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

		private void getDao()
		{
			if (_facDAO == null)
				_facDAO = FactoryDAO.Intance;
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
            if (_personId != 0)
            {
                getPersonDao();
                // Eliminacion de la Persona al finalidar todo.
                //_personDAO.Delete(_person);
            }
            _personDAO.ResetSession();
        }
	}
}

