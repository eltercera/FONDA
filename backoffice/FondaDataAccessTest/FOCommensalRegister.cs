using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    [TestFixture()]
    class FOCommensalRegister
    {
        private FactoryDAO _facDAO;

        private ICommensalDAO _commensalDAO;
        private Commensal _commensal;
        private int _commensalId;
        
        [Test()]
        public void CommensalDomainTest()
        {
            generateCommensal();
        }
        [Test()]
        public void CommensalSave()
        {
            // Genera una persona
            getCommensalDao();
            generateCommensal();

            // La persiste
            _commensalDAO.Save(_commensal);

        }

        private void generateCommensal(bool edit = false)
        {
            if (_commensal != null & !edit)
                return;

            if ((edit & _commensal == null) | _commensal == null)
                _commensal = new Commensal();

            string editadd = "";

            if (edit)
                editadd = "Editado";

            _commensal.Password = "prueba";
            //_commensal.SesionToken = "prueba";
            _commensal.Email = "prueba";
            _commensal.Status = ActiveSimpleStatus.Instance;

        }
        private void getCommensalDao()
        {
            getDao();
            if (_commensalDAO == null)
                _commensalDAO = _facDAO.GetCommensalDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }
    }
}
