using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Tests.DataAccess
{
    [TestFixture]
    public class BOPaymentTest
    {
        private FactoryDAO _facDAO;
        private ICreditCardPaymentDAO _creditCardPaymentDAO;
        private ICashPaymentDAO _cashPaymentDAO;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditCardPayment;
        private float _amount;
        private int _lastCardDigits, _creditId, _cashId;

        [SetUp]
        public void Init()
        {

            _facDAO = FactoryDAO.Intance;

            _creditCardPaymentDAO = _facDAO.GetCreditCardPaymentDAO();
            _cashPaymentDAO = _facDAO.GetCashPaymentDAO();

            _amount = 550.20F;
            _lastCardDigits = 1234;

            _creditId = 7;
            _cashId = 3;

            _cashPayment = EntityFactory.GetCashPayment(_amount);
            _creditCardPayment = EntityFactory.GetCreditCardPayment(_amount, _lastCardDigits,0);

        }

        [Test]
        public void CashPaymentFindByIdTest()
        {
            _cashPayment = _cashPaymentDAO.FindById(_cashId);

            Assert.IsNotNull(_cashPayment);
            Assert.IsInstanceOf<CashPayment>(_cashPayment);
        }

        [Test]
        public void SaveCashPaymentTest()
        {
            _cashPaymentDAO.Save(_cashPayment);
        }


        [Test]
        public void CreditCardPaymentFindByIdTest()
        {
            _creditCardPayment = _creditCardPaymentDAO.FindById(_creditId);

            Assert.IsNotNull(_creditCardPayment);
            Assert.IsInstanceOf<CreditCardPayment>(_creditCardPayment);
        }

        [Test]
        public void SaveCreditCardPaymentTest()
        {
            _creditCardPaymentDAO.Save(_creditCardPayment);

        }
    }
}
