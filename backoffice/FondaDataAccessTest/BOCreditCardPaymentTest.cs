using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    [TestFixture()]
    public class BOCreditCardPaymentTest
    {

        private FactoryDAO _facDAO;

        private ICreditCardPaymentDAO _creditCardPaymentDAO;
        private CreditCardPayment _creditCardPayment;  
        private int _creditCardPaymentId;

        /// <summary>
        /// Prueba de Dominio.
        /// Solo crea a una persona y se veridica si los campos
        /// estan correctamente asignados.
        /// </summary>
		[Test()]
        public void CreditCardPaymentDomainTerst()
        {
            generateCreditCardPayment();
            CreditCardPaymentAssertions();
        }

        /// <summary>
        /// Prueba de Acceso a Datos.
        /// Genera una persona, La persiste, la edita, la guarda,
        /// la obtiene y verifica si los cambios son correctos.
        /// </summary>
		[Test()]
        public void CreditCardPaymentSave()
        {
            // Genera una persona
            getCreditCardPaymentDao();
            generateCreditCardPayment();

            // La persiste
            _creditCardPaymentDAO.Save(_creditCardPayment);

            // Verificación de la asignacion de Identificador de DB
            Assert.AreNotEqual(_creditCardPayment.Id, 0);
            _creditCardPaymentId = _creditCardPayment.Id;

            // Agrega los cambio a propiedades
            generateCreditCardPayment(true);

            // Se Guarda
            _creditCardPaymentDAO.Save(_creditCardPayment);

            // Reinicio de session de DAO
            _creditCardPaymentDAO.ResetSession();

            _creditCardPayment = null;

            // Obencion del la persona por su identificador
            _creditCardPayment = _creditCardPaymentDAO.FindById(_creditCardPaymentId);

            // Verificacion de los cambios.
            CreditCardPaymentAssertions(true);

        }

        private void getCreditCardPaymentDao()
        {
            getDao();
            if (_creditCardPaymentDAO == null)
                _creditCardPaymentDAO = _facDAO.GetCreditCardPaymentDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        private void generateCreditCardPayment(bool edit = false)
        {
            if (_creditCardPayment != null & !edit)
                return;

            if ((edit & _creditCardPayment == null) | _creditCardPayment == null)
                _creditCardPayment = new CreditCardPayment();

            int editadd = 1548;

            if (edit)
                editadd = 1234;

            //_creditCardPayment.LastCardDigits = editadd;
            _creditCardPayment.Amount = 25000;
          

        }

        private void CreditCardPaymentAssertions(bool edit = false)
        {
            int editadd = 1548;
            if (edit)
                editadd = 1234;

            Assert.IsNotNull(_creditCardPayment);
            Assert.AreEqual(_creditCardPayment.Amount, 25000);
            Assert.AreEqual(_creditCardPayment.LastCardDigits, editadd);
     
        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            if (_creditCardPaymentId != 0)
            {
                getCreditCardPaymentDao();
                // Eliminacion de la Persona al finalidar todo.
                //_personDAO.Delete(_person);
            }
            _creditCardPaymentDAO.ResetSession();
        }
    }
}
