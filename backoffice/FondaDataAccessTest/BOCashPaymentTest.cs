using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccessTest
{
    [TestFixture()]
    public class BOCashPaymentTest
    {

        private FactoryDAOO _facDAO;

        private ICashPaymentDAO _cashPaymentDAO;
        private CashPayment _cashPayment;
        private int _cashPaymentId;

        /// <summary>
        /// Prueba de Dominio.
        /// Solo crea a una persona y se veridica si los campos
        /// estan correctamente asignados.
        /// </summary>
		[Test()]
        public void CashPaymentDomainTerst()
        {
            generateCashPayment();
            CashPaymentAssertions();
        }

        /// <summary>
        /// Prueba de Acceso a Datos.
        /// Genera una persona, La persiste, la edita, la guarda,
        /// la obtiene y verifica si los cambios son correctos.
        /// </summary>
		[Test()]
        public void CashPaymentSave()
        {
            // Genera una persona
            getCashPaymentDao();
            generateCashPayment();

            // La persiste
            _cashPaymentDAO.Save(_cashPayment);

            // Verificación de la asignacion de Identificador de DB
            Assert.AreNotEqual(_cashPayment.Id, 0);
            _cashPaymentId = _cashPayment.Id;

            // Agrega los cambio a propiedades
            generateCashPayment(true);

            // Se Guarda
            _cashPaymentDAO.Save(_cashPayment);

            // Reinicio de session de DAO
            _cashPaymentDAO.ResetSession();

            _cashPayment = null;

            // Obencion del la persona por su identificador
            _cashPayment = _cashPaymentDAO.FindById(_cashPaymentId);

            // Verificacion de los cambios.
            CashPaymentAssertions(true);

        }

        private void getCashPaymentDao()
        {
            getDao();
            if (_cashPaymentDAO == null)
                _cashPaymentDAO = _facDAO.GetCashPaymentDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAOO.Intance;
        }

        private void generateCashPayment(bool edit = false)
        {
            if (_cashPayment != null & !edit)
                return;

            if ((edit & _cashPayment == null) | _cashPayment == null)
                _cashPayment = new CashPayment();

            int editadd = 1548;

            if (edit)
                editadd = 1234;

            
            _cashPayment.Amount = editadd;


        }

        private void CashPaymentAssertions(bool edit = false)
        {
            int editadd = 1548;
            if (edit)
                editadd = 1234;

            Assert.IsNotNull(_cashPayment);
            Assert.AreEqual(_cashPayment.Amount, editadd);
           

        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            if (_cashPaymentId != 0)
            {
                getCashPaymentDao();
                // Eliminacion de la Persona al finalidar todo.
                //_personDAO.Delete(_person);
            }
            _cashPaymentDAO.ResetSession();
        }
    }
}
