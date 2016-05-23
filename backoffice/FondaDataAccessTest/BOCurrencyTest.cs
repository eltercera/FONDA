using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BOCurrencyTest
    {
        private FactoryDAO _facDAO;
        private ICurrencyDAO _currencyDAO;
        private Currency _currency;
        private Currency _result;

        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;

            _currencyDAO = _facDAO.GetCurrencyDAO();

            _currency = new Currency();
            _currency.Symbol = "$";
            _currency.Name = "Dolar";
        }

        [Test]
        public void SameCurrency()
        {
            string name = _currency.Name;
            _result = _currencyDAO.GetCurrency(name);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);

        }

        [Test]
        public void CurrencySave()
        {
            _result = _currencyDAO.GetCurrency(_currency.Name);
            _currencyDAO.Save(_currency);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual("Dolar", _result.Name);
            Assert.AreEqual("$", _result.Symbol);            
            
        }

        [Test]
        public void CurrencyUpdate()
        {
            _currency = _currencyDAO.GetCurrency(_currency.Name);
            _currency.Name = "Euro";
            _currency.Symbol = "@";
            _currencyDAO.Save(_currency);
            _result = _currencyDAO.GetCurrency(_currency.Name);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual("Euro", _result.Name);
            Assert.AreEqual("@", _result.Symbol);
        }

        [Test]
        public void CurrencyDelete()
        {
            _currency = _currencyDAO.GetCurrency(_currency.Name);
            _currencyDAO.Delete(_currency);
            _result = _currencyDAO.GetCurrency(_currency.Name);

            Assert.IsNull(_result);
        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
