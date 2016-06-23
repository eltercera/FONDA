using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BORoleTest
    {
        private FactoryDAO _facDAO;
        private IRoleDAO _roleDAO;
        private Role _role;
        private int _roleId;
        private IEmployeeDAO _employeeDAO;




        /// <summary>
        /// Prueba del constructor de la clase rol
        /// </summary>
        [Test]
        public void TestBuilderRole()
        {

            Role role = new Role();
            Assert.AreEqual(role.Id, 0);
            Assert.AreEqual(role.Name, null);
            Assert.AreEqual(role.Descripcion, null);
        }



        /// <summary>
        /// Prueba de Rol Dominio
        /// Crea un rol y verifica si correcto
        /// </summary>
        [Test]
        public void RoleTest()
        {
            generateRole();
            roleAssertions();
        }


        /// <summary>
        /// Prueba de Acceso a Datos guarda un rol.
        /// </summary>
        [Test]

        public void RoleSave()
        {
           Role _rolet= new Role();
            getRoleDao();
            generateRole();//crea un rol 
            _roleDAO.Save(_role);
            Assert.AreNotEqual(_role.Id, 0);
            _roleId = _role.Id;
            generateRole(true);
            _roleDAO.ResetSession();
            _rolet = _roleDAO.FindById(_role.Id);
            Assert.IsNotNull(_role);
            Assert.AreEqual(_rolet.Name, "role");
            Assert.AreEqual(_rolet.Descripcion, "descripcion");
            _roleDAO.Delete(_rolet);
            _role = null;
        }

        /// <summary>
        /// Se encarga de crear un rol en caso que no exista.
        /// </summary>
        /// <param name="edit"></param>
        private void generateRole(bool edit = false)
        {
            if (_role != null)
                return;
            if ((edit & _role == null) | _role == null)
                _role = new Role();
                _role.Name = "role";
                _role.Descripcion = "descripcion";
        }
        /// <summary>
        /// Verifica que el contenio de rol sea igual.
        /// </summary>
        /// <param name="edit"></param>
        private void roleAssertions(bool edit = false)
        {
            Assert.IsNotNull(_role);
            Assert.AreEqual(_role.Name, "role");
            Assert.AreEqual(_role.Descripcion, "descripcion");
        }

        /// <summary>
        /// Genera roleDao en caso de que este sea null
        /// </summary>
        private void getRoleDao()
        {
            getDao();
            if (_roleDAO == null)
                _roleDAO = _facDAO.GetRoleDAO();

        }
        /// <summary>
        /// Crea la intancia de factoryDAO
        /// </summary>
        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }
}
