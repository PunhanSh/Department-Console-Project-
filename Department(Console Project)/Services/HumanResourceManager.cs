using Department_Console_Project_.Interfaces;
using Department_Console_Project_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Department_Console_Project_.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments => throw new NotImplementedException();

        public void AddDepartment(Department department)
        {
            
        }

        public void AddEmployee(Employee employee, string DepartmentName)
        {
            throw new NotImplementedException();
        }

        public void EditDepartments(string _name, string newname)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(int number, string fullName, double salary, string position)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(int number, string DepartmentName)
        {
            throw new NotImplementedException();
        }
    }
}
