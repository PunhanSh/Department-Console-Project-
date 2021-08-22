using Department_Console_Project_.Interfaces;
using Department_Console_Project_.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Department_Console_Project_.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private List<Employee> _employee;
        public List<Employee> Employee
        {
            get
            {
                return _employee;
            }
        }
        private List<Department> _departments;
        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
        }
        public HumanResourceManager()
        {
            _departments = new List<Department>();
            _employee = new List<Employee>();
        }

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }

        public void AddEmployee(Employee employee, string DepartmentName)
        {
            Employee newemployee = new Employee();
            newemployee.Fullname = employee.Fullname;
            newemployee.Salary = employee.Salary;
            newemployee.Position = employee.Position;

            foreach (Department item in Departments)
            {
                if (item.Name.ToUpper() == DepartmentName.ToUpper())
                {
                    item.Employees.Add(newemployee);
                }
                else
                {
                    Console.WriteLine("Duzgun department adi daxil edin...");
                }
            }
        }

        public List<Department> EditDepartments(string name, string newname)
        {
            return _departments.FindAll(d => d.Name == name);
        }

        public List<Employee> EditEmployee(string no, string fullName, double salary, string position)
        {
            return _employee.FindAll(w => w.No.ToUpper() == no.ToUpper() && w.Fullname.ToUpper() == fullName.ToUpper() && w.Position.ToUpper() == position.ToUpper() && w.Salary == salary).ToList();
        }

        public List<Department> GetDepartments()
        {
            return Departments;
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            List<Employee> EmployeeList = _employee.ToList();
            Employee removeemployee = _employee.Find(w => w.No.ToUpper() == no.ToUpper() && w.DepartmentName.ToUpper() == w.DepartmentName.ToUpper());
            _employee.Remove(removeemployee);
        }
    }
}
