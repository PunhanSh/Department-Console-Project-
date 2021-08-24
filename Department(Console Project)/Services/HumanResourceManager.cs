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
        #region Isci        
        private List<Employee> _employee;
        public List<Employee> Employee
        {
            get
            {
                return _employee;
            }
        }
        #endregion

        #region Department
        private List<Department> _departments;
        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
        }
        #endregion

        #region Constructor
        public HumanResourceManager()
        {
            _departments = new List<Department>();
            _employee = new List<Employee>();
        }
        #endregion

        #region Departamentin elave edilmesi methodu
        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }
        #endregion

        #region Iscinin elave edilmesi methodu
        public void AddEmployee(Employee employee, string DepartmentName)
        {
            Employee newemployee = new Employee();
            newemployee.No = employee.No;
            newemployee.Fullname = employee.Fullname;
            newemployee.Salary = employee.Salary;
            newemployee.Position = employee.Position;
            newemployee.DepartmentName = employee.DepartmentName;

            foreach (Department item in Departments)
            {
                while (item.Name.ToUpper() != DepartmentName.ToUpper()) //Adin duzgun yoxlanilmasi ucun ikisi de upper olunmalidir
                {
                    Console.WriteLine("Duzgun department adi daxil edin");
                    Console.ReadLine();
                }
                if (item.WorkerLimit > item.Employees.Count)
                {
                    item.Employees.Add(newemployee);
                    Console.WriteLine("Isci departamente daxil edildi");
                }
                else
                {
                    Console.WriteLine($"{item.Name} adli departmentde isci doludur");
                }
            }
        }
        #endregion

        #region Department uzerinde deyisiklikler methodu

        public void EditDepartments(string name, Department department)
        {
            foreach (Department editdepartment in _departments)
            {
                if (editdepartment.Name.ToUpper() == name.ToUpper()) //gelen ad duzgun yoxlanilmasi ucun upper olunmalidir
                {
                    editdepartment.Name = department.Name;
                }
                else
                {
                    Console.WriteLine("Axtardiginiz adda department yoxdur");
                }
            }
        }
        #endregion

        #region Isci uzerinde deyisiklikler methodu
        public void EditEmployee(string no, string fullName, int salary, string position, Employee employee) 
        {
            Employee editedemployee = new Employee();
            foreach (Department item in _departments)
            {
                for (int i = 0; i < item.Employees.Count; i++)
                {
                    if (item.Employees[i].No == no)  //iscinin nomresine gore edit olunur
                    {

                        Console.WriteLine($"Iscinin adi ve soyadi: {item.Employees[i].Fullname}\nIscinin maasi: {item.Employees[i].Salary}\nIscinin vezifesi: {item.Employees[i].Position}");

                        editedemployee.Fullname = employee.Fullname;
                        editedemployee.Salary = employee.Salary;
                        editedemployee.Position = employee.Position;

                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz nomreli isci yoxdur");
                        return;
                    }
                }
            }
        }
        #endregion

        #region Sistemdeki departmentleri geriye qaytarmaq methodu
        public List<Department> GetDepartments() 
        {
            return Departments;
        }
        #endregion

        #region Iscini siyahidan silmek methodu
        public void RemoveEmployee(string no, string departmentName)
        {
            //iscinin nomresine gore silinmesi
            List<Employee> EmployeeList = _employee.ToList();
            Employee removeemployee = _employee.Find(w => w.No.ToUpper() == no.ToUpper() && w.DepartmentName.ToUpper() == w.DepartmentName.ToUpper());
            _employee.Remove(removeemployee);
        }
        #endregion   
    }
}
