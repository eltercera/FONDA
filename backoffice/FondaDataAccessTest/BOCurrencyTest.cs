using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;


namespace DataAccessTests
{
    [TestFixture]
    public class BOCurrencyTest
    {
        private FactoryDAO _facDAO;
        private ICurrencyDAO _currencyDAO;
        private Currency _currency;
        private int _currencyId;


        [Test]
        public void CurrencyTest()
        {
            generateCurrency();
            currencyAssertions();
        }

        private void generateCurrency(bool edit = false)
        {
            if (_currency != null)
                return;

            if ((edit & _currency == null) | _currency == null)
                _currency = new Currency();
            _currency.Symbol = "$";
            _currency.Name = "Dolar";
            //_currency.Name = "Euro";
            //_currency.Name = "BsF";
        }

        private void currencyAssertions(bool edit = false)
        {
            Assert.IsNotNull(_currency);
            Assert.AreEqual(_currency.Symbol, "$");
            Assert.AreEqual(_currency.Name, "Dolar");
        }

        [Test]
        public void TableSave()
        {
            generateCurrency();
            getCurrencyDao();
            _currencyDAO.Save(_currency);
            Assert.AreNotEqual(_currency.Id, 0);
            _currencyId = _currency.Id;
            generateCurrency(true);
            _currencyDAO.Save(_currency);
            _currencyDAO.ResetSession();
            _currency = null;

        }

        private void getCurrencyDao()
        {
            getDao();
            if (_currencyDAO == null)
                _currencyDAO = _facDAO.GetCurrencyDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
