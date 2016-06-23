
﻿using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackEndLogicTest
{
    public abstract class HelpTestCommand
    {

        private Commensal _commensal;
        private Profile _profile;
        private Person _person;
        private string _dataCommensalEmail;
        private string _dataCommensalPassword;
        private SimpleStatus _dataCommensalStatus;
        private Token _token;
        private string _dataProfileName;
        private SimpleStatus _dataProfileStatus;
        private string _dataTokenStrToken;
        private string _dataPersonName;
        private string _dataPersonLastName;
        private string _dataPersonSsn;
        private string _dataPersonPhoneNumber;
        private string _dataPersonAddress;
        private char _dataPersonGender;
        private DateTime _dataPersonBirthDate;

        public HelpTestCommand() : base() { }

        /// <summary>
        /// Genera un comensal
        /// </summary>
        protected Commensal generateCommensal()
        {
            _commensal = EntityFactory.GetCommensal();

            Random random = new Random();

            _dataCommensalEmail = random.Next(100, 600) + "jessikadaboin@gmail.com";
            _dataCommensalPassword = "jessi12345";
            _dataCommensalStatus = ActiveSimpleStatus.Instance;

            _commensal.Email = _dataCommensalEmail;
            _commensal.Password = _dataCommensalPassword;
            _commensal.Status = _dataCommensalStatus;
            _profile = generateProfile();
            _commensal.AddProfile(_profile);

            _token = EntityFactory.GetToken();

            _commensal.AddToken(_token);

            _dataTokenStrToken = _token.StrToken;

            return _commensal;

        }

        /// <summary>
        /// Genera un Perfil
        /// </summary>
        protected Profile generateProfile()
        {
            if (_profile != null)
                return _profile;

            _profile = EntityFactory.GetProfile();

            _dataProfileName = "Nombre de Perfil";
            _dataProfileStatus = ActiveSimpleStatus.Instance;

            _profile.ProfileName = _dataProfileName;
            _profile.Status = _dataProfileStatus;
            generatePerson();
            _profile.Person = _person;
            return _profile;
        }


        /// <summary>
        /// Genera los datos de una persona
        /// </summary>
        /// <param name="edit">true en caso de edicion, false en cualquier otro caso</param>
        protected void generatePerson(bool edit = false)
        {
            if (_person != null & !edit)
                return;

            if ((edit & _person == null) | _person == null)
                _person = EntityFactory.GetPerson();

            string editadd = "";

            if (edit)
                editadd = "Editado";

            Random rand = new Random();

            _dataPersonName = "Jessika Beatriz" + editadd;
            _dataPersonLastName = "Daboin Lira" + editadd;
            if (!edit)
                _dataPersonSsn = "" + rand.Next(19000000, 30000000);

            Console.WriteLine("SSn Creado: " + _dataPersonSsn);

            _dataPersonPhoneNumber = "0414-" + rand.Next(100, 999) + "-96-54";
            _dataPersonAddress = "Direccion de Prueba " + editadd;
            _dataPersonGender = 'F';
            _dataPersonBirthDate = Convert.ToDateTime("13/12/1991");


            _person.Name = _dataPersonName;
            _person.LastName = _dataPersonLastName;
            _person.Ssn = _dataPersonSsn;
            _person.PhoneNumber = _dataPersonPhoneNumber;
            _person.Address = _dataPersonAddress;
            _person.Gender = _dataPersonGender;
            _person.BirthDate = _dataPersonBirthDate;
            _person.Status = ActiveSimpleStatus.Instance;

        }
    }
    
}
