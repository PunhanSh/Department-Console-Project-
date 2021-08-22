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
        public List<Department> EditDepartments(string _name, string newname);
        public void AddEmployee(Employee employee, string DepartmentName);
        public void RemoveEmployee(string no,string departmentName);
        public List<Employee> EditEmployee(string no, string fullName, double salary, string position);
    }
}
