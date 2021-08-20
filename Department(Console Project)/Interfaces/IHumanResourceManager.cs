using System;
using System.Collections.Generic;
using System.Text;
using Department_Console_Project_.Models;

namespace Department_Console_Project_.Interfaces
{
    interface IHumanResourceManager 
    {
        public List<Department> Departments { get;}
        public void AddDepartment(Department department);
        public List<Department> GetDepartments();        
        public void EditDepartments(string _name, string newname);
        public void AddEmployee(Employee employee, string DepartmentName);
        public void RemoveEmployee(int number,string DepartmentName);
        public void EditEmployee(int number, string fullName, double salary, string position);

    }
}
