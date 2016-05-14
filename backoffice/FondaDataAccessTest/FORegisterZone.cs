using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccessTests
{
    [TestFixture()]
    class FORegisterZone
    {
        private FactoryDAO _facDAO;

        private IZoneDAO _zoneDAO;
        private Zone _zone;
        private int _zoneId;

        /// <summary>
        /// Prueba de Dominio.
        /// Solo crea a una zona y se verifica si los campos
        /// estan correctamente asignados.
        /// </summary>
        /// 
        [Test()]
        public void ZoneDomainTerst()
        {
            generateZone();
       
        }

        private void generateZone(bool edit = false)
        {
            if (_zone != null & !edit)
                return;

            if ((edit & _zone == null) | _zone == null)
                _zone = new Zone();

            string editadd = "";

            if (edit)
                editadd = "Editado";

            _zone.Name = "Altamira" + editadd;
           

        }

        private void PersonAssertions(bool edit = false)
        {
            string editadd = "";
            if (edit)
                editadd = "Editado";

            Assert.IsNotNull(_zone);
            Assert.AreEqual(_zone.Name, "Altamira" + editadd);
           
        }

        [Test()]
        public void ZoneSave()
        {
            // Genera una persona
            getZoneDao();
            generateZone();

            // La persiste
            _zoneDAO.Save(_zone);

        }

        private void getZoneDao()
        {
            getDao();
            if (_zoneDAO == null)
                _zoneDAO = _facDAO.GetZoneDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }
}
