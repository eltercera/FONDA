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
        /// Prueba de Acceso a Datos.
        /// </summary>
        [Test]

        public void RoleSave()
        {
            getRoleDao();
            generateRole();

            _roleDAO.Save(_role);

            Assert.AreNotEqual(_role.Id, 0);
            _roleId = _role.Id;

            generateRole(true);

            _roleDAO.Save(_role);

            _roleDAO.ResetSession();

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
            //_employeeDAO = _facDAO.GetEmployeeDAO();
            //Employee empleado= _employeeDAO.FindById(1);
            //_role.addEmployee(empleado);
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


        private void getRoleDao()
        {
            getDao();
            if (_roleDAO == null)
                _roleDAO = _facDAO.GetRoleDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }
}
