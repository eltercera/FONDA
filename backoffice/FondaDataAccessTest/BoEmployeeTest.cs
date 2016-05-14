using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{
    public class BoEmployeeTest
    {


        private FactoryDAOO _facDAO;
        private IEmployeeDAO _employeeDAO;
        private Employee _employee;
        private DateTime _employeeBirthDate = Convert.ToDateTime("08/08/1991");
        private int _employeeId;


/// <summary>
/// Prueba del Dominio
/// Crea un Empleado y verifica que fue de manera Correcta
/// </summary>
    [Test ()]
        public void EmployeeDomainTest()
        {

            generateEmployee();
            EmpoyeeAssertions();

        }

    private void generateEmployee(bool edit = false)
    {
        if (_employee != null & !edit)
            return;

        if ((edit & _employee == null) | _employee == null)
            _employee = new Employee();
 

        _employee.Name = "José" ;
        _employee.LastName = "Garcia";
        _employee.Ssn = "19932801";
        _employee.PhoneNumber = "0414-11-63-457";
        _employee.Address = "Direccion de Prueba";
        _employee.Gender = 'M';
        _employee.BirthDate = _employeeBirthDate;
        _employee.Username = "Usuario";
        _employee.Status = ActiveSimpleStatus.Instance;
    }
    private void EmpoyeeAssertions(bool edit = false)
    {
        Assert.IsNotNull(_employee);
        Assert.AreEqual(_employee.Name, "José");
        Assert.AreEqual(_employee.LastName, "Garcia");
        Assert.AreEqual(_employee.Ssn, "19932801");
        Assert.AreEqual(_employee.PhoneNumber, "0414-11-63-457");
        Assert.AreEqual(_employee.Address, "Direccion de Prueba");
        Assert.AreEqual(_employee.Gender, 'M');
        Assert.AreEqual(_employee.BirthDate, _employeeBirthDate);
        Assert.AreEqual(_employee.Username,"Usuario");
        Assert.AreEqual(_employee.Status, ActiveSimpleStatus.Instance);
    }






    }
}
